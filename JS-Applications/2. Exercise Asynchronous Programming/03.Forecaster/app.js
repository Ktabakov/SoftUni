function attachEvents() {
    let buttonEl = document.getElementById(`submit`);
    buttonEl.addEventListener(`click`, getWeatherHandler)
    let locationElement = document.getElementById(`location`);

    let conditions = {
        Sunny: `☀`,
        "Partly sunny": `⛅`,
        Overcast: `☁`,
        Rain: `☂`
    };

    function getWeatherHandler() {
        let forecastDiv = document.getElementById(`forecast`);
        let currentDiv = document.getElementById(`current`);
        let upcomingDiv = document.getElementById(`upcoming`);

        Array.from(currentDiv.querySelectorAll(`div`)).forEach((el, i) => {
            i !== 0 ? el.remove() : el;
        })
        Array.from(upcomingDiv.querySelectorAll(`div`)).forEach((el, i) => {
            i !== 0 ? el.remove() : el;
        })
        fetch(`http://localhost:3030/jsonstore/forecaster/locations`)
            .then(body => body.json())
            .then(locations => {
                forecastDiv.style.display = `block`;
                let locationValue = locationElement.value;
                let location = locations.find(x => x.name === locationValue)
                
                return fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
                .then(body => body.json())
                .then(currentWeatherReport => ({code: location.code, currentWeatherReport}))
            })
            .then(({code, currentWeatherReport}) => {
                
                let newDivForcasts = document.createElement(`div`);
                newDivForcasts.classList.add(`forecasts`);
                let conditionSymbolSpan = document.createElement(`span`);
                conditionSymbolSpan.classList.add(`condition`, `symbol`)
                conditionSymbolSpan.textContent = conditions[currentWeatherReport.forecast.condition];

                let conditionSpan = document.createElement(`span`);
                conditionSpan.classList.add(`condition`);
            
                let locationSpan = document.createElement(`span`);
                locationSpan.classList.add(`forecast-data`);
                locationSpan.textContent = currentWeatherReport.name;

                let degreesSpan = document.createElement(`span`);
                degreesSpan.classList.add(`forecast-data`);
                degreesSpan.textContent = `${currentWeatherReport.forecast.low}°/${currentWeatherReport.forecast.high}°`;

                let weatherSpan = document.createElement(`span`);
                weatherSpan.classList.add(`forecast-data`);
                weatherSpan.textContent = currentWeatherReport.forecast.condition;

                conditionSpan.appendChild(locationSpan);
                conditionSpan.appendChild(degreesSpan);
                conditionSpan.appendChild(weatherSpan);

                newDivForcasts.appendChild(conditionSymbolSpan);
                newDivForcasts.appendChild(conditionSpan);

                currentDiv.appendChild(newDivForcasts);

                return fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`)
            })
            .then(body => body.json())
            .then(upcomingWeather => {
                let newDivForeCastInfo = document.createElement(`div`);
                newDivForeCastInfo.classList.add(`forecast-info`);   

                createUppcomingWeatherReport(newDivForeCastInfo, upcomingWeather, 0);
                createUppcomingWeatherReport(newDivForeCastInfo, upcomingWeather, 1);
                createUppcomingWeatherReport(newDivForeCastInfo, upcomingWeather, 2);

                
            })
            .catch(err => {
                let errorDiv = document.createElement(`div`);
                errorDiv.textContent = `Error`;
                errorDiv.classList.add(`label`);

                currentDiv.appendChild(errorDiv);
            })

            function createUppcomingWeatherReport(newDivForeCastInfo, upcomingWeather, turn){

                     
                let upcomingSpan = document.createElement(`span`);
                upcomingSpan.classList.add(`upcoming`);

                let symbolSpan = document.createElement(`span`);
                symbolSpan.classList.add(`symbol`);
                symbolSpan.textContent = conditions[upcomingWeather.forecast[turn].condition];
                

                let degreeSpan = document.createElement(`span`);
                degreeSpan.classList.add(`forecast-data`)
                degreeSpan.textContent = `${upcomingWeather.forecast[turn].low}°${upcomingWeather.forecast[turn].high}°`;
                
                let conditionSpan = document.createElement(`span`);
                conditionSpan.classList.add(`forecast-data`);
                conditionSpan.textContent = upcomingWeather.forecast[turn].condition;

                upcomingSpan.appendChild(symbolSpan);
                upcomingSpan.appendChild(degreeSpan);
                upcomingSpan.appendChild(conditionSpan);

                newDivForeCastInfo.appendChild(upcomingSpan);

                upcomingDiv.appendChild(newDivForeCastInfo);

            }

            
            
    }
}

attachEvents();