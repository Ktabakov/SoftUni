const { assert, expect } = require("chai");
let testNumbers = require(`../testNumbers`);

describe("Tests …", () => {
    describe("sumNumber Test", () => {
        it("Should Return Undefined When not Numbers", () => {
            assert.isUndefined(testNumbers.sumNumbers(``, []));
            assert.isUndefined(testNumbers.sumNumbers(``, {}));
            assert.isUndefined(testNumbers.sumNumbers(undefined, {}));
            assert.isUndefined(testNumbers.sumNumbers(NaN, ``));
        });
        it("Should Return Correct With Negative And Positive", () => {
            assert.equal(testNumbers.sumNumbers(-1, -1), -2);
            assert.equal(testNumbers.sumNumbers(2, -1), 1);
            assert.equal(testNumbers.sumNumbers(-2, 5), 3);
        });
        it("With Float", () => {
            assert.equal(testNumbers.sumNumbers(2.42, 0.24), 2.66);
        });
        it("With Float Neagtive", () => {
            assert.equal(testNumbers.sumNumbers(-2.42, -0.24), -2.66);
        });
    });
    describe(`Number Checker Tests`, () => {
        it(
            `Should Throw When NAN`,
            () => {
                expect(() => testNumbers.numberChecker({})).to
                    .throw('The input is not a number!')
            })

        it("Return Even And Odd", () => {
            assert.equal(testNumbers.numberChecker(2), "The number is even!");
            assert.equal(testNumbers.numberChecker(3), "The number is odd!");
        });
    })
    describe(`averageSumArray Tests`, () => {
        it(`return Correct Arr`, () => {
            assert.equal(testNumbers.averageSumArray([10, 20]), 15)
        })
    })

});
