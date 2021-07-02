function focused() {
    let allItems = document.querySelectorAll(`input`);

    for (const item of allItems) {
        item.addEventListener(`focus`, onFocus);
        item.addEventListener(`blur`, onBlur);
    }

    function onFocus(e){
        e.target.parentNode.className = `focused`;
    }
    function onBlur(e){
        e.target.parentNode.className = `blured`;
    }
}