import auth from "../helpers/auth.js";
import { jsonRequest } from "../helpers/httpService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;

function initialize(domElement){
    section = domElement;
    let form = section.querySelector(`#register-form`);
    form.addEventListener(`submit`, registerUser)
}

async function getView(){
    return section;
}

async function registerUser(e){

    e.preventDefault();
    let data = new FormData(e.target)
    let email = data.get(`email`);
    let password = data.get(`password`);
    let repeatPassword = data.get(`repeatPassword`)
    if (email === `` || password === `` || password.length < 6 || password !== repeatPassword){
        alert(`Fields must not be empty and passwords must match`)
    }
    let user = {
        email: email,
        password: password
    }
    
    let url = 'http://localhost:3030/users/register';

    let result = await jsonRequest(url, `Post`, user);
    auth.setAuthToken(result.accessToken)
    auth.setUserId(result._id);
    e.target.reset();
    viewFinder.navigateTo('home');

}

let registerPage = {
    initialize,
    getView
};

export default registerPage;