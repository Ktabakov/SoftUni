function solve(input){
    let newArr = [];
    for (let i = 0; i < input.length; i++) {
        if (input[i] >= 0){
            newArr.push(input[i]);
        }else{
            newArr.unshift(input[i]);
        }
    }

    for (const item of newArr) {
        console.log(item);
    }
}   

solve([3, -2, 0, -1]);