import { render } from "../../node_modules/lit-html/lit-html.js";
import memesService from "./../../services/memesService.js"
import { detailsTemplate } from "./detailsTemplate.js"
import page from "../../node_modules/page/page.mjs"

let mainContainer = document.getElementById(`container`)

async function getView(context, next) {
    let id = context.params.id;
    let meme = await memesService.get(id);
    let user = context.user;
    let isOwner = false
    if (user !== undefined && user._id === meme._ownerId) {
        isOwner = true;
    }

    let model = {
        meme,
        deleteHandler,
        isOwner
    }
  
    let templateResult = detailsTemplate(model);
    render(templateResult, mainContainer);
    next()
}

async function deleteHandler(id, e) {
    try {
        await memesService.deleteItem(id);
        page.redirect(`/all-memes`)
    } catch (error) {
        alert(error)
    }
}

export default {
    getView
}