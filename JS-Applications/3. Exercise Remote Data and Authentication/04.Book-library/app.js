let loadBooksButton = document.getElementById(`loadBooks`);
loadBooksButton.addEventListener(`click`, loadBooks)

let formEl = document.getElementById(`add-book`);
formEl.addEventListener(`submit`, formSubmitted)

async function formSubmitted(e) {
    e.preventDefault();
    let data = new FormData(e.currentTarget);

    if (!data.get("author") || !data.get("title")){
        return;
    }
    await fetch(`http://localhost:3030/jsonstore/collections/books`, {
        method: `POST`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            author: data.get("author"),
            title: data.get("title")
        })
    });

    e.target.reset();
    loadBooks();
}

async function loadBooks() {
    let tbody = document.querySelector(`body > table > tbody`);

    while (tbody.firstChild) {
        tbody.removeChild(tbody.firstChild);
    }

    let request = await (await fetch(`http://localhost:3030/jsonstore/collections/books`)).json();

    Object.entries(request).forEach(element => {
        let tr = document.createElement(`tr`);
        let td1 = document.createElement(`td`);
        let td2 = document.createElement(`td`);

        let buttonTD = document.createElement(`td`);
        let editButton = document.createElement(`button`);
        editButton.textContent = `Edit`;
        editButton.addEventListener(`click`, editClicked)

        let deleteButton = document.createElement(`button`);
        deleteButton.textContent = `Delete`;
        deleteButton.addEventListener(`click`, deleteButtonClicked)

        buttonTD.appendChild(editButton);
        buttonTD.appendChild(deleteButton);

        tr.id = element[0];
        td2.textContent = element[1].author;
        td1.textContent = element[1].title;

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(buttonTD);

        tbody.appendChild(tr);

    });
}

async function deleteButtonClicked(e){
    let id = e.target.parentElement.parentElement.id;

    await fetch(`http://localhost:3030/jsonstore/collections/books/` + id, {
        method: `DELETE`,
        headers: {
            'Content-Type': 'application/json'
        },
    });
    loadBooks();
}

function editClicked(e) {
    let tr = e.target.parentElement.parentElement;
    let id = tr.id;

    formEl.querySelector(`h3`).textContent = `Edit FORM`;
    formEl.removeEventListener(`submit`, formSubmitted);

    let saveButton = formEl.querySelector(`button`);
    saveButton.textContent = `Save`

    document.getElementById(`title`).value = tr.firstChild.textContent;
    document.getElementById(`author`).value = tr.children[1].textContent;

    formEl.addEventListener(`submit`, sendSubmit.bind(id))

}

async function sendSubmit(e) {
    let data = new FormData(formEl);

    e.preventDefault();
    let id = this.toString();
    console.log(id);
    await fetch(`http://localhost:3030/jsonstore/collections/books/` + id, {
        method: `PUT`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            author: data.get(`author`),
            title: data.get(`title`)
        })
    });

    formEl.reset();
    loadBooks();
}
