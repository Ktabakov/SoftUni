function solve() {
    let onScreenButtonElement = document.querySelector(`#container button`)
    onScreenButtonElement.addEventListener(`click`, tempOnScreenEvent)
    let clearButton = document.querySelector(`#archive > button`);
    clearButton.addEventListener(`click`, deleteAllArchive);


    function tempOnScreenEvent(e){
        e.preventDefault();    
        let moviesOnScreenUlForLI = document.querySelector(`#movies > ul`);  
        let inputAddMovieName = document.querySelector(`#container > input[type=text]:nth-child(1)`);
        let inputAddMovieHall = document.querySelector(`#container > input[type=text]:nth-child(2)`);
        let inputAddMoviePrice = document.querySelector(`#container > input[type=text]:nth-child(3)`);
        let name = inputAddMovieName.value;
        let hall = inputAddMovieHall.value;
        let price = Number(inputAddMoviePrice.value);

        if (inputAddMovieName.value.trim() !== ``
         && inputAddMovieHall.value.trim() !== ``
         && inputAddMoviePrice.value.trim() !== ``
         && !isNaN(Number(price))){

            let newLi = document.createElement(`li`);
            let newDiv = document.createElement(`div`);
            let newSpanForName = document.createElement(`span`);
            let strongTypeOfMovie = document.createElement(`strong`);

            let divSinglePriceTicket = document.createElement(`strong`);
            let divInputPrice = document.createElement(`input`);
            let divButtonToArchive = document.createElement(`button`);


            newSpanForName.textContent = name;
            strongTypeOfMovie.textContent = `Hall: ${hall}`;
            divSinglePriceTicket.textContent = `${price.toFixed(2)}`
            divInputPrice.placeholder = "Tickets Sold";
            divButtonToArchive.textContent = `Archive`;
            divButtonToArchive.addEventListener(`click`, archiveMovie)

            newDiv.appendChild(divSinglePriceTicket);
            newDiv.appendChild(divInputPrice);
            newDiv.appendChild(divButtonToArchive);

            newLi.appendChild(newSpanForName);
            newLi.appendChild(strongTypeOfMovie);
            newLi.appendChild(newDiv)

            moviesOnScreenUlForLI.appendChild(newLi); 
            
            
            inputAddMovieName.value = ``;
            inputAddMovieHall.value = ``;
            inputAddMoviePrice.value = ``;
        }
    }

    function archiveMovie(e){
        e.preventDefault(); 
        let movieLi = e.target.parentElement.parentElement;
        let inputTicketsSold = movieLi.querySelector(`input`).value.trim();
        let pricePerTicket = movieLi.querySelector(`div > strong`).textContent;
        let theDiv = movieLi.querySelector(`div`);
        let theStrong = movieLi.querySelector(`strong`);
        let deleteButton = document.createElement(`button`);
        let achives = document.querySelector(`#archive > ul`);

        if (!isNaN(Number(inputTicketsSold))){
            let totalProfit = Number(inputTicketsSold) * Number(pricePerTicket);
            theDiv.remove();
            theStrong.textContent = `Total amount: ${totalProfit.toFixed(2)}`;
            deleteButton.textContent = `Delete`;
            deleteButton.addEventListener(`click`, deleteArchive)
            movieLi.appendChild(deleteButton);
            achives.appendChild(movieLi);
            
        }
        
    }

    function deleteArchive(e){
        e.preventDefault(); 
        e.target.parentElement.remove();
    }
    
    function deleteAllArchive(e){
        e.preventDefault(); 
        let archivedItems = document.querySelector(`#archive > ul`);
        let allItems = archivedItems.children;
        for (const item of allItems) {
            item.remove();
        }
    }
}