function solve(...params){
    let occurences = {};
    let result = [];

    for (const item of params) {
        let type = typeof(item);
        result.push(`${type}: ${item}`)
        if (occurences[type] !== undefined){
            occurences[type]++;
        }else{
            occurences[type] = 1;
        }
    }

    let sortedKeys = Object.keys(occurences)
    .sort((a, b) => occurences[a] - occurences[b])
    .forEach(key => result.push(`${key} = ${occurences[key]}`))

    console.log(result);
}

solve('cat', 42, function () { console.log('Hello world!'); });