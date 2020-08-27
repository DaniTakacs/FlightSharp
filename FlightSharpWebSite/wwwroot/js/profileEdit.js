let firstName = document.getElementById("fn");
let lastName = document.getElementById("ln");
let email = document.getElementById("email");
let saveBtn = document.getElementById("saveBtn");

let prevFirstName;
let prevLastName;
let prevEmail;

getData();

saveBtn.addEventListener("click", save);

function getData() {
    prevFirstName = firstName.textContent.replace(/\s/g, '');
    prevLastName = lastName.textContent.replace(/\s/g, '');
    prevEmail = email.textContent.replace(/\s/g, '');
}

function save() {
    let newFN = document.getElementById("fn").textContent.replace(/\s/g, '');
    let newLN = document.getElementById("ln").textContent.replace(/\s/g, '');
    let newEmail = document.getElementById("email").textContent.replace(/\s/g, '');

    if (prevFirstName != newFN || prevLastName != newLN || prevEmail != newEmail) {
        if (validateEmail(newEmail)) {
            var jsonToPost =
            {
                "firstName": newFN,
                "lastName": newLN,
                "email": newEmail
            }

            makePostRequest("api/profile", JSON.stringify(jsonToPost));
            console.log(jsonToPost);
            console.log("changes saved");
        }
    }
    else {
        console.log("nothing to change");
    }
}

function makePostRequest(whereToSend, whatToSend) {
    fetch(whereToSend, {
        method: 'POST',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        body: whatToSend
    })
}

function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

// TODO check proper inputs, length, email with regex, no whitespace
// TODO change user's data on server side
