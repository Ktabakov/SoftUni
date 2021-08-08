import authService from "../services/authService.js";

export async function jsonRequest(url, method, body, isAuthorized, skipResult){
    if (method === undefined){
        method = 'Get';
    }

    let headers = {};
    if (['post', 'put', 'patch'].includes(method.toLowerCase())){
        headers['Content-Type'] = 'application/json';
    }

    if(isAuthorized){
        headers['X-Authorization'] = authService.getAuthToken();
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
        throw new Error(`${responce.status}: ${responce.statusText}\n${message}`);
    }

    let result = undefined;
    if (!skipResult){
        result = await responce.json();
    }
    return result;
}
