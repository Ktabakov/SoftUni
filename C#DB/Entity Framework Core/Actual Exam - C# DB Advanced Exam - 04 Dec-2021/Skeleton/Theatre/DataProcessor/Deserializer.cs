namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer seriazlier = new XmlSerializer(typeof(ImportPlayDto[]), root);
            using StringReader reader = new StringReader(xmlString);

            ImportPlayDto[] playsDto = (ImportPlayDto[])seriazlier.Deserialize(reader);
            List<Play> plays = new List<Play>();

            foreach (var dto in playsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(typeof(Genre), dto.Genre, out object genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isTimeValid = TimeSpan.TryParseExact(dto.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan duration);

                if (!isTimeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play p = new Play()
                {
                    Screenwriter = dto.Screenwriter,
                    Description = dto.Description,
                    Rating = dto.Rating,
                    Genre = (Genre)genre,
                    Duration = duration,
                    Title = dto.Title
                };
                plays.Add(p);
                sb.AppendLine(string.Format(SuccessfulImportPlay, p.Title, p.Genre, p.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer seriazlier = new XmlSerializer(typeof(ImportCastDto[]), root);
            using StringReader reader = new StringReader(xmlString);

            ImportCastDto[] castsDto = (ImportCastDto[])seriazlier.Deserialize(reader);
            List<Cast> casts = new List<Cast>();

            foreach (var dto in castsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isMailValid = bool.TryParse(dto.IsMainCharacter, out bool isMailCharacter);

                if (!isMailValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast c = new Cast()
                {
                    FullName = dto.FullName,
                    IsMainCharacter = isMailCharacter,
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId
                };

                string mainOrLesser = c.IsMainCharacter == true ? "main" : "lesser";
                casts.Add(c);
                sb.AppendLine(string.Format(SuccessfulImportActor, c.FullName, mainOrLesser));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<ImportTheaterDto> theaterDtos = JsonConvert.DeserializeObject<IEnumerable<ImportTheaterDto>>(jsonString);
            List<Theatre> theatres = new List<Theatre>();

            foreach (var dto in theaterDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Director = dto.Director,
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls
                };

                foreach (var dtoTicket in dto.Tickets)
                {

                    if (!IsValid(dtoTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Ticket ticket = new Ticket()
                    {
                        RowNumber = dtoTicket.RowNumber,
                        Price = Math.Round(dtoTicket.Price, 2),
                        PlayId = dtoTicket.PlayId
                    };
                    theatre.Tickets.Add(ticket);
                }

                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
