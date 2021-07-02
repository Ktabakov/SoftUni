function solve(input){
    let n = input;    
    let row = ``;

    if (input === undefined){
        n = 5;
    }

    for (let index = 0; index < n; index++) {        
        row += `*` + ` ` ;
    }
    
    for (let index = 0; index < n; index++) {        
        console.log(row.trimEnd());
    } 
}

solve(4);