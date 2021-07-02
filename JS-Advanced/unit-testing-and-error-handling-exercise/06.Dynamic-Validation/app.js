function validate() {
    let emailInputElement = document.getElementById(`email`);
    emailInputElement.addEventListener(`change`, validateEmail);

    function validateEmail(){
        let emailRex = /^[a-z]+@[a-z]+\.[a-z]+$/;
        let isValid = emailRex.test(emailInputElement.value);
        if(isValid){
            emailInputElement.classList.remove(`error`);
        }else{
            emailInputElement.classList.add(`error`);
        }
    };
}