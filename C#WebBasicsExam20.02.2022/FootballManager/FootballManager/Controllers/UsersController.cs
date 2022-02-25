using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Services;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(Request request, IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            var (userId, isCorrect) = userService.IsLoginCorrect(model);

            if (isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName,
                    Request.Session.Id);

                return Redirect("/");
            }

            return View(new ErrorViewModel("Login incorrect"), "/Error");
        }
        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [Authorize]
        public Response Logout()
        {
            if (User.IsAuthenticated)
            {
                SignOut();
            }

            return Redirect("/");
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool registered, string error) = userService.Register(model);

            if (registered)
            {
                return Redirect("/Users/Login");
            }

            return View(new { ErrorMessage = error }, "/Error");

        }
    }
}
