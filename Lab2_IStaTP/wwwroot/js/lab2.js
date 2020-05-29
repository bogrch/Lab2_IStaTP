const uri = 'api/Countries';
let countries = [];

function getCountries() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCountries(data))
        .catch(error => console.error('Unable to get categories.', error));
}

function addCountry() {
    const addCountrynamingTextbox = document.getElementById('add-countryNaming');
    const addClimateTextbox = document.getElementById('add-climate');

    const country = {
        countryNaming: addCountrynamingTextbox.value.trim(),
        climate: addClimateTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(country)
    })
        .then(response => response.json())
        .then(() => {
            getCountries();
            addCountrynamingTextbox.value = '';
            addClimateTextbox.value = '';
        })
        .catch(error => console.error('Unable to add country.', error));
}

function deleteCountry(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCountries())
        .catch(error => console.error('Unable to delete country.', error));
}

function displayEditForm(id) {
    const country = countries.find(country => country.countryID === id);

    document.getElementById('edit-id').value = country.countryID;
    document.getElementById('edit-countryNaming').value = country.countryNaming;
    document.getElementById('edit-climate').value = country.climate;
    document.getElementById('editForm').style.display = 'block';
}

function updateCountry() {
    const countryID = document.getElementById('edit-id').value;
    const country = {
        countryID: parseInt(countryID, 10),
        countryNaming: document.getElementById('edit-countryNaming').value.trim(),
        climate: document.getElementById('edit-climate').value.trim()
    };

    fetch(`${uri}/${countryID}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(country)
    })
        .then(() => getCountries())
        .catch(error => console.error('Unable to update category.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayCountries(data) {
    const tBody = document.getElementById('countries');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(country => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${country.countryID})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCountry(${country.countryID})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(country.countryNaming);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeClimate = document.createTextNode(country.climate);
        td2.appendChild(textNodeClimate);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    countries = data;
}


