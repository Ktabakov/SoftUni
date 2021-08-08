import { townsTemplate } from "./templates/townsTemplate.js";
import { render, html } from "./../node_modules/lit-html/lit-html.js";

document.getElementById(`searchBtn`).addEventListener(`click`, search);

function search() {
   let input = document.getElementById(`searchText`).value;
   let allLiEl = document.querySelectorAll(`#towns ul li`);
   allLiEl.forEach(li => {
      if (input === ``) {
         li.classList.remove(`active`);
         return;
      }
      if (li.textContent.includes(input)) {
         li.classList.add(`active`);
      } else {
         li.classList.remove(`active`);
      }
   })

   let count = document.getElementsByClassName("active").length;
   document.getElementById(`result`).textContent = `${count} matches found`;
}