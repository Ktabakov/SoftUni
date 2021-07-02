const { assert, expect } = require("chai");
let dealership = require(`../dealership`);

describe("Tests …", function() {
    describe("newCarCostTests", function() {  
        it(`Return New Car, Correct Number`, function() {
           let actualResult = dealership.newCarCost(`Mercedess A4 B8`, 20000)
           assert.equal(actualResult, 20000);
        });
        it(`Return OLD Car, Correct Number`, function() {
            assert.equal(dealership.newCarCost('Audi A4 B8', 20000), 5000);
            assert.equal(dealership.newCarCost('Audi A6 4K', 20000), 0);
            assert.equal(dealership.newCarCost('Audi A8 D5', 30000), 5000);
            assert.equal(dealership.newCarCost('Audi A4 B8', 20000), 5000);
            assert.equal(dealership.newCarCost('Audi TT 8J', 15000), 1000);
         });
         it(`Return OLD Car, Negative Number`, function() {
            let actualResult = dealership.newCarCost('Audi A4 B8', -20000)
            assert.equal(actualResult, -35000);
         });
         it(`Should Throw When NAN`, () => {
            assert.equal(dealership.newCarCost('Audi A4 B8', []), -15000)
            assert.deepEqual(dealership.newCarCost('Audi A4 B8', ``), -15000)
         })
     });

     describe(`carEquipmentTest`, () => {
         it(`Should Accept Two Arrays`, () => {
             expect(() => dealership.carEquipment({}, {})).to.throw();
         })
         it(`Should Select correct Items`, () => {
             let actualResult = dealership.carEquipment([`turbo`, `stops`, `lights`], [0, 2]);
             assert.deepEqual(actualResult, [`turbo`, `lights`]);
         })
    
     })
     describe(`euroCategorytTests`, () => {
         it (`Should Return Correct Discount`, () => {
             let actualResult = dealership.euroCategory(5);
             assert.equal(actualResult, `We have added 5% discount to the final price: 14250.`);
         })
         it (`Should Return NO discount`, () => {
            let actualResult = dealership.euroCategory(2);
            assert.equal(actualResult, `Your euro category is low, so there is no discount from the final price!`);
        })
        it (`Should Return NO discount with Negative`, () => {
            let actualResult = dealership.euroCategory(-2);
            assert.equal(actualResult, `Your euro category is low, so there is no discount from the final price!`);
        })
        it (`Should Return NO discount with string`, () => {
            let actualResult = dealership.euroCategory('2');
            assert.equal(actualResult, `Your euro category is low, so there is no discount from the final price!`);
        })
        it (`Should Return NO discount with string`, () => {
           expect(() => dealership.euroCategory([]).to.throw);
           expect(() => dealership.euroCategory({}).to.throw);
           expect(() => dealership.euroCategory(``).to.throw);
           expect(() => dealership.euroCategory(undefined).to.throw);
           expect(() => dealership.euroCategory(NaN).to.throw);
        })
     })

     
});
