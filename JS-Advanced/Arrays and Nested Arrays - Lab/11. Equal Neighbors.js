function solve(matrix) {

    let count = 0;

    for (let i = 0; i < matrix.length - 1; i++) {
       for (let j = 0; j < matrix[i].length; j++) {
            if (matrix[i][j] === matrix[i + 1][j] || matrix[i][j] === matrix[i][j -1] || matrix[i][0] === matrix[i + 1][0]){
                count++;
            }
           
       }
        
    }

    for (let i = 0; i < matrix[matrix.length - 1].length; i++) {
        if (matrix[matrix.length - 1][i] === matrix[matrix.length - 1][i + 1]){
            count++;
        }
        
    }  

    return count;
}

solve([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']
]);