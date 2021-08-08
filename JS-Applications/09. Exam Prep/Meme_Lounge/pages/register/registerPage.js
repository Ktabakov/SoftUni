import { registerTemplate } from "./registerTemplate.js";
import authService from "../../services/authService.js";
import { render } from "../../node_modules/lit-html/lit-html.js"

let mainContainer = document.getElementById(`container`)

async function submitHandler(context, e) {
    e.preventDefault();
    console.log(`error`);
    let formData = new FormData(e.target);

    let username = formData.get(`username`);
    let email = formData.get(`email`);
    let password = formData.get(`password`);
    let rePass = formData.get(`repeatPass`);
    let gender = formData.get(`gender`);

    try {
        let user = {
            username: username,
            email: email,
            password: password,
            rePass: rePass,
            gender: gender,
        }

        if(username.trim() === ``){
            alert(`Username is Required`)
            return;
        }
        if(email.trim() === ``){
            alert(`Email is Required`)
            return;
        }
        if(password.trim() === ``){
            alert(`Password is Required`)
            return;
        }
        if(rePass.trim() === ``){
            alert(`Repeat Password is Required`)
            return;
        }
        if(password !== rePass){
            alert(`Passwords must match`)
            return;
        }
        if(gender.trim() === ``){
            alert(`Gender is Required`)
            return;
        }

        await authService.register(user); 
        context.page.redirect('/all-memes');
    } catch (error) {
        alert(error)
    }
}

async function getView(context) {
    let boundSubmitHandler = submitHandler.bind(null, context)
    let form = {
        submitHandler: boundSubmitHandler
    }
    let templateResult = registerTemplate(form);
    render(templateResult, mainContainer);
}

export default {
    getView
}