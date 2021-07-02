// const { assert } = require("chai");
// const mathEnforcer = require(`../04. Math Enforcer`);

// describe(`MathEnforcerTests`, () => {
//     let newMathEnforcer;
//     beforeEach(() => {
//         newMathEnforcer = mathEnforcer;
//     })
//     describe(`addFive`, () => {
//         it(`Should Return Correct Num When Added`, () => {
//             let actualResult = newMathEnforcer.addFive(5);
//             assert.closeTo(actualResult, 10, 0.01);
//         })
//         it(`Should Throw Undefined When Not Number`, () => {
//             assert.equal(newMathEnforcer.addFive(``), undefined);
//             assert.equal(newMathEnforcer.addFive(`232`), undefined);
//             assert.equal(newMathEnforcer.addFive([]), undefined);
//             assert.equal(newMathEnforcer.addFive({}), undefined);
//             assert.equal(newMathEnforcer.addFive(undefined), undefined);
//         })
//         it(`Should Return 5 Num When 0`, () => {
//             let actualResult = newMathEnforcer.addFive(0);
//             assert.equal(actualResult, 5);
//         })
//         it(`Should close to addFile float`, () => {
//             let actualResult = newMathEnforcer.addFive(2.14);
//             assert.closeTo(actualResult, 7.14, 0.01);
//         })
//         it(`Add floating point`, () => {
//             let actualResult = newMathEnforcer.addFive(3.142);
//             assert.closeTo(actualResult, 8.142, 0.01);
//         })
//     });
    
//     describe(`subtractTen`, () => {
//         it(`Should Throw Undefined When Not Number with Subtract`, () => {
//             assert.equal(newMathEnforcer.subtractTen(``), undefined);
//             assert.equal(newMathEnforcer.subtractTen(`232`), undefined);
//             assert.equal(newMathEnforcer.subtractTen([]), undefined);
//             assert.equal(newMathEnforcer.subtractTen({}), undefined);
//             assert.equal(newMathEnforcer.subtractTen(undefined), undefined);
//         })
//         it(`Should Return -10 Num When 0`, () => {
//             let actualResult = newMathEnforcer.subtractTen(0);
//             assert.closeTo(actualResult, -10, 0.01);
//         })
//         it(`Should Return Correct Num When Subtraced`, () => {
//             let actualResult = newMathEnforcer.subtractTen(10);
//             assert.equal(actualResult, 0);
//         })
//         it(`Subtract floating point`, () => {
//             let actualResult = newMathEnforcer.subtractTen(13.123);
//             assert.closeTo(actualResult, 3.123, 0.01);
//         })
//         it(`Subtract negative`, () => {
//             let actualResult = newMathEnforcer.subtractTen(-12);
//             assert.equal(actualResult, -22);
//         })
//         it(`Subtract negative float`, () => {
//             let actualResult = newMathEnforcer.subtractTen(-12.24);
//             assert.closeTo(actualResult, -22.24, 0.01);
//         })
//     });
    
//     describe(`sum`, () => {
//         it(`Should Throw Undefined When Both Not Numbers`, () => {
//             assert.equal(newMathEnforcer.sum((``), undefined), undefined);
//             assert.equal(newMathEnforcer.sum(([]), undefined), undefined);
//             assert.equal(newMathEnforcer.sum(({}), undefined), undefined);
//             assert.equal(newMathEnforcer.sum((`343`), undefined), undefined);
//             assert.equal(newMathEnforcer.sum(undefined, undefined), undefined);

//             assert.equal(newMathEnforcer.sum(undefined, ``), undefined);
//             assert.equal(newMathEnforcer.sum(undefined, ([])), undefined);
//             assert.equal(newMathEnforcer.sum(undefined, ({})), undefined);
//             assert.equal(newMathEnforcer.sum(undefined, (`343`)), undefined);
//             assert.equal(newMathEnforcer.sum(undefined, undefined), undefined);
            
//         })

//         it (`Should Return Sum with +Nums`, () => {
//             let expectedResult = newMathEnforcer.sum(1, 2)
//             assert.equal(expectedResult, 3)
//         })
//         it (`Should Return Sum with -Nums`, () => {
//             let expectedResult = newMathEnforcer.sum(-2, 2)
//             assert.closeTo(expectedResult, 0, 0.01)
//         })
//         it (`Should Return Sum with Floating Points`, () => {
//             let expectedResult = newMathEnforcer.sum(3.42, 12.43)
//             assert.equal(expectedResult, 15.85)
//         })
//         it (`Should Return Sum first Float`, () => {
//             let expectedResult = newMathEnforcer.sum(3.42, 2)
//             assert.closeTo(expectedResult, 5.42, 0.01)
//         })
//         it (`Should Return Sum second Float`, () => {
//             let expectedResult = newMathEnforcer.sum(3, 2.42)
//             assert.closeTo(expectedResult, 5.42, 0.01)
//         })
//         it (`Should Return Sum Negative Float`, () => {
//             let expectedResult = newMathEnforcer.sum(3.43, -2.42)
//             assert.closeTo(expectedResult, 1.01, 0.01)
//         })
//     });

// });