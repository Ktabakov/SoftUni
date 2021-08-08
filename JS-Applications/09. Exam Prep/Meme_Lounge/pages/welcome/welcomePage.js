// import authService from "../services/authService.js";
import { render } from "../../node_modules/lit-html/lit-html.js";
import { welcomeTemplate } from "./welcomeTemplate.js"
import authService from "./../../services/authService.js"

let mainContainer = document.getElementById(`container`)

function getView(context, next) {
    let templateResult = welcomeTemplate(context);
    render(templateResult, mainContainer);
}

export default {
    getView
}