import { optionsTemplate, optionTemplate } from "./templates/optionsTemplate.js";
import {render} from "../node_modules/lit-html/lit-html.js";

async function addItem() {
    let menu = document.getElementById(`menu`);
    let responce = await (await fetch(`http://localhost:3030/jsonstore/advanced/dropdown`)).json();
    let values = Object.values(responce);
    render(optionsTemplate(values), menu)

    let addOptionsform = document.getElementById(`addForm`);
    addOptionsform.addEventListener(`submit`, submitClicked);

}

async function submitClicked(e){
    e.preventDefault();
    let form = e.target;
    let data = new FormData(form);
    let text = data.get(`text`);
    
    if (text.value == ``){
        return;
    }
    
    let newOption = {
        text: text
    }
    
    let awaitResponce = await fetch(`http://localhost:3030/jsonstore/advanced/dropdown`, {
        method: `POST`,
        body: JSON.stringify(newOption),
        headers:{
            'Content-Type': 'application/json'
        }
    });
    
    let responce = awaitResponce.json();
    addItem();
}
addItem();