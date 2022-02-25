using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        List<AllPlayersViewModel> GetAll();
        (bool added, string error) AddToCollection(int playerId, string userId);
        List<PlayerCollectionViewModel> GetUserCollection(string userId);
        (bool added, string error) AddPlayer(AddPlayerViewModel model, string userId);
        (bool removed, string error) RemoveFromCollection(int playerId, string userId);
    }
}
