import {html} from "../../node_modules/lit-html/lit-html.js"

export let navTemplate = () => html`<a class="active" href="#">Home</a>
<a href="#">All Listings</a>
<a href="#">By Year</a>
<!-- Guest users -->
<div id="guest">
    <a href="#">Login</a>
    <a href="#">Register</a>
</div>
<!-- Logged users -->
<div id="profile">
    <a>Welcome username</a>
    <a href="#">My Listings</a>
    <a href="#">Create Listing</a>
    <a href="#">Logout</a>
</div>`
