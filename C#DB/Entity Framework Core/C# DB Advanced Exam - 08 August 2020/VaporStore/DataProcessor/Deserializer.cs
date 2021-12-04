namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public const string ERROR_MESSAGE = "Invalid Data";
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var tagNames = context.Tags.Select(t => t.Name).ToArray();

            StringBuilder sb = new StringBuilder();
            ICollection<ImportGamesDto> gamesDto = JsonConvert.DeserializeObject<ICollection<ImportGamesDto>>(jsonString);
            List<Game> games = new List<Game>();
            List<Developer> develoeprs = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime releaseDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Game game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                };

                Developer dev = develoeprs.FirstOrDefault(d => d.Name == gameDto.Developer);
                if (dev == null)
                {
                    dev = new Developer() { Name = gameDto.Name };
                    develoeprs.Add(dev);
                }
                game.Developer = dev;

                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if(genre == null)
                {
                    genre = new Genre() { Name = gameDto.Genre };
                    genres.Add(genre);
                }
                game.Genre = genre;
                              
                foreach (var tag in gameDto.Tags)
                {
                    Tag dbTag = tags.FirstOrDefault(t => t.Name == tag);
                    if (dbTag == null)
                    {
                        dbTag = new Tag() { Name = tag };
                        tags.Add(dbTag);
                    }
                    game.GameTags.Add(new GameTag() { Tag = dbTag });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();
            ICollection<UserImportDto> usersDto = JsonConvert.DeserializeObject<ICollection<UserImportDto>>(jsonString);
            List<User> users = new List<User>();

            foreach (var userDto in usersDto)
            {
                ICollection<Card> userCards = new HashSet<Card>();

                if (!IsValid(userDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }
                foreach (var userCard in userDto.Cards)
                {
                    if (!IsValid(userCard))
                    {
                        sb.AppendLine(ERROR_MESSAGE);
                        continue;
                    }


                    if (!Enum.TryParse(typeof(CardType), userCard.Type, out object cardType))
                    {
                        sb.AppendLine(ERROR_MESSAGE);
                        continue;
                    }
                    
                    Card card = new Card()
                    {
                        Cvc = userCard.Cvc,
                        Type = (CardType)cardType,
                        Number = userCard.Number
                    };
                    userCards.Add(card);
                }
                User user = new User()
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    FullName = userDto.FullName,
                    Cards = userCards
                };
                users.Add(user);
                sb.AppendLine($"Imported {userDto.Username} with {userDto.Cards.Count} cards"!);
                
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(PurchaseImportDto[]), root);
            using StringReader reader = new StringReader(xmlString);

            PurchaseImportDto[] purchaseDto = (PurchaseImportDto[])serializer.Deserialize(reader);
            List<Purchase> purchases = new List<Purchase>();

            var allCardKeys = context.Cards.ToArray();
            var allGameNames = context.Games.ToArray();

            foreach (var singleDto in purchaseDto)
            {
                if (!IsValid(singleDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(singleDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime purchaseDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                if (!allCardKeys.Any(c => c.Number == singleDto.Card))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                if (!allGameNames.Any(n => n.Name == singleDto.Title))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }
                var dbGame = context.Games.FirstOrDefault(g => g.Name == singleDto.Title);
                var dbCard = context.Cards.FirstOrDefault(c => c.Number == singleDto.Card);
                                              
                if (!Enum.TryParse(typeof(PurchaseType), singleDto.Type, out object purchaseType))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                Purchase p = new Purchase()
                {
                    Date = purchaseDate,
                    ProductKey = singleDto.Key,
                    Type = (PurchaseType)purchaseType,
                    Game = dbGame,  
                    Card = dbCard        
                };

                purchases.Add(p);
                sb.AppendLine($"Imported {singleDto.Title} for {p.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
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