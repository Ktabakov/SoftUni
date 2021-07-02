function solve(argCmd){

    let result = [];
    for (const command of argCmd) {
        let [cmd, word] = command.split(` `);

        if (cmd == `add`){
            result.push(word);
        }else if (cmd == `remove`){
            result = result.filter(a => a != word);
        }else if (cmd == `print`){
            console.log(result.join(`,`));
        }    
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);