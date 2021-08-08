let loadButton = document.querySelector(`main aside .load`);
loadButton.addEventListener(`click`, loadCathes);

let catchesContainer = document.getElementById(`catches`);
catchesContainer.querySelectorAll(`.catch`).forEach(x => x.remove());

let addButton = document.querySelector(`#addForm .add`);
addButton.disabled = localStorage.getItem(`token`) === null;
addButton.addEventListener(`click`, createCatch);

async function createCatch() {
    let anglerInput = document.querySelector(`#addForm .angler`);
    let weightInput = document.querySelector(`#addForm .weight`);
    let speciesInput = document.querySelector(`#addForm .species`);
    let locationInput = document.querySelector(`#addForm .location`);
    let baitInput = document.querySelector(`#addForm .bait`);
    let captureTimeInput = document.querySelector(`#addForm .captureTime`);

    let newCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value)
    };

    if (anglerInput.value === `` || weightInput.value === `` || speciesInput.value === `` || locationInput.value === `` || baitInput.value === `` || captureTimeInput.value === ``){
        return;
    }

    await fetch(`http://localhost:3030/data/catches`, {
        method: `POST`,
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem(`token`)
        },
        body: JSON.stringify(newCatch)
    });

    anglerInput.value = ``;
    weightInput.value = ``;
    speciesInput.value = ``;
    locationInput.value = ``;
    baitInput.value = ``;
    captureTimeInput.value = ``;

    loadCathes();
}

async function loadCathes() {
    let request = await (await fetch(`http://localhost:3030/data/catches`)).json();

    catchesContainer.querySelectorAll(`.catch`).forEach(x => x.remove());

    Object.entries(request).forEach(element => {
        let currCatch = createHTMLCatch(element[1].angler, element[1].weight, element[1].species, element[1].location, element[1].bait, element[1].captureTime, element[1]._id, element[1]._ownerId);
        catchesContainer.appendChild(currCatch);
        console.log(element);
    });
}

async function updateCatch(e) {

    let currCatch = e.target.parentElement;

    let anglerInput = currCatch.querySelector(`.angler`);
    let weightInput = currCatch.querySelector(`.weight`);
    let speciesInput = currCatch.querySelector(`.species`);
    let locationInput = currCatch.querySelector(`.location`);
    let baitInput = currCatch.querySelector(`.bait`);
    let captureTimeInput = currCatch.querySelector(`.captureTime`);

    let updatedCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value)
    };

    await fetch(`http://localhost:3030/data/catches/` + currCatch.dataset.id, {
        method: `PUT`,
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem(`token`)
        },
        body: JSON.stringify(updatedCatch)
    });
}

async function deleteCatch(e) {
    let currCatch = e.target.parentElement;

    await fetch(`http://localhost:3030/data/catches/` + currCatch.dataset.id, {
        method: `DELETE`,
        headers: {
            'X-Authorization': localStorage.getItem(`token`)
        },
    });

    currCatch.remove();
}

function createHTMLCatch(angler, weight, species, location, bait, captureTime, id, ownerId) {

    let divCatch = document.createElement(`div`);
    divCatch.classList.add(`catch`);
    divCatch.dataset.id = id;
    divCatch.dataset.ownerId = ownerId;

    anglerLabel = document.createElement(`label`);
    anglerLabel.textContent = `Angler`;

    let inputAngler = document.createElement(`input`);
    inputAngler.type = `text`;
    inputAngler.classList.add(`angler`);
    inputAngler.value = angler;
    let hr1 = document.createElement(`hr`);

    let weightLabel = document.createElement(`label`);
    weightLabel.textContent = `Weight`;

    let inputWeight = document.createElement(`input`);
    inputWeight.type = `number`;
    inputWeight.classList.add(`weight`)
    inputWeight.value = weight;
    let hr2 = document.createElement(`hr2`);

    let speciesLabel = document.createElement(`label`);
    speciesLabel.textContent = `Species`;

    let inputSpecies = document.createElement(`input`);
    inputSpecies.type = `text`;
    inputSpecies.classList.add(`species`);
    inputSpecies.value = species;
    let hr3 = document.createElement(`hr`);

    let locationLabel = document.createElement(`label`);
    locationLabel.textContent = `Location`;

    let inputLocation = document.createElement(`input`);
    inputLocation.type = `text`;
    inputLocation.classList.add(`location`);
    inputLocation.value = location;
    let hr4 = document.createElement(`hr`);

    let baitLabel = document.createElement(`label`);
    baitLabel.textContent = `Bait`;

    let inputBait = document.createElement(`input`);
    inputBait.type = `text`;
    inputBait.classList.add(`bait`);
    inputBait.value = bait;
    let hr5 = document.createElement(`hr`);

    let timeLabel = document.createElement(`label`);
    timeLabel.textContent = `Capture Time`;

    let inputTime = document.createElement(`input`);
    inputTime.type = `number`;
    inputTime.classList.add(`captureTime`);
    inputTime.value = captureTime;
    let hr6 = document.createElement(`hr`);

    let updateButton = document.createElement(`button`)
    updateButton.classList.add(`update`);
    updateButton.textContent = `Update`;
    updateButton.disabled = true;
    updateButton.addEventListener(`click`, updateCatch);
    updateButton.disabled = localStorage.getItem(`userId`) !== ownerId;

    let deleteButton = document.createElement(`button`)
    deleteButton.classList.add(`delete`);
    deleteButton.textContent = `Delete`;
    deleteButton.disabled = true;
    deleteButton.addEventListener(`click`, deleteCatch);
    deleteButton.disabled = localStorage.getItem(`userId`) !== ownerId;

    divCatch.appendChild(anglerLabel);
    divCatch.appendChild(inputAngler);
    divCatch.appendChild(hr1);
    divCatch.appendChild(weightLabel);
    divCatch.appendChild(inputWeight);
    divCatch.appendChild(hr2);
    divCatch.appendChild(speciesLabel);
    divCatch.appendChild(inputSpecies);
    divCatch.appendChild(hr3);
    divCatch.appendChild(locationLabel);
    divCatch.appendChild(inputLocation);
    divCatch.appendChild(hr4);
    divCatch.appendChild(baitLabel);
    divCatch.appendChild(inputBait);
    divCatch.appendChild(hr5);
    divCatch.appendChild(timeLabel);
    divCatch.appendChild(inputTime);
    divCatch.appendChild(hr6);
    divCatch.appendChild(updateButton);
    divCatch.appendChild(deleteButton);

    return divCatch;
}