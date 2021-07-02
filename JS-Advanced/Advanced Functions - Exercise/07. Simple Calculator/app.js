function calculator() {
    let firstEl;
    let secondEl;
    let resultEl;

    function init(num1, num2, result){
          firstEl = document.querySelector(num1);
          secondEl = document.querySelector(num2);
          resultEl = document.querySelector(result);
    }
    function add(){
        resultEl.value = Number(firstEl.value) + Number(secondEl.value);
    }
    function subtract (){
        resultEl.value = Number(firstEl.value) - Number(secondEl.value);
    }
    let resultObj = {
        init,
        add,
        subtract
    }
    return resultObj;
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 





