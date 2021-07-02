function solve(matrix) {

    let areSame = true;
    let lastArrsum = 0;

    for (let index = 0; index < matrix.length; index++) {
        const arr = matrix[index];
        let arrSum = arr.reduce((acc, el) => acc + el);
        
        if (index != 0){
            if (lastArrsum !== arrSum){
                areSame = false;
            }  
        }
        lastArrsum = arrSum;
    }

    return areSame;
}

solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);

solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
);

solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
);