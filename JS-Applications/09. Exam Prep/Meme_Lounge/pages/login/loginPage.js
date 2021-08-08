import { render } from "../../node_modules/lit-html/lit-html.js";
import { loginTemplate } from "./loginTemplate.js"
import authService from "../../services/authService.js"

let mainContainer = document.getElementById(`container`)

async function submitHandler(context, e) {
    e.preventDefault();
    try {
        let formData = new FormData(e.target);
        let email = formData.get(`email`);
        let password = formData.get(`password`)

        let user = {
            email: email,
            password: password
        }
        if(username.trim() === ``){
            alert(`Username is Required`)
            return;
        }
        if(password.trim() === ``){
            alert(`Password is Required`)
            return;
        }

        let result = await authService.login(user);
        console.log(result);
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
    let templateResult = loginTemplate(form);
    render(templateResult, mainContainer);
    next()
}

export default {
    getView
}
