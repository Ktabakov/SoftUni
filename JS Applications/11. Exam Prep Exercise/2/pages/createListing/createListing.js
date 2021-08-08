import { createTemplate } from "./createTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;
let _form = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}

async function submitHandler(e){
    e.preventDefault();
    try{
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let brand = formData.get('brand');
        if(brand.trim() === ''){
            _form.errorMessages.push('Title is required');
        }

        let description = formData.get('description');
        if(description.trim() === ''){
            _form.errorMessages.push('Description is required');
        }

        let year = formData.get('year');
        if(year.trim() === ''){
            _form.errorMessages.push('Year is required');
        }

        let imageUrl = formData.get('imageUrl');
        if(imageUrl.trim() === ''){
            _form.errorMessages.push('Url is required');
        }

        let price = formData.get('price');
        if(price.trim() === ''){
            _form.errorMessages.push('Price is required');
        }

        if(Number(price) <= 0){
            _form.errorMessages.push('Price must be above 0');
        }

        if(Number(year) <= 0){
            _form.errorMessages.push('Year must be above 0');
        }

        let model = formData.get('model');
        if(model.trim() === ''){
            _form.errorMessages.push('Model is required');
        }

        if(_form.errorMessages.length > 0){
            let templateResult = createTemplate(_form);
            alert(_form.errorMessages.join('\n'));
            return _renderHandler(templateResult);
        }

        let car = {
            brand,
            model,
            description,
            year,
            imageUrl,
            price,
        }
        car.year = Number(car.year)
        car.price = Number(car.price)
    
        await _carsService.create(car);
        _router.redirect('/all-listings');
    } catch (err){
        alert(err);
    }
   
}

async function getView(context) {
    _form = {
        submitHandler,
        errorMessages: []
    }
    let templateResult = createTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}