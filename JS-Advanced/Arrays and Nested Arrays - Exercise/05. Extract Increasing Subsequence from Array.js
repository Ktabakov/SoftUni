function solve(arr) {
    let newArr = arr.reduce((acc, el) => {
        if (acc.length === 0 | el >= acc[acc.length - 1]){
            acc.push(el);
        }
        return acc;
    }, [])
    return newArr;
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);

solve([1,
    2,
    3,
    4]
);

solve([20,
    3,
    2,
    15,
    6,
    1]
);