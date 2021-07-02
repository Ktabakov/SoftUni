function solve(){

   let archivedSection = new Set();
   let archiveSectionElement = document.querySelector("body > div > div > aside > section.archive-section > ol");

   let creatorElement = document.getElementById(`creator`);
   let titleElement = document.getElementById(`title`);
   let categoryElement = document.getElementById(`category`);
   let contentElement = document.getElementById(`content`);
   let createButton = document.querySelector(`section > form > button`)

   createButton.addEventListener(`click`, function(e) {
      e.preventDefault();
      createArticleBody();   
   })

   function createArticleBody(){
      let createdArticle = document.createElement(`article`);
      let createdH1 = document.createElement(`h1`);
      let categoryP = document.createElement(`p`);
      let strongCategory = document.createElement(`strong`)
      let creatorP = document.createElement(`p`);
      let strongCreator = document.createElement(`strong`);
      let contentP = document.createElement(`p`);
      let divForButtons = document.createElement(`div`);
      let deleteButton = document.createElement(`button`);
      let archiveButton = document.createElement(`button`);

      //buttons
      divForButtons.classList.add(`buttons`);
      deleteButton.classList.add("btn", "delete");
      deleteButton.textContent = "Delete";
      archiveButton.classList.add("btn", "archive");
      archiveButton.textContent = "Archive";
      divForButtons.appendChild(deleteButton);
      divForButtons.appendChild(archiveButton);
      
      //content
      contentP.textContent = contentElement.value;

      //creator
      creatorP.textContent = "Creator: ";
      strongCreator.textContent = creatorElement.value;
      creatorP.appendChild(strongCreator);

      //category
      categoryP.textContent = "Category: ";
      strongCategory.textContent = categoryElement.value;
      categoryP.appendChild(strongCategory);

      //h1
      createdH1.textContent = titleElement.value;

      //appendToArticle
      createdArticle.appendChild(createdH1);
      createdArticle.appendChild(categoryP);
      createdArticle.appendChild(creatorP);
      createdArticle.appendChild(contentP);
      createdArticle.appendChild(divForButtons);

      deleteButton.addEventListener(`click`, () => {
         deleteButton.parentElement.parentElement.remove();
      })
      archiveButton.addEventListener(`click`, archiveButtonClicked)

      let parentElementToArticle = document.querySelector(`main > section`)
      parentElementToArticle.appendChild(createdArticle);


      //clearFields
      creatorElement.value = ``;
      titleElement.value = ``;
      categoryElement.value = ``;
      contentElement.value = ``;
            
      function archiveButtonClicked(){
         {

            let titleToTake = archiveButton.parentElement.parentElement.querySelector(`h1`);
            archivedSection.add(titleToTake.textContent);
   
            let arrFrom = Array.from(archivedSection).sort((a, b) => a.localeCompare(b));
   
            while (archiveSectionElement.firstChild) {
               archiveSectionElement.removeChild(archiveSectionElement.firstChild);
            }
            
            archiveButton.parentElement.parentElement.remove();

            for (const item of arrFrom) {
               
               let createdLiTitleForArchive = document.createElement(`li`);
               createdLiTitleForArchive.textContent = item;
               archiveSectionElement.appendChild(createdLiTitleForArchive);
            }
   
         }
      }
   }
  }
