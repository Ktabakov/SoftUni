import page from "./node_modules/page/page.mjs";
import { LitRenderer } from "./rendering/litRenderer.js";
import nav from "./pages/nav/nav.js"
import authService from "./services/authService.js";
import dashboardPage from "./pages/dashboard/dashboardPage.js"
import loginPage from "./pages/login/loginPage.js";
import registerPage from "./pages/register/registerPage.js";
import createPage from "./pages/create/createPage.js";
import booksService from "./services/booksService.js";
import detailsPage from "./pages/details/detailsPage.js"
import editPage from "./pages/edit/editPage.js"
import myBooksPage from "./pages/myBooks/myBooksPage.js";



let navElement = document.getElementById('nav');
let appElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);

nav.initialize(page, navRenderHandler, authService);
dashboardPage.initialize(page, appRenderHandler, booksService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
createPage.initialize(page, appRenderHandler, booksService);
detailsPage.initialize(page, appRenderHandler, booksService);
editPage.initialize(page, appRenderHandler, booksService);
myBooksPage.initialize(page, appRenderHandler, booksService);


page('/index.html', '/dashboard');
page('/', '/dashboard');

page(decorateContextWithUser);
page(nav.getView);

page('/dashboard', dashboardPage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/add-book', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editPage.getView);
page('/my-books', myBooksPage.getView);


page.start();

function decorateContextWithUser(context, next){
    let user = authService.getUser();
    context.user = user;
    next();
}
