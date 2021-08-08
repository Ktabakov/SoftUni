let textArea = document.getElementById(`messages`);
let content = document.getElementById(`content`);
let submitButton = document.getElementById(`submit`);
let author = document.getElementById(`author`);
let refreshButton = document.getElementById(`refresh`);

function attachEvents() {
    submitButton.addEventListener(`click`, submitButtonClicked);
    refreshButton.addEventListener(`click`, refreshButtonClicked);
}

async function submitButtonClicked(){
    let request = await fetch(`http://localhost:3030/jsonstore/messenger`, {
        method: `POST`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            author: author.value,
            content: content.value
        })
    });
    
    author.value = ``;
    content.value = ``;
    return request.json();
}

async function refreshButtonClicked(){
    let request = await (await fetch(`http://localhost:3030/jsonstore/messenger`)).json();
    let result = ``;

    Object.entries(request).forEach(message => {
        result += `${message[1].author}: ${message[1].content}\n`;
    });
    
    textArea.textContent = ``;
    textArea.textContent = result.trim();
}


attachEvents();