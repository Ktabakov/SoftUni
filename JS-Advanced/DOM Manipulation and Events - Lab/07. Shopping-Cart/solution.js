function solve() {
   let textArea = document.querySelector(`body > div > textarea`);
   let allAddButtons = document.querySelectorAll(`.add-product`);
   let sum = 0;
   let allItemsSet = new Set();
   function addProducts(e){
      let currentProductElement = e.currentTarget.parentElement.parentElement;
      let itemPrice = Number(currentProductElement.querySelector(`.product-line-price`).textContent).toFixed(2);
      let itemName = currentProductElement.querySelector(`.product-title`).textContent;
      textArea.textContent += `Added ${itemName} for ${itemPrice} to the cart.\n`;
      sum += Number(itemPrice);
      allItemsSet.add(itemName);
   }
   for (const button of allAddButtons) {
      button.addEventListener(`click`, addProducts)
   }
   let chechoutButton = document.querySelector(`.checkout`);
   function checkout(){
      textArea.textContent += `You bought ${Array.from(allItemsSet).join(`, `)} for ${sum.toFixed(2)}.`;
      for (const button of allAddButtons) {
         button.removeEventListener(`click`, addProducts);
      }
      chechoutButton.removeEventListener(`click`, checkout);
   }
   chechoutButton.addEventListener(`click`, checkout)
}