let th = document.querySelector(`#results tbody`)
let submitButton = document.getElementById(`submit`);
submitButton.addEventListener(`click`, submitClicked)

let firstNameEl = document.getElementById(`firstName`);
let lastNameEl = document.getElementById(`lastName`);
let facultyNumberEl = document.getElementById(`facultyNumber`);
let gradeEl = document.getElementById(`grade`);

async function submitClicked(e) {
    e.preventDefault();
    if(!firstNameEl.value || !lastNameEl.value || !facultyNumberEl.value || !gradeEl.value){
        return
    }
    await fetch(`http://localhost:3030/jsonstore/collections/students`, {
        method: `POST`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            firstName: firstNameEl.value,
            lastName: lastNameEl.value,
            facultyNumber: facultyNumberEl.value,
            grade: gradeEl.value
        })
    });

    firstNameEl.value = ``;
    lastNameEl.value = ``;
    facultyNumberEl.value = ``;
    gradeEl.value = ``;

    getStudents() 
}

async function getStudents() {
    
    while (th.firstChild) {
        th.removeChild(th.firstChild);
    }
    let requrest = await (await fetch(`http://localhost:3030/jsonstore/collections/students`)).json();
    Object.entries(requrest).forEach(element => {

        let tr = document.createElement(`tr`);
        let td1 = document.createElement(`td`);
        let td2 = document.createElement(`td`);
        let td3 = document.createElement(`td`);
        let td4 = document.createElement(`td`);

        td1.textContent = element[1].firstName;
        td2.textContent = element[1].lastName;
        td3.textContent = element[1].facultyNumber;
        td4.textContent = element[1].grade;

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.id = element[0];

        th.append(tr);
    });
}

getStudents();