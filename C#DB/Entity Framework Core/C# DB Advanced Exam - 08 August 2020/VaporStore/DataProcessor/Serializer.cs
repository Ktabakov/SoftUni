namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context
                .Genres
                .ToArray()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Select(gm => new
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = string.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name)),
                        Players = gm.Purchases.Count
                    })
                    .Where(g => g.Players > 0)
                    .OrderByDescending(p => p.Players)
                    .ThenBy(i => i.Id),
                    TotalPlayers = g.Games
                    .Sum(g => g.Purchases.Count()),

                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(g => g.Id);

            string json = JsonConvert.SerializeObject(games, Formatting.Indented);
            return json.ToString().TrimEnd();
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(UserExDto[]), root);
            using StringWriter writer = new StringWriter(sb);

            List<UserExDto> users = new List<UserExDto>();
            PurchaseType purchaseType = (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType);

            var usersToProcess = context
                .Purchases
                .AsQueryable()
                .Where(c => c.Type == purchaseType)
                .Include(g => g.Game)
                .Include(c => c.Card.User)
                .ToList()
                .GroupBy(p => p.Card.User.Username);

            foreach (var user in usersToProcess)
            {
                var result = new UserExDto()
                {
                    Username = user.Key,
                    Purchases = user
                    .OrderBy(p => p.Date)
                    .Select(p => new UserPurchaseDto()
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new UserPurchaseGameDto()
                        {
                            Genre = p.Game.Genre.Name,
                            Title = p.Game.Name,
                            Price = p.Game.Price
                        }
                    })
                    .ToArray(),
                };

                result.TotalSpent = result
                    .Purchases
                    .Select(p => p.Game.Price)
                    .Sum();

                users.Add(result);
            }

            users = users
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToList();

            serializer.Serialize(writer, users.ToArray(), namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}