import {  html } from "../../node_modules/lit-html/lit-html.js";

export let rowTemplate = (row) => html`<tr>
    <td>${row.firstName} ${row.lastName}</td>
    <td>${row.email}</td>
    <td>${row.course}</td>
</tr>`

export let rowsTemplate = (rows) => html`${rows.map(r => rowTemplate(r))}`;