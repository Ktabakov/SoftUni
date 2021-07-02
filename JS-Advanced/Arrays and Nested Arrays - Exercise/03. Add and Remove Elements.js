function solve(commands) {
    let arr = [];
    let count = 1;
    for (const cmd of commands) {
        if (cmd == 'add'){
            arr.push(count);
            count++;
        }else{
            arr.pop();
            count++;
        }
    }
    if (arr.length > 0){
        for (const num of arr) {
            console.log(num);
        }
    }else{
        console.log('Empty');
    }
}

solve(['add',
    'add',
    'add',
    'add']
);

solve(['add', 
'add', 
'remove', 
'add', 
'add']
);

solve(['remove', 
'remove', 
'remove']
);