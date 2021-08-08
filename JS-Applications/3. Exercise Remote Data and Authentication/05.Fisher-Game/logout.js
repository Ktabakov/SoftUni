let logoutEl = document.getElementById(`logout`);
logoutEl.addEventListener(`click`, logout);

async function logout(){
    if (localStorage.getItem(`token`) === undefined){
        return;
    }

    let token = localStorage.getItem(`token`);

    let logoutResponce = await fetch(`http://localhost:3030/users/logout`, {
        method: `GET`,
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        }
    });
    localStorage.removeItem(`token`);
    localStorage.removeItem(`userId`);
    location.assign("login.html");
    
    alert(`Logout Successful`)
}
