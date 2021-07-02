class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {

        let oldCustomer = this.allCustomers.find(x => x.personalId == customer.personalId);

        if (oldCustomer != undefined) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        } else {
            customer.transactions = [];
            customer.totalMoney = 0;
            this.allCustomers.push(customer);

            let psudoCustomer = {
                firstName: customer.firstName,
                lastName: customer.lastName,
                personalId: customer.personalId
            };
            return psudoCustomer;
        }
    }

    depositMoney(personalId, amount) {
        let oldCustomer = this.allCustomers.find(x => x.personalId == personalId);

        if (oldCustomer == undefined) {
            throw new Error(`We have no customer with this ID!`);
        } else {
            oldCustomer.totalMoney += Number(amount);
            let transactionNumber = oldCustomer.transactions.length + 1;
            oldCustomer.transactions.push({ typeOfTransaction: `deposit`, amount: Number(amount), transactionNumber: transactionNumber, firstName : oldCustomer.firstName, lastName : oldCustomer.lastName });
            return `${oldCustomer.totalMoney}$`;
        }
    }
    withdrawMoney(personalId, amount) {
        let oldCustomer = this.allCustomers.find(x => x.personalId == personalId);

        if (oldCustomer == undefined) {
            throw new Error(`We have no customer with this ID!`);
        } else {
            if (oldCustomer.totalMoney < Number(amount)) {
                throw new Error(`${oldCustomer.firstName} ${oldCustomer.lastName} does not have enough money to withdraw that amount!`);
            } else {
                oldCustomer.totalMoney -= Number(amount);
                let transactionNumber = oldCustomer.transactions.length + 1;
                oldCustomer.transactions.push({ typeOfTransaction: `withdraw`, amount: Number(amount), transactionNumber: transactionNumber, firstName : oldCustomer.firstName, lastName : oldCustomer.lastName });
                return `${oldCustomer.totalMoney}$`;
            }
        }
    }
    customerInfo(personalId) {
        let oldCustomer = this.allCustomers.find(x => x.personalId == personalId);

        if (oldCustomer == undefined) {
            throw new Error(`We have no customer with this ID!`);
        }

        let basicInfo = `Bank name: ${this._bankName}
Customer name: ${oldCustomer.firstName} ${oldCustomer.lastName}
Customer ID: ${oldCustomer.personalId}
Total Money: ${oldCustomer.totalMoney}$
Transactions:\n`

        oldCustomer.transactions.sort((a, b) => b.transactionNumber - a.transactionNumber);
        let transactionsInfo = ``;
        oldCustomer.transactions.forEach(tr => {
            let currentSentance = ``;
            if (tr.typeOfTransaction === `withdraw`){
                currentSentance = `withdrew`;
            }else{
                currentSentance = `made deposit of`;
            }
            transactionsInfo += `${tr.transactionNumber}. ${tr.firstName} ${tr.lastName} ${currentSentance} ${tr.amount}$!\n`});

            return basicInfo + transactionsInfo.trimEnd();
    }
}

let bank = new Bank(`SoftUni Bank`);

console.log(bank.newCustomer({ firstName: `Svetlin`, lastName: `Nakov`, personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: `Mihaela`, lastName: `Mileva`, personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
