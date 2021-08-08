import { detailspageTemplate } from "./detailspageTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _moviesService = undefined;

function initialize(router, renderHandler, moviesService) {
    _router = router;
    _renderHandler = renderHandler;
    _moviesService = moviesService;
}

async function deleteHandler(id, e) {
    try {
        await _moviesService.deleteItem(id);
        _router.redirect('/home');
    } catch (err) {
        alert(err);
    }
}

async function likeHandler(id, e) {
    let movie = {
        movieId: id
    }
    try {
        await _moviesService.like(movie, id);
        _router.redirect(`/details/:${id}`);
    } catch (err) {
        alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let movie = await _moviesService.get(id);
    
    let user = context.user;
    let userLikes = await _moviesService.userLikes(movie._id, user._id);
    let isOwner = false;
    if (user !== undefined && user._id === movie._ownerId) {
        isOwner = true;
    }
    

    let model = {
        movie,
        deleteHandler,
        likeHandler,
        isOwner,
        userLikes
    };
    let templateResult = detailspageTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}