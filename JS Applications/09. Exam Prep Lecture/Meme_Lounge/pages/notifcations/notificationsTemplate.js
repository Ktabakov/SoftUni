import { html} from "./../../node_modules/lit-html/lit-html.js";

export let notificationsTemplate = (notifications) => html`
${notifications.map(n => notificationTemplate(n))}
`;

let notificationTemplate = (notification) => html`
<div id="errorBox" class="notification">
    <span>${notification.message}</span>
</div>`;