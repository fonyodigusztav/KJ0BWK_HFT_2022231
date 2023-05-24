let players = [];
let connection = null;

let playerIDToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:64355/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });

    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:64355/player')
        .then(x => x.json())
        .then(y => {
            players = y;
            console.log(players);
            display();
        });
}



function display() {
    const resultArea = document.getElementById('resultarea');
    resultArea.innerHTML = ''; // Törli az előző eredményeket
    players.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.playerID + "</td><td>"
        + t.playerName + "</td><td>" +
        `<button type="button" onclick="remove(${t.playerID})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.playerID})">Update</button>`
            +"</td></tr>";
    })
}

function remove(id) {
    fetch('http://localhost:64355/player/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('playernametoupdate').value = players.find(t => t['playerID'] == id)['playerName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    playerIDToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('playernametoupdate').value;
    fetch('http://localhost:64355/player', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { playerName: name, playerID: playerIDToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('playername').value;
    fetch('http://localhost:64355/player', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { playerName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}