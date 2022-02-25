namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;
    using FootballManager.ViewModels;

    public class HomeController : Controller
    {
        private readonly IPlayerService playerService;
        public HomeController(Request request, IPlayerService _playerService)
            : base(request)
        {
            playerService = _playerService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                List<AllPlayersViewModel> model = playerService.GetAll();
               
                return View(new {model,  IsAuthenticated = true }, "/Players/All");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}
