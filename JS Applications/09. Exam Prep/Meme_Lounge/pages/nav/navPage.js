// import authService from "../services/authService.js";
import { render } from "../../node_modules/lit-html/lit-html.js";
import authService from "../../services/authService.js";
import { navTemplate } from "./navTemplate.js"
import page from "../../node_modules/page/page.mjs"
let navContainer = document.getElementById(`navigation`)



function getView(context, next) {
    let user = context.user;
    let email = user !== undefined ? user.email : undefined;
    let navModel = {
        logoutHandler,
        email,
    }
    let templateResult = navTemplate(navModel);
    render(templateResult, navContainer);
    next()
}

async function logoutHandler(context) {
    let logout = await authService.logout();
    console.log(logout);
    page.redirect(`/welcome`)
}

export default {
    getView
}