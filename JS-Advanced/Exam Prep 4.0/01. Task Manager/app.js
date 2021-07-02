function solve() {
    let taskinputField = document.getElementById(`task`);
    let descriptionField = document.getElementById(`description`);
    let dateField = document.getElementById(`date`);
    let addButton = document.getElementById(`add`);

    addButton.addEventListener(`click`, addButtonClicked);

    function addButtonClicked(e) {
        e.preventDefault();
        if (validateFields()) {
            let divField = document.querySelector(`body > main > div > section:nth-child(2) > div:nth-child(2)`);
            createArticle(divField);

        }


        function createArticle(divField) {
            let newArticle = document.createElement(`article`);
            let newH3 = document.createElement(`h3`);
            newH3.textContent = taskinputField.value;
            let descriptionP = document.createElement(`p`);
            descriptionP.textContent = `Description: ${descriptionField.value}`;
            let dateP = document.createElement(`p`);
            dateP.textContent = `Due Date: ${dateField.value}`;

            //buttons
            let divForButtons = document.createElement(`div`);
            let startButton = document.createElement(`button`);
            let deleteButton = document.createElement(`button`);

            divForButtons.classList.add(`flex`);
            startButton.classList.add(`green`);
            startButton.textContent = `Start`;
            startButton.addEventListener(`click`, startButtonCliced)
            deleteButton.classList.add(`red`);
            deleteButton.textContent = `Delete`;
            deleteButton.addEventListener(`click`, deleteButtonClicked)
            divForButtons.appendChild(startButton)
            divForButtons.appendChild(deleteButton)

            //append All to article
            newArticle.appendChild(newH3);
            newArticle.appendChild(descriptionP);
            newArticle.appendChild(dateP);
            newArticle.appendChild(divForButtons);

            divField.appendChild(newArticle);

            function startButtonCliced(e) {
                let inProglressElement = document.getElementById(`in-progress`);
                let thisArticle = e.currentTarget.parentElement.parentElement;
                e.currentTarget.parentElement.parentElement.remove();
                thisArticle.querySelector(`.flex`).remove();

                let newDivForButtons = document.createElement(`div`);
                newDivForButtons.classList.add(`flex`);

                let deleteButton = document.createElement(`button`);
                deleteButton.textContent = `Delete`;
                deleteButton.classList.add(`red`);
                deleteButton.addEventListener(`click`, deleteButtonClicked)

                let finishButton = document.createElement(`button`);
                finishButton.textContent = `Finish`;
                finishButton.classList.add(`orange`);
                finishButton.addEventListener(`click`, finishButtonClicked)

                newDivForButtons.appendChild(deleteButton);
                newDivForButtons.appendChild(finishButton);

                thisArticle.appendChild(newDivForButtons);

                inProglressElement.appendChild(thisArticle);

                function finishButtonClicked(e){
                    let thisArticle = e.currentTarget.parentElement.parentElement;
                    thisArticle.querySelector(`.flex`).remove();
                    e.currentTarget.parentElement.remove();

                    let completeDivElement = document.querySelector(`body > main > div > section:nth-child(4) > div:nth-child(2)`);
                    completeDivElement.appendChild(thisArticle);                    
                }
            }

            function deleteButtonClicked(e) {
                e.currentTarget.parentElement.parentElement.remove();
            }
        }

        function validateFields() {
            return taskinputField.value != `` && descriptionField.value != `` && dateField.value != ``;
        }
    }
}