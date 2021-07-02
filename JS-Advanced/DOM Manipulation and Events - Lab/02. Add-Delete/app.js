function addItem() {
    let listItems = document.getElementById(`items`);
    let inputElement = document.getElementById(`newItemText`);

    let childToList = document.createElement(`li`);
    childToList.textContent = inputElement.value;

    let deleteButton = document.createElement(`a`);
    deleteButton.setAttribute(`href`, `#`);
    deleteButton.textContent = `[Delete]`;

    childToList.appendChild(deleteButton);
    listItems.appendChild(childToList);

    inputElement.value = ``;

    
    deleteButton.addEventListener(`click`, (e) => {
        e.currentTarget.parentNode.remove();
    })
}