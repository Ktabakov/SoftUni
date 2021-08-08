let form = document.querySelector(`.container form`);
let cancelButton = document.querySelector(`.new-topic-buttons .cancel`);
cancelButton.addEventListener(`click`, cancelClicked);

let postButton = document.querySelector(`.new-topic-buttons .public`);
postButton.addEventListener(`click`, postClicked);
listAllPosts();

async function listAllPosts(){

let container = document.querySelector(`.topic-container`);
container.innerHTML = ``;

let getResult = await (await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts`)).json();
    
    Object.entries(getResult).forEach(x => createHTMLTopic(x[1].topicName, x[1].username, x[1].date, x[1].post, x[1]._id));
}

function createHTMLTopic(title, username, date, post, id) {

    let container = document.querySelector(`.topic-container`);

    let divTopicNameWraper = document.createElement(`div`);
    divTopicNameWraper.classList.add(`topic-name-wrapper`);

    let divTopicName = document.createElement(`div`);
    divTopicName.classList.add(`topic-name`);
    let aTag = document.createElement(`a`);
    aTag.setAttribute(`href`, `theme-content.html#${id}`);
    aTag.setAttribute(`id`, id);
    aTag.classList.add(`normal`);
    let h2Name = document.createElement(`h2`);
    h2Name.textContent = title;
    h2Name.id = id;
    aTag.appendChild(h2Name);

    divTopicName.appendChild(aTag);

    let divColums = document.createElement(`div`);
    divColums.classList.add(`columns`);
    let emptyDiv = document.createElement(`div`);
    let dateP = document.createElement(`p`);
    dateP.textContent = `Date: `;
    let timeT = document.createElement(`time`);
    timeT.textContent = date;
    dateP.appendChild(timeT);

    let nickName = document.createElement(`div`);
    nickName.classList.add(`nick-name`);
    let nameP = document.createElement(`p`);
    nameP.textContent = `Username: `;
    let nameSpan = document.createElement(`span`);
    nameSpan.textContent = username;
    nameP.appendChild(nameSpan);
    nickName.appendChild(nameP);

    emptyDiv.appendChild(dateP);
    emptyDiv.appendChild(nickName);


    divColums.appendChild(emptyDiv);
    divTopicName.appendChild(divColums);

    divTopicNameWraper.appendChild(divTopicName);
    divTopicNameWraper.dataset.id = id;
    divTopicNameWraper.dataset.post = post;
    
    container.appendChild(divTopicNameWraper)
}


function cancelClicked(e) {
    e.preventDefault();
    let form = e.target.parentElement.parentElement;
    form.reset();
}

async function postClicked(e) {
    
    e.preventDefault();
    let form = e.target.parentElement.parentElement;
    let data = new FormData(form);

    let date = new Date();
    date = date.toUTCString();

    let newPost = {
        topicName: data.get(`topicName`),
        username: data.get(`username`),
        post: data.get(`postText`),
        date: date
    };

    if (newPost.topicName === `` || newPost.username === `` || newPost.post === ``){
        return;
    }
    let postRequest = await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts`, {
        method: `POST`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newPost),
    });

    let result = await postRequest.json();
    console.log(result);

    createHTMLTopic(newPost.topicName, newPost.username, newPost.date, newPost.post, result._id)
    form.reset();
}