let phonebookUL = document.getElementById(`phonebook`);
let loadButton = document.getElementById(`btnLoad`);
let createButton = document.getElementById(`btnCreate`);
let person = document.getElementById(`person`);
let phone = document.getElementById(`phone`);

function attachEvents() {
    loadButton.addEventListener(`click`, loadButtonPressed);
    createButton.addEventListener(`click`, createButtonClicked)
}

async function createButtonClicked() {
    try {
        await fetch(`http://localhost:3030/jsonstore/phonebook`, {
            method: `POST`,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                person: person.value,
                phone: phone.value
            })
        });
    } catch (error) {
        console.log(error);
    }

    person.value = ``;
    phone.value = ``;
}

async function loadButtonPressed() {
    while (phonebookUL.firstChild) {
        phonebookUL.removeChild(phonebookUL.firstChild);
    }

    try {
        let requrest = await (await fetch(`http://localhost:3030/jsonstore/phonebook`)).json();
        Object.entries(requrest).forEach(element => {

            let li = document.createElement(`li`);
            li.textContent = `${element[1].person}: ${element[1].phone}`;
            li.id = element[0];
            let deleteButton = document.createElement(`button`);
            deleteButton.textContent = `Delete`;
            deleteButton.classList.add(`button`);
            li.appendChild(deleteButton);
            phonebookUL.appendChild(li);

            deleteButton.addEventListener(`click`, deleteButtonClicked)
        });
    } catch (error) {
        console.log(error);
    }
}

async function deleteButtonClicked(e) {
    let liID = e.target.parentElement.id;
    try {
        await fetch(`http://localhost:3030/jsonstore/phonebook/` + liID, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        e.target.parentElement.remove();
    } catch (error) {
        console.log(error);
    }
}

attachEvents();