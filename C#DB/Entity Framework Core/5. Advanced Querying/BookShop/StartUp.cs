namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);


            Console.WriteLine(CountCopiesByAuthor(db));
        }

        //Problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction restrictionToInt = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(b => b.AgeRestriction == restrictionToInt)
                .Select(b => b.Title)
                .OrderBy(a => a)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] books = context
                        .Books
                        .Where(b => b.EditionType == Enum.Parse<EditionType>("Gold"))
                        .Where(c => c.Copies < 5000)
                        .OrderBy(b => b.BookId)
                        .Select(b => b.Title)
                        .ToArray();

            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Price, b.Title })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();


            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.BookCategories.All(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime datetime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < datetime)
                .OrderByDescending(d => d.ReleaseDate)
                .Select(b => new {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var names = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new {a.FirstName, a.LastName})
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            foreach (var item in names)
            {
                sb.AppendLine(item.FirstName + " " + item.LastName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(a => a.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToArray();

            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} ({item.FirstName} {item.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(b => b.Title.Length > lengthCheck).Count();
        }

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var result = context
                .Authors
                .Select(b => new
                {
                    AuthorName = b.FirstName != null ? b.FirstName + " " + b.LastName : b.LastName,
                    Copies = b.Books.Where(c => c.AuthorId == c.Author.AuthorId)
                    .Select(d => d.Copies).Sum()
                })
                .OrderByDescending(c => c.Copies)
                .ToArray();

            foreach (var item in result)
            {
                sb.AppendLine($"{item.AuthorName} - {item.Copies}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
