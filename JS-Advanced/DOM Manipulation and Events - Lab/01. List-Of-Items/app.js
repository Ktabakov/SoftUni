function addItem() {
    let inputFielt = document.getElementById(`newItemText`);
    let createdLiElement = document.createElement(`li`);
    createdLiElement.textContent = inputFielt.value;

    let listOfItems = document.getElementById(`items`);
    listOfItems.appendChild(createdLiElement);

    inputFielt.value = ``;
}