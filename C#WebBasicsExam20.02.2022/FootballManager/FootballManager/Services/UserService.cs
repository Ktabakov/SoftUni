using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }
        public (bool registered, string error) Register(RegisterViewModel model)
        {
            var userExists = GetUserByUsername(model.Username) != null;
            var emailIsUsed = GetUserByEmail(model.Email) != null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            bool registered = false;
            string error = string.Empty;

            if (userExists || emailIsUsed)
            {
                return (registered, "Registration Failed!");
            }


            if (!isValid)
            {
                return (isValid, validationError);
            }


            List<UserPlayer> userPlayers = new List<UserPlayer>();
            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = HashPassword(model.Password),
                UserPlayers = userPlayers
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registered, error);
        }

        private object GetUserByEmail(string email)
        {
            return repo.All<User>().FirstOrDefault(u => u.Email == email);
        }

        private string HashPassword(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
        private User GetUserByUsername(string username)
        {
            return repo.All<User>().FirstOrDefault(c => c.Username == username);
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashPassword(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }

        public string GetUserName(string userId)
        {
            return repo.All<User>().FirstOrDefault(u => u.Id == userId)?.Username;
        }
    }
}
