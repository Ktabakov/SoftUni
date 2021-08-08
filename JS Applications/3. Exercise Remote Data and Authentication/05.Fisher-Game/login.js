let loginForm = document.getElementById(`login-form`);
let registerForm = document.getElementById(`register-form`);
registerForm.addEventListener(`submit`, register);
loginForm.addEventListener(`submit`, login);

async function register(e) {
    try {
        e.preventDefault();
        let form = new FormData(e.target);

        let password = form.get(`password`);
        let rePass = form.get(`rePass`);

        if (password !== rePass) {
            alert(`Passwords don't Match!`);
            e.target.reset();
            return;
        }

        let newUser = {
            email: form.get(`email`),
            password: password
        };
        let registerResponce = await fetch(`http://localhost:3030/users/register`, {
            method: `POST`,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });

        e.target.reset();
        let result = await registerResponce.json();
        localStorage.setItem(`token`, result.accessToken);
        localStorage.setItem(`userId`, result._id);
        location.assign(`index.html`)

    } catch (error) {
        alert(`Some Error`)
    }
}

async function login(e) {
    e.preventDefault();
        let form = new FormData(e.target);
        let email = form.get(`email`);
        let password = form.get(`password`);


        let loginUser = {
            email: email,
            password: password
        };

        let loginRequest = await fetch(`http://localhost:3030/users/login`, {
            method: `POST`,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        });
        e.target.reset();
        if(loginRequest.status === 403){
            alert(`Invalid Email or Password`)
            return;
        }
        let result = await loginRequest.json();
        localStorage.setItem(`token`, result.accessToken)
        localStorage.setItem(`userId`, result._id);
        location.assign("index.html")        
}
