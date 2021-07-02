function solve(arg, num) {

    let result = arg.filter((el, index) => index % num == 0);

    console.log(result);
}

solve(
    ['5',
        '20',
        '31',
        '4',
        '20'],
    2
);

solve(
    ['dsa',
        'asd',
        'test',
        'tset'],
    2
);

solve(['1',
    '2',
    '3',
    '4',
    '5'],
    6
);