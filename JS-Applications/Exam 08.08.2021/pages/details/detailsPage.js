import {detailsTemplate} from "./detailsTemplate.js"

let _router = undefined;
let _renderHandler = undefined;
let _booksTemplate = undefined;

function initialize(router, renderHandler, booksTemplate) {
    _router = router;
    _renderHandler = renderHandler;
    _booksTemplate = booksTemplate;
}

async function deleteHandler(id, e){
    try{
        await _booksTemplate.deleteItem(id);
        _router.redirect('/dashboard');
    } catch(err){
        alert(err);
    }
}

async function likeHandler(id, e){
    try{
        let like = await _booksTemplate.addLike(id);
        console.log(like);

    } catch(err){
        alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let book = await _booksTemplate.get(id);
    let allLikes = await _booksTemplate.totalBookLikes(id);
    console.log(allLikes);
    let user = context.user;
    let isOwner = false;
    if(user !== undefined && user._id === book._ownerId){
        isOwner = true;
    }
    let model = {
        book,
        deleteHandler,
        isOwner,
        isLoggedIn: user !== undefined,
        likeHandler,
        allLikes
    };
    let templateResult = detailsTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}