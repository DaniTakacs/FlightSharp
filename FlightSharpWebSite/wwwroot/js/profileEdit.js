let accountName = document.getElementById("accN");
let firstName = document.getElementById("fn");
let lastName = document.getElementById("ln");
let email = document.getElementById("email");
let saveBtn = document.getElementById("saveBtn");
// let country = document.getElementById("country");
let city = document.getElementById("city");
let street = document.getElementById("str");
let streetNum = document.getElementById("strNum");

try {
    var emailFromSite = document.getElementById("manage").innerText;
    emailFromSite = emailFromSite.substr(6);
    console.log(emailFromSite);
} catch (e) {
    console.log("No user logged in");
}

let prevAccName;
let prevFirstName;
let prevLastName;
let prevEmail;
let prevCountry;
let prevCity;
let prevStreet;
let prevStreetNumber;

getData();

saveBtn.addEventListener("click", save);

function getData() {
    prevAccName = accountName.textContent.replace(/\s/g, '');
    prevFirstName = firstName.textContent.replace(/\s/g, '');
    prevLastName = lastName.textContent.replace(/\s/g, ''); 
    prevEmail = email.textContent.replace(/\s/g, '');
    // prevCountry = country.textContent.replace(/\s/g, '');
    prevCity = city.textContent.replace(/\s/g, '');
    prevStreet = street.textContent.replace(/\s/g, '');
    prevStreetNum = streetNum.textContent.replace(/\s/g, '');
}

function save() {
    let newFN = document.getElementById("fn").textContent.replace(/\s/g, '');
    let newLN = document.getElementById("ln").textContent.replace(/\s/g, '');
    let newEmail = document.getElementById("email").textContent.replace(/\s/g, '');
    let newAccName = document.getElementById("accN").textContent.replace(/\s/g, '');
    // let newCountry = document.getElementById("country").textContent.replace(/\s/g, '');
    let newCity = document.getElementById("city").textContent.replace(/\s/g, '');
    let newStreet = document.getElementById("str").textContent.replace(/\s/g, '');
    let newStreetNum = document.getElementById("strNum").textContent.replace(/\s/g, '');

    if (prevFirstName != newFN || prevLastName != newLN || prevEmail != newEmail ||
        prevCity != newCity || prevStreet != newStreet || prevStreetNumber != newStreetNum ||
        prevAccName != newAccName) {
        var jsonToPost =
        {
            "accName": newAccName,
            "city": newCity,
            "street": newStreet,
            "streetN": newStreetNum,
            "firstName": newFN,
            "lastName": newLN,
            "email": newEmail
        }

        makePostRequest("api/profile", JSON.stringify(jsonToPost));

        prevFirstName = newFN;
        prevLastName = newLN;
        prevEmail = newEmail;
        prevCity = newCity;
        prevAccName = newAccName;
        prevStreet = newStreet;
        prevStreetNumber = newStreetNum;

        console.log(jsonToPost);
        console.log("changes saved");
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

// TODO check proper inputs, length, email with regex, no whitespace
// TODO change user's data on server side
