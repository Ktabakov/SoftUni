function solve(num){
    let isSame = true;
    let sum = 0;

    let stringNum = String(num)
    for (let index = 0; index < stringNum.length; index++) {
        if (stringNum[index] !== stringNum[index + 1] && index !== stringNum.length - 1){
            isSame = false;
        }
        sum += Number(stringNum[index]);
    }
    console.log(isSame);
    console.log(sum);
}

solve(2222222);