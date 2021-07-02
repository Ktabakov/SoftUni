function extensibleObject() { 
    let proto = {};
    let extObject = Object.create(proto);
    extObject.extend = function(template){
        for (const key in template) {
            if (typeof template[key] === `function`){
                let proto = Object.getPrototypeOf(this)
                proto[key] = template[key];
            }else{
                this[key] = template[key];
            }
        }   
    }
    return extObject;
    } 




const myObj = extensibleObject(); 
const template = { 
    extensionMethod: function () {}, 
    extensionProperty: 'someString' 
  } 
  myObj.extend(template); 

  console.log(myObj);
  