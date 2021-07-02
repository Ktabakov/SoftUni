function solve(input){
    let catalogue = {};
    
    for (let i = 0; i < input.length; i++) {
        let [name, price] = input[i].split(` : `);
        price = Number(price);
        let initial = name[0].toUpperCase();

        if (catalogue[initial] === undefined){
            catalogue[initial] = {};
        }
        catalogue[initial][name] = price;
        
    }
    
    let result = [];
    let initialsSorted = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));
    for (const key of initialsSorted) {
        let products = Object.entries(catalogue[key]).sort((a, b) => a[0].localeCompare(b[0]));
        result.push(key);
        let productsAsString = products.map(x => `  ${x[0]}: ${x[1]}`).join(`\n`);

        result.push(productsAsString);
    }
    return result.join(`\n`);
}

console.log(solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
));