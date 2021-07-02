function solve(n1, n2){
    let num1 = Number(n1);
    let num2 = Number(n2);
    let result = 0;

    for (let index = num1; index <= num2; index++) {
        result += index;      
    }

    console.log(result);
}

solve('1', '5' );