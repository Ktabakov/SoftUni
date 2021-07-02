function lockedProfile() {
    let profiles = document.querySelectorAll(`.profile`);
    let buttons = document.querySelectorAll(`#main .profile button`);

    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener(`click`, function(){
            let hiddenFieldElement = document.getElementById(`user${i + 1}HiddenFields`);
            let radioButtonName = `user${i + 1}Locked`
            let radioButton = document.querySelector(`input[name="${radioButtonName}"]:checked`)
            if (radioButton.value === `unlock`){
                hiddenFieldElement.style.display = hiddenFieldElement.style.display === `block` ? `none` : `block`;
                buttons[i].textContent = buttons[i].textContent === `Show more` ? `Hide it` : `Show more`;
            }
        });
        
    }

    
}