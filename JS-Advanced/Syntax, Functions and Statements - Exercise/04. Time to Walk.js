function solve(steps, stride, speedInKmH){

    let distance = steps * stride;
    let speedInMpS = speedInKmH / 3.6;

    let time = distance / speedInMpS;
    let breaks = Math.trunc(distance / 500);
    time += (breaks * 60);

    let hours = Math.trunc(time / 3600);
    let minutes = Math.trunc(time % 3600 / 60);
    let seconds = time % 60;

    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, `0`)}:${Math.round(seconds.toString().padStart(2, `0`))}`);
    
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);