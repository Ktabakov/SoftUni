function solution() {
    let addGiftElement = document.querySelector(`body > div > section:nth-child(1) > div > input[type=text]`);
    let addGiftButton = document.querySelector(`body > div > section:nth-child(1) > div > button`);

    let listOfGiftsElement = document.querySelector(`body > div > section:nth-child(2) > ul`);


    let giftsArr = [];

    addGiftButton.addEventListener(`click`, addTheGift)

    function addTheGift(e) {
        e.preventDefault();

        giftsArr.push(addGiftElement.value);
        giftsArr.sort((a, b) => a.localeCompare(b));


        while (listOfGiftsElement.firstChild) {
            listOfGiftsElement.removeChild(listOfGiftsElement.firstChild);
        }

        for (const item of giftsArr) {
            createdLiForGift = document.createElement(`li`);
            createdLiForGift.classList.add(`gift`);
            createdLiForGift.textContent = item;

            //createButtons
            let sendButton = document.createElement(`button`);
            let discardButton = document.createElement(`button`);
            sendButton.classList.add(`gift`);
            sendButton.id = `sendButton`;
            sendButton.textContent = `Send`;
            discardButton.classList.add(`gift`);
            discardButton.id = `discardButton`;
            discardButton.textContent = `Discard`;

            createdLiForGift.appendChild(sendButton);
            createdLiForGift.appendChild(discardButton);

            listOfGiftsElement.appendChild(createdLiForGift);

            
            let sendButtonElement = document.getElementById(`sendButton`);
            let discardButtonElement = document.getElementById(`discardButton`);    
            sendButtonElement.addEventListener(`click`, sendButtonClicked)
            discardButtonElement.addEventListener(`click`, discartButtonClicked)
        }
        addGiftElement.value = ``;
    }

    function discartButtonClicked(e){
        let currentItemName = e.currentTarget;
        let currentGift = currentItemName.parentElement.firstChild.textContent;
        currentItemName.parentElement.remove();

        let sentItemsUL = document.querySelector(`body > div > section:nth-child(4) > ul`);
        let createdLi = document.createElement(`li`);
        createdLi.textContent = currentGift;
        createdLi.classList.add(`gift`);
        sentItemsUL.appendChild(createdLi);

        let toRemove = giftsArr.find(x => x == currentGift);
        let indexToRemove = giftsArr.indexOf(toRemove);
        giftsArr.splice(indexToRemove, 1);
    }

    function sendButtonClicked(e){
        let currentItemName = e.currentTarget;
        let currentGift = currentItemName.parentElement.firstChild.textContent;
        currentItemName.parentElement.remove();

        let sentItemsUL = document.querySelector(`body > div > section:nth-child(3) > ul`);
        let createdLi = document.createElement(`li`);
        createdLi.textContent = currentGift;
        createdLi.classList.add(`gift`);
        sentItemsUL.appendChild(createdLi);

        let toRemove = giftsArr.find(x => x == currentGift);
        let indexToRemove = giftsArr.indexOf(toRemove);
        giftsArr.splice(indexToRemove, 1);
    }
}