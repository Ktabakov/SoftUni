import { registerTemplate } from "./registerTemplate.js";


let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;
let _form = undefined;

function initialize(router, renderHandler, authService) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
}

async function submitHandler(e) {
    e.preventDefault();
    try {
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let email = formData.get('email');
        if (email.trim() === '') {
            _form.errorMessages.push('Email is required');
        }

        let password = formData.get('password');
        if (password.trim() === '') {
            _form.errorMessages.push('Password is required');
        }

        let repeatPassword = formData.get('confirm-pass');
        if (repeatPassword.trim() === '') {
            _form.errorMessages.push('Repeat Password is required');
        }

        if(password != repeatPassword){
            _form.errorMessages.push(`Password and repeat password must be the same`)
        }

        if (_form.errorMessages.length > 0) {
            let templateResult = registerTemplate(_form);
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let user = {
            email,
            password,
        }

        await _authService.register(user);
        _router.redirect('/dashboard');
    } catch (err) {
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