import { render } from "../../node_modules/lit-html/lit-html.js";
import memesService from "../../services/memesService.js";
import { createTemplate } from "./createTemplate.js";

let mainContainer = document.getElementById(`container`)

async function submitHandler(context, e) {
    e.preventDefault();
    try {
        let formData = new FormData(e.target);

        let title = formData.get(`title`);
        let description = formData.get(`description`);
        let imageUrl = formData.get(`imageUrl`);

        let meme = {
            title: title,
            description: description,
            imageUrl: imageUrl
        }
        if(title.trim() === ``){
            alert(`Title is Required`)
            return;
        }
        if(description.trim() === ``){
            alert(`Description is Required`)
            return;
        }
        if(imageUrl.trim() === ``){
            alert(`Image Url is Required`)
            return;
        }


        let result = await memesService.create(meme);
        context.page.redirect('/all-memes');
    } catch (error) {
        alert(error)
    }
}

function getView(context, next) {
    let boundSubmitHandler = submitHandler.bind(null, context)
    let form = {
        submitHandler: boundSubmitHandler
    }
    let templateResult = createTemplate(form);
    render(templateResult, mainContainer);
    next()
}

export default {
    getView
}
