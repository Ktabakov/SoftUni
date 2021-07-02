function solve() {
  let textInput = document.getElementById("text").value;
  let convention = document.getElementById("naming-convention");
  let result;
  let output = '';

  if (convention.value == "Camel Case"){

   result = Array.from(textInput.split(" "));
   for (let index = 0; index < result.length; index++) {
      const element = result[index].toLowerCase();
      if (index == 0){
        output += element;
      }else{
        let newEl = element.charAt(0).toUpperCase() + element.slice(1)
        output += newEl;
      }
   }

  }else if (convention.value == "Pascal Case"){
    result = Array.from(textInput.split(" "));
   for (let index = 0; index < result.length; index++) {
      const element = result[index].toLowerCase();
      let newEl = element.charAt(0).toUpperCase() + element.slice(1)
      output += newEl;
  }
  }else{
    output += "Error!"
  }
  
  document.getElementById("result").textContent = output;
  console.log(output);
}