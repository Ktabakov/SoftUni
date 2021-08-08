import { editpageTemplate } from "./editpageTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _moviesService = undefined;
let _form = undefined;

function initialize(router, renderHandler, moviesService) {
    _router = router;
    _renderHandler = renderHandler;
    _moviesService = moviesService;
    //_notification = notification;
}

async function submitHandler(id, e){
    e.preventDefault();
    try{
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let title = formData.get('title');
        if(title.trim() === ''){
            _form.errorMessages.push('Title is required');
        }

        let description = formData.get('description');
        if(description.trim() === ''){
            _form.errorMessages.push('Description is required');
        }

        let img = formData.get('imageUrl');
        if(img.trim() === ''){
            _form.errorMessages.push('Image Url is required');
        }

        if(_form.errorMessages.length > 0){
            let templateResult = editpageTemplate(_form);
            _//notification.createNotification(_form.errorMessages.join('\n'));
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let movie = {
            title,
            description,
            img
        }
    
        await _moviesService.update(movie, id);
        _router.redirect(`/details/${id}`);
    } catch (err){
        alert(err);
    }
   
}

async function getView(context) {
    let id = context.params.movieId;
    let movie = await _moviesService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        movie
    }
    let templateResult = editpageTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}