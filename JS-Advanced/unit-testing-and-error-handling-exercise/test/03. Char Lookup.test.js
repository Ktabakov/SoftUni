// const { assert } = require("chai");
// const lookupChar = require(`../03. Char Lookup`);

// describe(`LookUpChar Test`, () => {

//     it(`If first Param is not String Should Return Undefined`, () => {
//         assert.isUndefined(lookupChar([], 3));
//         assert.isUndefined(lookupChar({}, 3));
//         assert.isUndefined(lookupChar(2, 3));
//         assert.isUndefined(lookupChar(NaN, 3));
//         assert.isUndefined(lookupChar(undefined, 3));
//     })

//     it(`If second Param is not number Should Return Undefined`, () => {
//         assert.isUndefined(lookupChar(`koko`, []));
//         assert.isUndefined(lookupChar(`koko`, {}));
//         assert.isUndefined(lookupChar(`koko`, NaN));
//         assert.isUndefined(lookupChar(`koko`, undefined));
//         assert.isUndefined(lookupChar(`koko`, ``));
//         assert.isUndefined(lookupChar(`koko`, `sdds`));
//     })

//     it(`if Index Value is Wrong Should Throw`, () => {
//         assert.equal(lookupChar(`koko`, -1), `Incorrect index`);
//         assert.equal(lookupChar(`koko`, 12), `Incorrect index`);
//     })

//     it(`Should work Correctly`, () => {
//         assert.equal(lookupChar(`koko`, 0), `k`)
//         assert.equal(lookupChar(`koko`, 2), `k`)
//         assert.equal(lookupChar(`koko`, 3), `o`)
//     })

// });