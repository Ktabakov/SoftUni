window.addEventListener('load', solution);

function solution() {
  let fullNameElement = document.getElementById(`fname`);
  let emailElement = document.getElementById(`email`);
  let phoneElement = document.getElementById(`phone`);
  let addressElement = document.getElementById(`address`);
  let postCodeElement = document.getElementById(`code`);

  let submitButton = document.getElementById(`submitBTN`);
  submitButton.addEventListener(`click`, submitButtonClicked);

  let edditButton = document.getElementById(`editBTN`);
  let continueButton = document.getElementById(`continueBTN`);

  let infoPreviewUL = document.getElementById(`infoPreview`);

  let blockDiv = document.getElementById(`block`);

  function submitButtonClicked(e){
    e.preventDefault();
    if(fullNameElement.value != `` && emailElement.value != ``){

      submitButton.disabled = true;

      let nameLi = document.createElement(`li`);
      nameLi.textContent = `Full Name: ${fullNameElement.value}`;
      let emailLi = document.createElement(`li`);
      emailLi.textContent = `Email: ${emailElement.value}`;
      let phoneLi = document.createElement(`li`);
      phoneLi.textContent = `Phone Number: ${phoneElement.value}`;
      let addressLi = document.createElement(`li`);
      addressLi.textContent = `Address: ${addressElement.value}`;
      let postCodeLi = document.createElement(`li`);
      postCodeLi.textContent = `Postal Code: ${postCodeElement.value}`;
  
      let rememberValueName = fullNameElement.value;
      let rememberValueEmail = emailElement.value;
      let rememberValuePhone = phoneElement.value;
      let remmeberValueAddress = addressElement.value;
      let rememberValuePostCode = postCodeElement.value;

      //append ChildrenToinfoPreveiew
      infoPreviewUL.appendChild(nameLi);
      infoPreviewUL.appendChild(emailLi);
      infoPreviewUL.appendChild(phoneLi);
      infoPreviewUL.appendChild(addressLi);
      infoPreviewUL.appendChild(postCodeLi);
      
      edditButton.disabled = false;
      continueButton.disabled = false;

      fullNameElement.value = ``;
      emailElement.value = ``;
      phoneElement.value = ``;
      addressElement.value = ``;
      postCodeElement.value = ``;

      edditButton.addEventListener(`click`, (e) => {

        fullNameElement.value = rememberValueName;
        emailElement.value = rememberValueEmail;
        phoneElement.value = rememberValuePhone;
        addressElement.value = remmeberValueAddress;
        postCodeElement.value = rememberValuePostCode;

        while (infoPreviewUL.firstChild) {
          infoPreviewUL.removeChild(infoPreviewUL.lastChild);
        }
        edditButton.disabled = true;
        continueButton.disabled = true;
        submitButton.disabled = false;
      });

      continueButton.addEventListener(`click`, () => {
        while (blockDiv.firstChild) {
          blockDiv.removeChild(blockDiv.lastChild);
        }

        let newH3 = document.createElement(`h3`);
        newH3.textContent = `Thank you for your reservation!`;
        blockDiv.appendChild(newH3);
      })
  
    
    }
  }


}
