import auth, { getUserId } from "../helpers/auth.js";
import { jsonRequest } from "../helpers/httpService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
}

async function getView(id) {
    let movieDetails = await jsonRequest(`http://localhost:3030/data/movies/${id}`);
    let container = section.querySelector(`#movie-details-container`);
    [...container.children].forEach(x => x.remove());
    let movieDetailLinks = createMovieDetails(movieDetails);
    container.querySelectorAll(`.link`).forEach(e => e.addEventListener(`click`, viewFinder.changeViewHandler))
    container.innerHTML = movieDetailLinks;
    return section;
}

export async function like(movieId){
    let movieDetails = await jsonRequest(`http://localhost:3030/data/movies/${movieId}`);
   console.log(movieDetails);
    let userId = auth.getUserId();
    let isOwner = userId === movieDetails._ownerId;
    let userLikes = await jsonRequest(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`)
    console.log(userLikes);
}

function createMovieDetails(movie) {

    let deleteButton = `<a class="btn btn-danger link" data-route="delete" data-id="${movie._id}" href="#">Delete</a>`
    let editButton = `<a class="btn btn-warning link" data-route="edit" data-id="${movie._id}" href="#">Edit</a>`
    let likeButton = `<a class="btn btn-primary link" data-route="like" data-id="${movie._id}" href="#">Like</a>`

    let buttons = [];
    if (auth.getUserId() === movie._ownerId) {
        buttons.push(deleteButton, editButton)
    } else {
        buttons.push(likeButton)
    }

    let buttonsSection = buttons.join(`\n`);

    let element = `<div class="row bg-light text-dark">
                <h1>Movie title: ${movie.title}</h1>

    <div class="col-md-8">
        <img class="img-thumbnail"
            src="${movie.img}" alt="Movie">
    </div>
    <div class="col-md-4 text-center">
        <h3 class="my-3 ">Movie Description</h3>
        <p>${movie.description}</p>
        ${buttonsSection}
        <span class="enrolled-span">Liked 1</span>
    </div>
</div>`;

    return element;

}

let movieDetailsPage = {
    initialize,
    getView,
    like
};

export default movieDetailsPage;