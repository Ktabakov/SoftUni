import carsService from "../../services/carsService.js";
import {searchTemplate} from "./searchTemplate.js"

let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;
let year = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}


async function getView(context) {
    let templateResult = searchTemplate(onChange, onSearch);
    _renderHandler(templateResult);
}

async function onChange(){
    let input = document.getElementById(`search-input`);
    year = input.value;    
}
async function onSearch(){
    let myCars = await carsService.getByYear(year);
    let templateResult = searchTemplate(onChange, onSearch, myCars);
    _renderHandler(templateResult);
}


export default {
    getView,
    initialize
}