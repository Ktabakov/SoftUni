import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _booksService = undefined;
let _form = undefined;

function initialize(router, renderHandler, booksService) {
    _router = router;
    _renderHandler = renderHandler;
    _booksService = booksService;
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

        let imageUrl = formData.get('imageUrl');
        if(imageUrl.trim() === ''){
            _form.errorMessages.push('Image Url is required');
        }
        let type = formData.get('type');


        if(_form.errorMessages.length > 0){
            let templateResult = editTemplate(_form);
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let book = {
            title,
            description,
            imageUrl,
            type
        }
    
        let bookUpdate = await _booksService.update(book, id);
        console.log(bookUpdate);
        _router.redirect(`/details/${id}`);
    } catch (err){
        alert(err);
    }
   
}

async function getView(context) {
    let id = context.params.id;
    let book = await _booksService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        book
    }
    let templateResult = editTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}