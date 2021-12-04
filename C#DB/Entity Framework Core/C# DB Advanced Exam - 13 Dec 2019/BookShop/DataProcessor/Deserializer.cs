namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(BookDto[]), root);
            StringBuilder sb = new StringBuilder();
            List<Book> books = new List<Book>();

            using (StringReader reader = new StringReader(xmlString))
            {
                BookDto[] booksDto = (BookDto[])serializer.Deserialize(reader);

                foreach (var book in booksDto)
                {
                    if (!IsValid(book))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    bool isDateValid = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out DateTime publishedOn);

                    if (!isDateValid)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    Book b = new Book()
                    {
                        Genre = (Genre)book.Genre,
                        Name = book.Name,
                        Pages = book.Pages,
                        Price = Math.Round(book.Price, 2),
                        PublishedOn = publishedOn,
                    };
                    books.Add(b);
                    sb.AppendLine($"Successfully imported book {b.Name} for {b.Price}.");
                }
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<AuthorDto> authrosDto = JsonConvert.DeserializeObject<ICollection<AuthorDto>>(jsonString);
            List<Author> authors = new List<Author>();
            var bookIds = context
                .Books
                .Select(b => b.Id)
                .ToArray();

            foreach (var author in authrosDto)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (authors.Any(au => au.Email == author.Email))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (author.Books.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                Author a = new Author()
                {
                    Email = author.Email,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,                   
                };

                foreach (var book in author.Books)
                {
                    if (string.IsNullOrWhiteSpace(book.Id))
                    {
                        continue;
                    }
                    if (!bookIds.Contains(int.Parse(book.Id)))
                    {
                        continue;
                    }
                    a.AuthorsBooks.Add(new AuthorBook() { BookId = int.Parse(book.Id) });
                }
                if (a.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                authors.Add(a);
                sb.AppendLine($"Successfully imported author - {a.FirstName + " " + a.LastName} with {a.AuthorsBooks.Count} books.");
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}