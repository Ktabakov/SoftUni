function lockedProfile() {
    (async () => {
        let request = await fetch(`http://localhost:3030/jsonstore/advanced/profiles`);
        let profiles = await request.json();
        let mainID = document.getElementById(`main`);
        
        let templateProfile = document.querySelector(`.profile`);
        templateProfile.remove();

        Object.keys(profiles).forEach((key, i) => {
            let profile = profiles[key];

            let htmlProfile = createProfile(i + 1, profile.username, profile.email, profile.age);
            mainID.appendChild(htmlProfile);
        });
    })();

    function createProfile(userIndex, name, email, age){
        // <div class="profile">
		// 		<img src="./iconProfile2.png" class="userIcon" />
		// 		<label>Lock</label>
		// 		<input type="radio" name="user1Locked" value="lock" checked>
		// 		<label>Unlock</label>
		// 		<input type="radio" name="user1Locked" value="unlock"><br>
		// 		<hr>
		// 		<label>Username</label>
		// 		<input type="text" name="user1Username" value="" disabled readonly />
		// 		<div id="user1HiddenFields">
		// 			<hr>
		// 			<label>Email:</label>
		// 			<input type="email" name="user1Email" value="" disabled readonly />
		// 			<label>Age:</label>
		// 			<input type="email" name="user1Age" value="" disabled readonly />
		// 		</div>
		// 		<button>Show more</button>
		// 	</div>

        let divProfile = document.createElement(`div`);
        divProfile.classList.add(`profile`);

        let imgEl = document.createElement(`img`);
        imgEl.src = "./iconProfile2.png";
        imgEl.classList.add(`userIcon`);

        let lockLabel = document.createElement(`label`);
        lockLabel.textContent = `lock`;
        
        let lockRadio = document.createElement(`input`);
        lockRadio.type = `radio`;
        lockRadio.name = `user${userIndex}Locked`;
        lockRadio.value = `lock`;
        lockRadio.checked = true;

        let unlockLabel = document.createElement(`label`);
        unlockLabel.textContent = `unlock`;
        
        let unlockRadio = document.createElement(`input`);
        unlockRadio.type = `radio`;
        unlockRadio.name = `user${userIndex}Locked`;
        unlockRadio.value = `unlock`;
       

        let brEl = document.createElement(`br`);
        let hrEl = document.createElement(`hr`);

        let labelUsername = document.createElement(`label`);
        labelUsername.textContent = `Username`

        let inputName = document.createElement(`input`);
        inputName.type = `text`;
        inputName.name = `user${userIndex}Username`;
        inputName.value = name;
        inputName.readOnly = true;
        inputName.disabled = true;

        let divHiddenFields = document.createElement(`div`);
        divHiddenFields.id = `user1HiddenFields`;
        let seondHr = document.createElement(`hr`);

        let labelEmail = document.createElement(`label`);
        labelEmail.textContent = `Email`;

        let inputEmail = document.createElement(`input`);
        inputEmail.type = `email`;
        inputEmail.name = `user${userIndex}Email`;
        inputEmail.value = email;
        inputEmail.readOnly = true;
        inputEmail.disabled = true;

        let labelAge = document.createElement(`label`);
        labelAge.textContent = `Email`;

        let inputAge = document.createElement(`input`);
        inputAge.type = `number`;
        inputAge.name = `user${userIndex}Age`;
        inputAge.value = age;
        inputAge.readOnly = true;
        inputAge.disabled = true;

        divHiddenFields.appendChild(seondHr);
        divHiddenFields.appendChild(labelEmail)
        divHiddenFields.appendChild(inputEmail)
        divHiddenFields.appendChild(labelAge)
        divHiddenFields.appendChild(inputAge)

        divProfile.appendChild(imgEl);
        divProfile.appendChild(lockLabel);
        divProfile.appendChild(lockRadio);
        divProfile.appendChild(unlockLabel);
        divProfile.appendChild(unlockRadio);
        divProfile.appendChild(brEl);
        divProfile.appendChild(hrEl);
        divProfile.appendChild(labelUsername);
        divProfile.appendChild(inputName);
        divProfile.appendChild(divHiddenFields);

        let button = document.createElement(`button`);
        button.textContent = `Show More`;
        button.addEventListener(`click`, displayHiddenInfo)

        divProfile.appendChild(button);
        
        return divProfile;
    }

    function displayHiddenInfo(e){
        let profile = e.target.parentElement;
        let hiddenDivEl = e.target.previousElementSibling;
        let showMoreButton = e.target;
        
        let radioButton = profile.querySelector(`input[type="radio"]:checked`);
        console.log(radioButton.value);
        if (radioButton.value !== `unlock`){
            return;
        }

        showMoreButton.textContent = showMoreButton.textContent === `Show More`
        ? `Hide it`
        : `Show More`;

        hiddenDivEl.style.display = hiddenDivEl.style.display === `block`
        ? `none`
        : `block`;
    }
}