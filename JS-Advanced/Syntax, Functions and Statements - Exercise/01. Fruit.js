function solve(fruit, weight, price){
let weightInKg = weight/1000;
let cost = weightInKg * price;

console.log(`I need $${cost.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);