function solve(input){
    input.sort((a, b) => a - b).splice(0, input.length / 2);

    return input;
}

solve([4, 7, 2, 5, 6]);
solve([3, 19, 14, 7, 2, 19, 6]);