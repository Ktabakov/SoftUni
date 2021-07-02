function solve(obj) {

    validateMethod(obj);
    validateURI(obj);
    validateVersion(obj);
    validateMessage(obj);

    function validateMethod(obj){
        let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
        let propName = 'method';
        if (obj[propName] === undefined || !validMethods.includes(obj[propName])){
            throw new Error('Invalid request header: Invalid Method');
        }
    }
    function validateURI(obj){
        let propName = 'uri';
        let uriRex = /^\*$|^[a-zA-Z0-9.]+$/;
        if (obj[propName] === undefined || !uriRex.test(obj[propName])){
            throw new Error('Invalid request header: Invalid URI');
        }
    }   
    function validateVersion(obj){
        let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
        let propName = 'version';
        if (obj[propName] === undefined || !validVersions.includes(obj[propName])){
            throw new Error('Invalid request header: Invalid Version');
        }
    }   
    function validateMessage(obj){
        let propName = 'message';
        let messageRex = /^[^<>\\&`"]*$/;
        if (obj[propName] === undefined || !messageRex.test(obj[propName])){
            throw new Error('Invalid request header: Invalid Message');
        }
    }

    return obj
}

try {
    console.log(solve({
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: ''
    }));
} catch (error) {
    console.log(error.message);
}

try {
    console.log(solve({
        method: 'OPTIONS',
        uri: 'git.master',
        version: 'HTTP/1.1',
        message: '-recursive'
      }));
} catch (error) {
    console.log(error.message);
}