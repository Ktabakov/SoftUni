function solve(input){
      
    const result = {};
    for (const key in input) {

        let data = input[key].split(' <-> ');

        if (result[data[0]]){
            result[data[0]] += Number(data[1]);
        }else{
            result[data[0]] = Number(data[1]);
        }
    }

    for (const key in result) {
            console.log(`${key} : ${result[key]}`)
            
    }
}

// solve(['Sofia <-> 1200000',
// 'Montana <-> 20000',
// 'New York <-> 10000000',
// 'Washington <-> 2345000',
// 'Las Vegas <-> 1000000']
// );

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);