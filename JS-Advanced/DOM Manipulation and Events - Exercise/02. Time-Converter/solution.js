function attachEventsListeners() {

    let buttons = document.querySelectorAll('input[type="button"]');

    for (const butt of buttons) {
        butt.addEventListener(`click`, convert)
    }

    let seconds = 0;

    function convert(e){
        let type = e.target.parentElement.children[1].id;
        let value = Number(e.target.parentElement.children[1].value);

        if (type == `days`){
            seconds = value * 24 *60 * 60;
        }else if (type == `hours`){
            seconds = value * 60 * 60;
        }else if (type == `minutes`){
            seconds = value * 60;
        }else if (type == `seconds`){
            seconds = value;
        }

        let minutes = seconds / 60;
        let hours = minutes / 60;
        let days = hours / 24;

        document.getElementById(`days`).value = days;
        document.getElementById(`hours`).value = hours;
        document.getElementById(`minutes`).value = minutes;
        document.getElementById(`seconds`).value = seconds;
    }
}