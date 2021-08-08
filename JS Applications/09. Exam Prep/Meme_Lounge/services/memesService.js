import { jsonRequest } from "../helpers/jsonRequest.js"

let baseUrl = 'http://localhost:3030/data/memes'

async function getAll(){
    let result = await jsonRequest(baseUrl);
    return result;
}
async function get(id){
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}
async function create(item){
    let result = await jsonRequest(`${baseUrl}`, `Post`, item, true);
    return result;
}
async function update(item, id){
    let result = await jsonRequest(`${baseUrl}/${id}`, `Put`, item, true);
    return result;
}
async function deleteItem(id){
    let result = await jsonRequest(`${baseUrl}/${id}`,`Delete`, undefined, true);
    return result;
}
async function getMyFurniture(userId){
    let result = await jsonRequest(`http://localhost:3030/data/catalog?where=_ownerId%3D%22${userId}%22`)
    return result;
}
async function getAllMemes(){
    let result = await jsonRequest(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
}


export default {
    getAll,
    get,
    deleteItem,
    create,
    update,
    getMyFurniture,
    getAllMemes
}