function solve(arg){
    let sum = 0;
    let sumR = 0;
    let items = ``;

    for (let index = 0; index < arg.length; index++) {
        sum += Number(arg[index]);
        sumR += 1/(Number(arg[index]));
        items += arg[index];
    }
    

    console.log(sum);
    console.log(sumR);
    console.log(items);
}

solve([1, 2, 3]);