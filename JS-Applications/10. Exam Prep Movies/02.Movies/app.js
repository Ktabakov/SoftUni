import {LitRenderer} from "./rendering/litRenderer.js"
import page from "./node_modules/page/page.mjs";
import authService from "./services/authService.js";
import nav from "./pages/nav/nav.js"
import homePage from "./pages/home/homepage.js"
import registerPage from "./pages/register/registerpage.js"
import loginPage from "./pages/login/loginpage.js"
import addMoviePage from "./pages/addMovie/addMoviePage.js"
import moviesService from "./services/moviesService.js";
import detailsPage from "./pages/detailspage/detailspage.js"
import editpage from "./pages/edit/editpage.js";

let navEl = document.getElementById(`nav`);
let mainEl = document.getElementById(`main`);

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navEl);
let mainRenderHandler = renderer.createRenderHandler(mainEl);

nav.initialize(page, navRenderHandler, authService);
homePage.initialize(page, mainRenderHandler, authService);
registerPage.initialize(page, mainRenderHandler, authService);
loginPage.initialize(page, mainRenderHandler, authService);
addMoviePage.initialize(page, mainRenderHandler, moviesService);
detailsPage.initialize(page, mainRenderHandler, moviesService);
editpage.initialize(page, mainRenderHandler, moviesService);

page(`/index.html`, '/home');
page(`/`, `/home`)

page(decorateContextWithUser)
page(nav.getView);


page('/home', homePage.getView);
page('/register', registerPage.getView)
page('/login', loginPage.getView)
page('/add-movie', addMoviePage.getView)
page(`/details/:id`, detailsPage.getView)
page(`/edit/:movieId`, editpage.getView)

page.start();

function decorateContextWithUser(context, next){
    let user = authService.getUser();
    context.user = user;
    next();
}


