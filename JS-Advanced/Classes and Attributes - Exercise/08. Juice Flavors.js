function solve(input) {
    let juiceAmount = new Map();
    let juiceBottles = new Map();

    for (const line of input) {
        let [juiceName, juiceQuantity] = line.split(` => `);
        juiceQuantity = Number(juiceQuantity);

        if (!juiceAmount.has(juiceName)) {
            juiceAmount.set(juiceName, 0);
        }

        let totalAmount = juiceAmount.get(juiceName) + juiceQuantity;
        if (totalAmount >= 1000) {
            if (!juiceBottles.has(juiceName)) {
                juiceBottles.set(juiceName, 0);
            }

            let newBottles = Math.trunc(totalAmount / 1000)
            let totalBottles = juiceBottles.get(juiceName) + newBottles
            juiceBottles.set(juiceName, totalBottles);
        }

        juiceAmount.set(juiceName, totalAmount % 1000);
    }

    return [...juiceBottles].map(([key, value]) => `${key} => ${value}`).join(`\n`);
}

console.log(solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
));

console.log(solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'])
);