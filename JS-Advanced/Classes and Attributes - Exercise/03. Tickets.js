function solve(tichetsArr, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];
    for (const singleTicket of tichetsArr) {
        let newTicket = singleTicket.split(`|`);
        tickets.push(new Ticket(...newTicket))
    }
    
    return tickets.sort((a, b) => criteria === `price`
        ? a[criteria] - b[criteria]
        : a[criteria].localeCompare(b[criteria]));
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));