function getInfo() {
    let stopIDEl = document.getElementById(`stopId`);
    let baseURL = `http://localhost:3030/jsonstore/bus/businfo/`;

    let divStopName = document.getElementById('stopName');
    let ulBuses = document.getElementById(`buses`);

    fetch(`${baseURL}${stopIDEl.value}`)
        .then(busInfo => busInfo.json())
        .then(buses => {
            divStopName.textContent = buses.name;
            
            while (ulBuses.firstChild) {
                ulBuses.removeChild(ulBuses.firstChild);
            }

            Object.keys(buses.buses).forEach(busId => {
                let busIdLi = document.createElement(`li`);
                busIdLi.textContent = `Bus ${busId} arrives in ${buses.buses[busId]} minutes`;
                ulBuses.appendChild(busIdLi);
            });

            stopIDEl.value = ``;
        })
        .catch(err => {
            divStopName.textContent = `Error`;
            Array.from(ulBuses.querySelectorAll(`li`)).forEach(li => li.remove());
        })
}