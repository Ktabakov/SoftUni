import {allTownsTemplate} from "./Templates/townsTemplate.js";
import {render, html} from "./../node_modules/lit-html/lit-html.js";

let loadButton = document.getElementById(`btnLoadTowns`);
loadButton.addEventListener(`click`, loadTowns);

let root = document.getElementById(`root`);

function loadTowns(e){
    e.preventDefault();
    let townsElement = document.getElementById(`towns`);
    let towns = townsElement.value.split(`, `);

    render(allTownsTemplate(towns), root);
}