const { assert, expect } = require("chai");
let pizzUni = require(`../pizza`);

describe(`Tests`, () => {
    describe(`makeAnOrder Test`, () => {
        it(`Should Throw When no Prop - orderedPizza exists`, () => {
            let obj = {
                name : `koko`
            };

            expect(() => pizzUni.makeAnOrder(obj)).to.throw();
        })  
        it(`Should Throw When nothing is used`, () => {

            expect(() => pizzUni.makeAnOrder()).to.throw();
        }) 
        it(`Should Return when Order Pizza`, () => {
            let obj = {
                orderedPizza : `Margharitta`
            };

            let result = pizzUni.makeAnOrder(obj);
            assert.equal(result, `You just ordered Margharitta`);
        }) 
        it(`Should Return when Order Only Drink`, () => {
            let obj = {
                orderedDrink : `Coke`
            };
            expect(() => pizzUni.makeAnOrder(obj)).to.throw();
        })  
        it(`Should Return when Order Drink`, () => {
            let obj = {
                orderedPizza : `Margharitta`,
                orderedDrink : `Coke`
            };

            let result = pizzUni.makeAnOrder(obj);
            assert.equal(result, `You just ordered Margharitta and Coke.`);
        }) 
    })

    describe(`getRemainingWork Tests`, () => {
        it(`Should Return Correct when ONE Preparing`, () => {
            let arr =  [{pizzaName: `Margharitta`, status: `ready`}, {pizzaName: `Salami`, status: `preparing`}];

            assert.equal(pizzUni.getRemainingWork(arr), `The following pizzas are still preparing: Salami.`)
        })
        it(`Should Return Correct when TWO Preparing`, () => {
            let arr =  [{pizzaName: `Margharitta`, status: `preparing`}, {pizzaName: `Salami`, status: `preparing`}];

            assert.equal(pizzUni.getRemainingWork(arr), `The following pizzas are still preparing: Margharitta, Salami.`)
        })
        it(`Should Return Correct when ALL READY`, () => {
            let arr =  [{pizzaName: `Margharitta`, status: `ready`}, {pizzaName: `Salami`, status: `ready`}];

            assert.equal(pizzUni.getRemainingWork(arr), 'All orders are complete!');
        })
        it(`Should Throw When nothing Is Given`, () => {
            let arr = [];

            expect(() => pizzUni.getRemainingWork()).to.throw();
            expect((arr) => pizzUni.getRemainingWork(arr)).to.throw();
        })
    })

    describe(`orderType Tests`, () => {
        let totalSum = 20;
        let carryOutOrder = 'Carry Out';
        let deliveryOrder = 'Delivery';

        it(`Price Should Be Right When Carry Out`, () => {
            assert.equal(pizzUni.orderType(totalSum, carryOutOrder), 18);
        })
        it(`Price Should Be Right When Delivery`, () => {
            assert.equal(pizzUni.orderType(totalSum, deliveryOrder), 20);
        })
        it(`Should Try When negative`, () => {
            assert.equal(pizzUni.orderType(-24, deliveryOrder), -24);
        })
    })
})