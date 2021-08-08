function solve() {

    let infoSpan = document.querySelector(`.info`);
    let stop = {
        next: `depot`
    };

    async function depart() {
       try {
        let data = await (await fetch(`http://localhost:3030/jsonstore/bus/schedule/` + stop.next)).json();
        stop = data;
        infoSpan.textContent = `Next Stop ` + stop.name;

        document.getElementById(`depart`).disabled = true;
        document.getElementById(`arrive`).disabled = false;

       } catch (error) {
        infoSpan.textContent = `Error`;
        document.getElementById(`depart`).disabled = true;
        document.getElementById(`arrive`).disabled = true;
       }
    }

    async function arrive() {
        infoSpan.textContent = `Arriving at ` + stop.name;
        document.getElementById(`depart`).disabled = false;
        document.getElementById(`arrive`).disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();