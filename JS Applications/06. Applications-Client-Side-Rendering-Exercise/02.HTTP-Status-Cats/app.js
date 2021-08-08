import { catsTemplate, catTemplate } from "./images/templates/catTemplate.js";
import { render, html } from "./../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js"

function showCatInfo(e) {
    let button = e.target;
    button.textContent = button.textContent === `Show status code`
        ? `Hide status code`
        : `Show status code`;
    let infoDiv = button.closest(`.info`);
    let statusDiv = infoDiv.querySelector(`.status`);
    if (statusDiv.classList.contains(`hidden`)){
        statusDiv.classList.remove(`hidden`);
    }else{
        statusDiv.classList.add(`hidden`);
    }

}
let section = document.getElementById(`allCats`);

render(catsTemplate(cats, showCatInfo), section);