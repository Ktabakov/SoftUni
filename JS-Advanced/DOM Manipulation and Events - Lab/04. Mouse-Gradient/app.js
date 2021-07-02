function attachGradientEvents() {
    let resultElement = document.getElementById(`result`);
    let gradiantBoxElement = document.getElementById(`gradient`);

    function addGradient(e) {
        const offsetX = e.offsetX;
        const percent = Math.floor(offsetX / e.target.clientWidth * 100);

        resultElement.textContent = `${percent}%`;
    }

    gradiantBoxElement.addEventListener(`mousemove`, addGradient);

}