import {myBooksTemplate} from "./myBooksTemplate.js"

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
}

async function getView(context) {
    let user = context.user;
    let myBooks = await _booksService.getMyBooks(user._id);
    let templateResult = myBooksTemplate(myBooks);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}