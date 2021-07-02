class Stringer{
    constructor(string, length){
        this.innerString = string;
        this.innerLength = length;
        this.vanila = string;
    }
    
    increase(value){
        if (this.innerLength + length < 0){
            this.innerLength = 0;
        }
        this.innerString
    }
    decrease(value){
        if (this.innerLength + value < 0){
            this.innerLength = 0;
        }
        let oldLength = this.innerString.length;
        this.innerString = this.innerString.slice(0, this.innerString.length - value + 1);
        if (this.innerString.length <= 0){
            return this.innerString + `...`;
        }else{
            this.innerString += `...`;
        }
        this.innerLength = oldLength;
    }
    toString(){
        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
