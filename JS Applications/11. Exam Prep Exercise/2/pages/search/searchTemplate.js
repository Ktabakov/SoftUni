import {html} from "../../node_modules/lit-html/lit-html.js"

let main = document.getElementById(`site-content`);

export let searchTemplate = (onChange, onSearch, cars) => html`<section id="search-cars">
<h1>Filter by year</h1>

<div class="container">
    <input id="search-input" type="text" name="search" placeholder="Enter desired production year" @input="${onChange}">
    <button class="button-list" @click="${onSearch}">Search</button>
</div>

<h2>Results:</h2>
<div class="listings">
    ${cars !== undefined
    ? html `${cars.length > 0
    ?html`${cars.map(c => singleCar(c))}`
    :html`<p class="no-cars"> No results.</p>`}`
    : html ``}
</div>
</section>`

let singleCar = (car) => html`<div class="listing">
<div class="preview">
    <img src="${car.imageUrl}">
</div>
<h2>${car.brand} ${car.model}</h2>
<div class="info">
    <div class="data-info">
        <h3>Year: ${car.year}</h3>
        <h3>Price: ${car.price} $</h3>
    </div>
    <div class="data-buttons">
        <a href="/details/${car._id}" class="button-carDetails">Details</a>
    </div>
</div>
</div>`;
