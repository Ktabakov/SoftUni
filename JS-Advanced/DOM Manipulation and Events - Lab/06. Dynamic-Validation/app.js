function validate() {
    let inputField = document.getElementById(`email`);
    inputField.addEventListener(`change`, onChange);

    function onChange(e){
     let email = e.target.value;
     if (/[a-z]+@[a-z]+\.[a-z]+$/.test(email)){
        e.target.className = ``;
     }else{ 
        e.target.className = `error`;
     }
    }

}