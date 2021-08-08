import { html } from "../../node_modules/lit-html/lit-html.js"
import authService from "../../services/authService.js"

export let navTemplate = (nav) => html`<nav id="nav">
    ${authService.isLoggedIn()
            ? html`<a href="/all-memes">All Memes</a>
    <div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, ${nav.email}</span>
            <a href="/my-profile">My Profile</a>
            <a href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a>
        </div>
    </div>`
            : html`<div class="guest">
            <a class="active" href="/welcome">Home Page</a>
            <a href="/all-memes">All Memes</a>
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
    </div>`}
</nav>`