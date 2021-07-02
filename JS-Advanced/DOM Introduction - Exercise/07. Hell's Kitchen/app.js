function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let input = document.querySelector(`#inputs > textarea`);
      let jsonArr = JSON.parse(input.value);

      let restaurants = {};

      for (let i = 0; i < jsonArr.length; i++) {
         let [restaurantsName, workersString] = jsonArr[i].split(` - `);
         let inputWorkers = workersString.split(`, `).map(w => {
            let [name, salary] = w.split(` `);
            return {name, salary: Number(salary)};
         });

         if (!restaurants[restaurantsName]){
            restaurants[restaurantsName] = {
               workers: [],
               restaurantsName: restaurantsName,
               getAverareSalary: function() {
                  return this.workers.reduce((acc, el) => acc + el.salary, 0) / this.workers.length;
               }
            };
         }

         restaurants[restaurantsName].workers = restaurants[restaurantsName].workers.concat(inputWorkers);
      } 

      let sortedRestaurants = Object.values(restaurants)
      .sort((a, b) =>  b.getAverareSalary() - a.getAverareSalary());

      let bestRestaurant = sortedRestaurants[0];
      let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);
      let averageSalary = bestRestaurant.getAverareSalary().toFixed(2);

      let bestSalary = sortedWorkers[0].salary.toFixed(2);
      let workersString = sortedWorkers.map(x => `Name: ${x.name} With Salary: ${x.salary}`).join(` `);
      let topRestaurantString = `Name: ${bestRestaurant.restaurantsName} Average Salary: ${averageSalary} Best Salary: ${bestSalary}`;

      document.querySelector(`#bestRestaurant > p`).textContent = topRestaurantString;
      document.querySelector(`#workers > p`).textContent = workersString;
   }
}
