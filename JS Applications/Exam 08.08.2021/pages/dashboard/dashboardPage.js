import {dashboardTemplate} from "./dashboardTemplate.js"

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
}

async function getView(context) {
    let books = await _booksService.getAllBooks();
    let templateResult = dashboardTemplate(books);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}