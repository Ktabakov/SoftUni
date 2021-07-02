// const { assert } = require("chai");
// const isOddOrEven = require("../02. Even Or Odd");

// describe(`IsEvenOrODdd tests`, () => {
//     it (`Should Return undefines when input is not a string`, () => {
        
//         assert.equal(isOddOrEven([]), undefined);
//         assert.equal(isOddOrEven(5), undefined);
//         assert.equal(isOddOrEven({}), undefined);
//         assert.equal(isOddOrEven(undefined), undefined);
//         assert.equal(isOddOrEven(NaN), undefined);
//     })

//     it (`Should Return even when EVEN`, () => {

//         let acutialResult = isOddOrEven(`koko`);
//         assert.equal(acutialResult, `even`);
//     })
//     it (`Should Return odd when ODD`, () => {

//         let acutialResult = isOddOrEven(`kok`);
//         assert.equal(acutialResult, `odd`);
//     })
//     it (`Should Return correct when Multiple Lines`, () => {
//         let acutialResult = isOddOrEven(`kok
//         e 
//         pichka`);
//         assert.equal(acutialResult, `odd`);
//     })
// })