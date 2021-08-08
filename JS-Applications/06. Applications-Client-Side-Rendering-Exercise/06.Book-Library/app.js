import { render } from "../node_modules/lit-html/lit-html.js";
import booksService from "./services/booksService.js";
import { allBooksTemplate, allFromsTemplate, bookLibraryTemplate } from "./templates/booksTemplate.js";

let books = [];

let addFrom = {
    id: 'add-form',
    title: 'Add Book',
    type: 'add',
    submitText: 'Submit',
    submitHandler: createBook

}
let editForm = {
    id: 'edit-form',
    title: 'Edit Book',
    type: 'edit',
    submitText: 'Save',
    class: 'hidden'
}

let forms = [addFrom, editForm];
render(bookLibraryTemplate([], forms, loadBooks), document.body);

async function loadBooks() {
    let booksContainer = document.getElementById(`books-container`);
    let booksObj = await booksService.getAllBooks();
    books = Object.entries(booksObj).map(([key, val]) => {
        val._id = key; return val;
    })
    render(allBooksTemplate(books), booksContainer);
}

async function createBook(e){
    e.preventDefault();
    let booksContainer = document.getElementById(`books-container`);
    let form = e.target;
    let formData = new FormData(form);
    let newBook = {
        author: formData.get(`author`),
        title: formData.get(`title`)
    }
    if (formData.get(`author`) == `` || formData.get(`title`) == ``){
        return
    }
    let createdResult = await booksService.createBook(newBook);
    books.push(createdResult);
    render(allBooksTemplate(books), booksContainer);
}
