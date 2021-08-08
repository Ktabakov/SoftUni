import auth from "../helpers/auth.js";
import { jsonRequest } from "../helpers/httpService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;

function initialize(domElement){
    section = domElement;
    let form = section.querySelector(`#login-form`);
    form.addEventListener(`submit`, loginUser)
}

async function loginUser(e){
    e.preventDefault();
    let data = new FormData(e.target)
    let user = {
        email: data.get(`email`),
        password: data.get(`password`)
    }
    
    let url = 'http://localhost:3030/users/login';
    let result = await jsonRequest(url, `Post`, user);
    auth.setAuthToken(result.accessToken)
    auth.setUserId(result._id);
    e.target.reset();
    viewFinder.navigateTo('home');

}

async function getView(){
    return section;
}

let loginPage = {
    initialize,
    getView
};

export default loginPage;