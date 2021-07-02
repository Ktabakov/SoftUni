function solve() {
  let textAreaElement = document.getElementById(`input`);
  let text = textAreaElement.value;
  let sentances = text.split(`.`).filter(x => x !== ``).map(x => x + `.`);

  let outputValue = document.getElementById(`output`);

  let paragRoof = Math.ceil(sentances.length / 3);

  for (let index = 0; index < paragRoof; index++) {
   outputValue.innerHTML += `<p>${sentances.splice(0, 3).join(``)}</p>`;   
  }
}