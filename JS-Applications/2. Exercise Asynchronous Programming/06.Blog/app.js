function attachEvents() {
    document.getElementById(`btnLoadPosts`).addEventListener(`click`, getPosts)
    document.getElementById(`btnViewPost`).disabled = true;
    document.getElementById(`btnViewPost`).addEventListener(`click`, displayPost)
}

attachEvents();

function displayPost() {
    const postId = document.getElementById(`posts`).value;
    getComments(postId);
}

async function getPosts(e) {
    document.getElementById(`btnViewPost`).disabled = false;
    document.getElementById(`btnLoadPosts`).disabled = true;
    let request = await fetch(`http://localhost:3030/jsonstore/blog/posts`);
    let data = await request.json();

    const select = document.getElementById(`posts`);
    Object.values(data).map(createOption).forEach(o => select.appendChild(o));

    function createOption(post) {
        const result = document.createElement(`option`);
        result.textContent = post.title;
        result.value = post.id;

        return result;
    }
}

async function getComments(postId) {
    let commentsUl = document.getElementById(`post-comments`);

    while (commentsUl.firstChild) {
        commentsUl.removeChild(commentsUl.firstChild);
    }

    let postUrl = `http://localhost:3030/jsonstore/blog/posts/` + postId;
    let commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;

    const [postResponce, commentsResponce] = await Promise.all([
        fetch(postUrl),
        fetch(commentsUrl)
    ]);

    let postData = await postResponce.json();

    document.getElementById(`post-title`).textContent = postData.title;
    document.getElementById(`post-body`).textContent = postData.body;

    let commentsData = await commentsResponce.json();
    let comments = Object.values(commentsData).filter(c => c.postId == postId)
    comments.map(createComment).forEach(c => commentsUl.appendChild(c));
}

function createComment(comment) {
    let result = document.createElement(`li`);
    result.textContent = comment.text;
    result.id = comment.id;
    return result;
}