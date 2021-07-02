function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchElement = document.getElementById(`searchField`);
      let seatchText = searchElement.value;
      let rowElements = Array.from(document.querySelectorAll(`tbody tr`));

      rowElements.forEach(x => x.className = ``);
      let filteredRows = rowElements.forEach(x => {
         let cells = Array.from(x.children);
         
         if (cells.some(x => x.textContent.includes(seatchText))){
            x.className = `select`;
         }

      })
   }
}