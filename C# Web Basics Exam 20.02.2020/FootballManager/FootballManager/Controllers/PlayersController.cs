using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(Request request, IPlayerService _playerService) 
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response All()
        {
            List<AllPlayersViewModel> model = playerService.GetAll();
           
            return View(new { model, IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response AddToCollection(int playerId)
        {
            (bool added, string error) = playerService.AddToCollection(playerId, User.Id);

            if (!added)
            {
                return View(new ErrorViewModel(error), "/Error");
            }

            return All();
        }

        [Authorize]
        [HttpPost]
        public Response RemoveFromCollection(int playerId)
        {
            (bool removed, string error) = playerService.RemoveFromCollection(playerId, User.Id);

            if (!removed)
            {
                return View(new ErrorViewModel(error), "/Error");
            }

            return Collection();
        }

        [Authorize]
        public Response Collection()
        {
            List<PlayerCollectionViewModel> model = playerService.GetUserCollection(User.Id);
            return View(new { model, IsAuthenticated = true });
        }


        [Authorize]
        public Response Add()
        {
            return View( new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddPlayerViewModel model)
        {
            (bool added, string error) = playerService.AddPlayer(model, User.Id);


            if (!added)
            {
                return View(new ErrorViewModel(error), "/Error");
            }

            return Collection();
        }


    }
}
