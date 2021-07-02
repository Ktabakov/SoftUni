function solve(input){
    newItems = input.filter((a, i) => i % 2 != 0).map(n => n * 2).reverse();

    console.log(newItems.join(` `));
}

solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);