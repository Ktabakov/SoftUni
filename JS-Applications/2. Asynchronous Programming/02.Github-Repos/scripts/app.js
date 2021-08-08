function loadRepos() {
	let ulElement = document.getElementById(`repos`);

	let inputElement = document.getElementById(`username`);
	let inputElValue = inputElement.value;
	let baseURL = "https://api.github.com/users";
	
	while (ulElement.firstChild) {
		ulElement.removeChild(ulElement.firstChild);
	}

	fetch(`${baseURL}/${inputElValue}/repos`)
		.then(res => res.json())
		.then(info => info.forEach(repo => {

			let a = document.createElement(`a`);
			let newLi = document.createElement(`li`);
			a.textContent = repo.full_name;
			a.setAttribute(`href`, repo.html_url);
			newLi.appendChild(a);
			ulElement.appendChild(newLi);

		}))
		.catch(err => console.log(err))
}