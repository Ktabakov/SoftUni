function encodeAndDecodeMessages() {
    let encodeButton = document.querySelector(`#main > div:nth-child(1) > button`);
    let decodeButton = document.querySelector(`#main > div:nth-child(2) > button`);
    let receiverArea = document.querySelector(`#main > div:nth-child(2) > textarea`);
    let text = document.querySelector(`#main > div:nth-child(1) > textarea`);

    encodeButton.addEventListener(`click`, encodeIt);
    decodeButton.addEventListener(`click`, decodeIt);    

    function encodeIt(){
        let theText = text.value;
        let encryptedText = ``;
        for (let i = 0; i < theText.length; i++) {
            encryptedText += String.fromCharCode(ascii(`${theText[i]}`) + 1);       
        }
        text.value = ``;
        receiverArea.value = encryptedText;
    }
    
    function decodeIt(){
        let normalText = ``;
        let theText = receiverArea.value;
        for (let i = 0; i < theText.length; i++) {
             normalText += String.fromCharCode(ascii(`${theText[i]}`) - 1);   
        }
        receiverArea.value = normalText;  
    }

    function ascii(a){
        return a.charCodeAt(0);
    }
}