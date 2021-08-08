import { jsonRequest } from "../helpers/httpService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
}

async function getView() {
    let url = `http://localhost:3030/data/movies`;
    let movies = await jsonRequest(url);
    let moviesHtml = movies.map(m => createHtmlMovie(m)).join(`\n`);

    let movieContainer = section.querySelector(`#movie-container`);
    movieContainer.querySelectorAll(`.movie`).forEach(e => e.remove());

    movieContainer.innerHTML = moviesHtml;
    console.log(movieContainer);
    movieContainer.querySelectorAll(`.link`).forEach(el => el.addEventListener(`click`, viewFinder.changeViewHandler))
    return section;
}

function createHtmlMovie(movie) {
let element =
    `<div class="card mb-4 movie">
        <img class="card-img-top" src="${movie.img}"
            alt="Card image cap" width="400">
            <div class="card-body">
                <h4 class="card-title">${movie.title}</h4>
            </div>
            <div class="card-footer">
                <a class="link" data-route="movie-details" data-id =${movie._id} href="#/details/6lOxMFSMkML09wux6sAF">
                    <button type="button" class="btn btn-info">Details</button>
                </a>
            </div>
        </div>`

        return element;
}

        let homePage = {
            initialize,
            getView
        };

        export default homePage;