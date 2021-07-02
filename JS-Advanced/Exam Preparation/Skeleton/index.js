function solve() {
    let addButtonElement = document.querySelector(`.admin-view .action button`);
    addButtonElement.addEventListener(`click`, addModule);

    let modules = {};

    function addModule(e) {
        e.preventDefault();
        let lectureNameElement = document.querySelector(`input[name="lecture-name"]`);
        let lectureDateElement = document.querySelector(`input[name="lecture-date"]`);
        let lectureModuleElement = document.querySelector(`select[name="lecture-module"]`);

        let lectureName = lectureNameElement.value;
        let lectureDate = lectureDateElement.value;
        let lectureModule = lectureModuleElement.value;

        if (!lectureName || !lectureDate || lectureModule === "Select module") {
            return;
        }

        

        let lectureDateString = formatDate(lectureDate);

        if (!modules[lectureModule]) {
            modules[lectureModule] = [];
        }
        let currentLecture = { name: lectureName, date: lectureDateString };
        modules[lectureModule].push(currentLecture);

        createTrainings(modules);


        function formatDate(dateInput) {
            let [date, time] = dateInput.split(`T`);
            date = date.replace(/-/g, '/');

            return `${date} - ${time}`;
        }

        function createTrainings(modules) {
            let modulesElement = document.querySelector(`.modules`);
            modulesElement.innerHTML = ``;
            for (const moduleName in modules) {
                let moduleElement = createModule(moduleName);
                let createUl = document.createElement(`ul`);
                let lectures = modules[moduleName];

                lectures
                .sort((a, b) => a.date.localeCompare(b.date))
                .forEach(({name, date}) => {
                    let lectureEl = createLecture(name, date, moduleName);
                    createUl.appendChild(lectureEl);

                    let deleteButtonElement = lectureEl.querySelector(`button`);
                    deleteButtonElement.addEventListener(`click`, (e) => {  
                        modules[moduleName] = modules[moduleName]
                        .filter(x => !(x.name == name && x.date == date));

                        if (modules[moduleName].length == 0){
                            delete modules[moduleName];
                            e.currentTarget.closest(`.module`).remove(); 

                        }else{
                            e.currentTarget.parentNode.remove(); 
                        }
                    });
                    
                    
                });

                moduleElement.appendChild(createUl);
                modulesElement.appendChild(moduleElement);
            }
        }

        function createLecture(name, date, moduleName) {

            let createLi = document.createElement(`li`);
            createLi.classList.add(`flex`);
            let createH4 = document.createElement(`h4`);
            createH4.textContent = `${name} - ${date}`;
            let createButton = document.createElement(`button`);
            createButton.classList.add(`red`);
            createButton.textContent = `Del`;

          
            createLi.appendChild(createH4);
            createLi.appendChild(createButton);

            return createLi;
        }

        function createModule(name) {

            let createDiv = document.createElement(`div`);
            createDiv.classList.add(`module`);
            let createH3 = document.createElement(`h3`);
            createH3.textContent = `${name.toUpperCase()}-MODULE`;
            createDiv.appendChild(createH3);

            return createDiv;
        }
    }
};