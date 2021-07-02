function solve(num, op1, op2, op3, op4, op5){
    let number = Number(num);

    number = applyOperation(number, op1);
    number = applyOperation(number, op2);
    number = applyOperation(number, op3);
    number = applyOperation(number, op4);
    number = applyOperation(number, op5);

    function applyOperation(num, op){
        switch (op) {
            case `chop`: {
                num /= 2;
            }              
                break;
            case `dice`: {
                num = Math.sqrt(num);
            }
                break;
            case `spice`: {
                num += 1;
            }
                break;
            case `bake`: {
                num *= 3;
            }
                break;
            case `fillet`:{
                num = num * 0.80;
            }
                break;
            default:
                break;
        }

        console.log(num);
        return num;
    }   

}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve(9, `dice`, `spice`, `chop`, `bake`, `fillet`);