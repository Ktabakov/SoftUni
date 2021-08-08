class List{
    constructor(){
        this.list = [];
        this.size = 0;
    }
    add(value){
        this.list.push(value);
        this.size = this.list.length;
        return this.list.sort((a, b) => a - b);
    }
    remove(index){
        if (index >= 0 && index <= this.size){
            this.list.splice(index, 1);
        this.size = this.list.length;
        return this.list;
        }
    }
    get(index){
        if (index >= 0 && index <= this.size){
            return this.list[index];
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);