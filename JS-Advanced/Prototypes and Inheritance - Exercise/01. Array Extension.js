(function solve(){
    Array.prototype.last = function(){
        return this[this.length - 1];
    }
    Array.prototype.skip = function(n){
        let result = [];
        for (let index = n; index < this.length; index++) {
            result.push(this[index]);
        }
        return result;
    }
    Array.prototype.take = function(n){
        let result = [];
        for (let index = 0; index < this[n]; index++) {
            result.push(this[index]);          
        }
        return result;
    }
    Array.prototype.sum = function(){
        return this.reduce((acc, n) => acc += n);
    }
    Array.prototype.average = function(){
        return this.sum() / this.length;
    }

})();