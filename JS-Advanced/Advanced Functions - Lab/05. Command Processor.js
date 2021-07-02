function solution(){
    let result = ``;
    let print = function(){
        console.log(result);
    }

    return {
        append: (n) => {
            result += n;
        },
        removeStart: (n) => {
            result = result.substring(n);
        },
        removeEnd: (n) => {
            result = result.substring(0, result.length - n);
        },
        print
    }
}


let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
