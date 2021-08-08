import { html } from "../../node_modules/lit-html/lit-html.js"

export let navTemplate = (navModel) => html`
${navModel.isLoggedIn
? html`<a class="navbar-brand text-light" href="/home">Movies</a>
<ul class="navbar-nav ml-auto ">
    <li class="nav-item">
        <a class="nav-link">Welcome, ${navModel.email}</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="javascript:void(0)" @click=${navModel.logoutHandler}>Logout</a>
    </li>
</ul>`
: html`<a class="navbar-brand text-light" href="/home">Movies</a>
<ul class="navbar-nav ml-auto ">
    <li class="nav-item">
        <a class="nav-link" href="/login">Login</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="/register">Register</a>
    </li>
</ul>`}`