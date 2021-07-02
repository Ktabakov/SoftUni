const { assert } = require("chai");
let createCalculator = require(`../07. Add - Subtract`);

describe(`createCalculatorTests`, () => {

    let calculator;
    beforeEach(function(){
        calculator = createCalculator()
    })

    it(`Should Add Corectly Number`, () => {

        let expectedResult = 12;
        calculator.add(12);
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult)
    })

    it(`Should Add Correctly Num As String`, () => {
        let expectedResult = 5;

        calculator.add(`5`);

        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    })

    it (`Should Return NaN when String is Added`, () => {
        let expectedResult = NaN;

        calculator.add(`koko`);

        let actualResult = calculator.get();

        assert.isNaN(actualResult, expectedResult);
    })

    it(`Should Subtract Corectly Number`, () => {
        calculator.add(10);
        let expectedResult = 4;
        calculator.subtract(6);
        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult)
    })

    it(`Should Subtract Correctly Num As String`, () => {
        calculator.add(10);
        let expectedResult = 5;

        calculator.subtract(`5`);

        let actualResult = calculator.get();

        assert.equal(actualResult, expectedResult);
    })

    it (`Should Return NaN when String is Removed`, () => {
        let expectedResult = NaN;

        calculator.subtract(`koko`);

        let actualResult = calculator.get();

        assert.isNaN(actualResult, expectedResult);
    })

    it(`Should Get Integer`, () => {
        calculator.add(10);
        let expectedResult = 5;

        calculator.subtract(`5`);

        let actualResult = calculator.get();

        assert.isNumber(actualResult, expectedResult);
    })

    it(`Should Return Object`, () => {
        expectedCalculator = {
            add : (num) => {},
            subtract : (num) => {},
            get : () => {}
        };


        assert.hasAllKeys(calculator, expectedCalculator);
    })

    it (`Should Throw When Icorrect Types Are Passed To Add`, () => {
        assert.equal(calculator.add(``), undefined);
        assert.equal(calculator.add([]), undefined);
        assert.equal(calculator.add({}), undefined);
    })

    it (`Should Throw When Icorrect Types Are Passed To Subtract`, () => {
        assert.equal(calculator.subtract(``), undefined);
        assert.equal(calculator.subtract([]), undefined);
        assert.equal(calculator.subtract({}), undefined);
    })

    it (`Should Throw When Get is Given Value`, () => {
        assert.equal(calculator.get(`2`), 0);
    })

    it (`Should return negative Number`, () => {
        calculator.subtract(1)
        assert.equal(calculator.get(), -1);
    })

    it (`Should return Value of Sum`, () => {
        calculator.add(12);
        calculator.subtract(1);
        assert.equal(calculator.get(), 11);
    })

    it (`Subtrcact string and Int`, () => {
        calculator.subtract(12);
        calculator.subtract(`1`);
        assert.equal(calculator.get(), -13);
    })

    it (`Add string and Int`, () => {
        calculator.add(12);
        calculator.add(`1`);
        assert.equal(calculator.get(), 13);
    })


});

