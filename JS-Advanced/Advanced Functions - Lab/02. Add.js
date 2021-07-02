function solution(num){
    let number = num;
    function add5(newNum){
        return number + newNum;
    }
    return add5;
}

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));

