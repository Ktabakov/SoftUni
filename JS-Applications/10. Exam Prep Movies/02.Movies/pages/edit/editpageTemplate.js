import {html} from "./../../node_modules/lit-html/lit-html.js"

export let editpageTemplate = (form) => html`<section id="edit-movie">
<form class="text-center border border-light p-5" @submit="${(e) => form.submitHandler(form.movie._id, e)}" method="">
    <h1>Edit Movie</h1>
    <div class="form-group">
        <label for="title">Movie Title</label>
        <input type="text" class="form-control" placeholder="Movie Title" .value="${form.movie.title}" name="title">
    </div>
    <div class="form-group">
        <label for="description">Movie Description</label>
        <textarea class="form-control" placeholder="Movie Description..." .value ="${form.movie.description}" name="description"></textarea>
    </div>
    <div class="form-group">
        <label for="imageUrl">Image url</label>
        <input type="text" class="form-control" placeholder="Image Url" .value=${form.movie.img} name="imageUrl">
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
</section>`