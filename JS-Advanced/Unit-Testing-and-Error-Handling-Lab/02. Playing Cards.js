function solve(cardNumber, suit){
    let validCards = [2, 3, 4, 5, 6, 7, 8, 9, 10, `J`, `Q`, `K`, `A`].map(x => x.toString());
    let suits = {
        S : `\u2660 `,
        H : `\u2665 `,
        D : `\u2666 `,
        C : `\u2663` 
    }  

    if (!validCards.includes(cardNumber)){
        throw new Error(`Error`);
    }
    if(!suits[suit]){
        throw new Error(`Error`);
    }

    return (cardNumber + suits[suit]).toString();
}

console.log(solve(`A`, `S`));
console.log(solve('10', 'H'));
console.log(solve('1', 'C'));