import logo from './logo.svg';
import './App.css';
import React, {useState, useEffect} from 'react';

function App() {
  let [numberOfUsers, setNumberOfUsers] = useState();
  let [listOfUsers, setListOfUsers] = useState("");

  function getListOfUser(event) {
    event.preventDefault();
    ResponseToApi();
  }

  async function ResponseToApi() {
    try {
            // useEffect(async ()=>{
              await fetch("http://localhost:7071/api/usersList/"+numberOfUsers, {method: "GET", mode: "cors"}).then(res=> res.json()).then(res=>setListOfUsers(res));
            // }, [])
        } catch (err) {
            console.error(err)
        }
    }



  return (
    <div className="App">
      <div>
        <p>Podaj liczbę użytkowników do pobrania</p><br />
        <input id="numberOfUsers" type="text" placeholder="Podaj liczbę..." onChange={e => (setNumberOfUsers(e.target.value))}/>
        <button onClick={(e)=>(getListOfUser(e))}>Pobierz</button>
        <div>{listOfUsers}</div>
      </div>
    </div>
  );
}

export default App;
