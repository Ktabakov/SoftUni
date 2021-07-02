function addHero(){
    let heroNameElement = document.getElementById(`hero-name`);
    let heroListElement = document.getElementById(`hero-list`);

    let newHeroItemElement = document.createElement(`li`);
    newHeroItemElement.textContent = heroNameElement.value;
    heroListElement.appendChild(newHeroItemElement);

    let firstListItemElement = heroListElement.children[0];
    let newClonedItemElement = firstListItemElement.cloneNode();
    newClonedItemElement.textContent = heroNameElement.value;

    heroNameElement.value = ``;
}