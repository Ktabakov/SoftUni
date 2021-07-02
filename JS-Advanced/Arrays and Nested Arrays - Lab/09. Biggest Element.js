function solve(matrix){

    let maxNum = Number.MIN_SAFE_INTEGER;
    
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
         
            if(matrix[i][j] > maxNum){
                maxNum = matrix[i][j];
            }
        }
    }
    return maxNum;
}

solve([
    [20, 50, 10],
    [8, 33, 145]
]);

solve([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]
]);