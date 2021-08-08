import { towns } from "./towns.js";
import { townsTemplate } from "./templates/townsTemplate.js";
import { render } from "../node_modules/lit-html/lit-html.js";

let divToAttatch = document.getElementById(`towns`);
render(townsTemplate(towns), divToAttatch);