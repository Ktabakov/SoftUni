import { jsonRequest } from "../helpers/jsonRequest.js";


let baseUrl = 'http://localhost:3030/data/books';

async function getAll(){
    let result = await jsonRequest(baseUrl);
    return result;
}

async function get(id){
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function create(item){
    let result = await jsonRequest(`${baseUrl}`, 'Post', item, true);
    return result;
}

async function update(item, id){
    let result = await jsonRequest(`${baseUrl}/${id}`, 'Put', item, true);
    return result;
}

async function getAllBooks(){
    let result = await jsonRequest(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
}

async function getMyBooks(userId){
    let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

async function deleteItem(id){
    let result = await jsonRequest(`${baseUrl}/${id}`, 'Delete', undefined, true);
    return result;
}

async function addLike(id){
    let result = await jsonRequest(`http://localhost:3030/data/likes`, 'Post', id, true);
    return result;
}

async function totalBookLikes(id){
    let result = await jsonRequest(`http://localhost:3030/data/likes?where=bookId%3D%22${id}%22&distinct=_ownerId&count`);
    return result;
}

export default {
    getAll,
    get,
    create,
    update,
    deleteItem,
    getAllBooks,
    getMyBooks,
    addLike,
    totalBookLikes
}