function solution(title, id) {
    
    let divAccordion = document.createElement(`div`);
    divAccordion.classList.add(`accordion`);

    let divHead = document.createElement(`div`);
    divHead.classList.add(`head`);

    let span = document.createElement(`span`);
    span.textContent = title;

    let button = document.createElement(`button`);
    button.classList.add(`button`);
    button.id = id;
    button.textContent = `More`;
    button.addEventListener(`click`, click);


    divHead.appendChild(span);
    divHead.appendChild(button);

    let divExtra = document.createElement(`div`);
    divExtra.classList.add(`extra`);
    let insideP = document.createElement(`p`);
    insideP.textContent = ``;

    divExtra.appendChild(insideP);

    divAccordion.appendChild(divHead);
    divAccordion.appendChild(divExtra);

    return divAccordion;
}

async function start() {
    let mainSection = document.getElementById(`main`);
    let request = await fetch(`http://localhost:3030/jsonstore/advanced/articles/list`);
    let body = await request.json();   

    body.forEach(item => {
        console.log(item.title, item._id);
        mainSection.appendChild(solution(item.title, item._id));
    });
}

async function click(e) {
    let div = e.target.parentElement.parentElement;
    let extra = div.querySelector('.extra');
    let p = div.querySelector('p');

    let url = `http://localhost:3030/jsonstore/advanced/articles/details/${e.target.id}`;
    let resposne = await fetch(url);
    let data = await resposne.json();
    console.log(data);

    p.textContent = data.content;

    extra.style.display = extra.style.display === `block`
    ? `none`
    : `block`;

    e.target.textContent = e.target.textContent === `More`
    ? `Less`
    : `More`;
    
}
window.onload = start();