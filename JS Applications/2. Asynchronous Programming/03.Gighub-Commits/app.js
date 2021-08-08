function loadCommits() {
    let theUL = document.getElementById(`commits`);

    let usernameEl = document.getElementById(`username`);
    let repoEl = document.getElementById(`repo`);
    let baseUrl = `https://api.github.com/repos`;
    fetch(`${baseUrl}/${usernameEl.value}/${repoEl.value}/commits`)
        .then(repo => repo.json())
        .then(info => info.forEach(item => {

            let newLi = document.createElement(`li`);
            newLi.textContent = `${item.commit.author.name}: ${item.commit.message}`;
            theUL.appendChild(newLi);
        }))
        .catch(err => {
            let newLi = document.createElement(`li`);
            newLi.textContent = `Error: ${err.status} (Not Found)`;
            theUL.appendChild(newLi);
        })
}