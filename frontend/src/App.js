import logo from './logo.svg';
import './App.css';
import React, { useState, useEffect } from 'react';

function App() {
  let [numberOfUsers, setNumberOfUsers] = useState();
  let [listOfUsers, setListOfUsers] = useState({});
  let [listOfUsersFilter, setListOfUsersFilter] = useState([]);
  let [renderList, setRenderList] = useState();
  let [string, setString] = useState("");

  async function getListOfUser(event) {
    event.preventDefault();
    fetch("https://localhost:5001/usersList/" + numberOfUsers,
      { method: "GET", mode: "cors" })
      .then(res => res.json())
      .then(res => setListOfUsers(res));
    setListOfUsersFilter([])
    listOfUsers = JSON.parse(listOfUsers);
    for (let obj in listOfUsers["results"]) {
      listOfUsersFilter[obj] = {
        "name": listOfUsers["results"][obj]['name']['first'],
        "surname": listOfUsers["results"][obj]['name']['last'],
        "email": listOfUsers["results"][obj]['email']
      }
    }
    console.log(listOfUsersFilter)
    setString((string) => {
      string = ""
      for (let obj in listOfUsersFilter) {
        string += "Imię: " + JSON.stringify(listOfUsersFilter[obj].name)
          + " Nazwisko: " + JSON.stringify(listOfUsersFilter[obj].surname)
          + " E-mail: " + JSON.stringify(listOfUsersFilter[obj].email) + " | "
      }
      return string;
    })
    // console.log(listOfUsersFilter);
  }

  function showError() {
    setString("Wprowadzono złe dane wejściowe. Spróbuj ponownie.");
  }


  return (
    <div className="App">
      <div>
        <p>Podaj liczbę użytkowników do pobrania</p><br />
        <input id="numberOfUsers" type="text" placeholder="Podaj liczbę..." onChange={e => (setNumberOfUsers(e.target.value))} />
        <button onClick={(e) => (numberOfUsers !== null && numberOfUsers !== ""
          && numberOfUsers !== "undefined" ? getListOfUser(e) : showError())}>Pobierz</button>
        <div className='List-of-users'>
          {string}
        </div>
      </div>
    </div>
  );
}

export default App;