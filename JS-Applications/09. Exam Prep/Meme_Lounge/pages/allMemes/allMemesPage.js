// import authService from "../services/authService.js";
import { render } from "../../node_modules/lit-html/lit-html.js";
import { allMemesTemplate } from "./allMemesTemplate.js"
import memesService from "./../../services/memesService.js"

let navContainer = document.getElementById(`container`)

async function getView(context, next) {
    let allMemes = await memesService.getAllMemes();
    let templateResult = allMemesTemplate(allMemes);
    render(templateResult, navContainer);
    next()
}

export default {
    getView
}