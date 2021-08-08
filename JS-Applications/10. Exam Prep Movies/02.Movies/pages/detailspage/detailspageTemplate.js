import {html} from "./../../node_modules/lit-html/lit-html.js"


export let detailspageTemplate = (model) => html`
<section id="movie-example">
<div class="container">
    <div class="row bg-light text-dark">
        <h1>Movie title: ${model.movie.title}</h1>

        <div class="col-md-8">
            <img class="img-thumbnail" src="${model.movie.img}"
                 alt="Movie">
        </div>
        <div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>${model.movie.description}</p>
            ${model.isOwner 
            ? html`<a class="btn btn-danger" @click=${(e) => model.deleteHandler(model.movie._id, e)}>Delete</a>
            <a class="btn btn-warning" href="/edit/${model.movie._id}">Edit</a>`
            : html`<a class="btn btn-primary"  @click=${(e) => model.likeHandler(model.movie._id, e)}>Like</a>`}            
            <span class="enrolled-span">Liked ${model.userLikes}</span>
        </div>
    </div>
</div>
</section>`