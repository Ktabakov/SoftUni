function solve(arr, strartIndex, endIndex){
    if (!Array.isArray(arr)){
        return NaN;
    }
    if (strartIndex < 0){
        strartIndex = 0;
    }
    if (endIndex > arr.length){
        endIndex = arr.length;
    }

    return arr.map(x => parseInt(x)).slice(strartIndex, endIndex + 1).reduce((acc, x) => acc + x, 0)
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([],1, 2));
console.log(solve('text', 0, 2));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));