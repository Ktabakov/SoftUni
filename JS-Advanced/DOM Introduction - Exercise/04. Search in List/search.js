function search() {
   let townsList = Array.from(document.querySelectorAll(`#towns li`));
   let searchBar = document.getElementById("searchText").value;
   
   let targetList = townsList.filter(x => x.textContent.includes(searchBar)).map(x => {
      x.style.fontWeight = "bold";
      x.style.textDecoration = "underline";
   });

   let resultDiv = document.getElementById("result");
   resultDiv.textContent = `${targetList.length} matches found`;
}
