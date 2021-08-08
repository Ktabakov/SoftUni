import { render} from "../node_modules/lit-html/lit-html.js";
import {rowsTemplate} from "./templates/rowTemplate.js"

async function solve() {
   let request = await (await fetch(`http://localhost:3030/jsonstore/advanced/table`)).json();
   let tbody = document.getElementById(`tbody`);
   let values = Object.values(request);
   render(rowsTemplate(values), tbody);
  
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick(e) {
      let input = document.getElementById(`searchField`);
      let tbodyChildren = tbody.children;
      Object.values(tbodyChildren).forEach(e => e.classList.remove(`select`));
      Object.values(tbodyChildren).forEach(element => {
         if (input.value == ``){
            element.classList.remove(`select`);
            return;
         }
         console.log(element);
         if (element.innerHTML.includes(input.value)){
            element.classList.add(`select`);
         }else{
            element.classList.remove(`select`);
         }
      });
      input.value = ``;
   }
}

solve();