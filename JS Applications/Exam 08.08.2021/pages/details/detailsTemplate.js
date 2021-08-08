import { html } from "../../node_modules/lit-html/lit-html.js"


export let detailsTemplate = (model) => html`<section id="details-page" class="details">
    <div class="book-information">
        <h3>${model.book.title}</h3>
        <p class="type">Type: ${model.book.type}</p>
        <p class="img"><img src=${model.book.imageUrl}></p>
        <div class="actions">
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            ${model.isOwner
            ? html`<a class="button" href="/edit/${model.book._id}">Edit</a>
            <a class="button" @click=${(e)=> model.deleteHandler(model.book._id, e)}>Delete</a>`
            : html``}

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${!model.isOwner && model.isLoggedIn
            ? html `<a class="button" href="javascript:void(0)" @click=${model.likeHandler}>Like</a>`
            : ``}
            
            <!-- ( for Guests and Users )  -->
            <div class="likes">
            <img class="hearts" src="/images/heart.png">
            <span id="total-likes">Likes: ${model.allLikes}</span>
        </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${model.book.description}</p>
    </div>
</section>`