class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = +budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(argArr) {
        let currentHistory = [];
        for (const items of argArr) {
            let [productName, productQuantity, price] = items.split(` `);
            price = Number(price);
            productQuantity = Number(productQuantity);

            if (price <= this.budgetMoney) {
                if (!this.stockProducts.hasOwnProperty(`${productName}`)) {
                    this.stockProducts[`${productName}`] = { productName: productName, productQuantity: productQuantity, totalPrice: price };
                    this.budgetMoney -= price;
                } else {
                    this.stockProducts[`${productName}`].productQuantity += productQuantity;
                    this.budgetMoney -= price;
                }
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
                currentHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
            }else{
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
                currentHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }
        return this.history.join(`\n`);
    }
    addToMenu(meal, neededProducts, price){

        let allProducts = {}
        for (const currProduct of neededProducts) {
            let [productName, productQuantity] = currProduct.split(` `);
            productQuantity = Number(productQuantity);
            if (!allProducts.hasOwnProperty(`${productName}`)){
                allProducts[`${productName}`] = productQuantity;
            }else{
                allProducts[`${productName}`] += productQuantity;
            }
        }
        if (!this.menu.hasOwnProperty(`${meal}`)){
            this.menu[`${meal}`] = { products: allProducts, price: +price};
        }else{
            return `The ${meal} is already in the our menu, try something different.`;
        }

        let menuMeals = Object.keys(this.menu).length;
        if(menuMeals == 1){
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }else if (menuMeals >= 2){
            return `Great idea! Now with the ${meal} we have ${menuMeals} meals in the menu, other ideas?`;
        }
    }
    showTheMenu(){
        let result = [];
        let mealsCount = Object.keys(this.menu).length;
        if (mealsCount == 0){
            return "Our menu is not ready yet, please come later...";
        }else{
            for (const [key, value] of Object.entries(this.menu)){
                result.push(`${key} - $ ${value.price}`)
            }
        }
        return result.join(`\n`);
    }

    makeTheOrder(meal){
        if (!this.menu.hasOwnProperty(`${meal}`)){
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        let haveAllProducts = true;

        for (const [key, value] of Object.entries(this.menu[`${meal}`].products)) {
            if (value <= 0){
                haveAllProducts = false;
            }
        }
        if (haveAllProducts){
            for (const [key, value] of Object.entries(this.menu[`${meal}`].products)) {
                let productQuantity = this.menu[`${meal}`].products[`${key}`];
                productQuantity -= productQuantity;
            }
            let mealPrice = Number(`${this.menu[`${meal}`].price}`);
            this.budgetMoney += mealPrice;
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${mealPrice}.`;
        }else{
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }
    }

}

let kitchen = new Restaurant(1000);
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.makeTheOrder('Pizza'));


