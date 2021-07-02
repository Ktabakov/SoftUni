function extractText() {
    let getList = document.querySelectorAll("ul#items li");
    
    let getArea = document.getElementById("result");

    for (const item of getList) {
        getArea.value += item.textContent + '\n';
    }
}