class Hex{
    constructor(value){
        this.value = Number(value);
    }

    valueOf(){
        return this.value;
    }
    toString(){
        return  `0x` + this.value.toString(16).toUpperCase();
    }
    plus(input){
        let result = this.value + Number(input.valueOf());
        return new Hex(result);
    }
    minus(input){
        let result = this.value - Number(input.valueOf());
        return new Hex(result);
    }
    parse(text){
       return parseInt(text, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(Hex.parse('AAA'));
