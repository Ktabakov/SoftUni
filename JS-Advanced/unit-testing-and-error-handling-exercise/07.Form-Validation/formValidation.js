function validate() {
    let submitButton = document.getElementById(`submit`);
    let isCompanyElement = document.getElementById(`company`);

    submitButton.addEventListener(`click`, submitButtonClicked);
    isCompanyElement.addEventListener(`change`, isCompanyIsClicked);
    let fieldForCompanyInfo = document.getElementById(`companyInfo`);

    function isCompanyIsClicked(e) {

        fieldForCompanyInfo.style.display = e.target.checked ? `block` : `none`;
    }

    function submitButtonClicked(e) {
        e.preventDefault();
        let userNameElement = document.getElementById(`username`);               
        let userNameRex = /^[a-zA-Z0-9]{3,20}$/;
        let isUserNameValid = userNameRex.test(userNameElement.value);
        setBorder(userNameElement, isUserNameValid);

        let emailElement = document.getElementById(`email`);
        let emailRex = /^.*@.*\..*$/;
        let isEmailValid = emailRex.test(emailElement.value);
        setBorder(emailElement, isEmailValid);

        let passwordRex = /^\w{5,15}$/;
        let passwordElement = document.getElementById(`password`);
        isPasswordCorrect = passwordRex.test(passwordElement.value);

        let confirmPasswordElement = document.getElementById(`confirm-password`);
        let isConfirmPassCorrect = passwordRex.test(confirmPasswordElement.value);
        
        let passwordsAreOk = isPasswordCorrect && isConfirmPassCorrect && passwordElement.value === confirmPasswordElement.value;
        
        setBorder(passwordElement, passwordsAreOk);
        setBorder(confirmPasswordElement, passwordsAreOk);

        let companyNumberIsValid = false;
        if (isCompanyElement.checked){
            let companyNumber = document.getElementById(`companyNumber`);
            if (companyNumber.value.trim() !== `` && !isNaN(Number(companyNumber.value))){
                let companyNumberValue = Number(companyNumber.value);
                if (companyNumberValue >= 1000 && companyNumberValue <= 9999){
                    companyNumberIsValid = true;
                }
            }
        }

        setBorder(companyNumber, companyNumberIsValid);

        let finalCheck = document.getElementById(`valid`);
        let mainValidations = isUserNameValid && passwordsAreOk && isEmailValid;
        let companyInfoValidations = !isCompanyElement.checked || (isCompanyElement.checked && companyNumberIsValid);
        let shouldShowValidDiv = mainValidations && companyInfoValidations;

        finalCheck.style.display = shouldShowValidDiv ? `block` : `none`;
        
    }

    function setBorder(element, isValid) {
        if (isValid) {
            element.style.setProperty = `border`, `none`;
        } else {
            element.style.setProperty(`border`, `2px solid red`);
        }
    }

}
