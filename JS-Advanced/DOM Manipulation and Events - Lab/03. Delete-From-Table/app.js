function deleteByEmail() {
    let emailInput = document.querySelector(`label > input`);
    let customers = document.querySelectorAll(`#customers > tbody > tr`);
    let resultField = document.getElementById(`result`);
    let isDeleted = false;

    for (const cust of customers) {
        if (cust.textContent.includes(emailInput.value)){
            cust.remove();
            isDeleted = true;
        }
        
    }
    if (isDeleted){
        resultField.textContent = `Deleted`;
    }
    else{
        resultField.textContent = `Not found`;
    }
}