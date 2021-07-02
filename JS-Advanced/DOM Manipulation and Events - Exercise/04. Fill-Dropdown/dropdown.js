function addItem() {
    let text = document.getElementById(`newItemText`);
    let value = document.getElementById(`newItemValue`);
    let select = document.getElementById(`menu`);
    let optionEl = document.createElement(`option`);
    optionEl.textContent = text.value;
    optionEl.value = value.value;

    text.value = ``;
    value.value = ``;

    select.appendChild(optionEl); 
}