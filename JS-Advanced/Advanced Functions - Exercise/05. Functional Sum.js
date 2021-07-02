function add(num){
    let sum = 0;

    function inner(number){
        sum += number;
        return inner;
    }
    inner.toString = () => {
        return sum;
    }
    return inner(num)
}

let a = add(1);
console.log(a.toString());
let b = add(1)(6)(-3);
console.log(b.toString());