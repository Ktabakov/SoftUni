(function solve(){
    String.prototype.ensureStart = function(str){
        if (!this.startsWith(str)){
            return `${str}${this}`
        }else{
            return this.toString();
        }
    };
    String.prototype.ensureEnd = function(str){
        if (!this.endsWith(str)){
            return `${this}${str}`;
        }else{
            return this.toString();
        }
    };
    String.prototype.isEmpty = function(){
        return this.toString() === ``;
    };
    String.prototype.truncate = function(n){
        if (this.length <= n){
            return this.toString();
        }

        if (this.includes(` `)){
            let words = this.split(` `);
            while (words.join(` `).length + 3 > n){
                words.pop();
            }
          let string = `${words.join(` `)}...`
          return string;
        }

        if (n > 3){
            let string = `${this.slice(0, n - 3)}...`;
            return string;
        }
        
        return `.`.repeat(n);
    };
    String.format = function(string, ...params){
        let regex = /{(\d+)}/g;
        let replaced = string.replace(regex, (match, group1) => {
            let index = Number(group1);
            if (index < params.length){
                return params[index];
            }
            return match;
        })
        return replaced;
    }

})();

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
  console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
  console.log(str);

