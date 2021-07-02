function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

let result = createCalculator();
let num = result.get(`2`)
console.log(num);
module.exports = createCalculator;