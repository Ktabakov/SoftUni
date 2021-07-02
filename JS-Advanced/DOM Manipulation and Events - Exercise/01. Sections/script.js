function create(words) {
   let contentDiv = document.getElementById(`content`);
   
   for (const word of words) {
      let newDiv = document.createElement(`div`);
      let newPar = document.createElement(`p`);

      newPar.textContent = word;
      newPar.style.display = `none`;
      newDiv.appendChild(newPar);
      contentDiv.appendChild(newDiv);
      
      newDiv.addEventListener(`click`, function(e) {
         newPar.style.display = `block`;
      })

   }
}