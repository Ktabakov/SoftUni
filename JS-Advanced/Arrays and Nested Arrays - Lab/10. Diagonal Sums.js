function solve(matrix) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    for (let i = 0; i < matrix.length; i++) {

        leftDiagonalSum += matrix[i][i];
        rightDiagonalSum += matrix[i][matrix.length - i - 1];
    }

    console.log(leftDiagonalSum + " " + rightDiagonalSum);
}

solve(
    [[20, 40],
    [10, 60]
]);

solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]);