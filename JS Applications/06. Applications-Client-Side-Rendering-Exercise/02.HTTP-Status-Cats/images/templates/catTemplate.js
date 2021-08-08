import {render, html} from "./../../../node_modules/lit-html/lit-html.js";
import { cats } from "../../catSeeder.js";



export let catTemplate = (cat, showCatInfo) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn" @click=${showCatInfo}> Show status code</button>
        <div class="status hidden" id=${cat.id}>
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>`

export let catsTemplate = (cats, showCatInfo) => html`
<ul>${cats.map(c => catTemplate(c, showCatInfo))}</ul>`