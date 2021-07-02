function extract(content) {
    let text = document.getElementById("content").textContent.toString();
    let rex = /\(([^)]+)\)/g;
    result = [];

    let matches = [...text.matchAll(rex)];
    for (const item of matches) {
        result.push(item[1]);
    }
    let stringResult = result.join(`; `);
    return stringResult;
}