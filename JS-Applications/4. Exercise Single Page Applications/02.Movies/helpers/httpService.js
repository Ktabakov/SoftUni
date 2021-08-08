import auth from "./auth.js";

export async function jsonRequest(url, method, body, isAuthorised, skipResult) {
    try {
        if (method == undefined) {
            method = `GET`;
        }
        let headers = {};
        if (['post', 'put', 'patch'].includes(method.toLowerCase())) {
            headers['Content-Type'] = 'application/json';
        }

        let options = {
            headers,
            method
        }

        if (isAuthorised) {
            headers[`X-Authorization:`] = auth.getAuthToken();
        }

        if (body !== undefined) {
            options.body = JSON.stringify(body);
        }


        let responce = await fetch(url, options);
        if (!responce.ok) {
            let message = await responce.text();
            throw new Error(`${responce.status}: ${responce.statusText}\n${message}`)
        }
        let result = undefined;
        if (!skipResult) {
            result = await responce.json();
        }
        return result;
    } catch (error) {
        alert(error)
    }
}