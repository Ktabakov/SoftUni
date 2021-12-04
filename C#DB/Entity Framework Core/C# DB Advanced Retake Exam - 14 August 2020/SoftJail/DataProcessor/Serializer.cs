namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(p => p.Officer.Salary), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            string result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return result.ToString().TrimEnd();

            
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            XmlRootAttribute root = new XmlRootAttribute("Prisoners");
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces spaces = new XmlSerializerNamespaces();
            spaces.Add(string.Empty, string.Empty);
            XmlSerializer seriazlizer = new XmlSerializer(typeof(PrisonerDto[]), root);

            using StringWriter writer = new StringWriter(sb);
            string[] myPrisonersNames = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            PrisonerDto[] prisoners = context
                                    .Prisoners
                                    .Where(p => myPrisonersNames.Contains(p.FullName))
                                    .Select(p => new PrisonerDto()
                                    {
                                        Id = p.Id,
                                        Name = p.FullName,
                                        IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                        EncryptedMessages = p.Mails
                                        .Select(m => new PrisonerMessagesDto()
                                        {
                                            Description = Reverse(m.Description)
                                        })
                                        .ToArray()
                                    })
                                    .OrderBy(p => p.Name)
                                    .ThenBy(p => p.Id)
                                    .ToArray();

            seriazlizer.Serialize(writer, prisoners, spaces);

            return sb.ToString().TrimEnd();
        }
        public static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}