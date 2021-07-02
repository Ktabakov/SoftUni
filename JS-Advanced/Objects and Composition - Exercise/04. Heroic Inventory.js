function solve(array){
    let repo = [];

    for (let i = 0; i < array.length; i++) {
        let warrior = array[i].split('/');

        let name = warrior[0].trim();
        let level = warrior[1].trim();
        let items = warrior[2].trim().split(`, `);

        let hero = createHero(name, level, items);
        repo.push(hero);

        function createHero(name, level, items){
            let hero = {};
            hero.name = name,
            hero.level = Number(level)
            if (items !== undefined){
                hero.items = items;
            }
            
            
            return hero;
        }
    }
    return JSON.stringify(repo);
}


console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));