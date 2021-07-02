function solve(arr) {

    let cardsArr = [];
    for (const item of arr) {

        let cardNumber = item[0];
        let suit = item[1];

        let validCards = [2, 3, 4, 5, 6, 7, 8, 9, 10, `J`, `Q`, `K`, `A`].map(x => x.toString());
        let suits = {
            S: `\u2660 `,
            H: `\u2665 `,
            D: `\u2666 `,
            C: `\u2663`
        }

        if (!validCards.includes(cardNumber)) {
            return `Invalid Card: ` + card.toString();
        }
        if (!suits[suit]) {
            return `Invalid Card: ` + card.toString();
        }

        let card = {
            face: face,
            suit: suit,
            toString() {
                let suitToChar = {
                    'S': "\u2660",
                    'H': "\u2665",
                    'D': "\u2666",
                    'C': "\u2663"
                };
                return card.face + suitToChar[card.suit];
            }
        }
        return card;
    }
        


        console.log(card.cardNumber + card.suit).toString();
        cardsArr.push(card)
    }
    return cardsArr.join(` `);

console.log(solve(['AS', '10D', 'KH', '2C']));