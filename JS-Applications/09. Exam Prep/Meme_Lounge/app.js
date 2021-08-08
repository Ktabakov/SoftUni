import page from "./node_modules/page/page.mjs";
import allMemesPage from "./pages/allMemes/allMemesPage.js";
import createPage from "./pages/create/createPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import loginPage from "./pages/login/loginPage.js"
import nav from "./pages/nav/navPage.js"
import registerPage from "./pages/register/registerPage.js";
import welcomePage from "./pages/welcome/welcomePage.js"
import authService from "./services/authService.js";

page(decorateContextWithUser);
page(nav.getView);

page(`/welcome`, welcomePage.getView);
page(`/login`, loginPage.getView);
page(`/all-memes`, allMemesPage.getView);
page(`/register`, registerPage.getView);
page(`/create`, createPage.getView);
page(`/details/:id`, detailsPage.getView);



page(`index.html`, `/welcome`);
page(`/`, `/welcome`);

page.start();

function decorateContextWithUser(context, next){
    let user = authService.getUser();
    context.user = user;
    next();
}
