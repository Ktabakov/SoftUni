export async function jsonRequest(url, method, body, isAuthorized, skipResult){
    try {
        if (method === undefined){
            method = 'Get';
        }

        let headers = {};
        if (['post', 'put', 'patch'].includes(method.toLowerCase())){
            headers['Content-Type'] = 'application/json';
        }

        if(isAuthorized){
            headers['X-Authorization'] = localStorage.getItem(`auth_token`)
        }
        let options = {
            headers,
            method
        }

        if (body !== undefined){
            options.body = JSON.stringify(body);
        }

        let responce = await fetch(url, options);
        if (!responce.ok){
            let message = await responce.text();
            throw new Error(`${responce.status}: ${responce.statusText}`);
        }
        
        let result = undefined;
        if (!skipResult){
            result = await responce.json();
        }

        return result;

    } catch (error) {
        alert(error);
    }
}