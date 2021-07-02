const { assert, expect } = require("chai");
let numberOperations = require(`../numberOperations`);

describe(`Tests`, () => {
    describe(`powNumberTests`, () => {
        it(`powNumberTest with Positive`, () => {
            let actualResult = numberOperations.powNumber(2);
    
            assert.equal(actualResult, 4);
        })
        it(`powNumberTest with Negative`, () => {
            let actualResult = numberOperations.powNumber(-2);
    
            assert.equal(actualResult, 4);
        })
        it(`powNumberTest with zero`, () => {
            let actualResult = numberOperations.powNumber(0);
    
            assert.equal(actualResult, 0);
        })
        it(`powNumberTest with positive String`, () => {
            let actualResult = numberOperations.powNumber(`4`);
    
            assert.equal(actualResult, 16);
        })
        it(`powNumberTest with negative String`, () => {
            let actualResult = numberOperations.powNumber(`-4`);
    
            assert.equal(actualResult, 16);
        })
        it(`powNumberTest with NAN`, () => {
            assert.equal(numberOperations.powNumber([]), 0);
            assert.deepEqual(numberOperations.powNumber({}), NaN);
            assert.equal(numberOperations.powNumber(``), NaN);
            assert.equal(numberOperations.powNumber(NaN), NaN);
        })
    }) 
    describe(`numberCheckerTests`, () => {
        it(`Should Throw when NAN`, () => {
            expect(([]) => numberOperations.numberChecker([])).to.throw();
            expect(([]) => numberOperations.numberChecker({})).to.throw();
            expect(([]) => numberOperations.numberChecker(undefined)).to.throw();
            expect(([]) => numberOperations.numberChecker(NaN)).to.throw();
        })
        it(`Chekc Number less Than 100 Positive`, () => {
            assert.equal(numberOperations.numberChecker(20), 'The number is lower than 100!');
        })
        it(`Chekc Number less Than 100 Negative`, () => {
            assert.equal(numberOperations.numberChecker(-20), 'The number is lower than 100!');
        })
        it(`Chekc Number less Than 100 Negative`, () => {
            assert.equal(numberOperations.numberChecker(`14`), 'The number is lower than 100!');
        })
        it(`Chekc Number greater Than 100 - 100`, () => {
            assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
        })
        it(`Chekc Number greater Than 100`, () => {
            assert.equal(numberOperations.numberChecker(101), 'The number is greater or equal to 100!');
        })
        it(`Chekc Number greater Than 100 with String`, () => {
            assert.equal(numberOperations.numberChecker(`101`), 'The number is greater or equal to 100!');
        })
    }) 

    describe(`sumArraysTests`,() => {
        it(`Should Return Correct Arr with equal Length`, () => {
            assert.deepEqual(numberOperations.sumArrays([1, 2, 3, 4], [5, 6, 7, 8]), [6, 8, 10, 12]);
        })
        it(`Should Return Correct Arr with second bigger Length`, () => {
            assert.deepEqual(numberOperations.sumArrays([1, 2, 3, 4], [5, 6, 7, 8, 10]), [6, 8, 10, 12, 10]);
        })
        it(`Should Return Correct Arr with first bigger Length`, () => {
            assert.deepEqual(numberOperations.sumArrays([1, 2, 3, 4, 10], [5, 6, 7, 8]), [6, 8, 10, 12, 10]);
        })
        it(`Should Return Correct Arr with String qeual`, () => {
            assert.deepEqual(numberOperations.sumArrays([`a`, `b`, `c`], [`q`, `w`, `e`]), [`aq`, `bw`, `ce`]);
        })
        it(`Should Return Correct Arr with String first biiger`, () => {
            assert.deepEqual(numberOperations.sumArrays([`a`, `b`, `c`, `d`], [`q`, `w`, `e`]), [`aq`, `bw`, `ce`, `d`]);
        })
        it(`Should Return Correct Arr with String second biiger`, () => {
            assert.deepEqual(numberOperations.sumArrays([`a`, `b`, `c`], [`q`, `w`, `e`, `d`]), [`aq`, `bw`, `ce`, `d`]);
        })
        it(`Throws When Empty`, () => {
            expect(numberOperations.sumArrays([], []), []);
        })
        it(`Throws When Empty`, () => {
            expect(numberOperations.sumArrays({}, []), undefined);
            expect(() => numberOperations.sumArrays([], {})).to.throw();
        })
    })
})