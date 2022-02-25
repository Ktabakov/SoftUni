using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IUserService 
    {
        (bool registered, string error) Register(RegisterViewModel model);
        (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model);

        string GetUserName(string userId);
    }
}
