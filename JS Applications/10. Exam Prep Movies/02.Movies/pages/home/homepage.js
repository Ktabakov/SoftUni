import moviesService from "../../services/moviesService.js";
import { homeTemplate } from "./homeTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _memesService = undefined;

function initialize(router, renderHandler, memesService) {
    _router = router;
    _renderHandler = renderHandler;
    _memesService = memesService;
}

async function getView(context) {
    let user = context.user;
    let isLoggedIn = user !== undefined;

    let movies = await moviesService.getAll();
    let info = {
        movies,
        isLoggedIn
    }
    let templateResult = homeTemplate(info);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}