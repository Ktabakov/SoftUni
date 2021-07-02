// const { assert } = require("chai");
// const isSymmetric = require("../05. Check for Symmetry");

// describe(`Test isSymetric Function`, () => {

//     it(`Should Pass When Symetric Array is Added`, () => {
//         let arr = [1,2,3,2,1];

//         let expectedResult = true;
//         let actualResult = isSymmetric(arr);

//         assert.strictEqual(actualResult, expectedResult);
//     });

//     it (`Should Throw if Input is not Array!`, () => {
//         let expectedResult = false;

//         assert.equal(isSymmetric(``), expectedResult);
//         assert.equal(isSymmetric({}), expectedResult);
//         assert.equal(isSymmetric(4), expectedResult);
//         assert.equal(isSymmetric(`3`), expectedResult);
//         assert.equal(isSymmetric(true), expectedResult);
//         assert.equal(isSymmetric(0), expectedResult);
//         assert.equal(isSymmetric(undefined), expectedResult);
//         assert.equal(isSymmetric(null), expectedResult);
//     })

//     it(`Should Return False When Not Symetric`, () => {

//         let expectedResult = false;

//         assert.equal(isSymmetric([1,'1']), expectedResult);
//     });

//     it(`Should Return False When Not Symetric`, () => {

//         let expectedResult = false;

//         assert.equal(isSymmetric([1, 2]), expectedResult);
//     });

//     it(`Should Pass when Empty Array is Provided`, () => {
//         assert.equal(isSymmetric([]), true)
//     });

//     it(`Should pass when symetric string Array is Provided`, () => {
//         let input = [`pesho`, `gosho`, `ivan`];

//         assert.equal(isSymmetric([input]), true);
//     });
//     it(`Should Return False When Not Symetric string`, () => {

//         let expectedResult = false;

//         assert.equal(isSymmetric([`1`, `2`]), expectedResult);
//     });

// });