import auth from "./helpers/auth.js";
import homePage from "./pages/home.js";
import loginPage from "./pages/login.js";
import movieDetailsPage from "./pages/movieDetails.js";
import registerPage from "./pages/register.js";

let viewCallback = undefined;

function initialize(allLinkElements, callback) {
    allLinkElements.forEach(a => a.addEventListener(`click`, changeViewHandler))
    viewCallback = callback;
}

let views = {
    'home': async() => await homePage.getView(),
    'login': async() => await loginPage.getView(),
    'register': async() => await registerPage.getView(),
    'logout': async() => await auth.logout(),
    'movie-details': async(id) => await movieDetailsPage.getView(id),
    'like': async(id) => await movieDetailsPage.like(id)
};

export async function changeViewHandler(e) {
    let element = e.target.matches(`.link`)
    ? e.target
    : e.target.closest(`.link`);

    let route = element.dataset.route;
    let id = element.dataset.id;
    navigateTo(route, id);
}

export async function navigateTo(route, id) {
    let main = document.getElementById(`main`);
    if (views.hasOwnProperty(route)) {
        let view = await views[route](id);   
        main.querySelectorAll(`.view`).forEach(v => v.remove());
        main.appendChild(view); 
    }
}

export async function redirectTo(route){
    let main = document.getElementById(`main`);
    if (views.hasOwnProperty(route)) {
        let viewFunc = views[route]();   
        return viewFunc;
    }
}
let viewFinder = {
    initialize,
    navigateTo,
    changeViewHandler,
    redirectTo
};

export default viewFinder;