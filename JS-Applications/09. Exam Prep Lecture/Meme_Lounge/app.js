
import page from "./node_modules/page/page.mjs";
import allMemesPage from "./pages/allMemes/allMemesPage.js";
import createPage from "./pages/create/createPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import editPage from "./pages/edit/editPage.js";
import homePage from "./pages/home/homePage.js";
import loginPage from "./pages/login/loginPage.js";
import nav from "./pages/nav/nav.js";
import notification from "./pages/notifcations/notification.js";
import profilePage from "./pages/profile/profilePage.js";
import registerPage from "./pages/register/registerPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import memesService from "./services/memesService.js";


let navElement = document.getElementById('nav');
let appElement = document.getElementById('app');
let notificationsElement = document.getElementById('notifications');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);
let notificationsRenderHandler = renderer.createRenderHandler(notificationsElement);

notification.initialize(page, notificationsRenderHandler);

nav.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler, authService);
loginPage.initialize(page, appRenderHandler, authService, notification);
registerPage.initialize(page, appRenderHandler, authService, notification);
allMemesPage.initialize(page, appRenderHandler, memesService);
createPage.initialize(page, appRenderHandler, memesService, notification);
detailsPage.initialize(page, appRenderHandler, memesService);
editPage.initialize(page, appRenderHandler, memesService, notification);
profilePage.initialize(page, appRenderHandler, memesService);


page('/index.html', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(nav.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/all-memes', allMemesPage.getView);
page('/create', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:memeId', editPage.getView);
page('/profile', profilePage.getView);

page.start();

function decorateContextWithUser(context, next){
    let user = authService.getUser();
    context.user = user;
    next();
}
