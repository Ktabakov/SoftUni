namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .ToArray()
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks.OrderByDescending(c => c.Book.Price)
                    .Select(ab => new
                    {
                        BookName = ab.Book.Name,
                        BookPrice = ab.Book.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return json.ToString().TrimEnd();
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializerNamespaces spaces = new XmlSerializerNamespaces();
            spaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(BooksExportDto[]), root);

            using (StringWriter writer = new StringWriter(sb))
            {
                BooksExportDto[] booksBeforeDate = context
                    .Books
                    .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                    .ToArray()
                    .OrderByDescending(d => d.Pages)
                    .ThenByDescending(d => d.PublishedOn)
                    .Take(10)
                    .Select(b => new BooksExportDto()
                    {
                        Pages = b.Pages,
                        Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                        Name = b.Name
                    })
                    .ToArray();

                serializer.Serialize(writer, booksBeforeDate, spaces);
                return sb.ToString().TrimEnd();

            }
        }
    }
}