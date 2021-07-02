function solve(input){
    let obj = {};

    for (let i = 0; i < input.length; i++) {
        if (i % 2 == 0){
            let prop = input[i];
            let value = input[i + 1];

            obj[prop] = Number(value);
        }
    }
    return obj;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));