function solution(){
    let stock = {
        "protein": 0,
        "carbohydrate": 0,
        "fat": 0,
        "flavour": 0
    };

    let recipes = {
        apple: new Map(),
        lemonade : new Map(),
        burger : new Map(),
        eggs: new Map(),
        turkey: new Map() 
    };

    recipes.apple.set("carbohydrate", 1);
    recipes.apple.set("flavour", 2);
    recipes.lemonade.set("carbohydrate", 10);
    recipes.lemonade.set("flavour", 20);
    recipes.burger.set("carbohydrate", 5);
    recipes.burger.set("fat", 7);
    recipes.burger.set("flavour", 3);
    recipes.eggs.set("protein", 5);
    recipes.eggs.set("fat", 1);
    recipes.eggs.set("flavour", 1);
    recipes.turkey.set("protein", 10);
    recipes.turkey.set("carbohydrate", 10);
    recipes.turkey.set("fat", 10);
    recipes.turkey.set("flavour", 10);

    let cook = {
        "restock": (...args) => {
            let element = args.shift();
            let qnt = args.shift();
            stock[element] += qnt;
            return "Success";
        },
        "prepare": (...args) => {
            let recipe = args.shift();
            recipe = recipes[recipe];
            let qnt = args.shift();
            for (const [key, value] of recipe) {
                if (stock[key] < value * qnt){
                    return `Error: not enough ${key} in stock`
                }
            }   
            for (const [key, value] of recipe) {
                stock[key] -= value * qnt;
            }
            return `Success`;
        },
        "report": () => {
            let output = [];
            Object.entries(stock).forEach(el => {
                output.push(`${el[0]}=${el[1]}`)
            });

            return output.join(` `);
        }
    }

    function processor(args){
        let com = args.split(` `);
        return eval(`cook.${com.shift()}("${com[0]}", ${com[1]})`);
    }
    return processor;
}


let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
