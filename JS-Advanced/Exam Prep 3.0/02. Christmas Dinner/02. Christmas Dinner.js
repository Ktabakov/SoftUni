class ChristmasDinner {
    constructor(budget) {
        if (budget < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }


    shopping(productArr) {
        let [product, price] = productArr;

        if (price > this.budget) {
            throw new Error("Not enough money to buy this product");
        } else {
            this.products.push(product);
            this.budget -= price;
            return `You have successfully bought ${product}!`;
        }
    }

    recipes(recipe) {
        let productsRequired = recipe.productsList;
        let haveProducts = true;

        for (let index = 0; index < productsRequired.length; index++) {
            if (!this.products.includes(productsRequired[index])) {
                haveProducts = false;
            }

        }
        let recipeName = recipe.recipeName;
        if (haveProducts) {
            this.dishes.push({
                recipeName: recipeName,
                productsList: productsRequired
            })

            return `${recipeName} has been successfully cooked!`;
        } else {
            throw new Error(`We do not have this product`);
        }
    }
    inviteGuests(name, dish) {
        let isThere = false;
        this.dishes.forEach((obj) => {
            if(obj.recipeName === dish){
                isThere = true;
            }
        });
        if (!isThere) {
            throw new Error("We do not have this dish");
        }
        
        if (name in this.guests) {
            throw new Error("This guest has already been invited");
        } else {
            this.guests[name] = dish;
        }
        return `You have successfully invited ${name}!`;
    }
    showAttendance() {
        let output = '';
        Object.keys(this.guests).forEach(name => {
            let dish = this.guests[name];
            let products = [];
            this.dishes.forEach((curDish) => {
                if (curDish.recipeName === dish) {
                    products = curDish.productsList;
                }
            });
            output += `${name} will eat ${dish}, which consists of ${products.join(', ')}\n`;
        });
        return output.trim();
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
