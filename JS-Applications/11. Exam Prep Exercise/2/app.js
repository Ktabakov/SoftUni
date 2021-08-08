import page from "./node_modules/page/page.mjs";
import { LitRenderer } from "./rendering/litRenderer.js";
import nav from "./pages/nav/nav.js"
import login from "./pages/login/login.js"
import register from "./pages/register/register.js"
import authService from "./services/authService.js"
import home from "./pages/home/home.js";
import allListings from "./pages/allListings/allListings.js"
import carsService from "./services/carsService.js";
import createListing from "./pages/createListing/createListing.js"
import detailsPage from "./pages/details/details.js"
import editPage from "./pages/edit/edit.js"
import myListings from "./pages/myListings/myListings.js";
import search from "./pages/search/search.js";



let navElement = document.getElementById('nav');
let mainElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(mainElement);

nav.initialize(page, navRenderHandler, authService);
login.initialize(page, appRenderHandler, authService);
register.initialize(page, appRenderHandler, authService);
home.initialize(page, appRenderHandler, authService);
allListings.initialize(page, appRenderHandler, carsService);
createListing.initialize(page, appRenderHandler, carsService);
detailsPage.initialize(page, appRenderHandler, carsService);
editPage.initialize(page, appRenderHandler, carsService);
myListings.initialize(page, appRenderHandler, carsService);
search.initialize(page, appRenderHandler, carsService);



page('/index.html', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(nav.getView);

page('/home', home.getView);
page('/login', login.getView);
page('/register', register.getView);
page('/all-listings', allListings.getView);
page('/create-listing', createListing.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editPage.getView);
page('/my-listings', myListings.getView);
page('/search', search.getView);




page.start();

function decorateContextWithUser(context, next){
    let user = authService.getUser();
    context.user = user;
    next();
}