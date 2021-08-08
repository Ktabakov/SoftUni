import { registerTemplate } from "./registerTemplate.js";


let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;
let _form = undefined;
let _notification = undefined;

function initialize(router, renderHandler, authService, notification) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
    _notification = notification;
}

async function submitHandler(e){
    e.preventDefault();
    try{
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let email = formData.get('email');
        if(email.trim() === ''){
            _form.errorMessages.push('Email is required');
        }

        let password = formData.get('password');
        if(password.trim() === ''){
            _form.errorMessages.push('Password is required');
        }

        let repeatPassword = formData.get('repeatPassword');
        if(repeatPassword.trim() === ''){
            _form.errorMessages.push('Repeat Password is required');
        }

        if(password.length < 6 || repeatPassword.length < 6){
            _form.errorMessages.push(`Password must contain atleast 6 characters`)
        }
        if (password != repeatPassword){
            _form.errorMessages.push(`Passwords must match`)
        }

        if(_form.errorMessages.length > 0){
            let templateResult = registerTemplate(_form);
            //_notification.createNotification(_form.errorMessages.join('\n'));
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let user = {
            email,
            password,
        }
    
        await _authService.register(user);
        _router.redirect('/home');
    } catch (err){
        alert(err);
    }
   
}

async function getView(context) {
    _form = {
        submitHandler,
        errorMessages: []
    }
    let templateResult = registerTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}