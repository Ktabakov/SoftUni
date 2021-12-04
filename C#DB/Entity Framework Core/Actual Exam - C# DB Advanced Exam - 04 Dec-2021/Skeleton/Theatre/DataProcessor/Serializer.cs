namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .ToArray()
                .Where(h => h.NumberOfHalls >= numbersOfHalls && h.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .Sum(t => Math.Round(t.Price, 2)),
                    Tickets = t.Tickets
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .Select(ti => new
                    {
                        Price = Math.Round(ti.Price, 2),
                        RowNumber = ti.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            string json = JsonConvert.SerializeObject(theatres, Formatting.Indented);
            return json.ToString().TrimEnd();
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer seriazlizer = new XmlSerializer(typeof(PlaysExportDto[]), root);
            XmlSerializerNamespaces spaces = new XmlSerializerNamespaces();
            spaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            PlaysExportDto[] plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= (float)rating)
                .Select(p => new PlaysExportDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Genre = p.Genre.ToString(),
                    Rating = p.Rating.ToString() == "0" ? "Premier" : p.Rating.ToString(),
                    Actors = p.Casts
                    .Where(p => p.IsMainCharacter == true)
                    .Select(c => new ExportPlayActors()
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{c.Play.Title}'."
                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            seriazlizer.Serialize(writer, plays, spaces);
            return sb.ToString().TrimEnd();
        }
    }
}
