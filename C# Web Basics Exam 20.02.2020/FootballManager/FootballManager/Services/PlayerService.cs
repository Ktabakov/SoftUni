using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;
        public PlayerService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool added, string error) AddPlayer(AddPlayerViewModel model, string userId)
        {
            bool added = false;
            string error = string.Empty;

            var (isValid, validationError) = validationService.ValidateModel(model);


            if (!isValid)
            {
                return (isValid, validationError);
            }

            Player player = new Player()
            {
                Speed = model.Speed,
                Description = model.Description,
                Endurance = model.Endurance,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                UserPlayers = new List<UserPlayer>(),
            };

            try
            {
                repo.Add(player);
                repo.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                error = "Could not add player!";
            }
            int playerId = 0;
            if (added)
            {
                playerId = repo.All<Player>()
                    .FirstOrDefault(c => c == player).Id;

                (bool addedToCollection, string errorCollection) = AddToCollection(playerId, userId);
            }

            
            return (added, error);
        }

        public (bool added, string error) AddToCollection(int playerId, string userId)
        {
            bool added = false;
            string error = string.Empty;

            var player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);


            if (player == null || user == null)
            {
                return (added, "User or player don't exist");
            }


            UserPlayer userPlayer = new UserPlayer()
            {
                PlayerId = player.Id,
                UserId = user.Id
            };

            if (user.UserPlayers.Contains(userPlayer))
            {
                return (added, "Player Already Exists in Collection");
            }
            try
            {
                user.UserPlayers.Add(userPlayer);
                repo.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                error = "Adding Failed!";
            }

            return (added, error);
        }

        public List<AllPlayersViewModel> GetAll()
        {
            return repo.All<Player>()
                .Select(p => new AllPlayersViewModel()
                {
                    Description = p.Description,
                    Endurance = p.Endurance,
                    Speed = p.Speed,
                    ImageUrl = p.ImageUrl,
                    PlayerId = p.Id,
                    FullName = p.FullName,
                    Position = p.Position
                })
                .ToList();
        }

        public List<PlayerCollectionViewModel> GetUserCollection(string userId)
        {
            return repo.All<UserPlayer>()
                .Include(p => p.Player)
                .Where(p => p.UserId == userId)
                .Select(p => new PlayerCollectionViewModel()
                {
                    Speed = p.Player.Speed,
                    Description = p.Player.Description,
                    Endurance = p.Player.Endurance,
                    ImageUrl = p.Player.ImageUrl,
                    Position = p.Player.Position,
                    FullName = p.Player.FullName,
                    PlayerId = p.PlayerId
                })
                .ToList();
        }

        public (bool removed, string error) RemoveFromCollection(int playerId, string userId)
        {
            bool removed = false;
            string error = string.Empty;

            var player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);


            if (player == null || user == null)
            {
                return (removed, "User or player don't exist");
            }


            UserPlayer userPlayer = new UserPlayer()
            {
                PlayerId = player.Id,
                UserId = user.Id
            };

            try
            {
                repo.Remove<UserPlayer>(userPlayer);
                repo.SaveChanges();
                removed = true;
            }
            catch (Exception)
            {
                error = "Removing Failed!";
            }

            return (removed, error);
        }
    }
}
