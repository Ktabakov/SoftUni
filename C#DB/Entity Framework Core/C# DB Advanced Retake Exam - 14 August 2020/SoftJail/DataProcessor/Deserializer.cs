namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<DepartmentDto> departmentsDto = JsonConvert.DeserializeObject<IEnumerable<DepartmentDto>>(jsonString);
            List<Department> departments = new List<Department>();

            foreach (var dto in departmentsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (dto.Cells.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isHasWindowValid = dto.Cells.All(w => bool.TryParse(w.HasWindow, out bool result));
                if (!isHasWindowValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department d = new Department()
                {
                    Name = dto.Name,
                };

                bool isCellValid = true;
                foreach (var cell in dto.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isCellValid = false;
                        sb.AppendLine("Invalid Data");
                        break;
                    }

                    Cell c = new Cell()
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = bool.Parse(cell.HasWindow)
                    };

                    d.Cells.Add(c);
                }
                if (!isCellValid)
                {
                    continue;
                }

                    departments.Add(d);
                sb.AppendLine($"Imported {dto.Name} with {dto.Cells.Length} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<PrisonderDto> prisonersDto = JsonConvert.DeserializeObject<IEnumerable<PrisonderDto>>(jsonString);
            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var dto in prisonersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isReleaseDateValid = DateTime.TryParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime releaseDate);

                if (dto.ReleaseDate != null && !isReleaseDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Prisoner p = new Prisoner()
                {
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = dto.Bail == null ? 0 : dto.Bail,
                    Age = dto.Age,
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    CellId = dto.CellId,
                };
                bool isMailValid = true;
                foreach (var mail in dto.Mails)
                {
                    if (!IsValid(mail))
                    {
                        isMailValid = false;
                        break;
                    }
                    Mail m = new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    };
                    p.Mails.Add(m);
                }
                if (!isMailValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                prisoners.Add(p);
                sb.AppendLine($"Imported {p.FullName} {p.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(OfficerDto[]), root);
            StringBuilder sb = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ICollection<OfficerDto> officerDto = (ICollection<OfficerDto>)serializer.Deserialize(reader);
            List<Officer> officers = new List<Officer>();

            var departmentIds = context.Departments.Select(d => d.Id).ToArray();

            foreach (var dto in officerDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse(typeof(Position), dto.Position, out object position))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (!Enum.TryParse(typeof(Weapon), dto.Weapon, out object weapon))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                /*if (!departmentIds.Contains(dto.DepartmentId))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }*/

                if (dto.Money < 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer o = new Officer()
                {
                    FullName = dto.Name,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    Salary = dto.Money,
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = dto.Prisoners
                    .Select(p => new OfficerPrisoner()
                    {
                        PrisonerId = p.Id
                    })
                    .ToList()
                };

                officers.Add(o);
                sb.AppendLine($"Imported {o.FullName} ({o.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}