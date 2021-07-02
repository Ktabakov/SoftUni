// const { assert } = require("chai");
// let rgbToHexColor = require(`../06. RGB to Hex`);

// describe(`TestsToHex`, () => {

//        it (`Return Correct Output`, () => {
//         let red = 22;
//         let green = 13;
//         let blue = 55;

//         let actualOutput = rgbToHexColor(red, green, blue);

//         assert.equal(actualOutput, `#160D37`);
//        });

//        it (`Should Throw When Input Nums are Bigger than 255`, () => {


//         let actualOutput1 = rgbToHexColor(260, 24, 12);
//         let actualOutput2 = rgbToHexColor(52, -32, 15);
//         let actualOutput3 = rgbToHexColor(67, 2, 600);
        
//         let actualOutput1a = rgbToHexColor(-23, 2, 53);
//         let actualOutput2a = rgbToHexColor(67, 523, 34);
//         let actualOutput3a = rgbToHexColor(67, 2, -5);
        
//         let actualOutput1b= rgbToHexColor(3.14, 2, 53);
//         let actualOutput2b = rgbToHexColor(67, 3.14, 34);
//         let actualOutput3b = rgbToHexColor(67, 2, 3.14);

//         assert.equal(actualOutput1, undefined);
//         assert.equal(actualOutput2, undefined);
//         assert.equal(actualOutput3, undefined);
//         assert.equal(actualOutput1a, undefined);
//         assert.equal(actualOutput2a, undefined);
//         assert.equal(actualOutput3a, undefined);
//         assert.equal(actualOutput1b, undefined);
//         assert.equal(actualOutput2b, undefined);
//         assert.equal(actualOutput3b, undefined);
//        });

//        it(`Should Throw When Different Types Are Given`, () => {
//         assert.equal(rgbToHexColor(`5`, [3], {5: 4}), undefined)
//        });
//        it(`Should Throw When Empty`, () => {
//         assert.equal(rgbToHexColor(), undefined)
//        });
//        it(`Should Throw When Empty`, () => {
//         assert.equal(rgbToHexColor(0, 0, 0), "#000000")
//        });
//        it("should return #FFFFFF for (255, 255, 255)", function () {
//         assert.equal(rgbToHexColor(255, 255, 255), "#FFFFFF");
//     });
// });