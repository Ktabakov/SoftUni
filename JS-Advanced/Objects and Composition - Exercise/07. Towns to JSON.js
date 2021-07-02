function solve(input){
    let titles = serializeRows(input[0]);
    let rows = input
    .slice(1)
    .map(row => serializeRows(row).reduce(accumulateObject, {}));

    return JSON.stringify(rows);


    function serializeRows(str){
        return str
        .split(/\s*\|\s*/gim)
        .filter(x => x !== '')
        .map(x => parseNumber(x));
    }
    
    function parseNumber(x){
        return isNaN(Number(x)) ? x : Number(Number(x).toFixed(2));
    }

    function accumulateObject(obj, el, i){
        obj[titles[i]] = el;
        return obj;
    }
}

console.log(
    solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
    ));