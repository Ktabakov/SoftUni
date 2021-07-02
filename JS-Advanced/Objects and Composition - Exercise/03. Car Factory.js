function carManufacturer(car) {

    let newCar = {};

    function createEngine(hp) {
        let engine = {};
        if (hp <= 90) {
            engine.power = 90;
            engine.volume = 1800;
        } else if (hp <= 120 && hp > 90) {
            engine.power = 120;
            engine.volume = 2400;
        } else if (hp <= 200 && hp > 120) {
            engine.power = 200;
            engine.volume = 3500;
        }
        return engine;
    }

    function paintCar(color, type) {
        let carriage = {};
        carriage.type = type;
        carriage.color = color;

        return carriage;
    }

    function putWheels(size) {
        if (size % 2 == 0) {
            size--;
        };
        let wheels = [size, size, size, size];
        return wheels;
    }

    newCar.model = car.model;
    newCar.engine = createEngine(car.power);
    newCar.carriage = paintCar(car.color, car.carriage);
    newCar.wheels = putWheels(car.wheelsize);
    return newCar;
}

// console.log(carManufacturer({ model: 'VW Golf II',
// power: 90,
// color: 'blue',
// carriage: 'hatchback',
// wheelsize: 14 }
// ));

console.log(carManufacturer({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));