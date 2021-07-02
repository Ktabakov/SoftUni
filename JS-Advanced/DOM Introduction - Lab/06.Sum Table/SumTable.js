function sumTable() {
    let values = document.querySelectorAll("tr")
    let sum = 0;

    for (let i = 1; i < values.length; i++) {
        let cols = values[i].children;
        let cost = cols[cols.length - 1].textContent;
        sum += Number(cost);
    }
    document.getElementById("sum").textContent = sum;
}