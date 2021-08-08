import { jsonRequest } from "../helpers/jsonRequest.js";

let baseUrl = `http://localhost:3030/users`;

function getAuthToken() {
    return localStorage.getItem(`authToken`);
}
function getUsername() {
    return localStorage.getItem(`username`)
}
function getEmail() {
    return localStorage.getItem(`user`)
}
function getUserId() {
    return localStorage.getItem(`userId`)
}
function isLoggedIn() {
    return localStorage.getItem(`user`) !== null;
}

async function login(user) {
    let result = await jsonRequest(`${baseUrl}/login`, `Post`, user);
    setUser(result);
}

async function register(user) {
    let result = await jsonRequest(`${baseUrl}/register`, `Post`, user);
    setUser(result)
}

function setUser(user){
    localStorage.setItem(`user`, JSON.stringify(user));
}

async function logout() {
    await jsonRequest(`${baseUrl}/logout`, `Get`, undefined, true, true);
    localStorage.clear();
}
function getUser() {
    let user = localStorage.getItem('user') === null
        ? undefined
        : JSON.parse(localStorage.getItem('user'));

    return user;
}

export default {
    getAuthToken,
    getUsername,
    getUserId,
    isLoggedIn,
    login,
    register,
    logout,
    getEmail,
    setUser,
    getUser
}