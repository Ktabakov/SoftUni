let id = document.URL;
id = id.substring(id.indexOf("#") + 1);

async function loadCurrentPost() {
    let request = await (await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/` + id)).json();
    createHTMLPost(request.topicName, request.username, request.date, request.post);
}
window.onload = loadCurrentPost();

let commentForm = document.getElementById(`commentForm`);
commentForm.addEventListener(`submit`, commentOn)

async function commentOn(e){
    e.preventDefault();

    let form = e.target;
    let data = new FormData(form);
    let date = new Date();
    date = date.toUTCString();
    
    let newComment = {
        comment: data.get(`postText`),
        postId: id,
        username: data.get(`username`),
        date: date
    };

    let commentRequest = await fetch(`http://localhost:3030/jsonstore/collections/myboard/comments/` + id, {
        method: `POST`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newComment)
    })
    let result = await commentRequest.json();
    console.log(result);

    form.reset();
}

function createHTMLPost(title, username, time, post) {
    let divToAttatch = document.querySelector(`#topic`);
    divToAttatch.innerHTML = ``;

    let container = document.querySelector(`body > div > div:nth-child(1) > div.theme-title > div > div > h2`);
    container.textContent = title;

    let divHeader = document.createElement(`div`);
    divHeader.classList.add(`header`);
    let imgEl = document.createElement(`img`);
    imgEl.src = `./static/profile.png`;
    imgEl.alt = `avatar`;
    let dateP = document.createElement(`p`);
    let dateSpan = document.createElement(`span`);
    dateSpan.textContent = username;
    dateP.appendChild(dateSpan);
    dateP.textContent = ` posted on `;
    let timeP = document.createElement(`time`);
    timeP.textContent = time;
    dateP.appendChild(timeP);

    let postContentP = document.createElement(`p`);
    postContentP.classList.add(`post-content`);
    postContentP.textContent = post;

    divHeader.appendChild(imgEl);
    divHeader.appendChild(dateP);
    divHeader.appendChild(postContentP);

    divToAttatch.appendChild(divHeader);

    loadComments();
}

async function loadComments(){  
    let divToAttatch = document.querySelector(`#comment`);
    divToAttatch.innerHTML = ``;
    
    let commentsRequest = await fetch(`http://localhost:3030/jsonstore/collections/myboard/comments`);
    let result = await commentsRequest.json();
    for (const [key, value] of Object.entries(result)) {
        if (key == id){
            for (const [innerKey, items] of Object.entries(value)) {
                console.log(items);

                createComment(items.username, items.date, items.comment);
            }
        }
    }

}

function createComment(username, time, comment){

    let divToAttatch = document.querySelector(`.comment`);

    let divHeader = document.createElement(`div`);
    divHeader.classList.add(`header`);
    let imgEl = document.createElement(`img`);
    imgEl.src = `./static/profile.png`;
    imgEl.alt = `avatar`;
    let dateP = document.createElement(`p`);
    let dateSpan = document.createElement(`span`);
    dateSpan.textContent = username;
    dateP.appendChild(dateSpan);
    dateP.textContent = ` commented on: `;
    let timeP = document.createElement(`time`);
    timeP.textContent = time;
    dateP.appendChild(timeP);

    let postContentP = document.createElement(`p`);
    postContentP.classList.add(`post-content`);
    postContentP.textContent = comment;

    divHeader.appendChild(imgEl);
    divHeader.appendChild(dateP);
    divHeader.appendChild(postContentP);

    divToAttatch.appendChild(divHeader); 
}