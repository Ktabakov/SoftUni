import {myListingsTemplate} from "./myListingsTemplate.js"

let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}

async function getView(context) {
    let user = context.user;
    let myCars = await _carsService.getMyCars(user._id);
    console.log(myCars);
    let templateResult = myListingsTemplate(myCars);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}