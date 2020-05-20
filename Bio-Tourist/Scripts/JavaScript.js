function checkPassword() {
    if (document.getElementById('PASSWORD_USER').value == document.getElementById('CONFIRMING_PASSWORD').value) {
        document.getElementById('message').style.color = 'green';
        document.getElementById('message').innerHTML = 'matching';
    } else {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = 'not matching';
    }
}
function img1click() { "https://www.google.com/search?q=image&safe=active&rlz=1C1CHBF_frFR880FR880&sxsrf=ACYBGNQwaXvy0z4CVInz-_i_I24_d_BKTA:1580806995215&tbm=isch&source=iu&ictx=1&fir=rQTDgjlYUmwEsM%253A%252CJ53VtjBzZJ6nxM%252C_&vet=1&usg=AI4_-kT9ZyfNymSyRSlLnFDn-YyLEheJ2Q&sa=X&ved=2ahUKEwix5qH7xLfnAhVLzhoKHUD1DBIQ9QEwAnoECAoQBw#imgrc=rQTDgjlYUmwEsM:"; }

// Nous initialisons une liste de marqueurs
var villes = {
    "Paris": { "lat": 48.852969, "lon": 2.349903 },
    "Brest": { "lat": 48.383, "lon": -4.500 },
    "Quimper": { "lat": 48.000, "lon": -4.100 },
    "Bayonne": { "lat": 43.500, "lon": -1.467 }
};
function geoloc() { // ou tout autre nom de fonction
    var geoSuccess = function (position) { // Ceci s'exécutera si l'utilisateur accepte la géolocalisation
        startPos = position;
        userlat = startPos.coords.latitude;
        userlon = startPos.coords.longitude;
        console.log("lat: " + userlat + " - lon: " + userlon);
    };
    var geoFail = function () { // Ceci s'exécutera si l'utilisateur refuse la géolocalisation
        console.log("refus");
    };
    // La ligne ci-dessous cherche la position de l'utilisateur et déclenchera la demande d'accord
    navigator.geolocation.getCurrentPosition(geoSuccess, geoFail);
}

// On initialise la latitude et la longitude de Paris (centre de la carte)
var lat = 48.852969;
var lon = 2.349903;
var macarte = null;
// Fonction d'initialisation de la carte
function initMap() {
    // Créer l'objet "macarte" et l'insèrer dans l'élément HTML qui a l'ID "map"
    macarte = L.map('map').setView([lat, lon], 11);
    // Leaflet ne récupère pas les cartes (tiles) sur un serveur par défaut. Nous devons lui préciser où nous souhaitons les récupérer. Ici, openstreetmap.fr
    L.tileLayer('https://{s}.tile.openstreetmap.fr/osmfr/{z}/{x}/{y}.png', {
        // Il est toujours bien de laisser le lien vers la source des données
        attribution: 'données © <a href="//osm.org/copyright">OpenStreetMap</a>/ODbL - rendu <a href="//openstreetmap.fr">OSM France</a>',
        minZoom: 1,
        maxZoom: 20
    }).addTo(macarte);

    // on crée un marquer et on lui attribu un popup
    // Nous parcourons la liste des villes
    for (ville in villes) {
        var marker = L.marker([villes[ville].lat, villes[ville].lon]).addTo(macarte);
        // Nous ajoutons la popup. A noter que son contenu (ici la variable ville) peut être du HTML
        marker.bindPopup(ville);
    }      
}
window.onload = function () {
    // Fonction d'initialisation qui s'exécute lorsque le DOM est chargé
    initMap();
};

let xmlhttp = new XMLHttpRequest();

xmlhttp.onreadystatechange = () => {
    //La transaction et terminer?
    if (xmlhttp.readyState == 1) {
        //si la transaction est un succés
        if (xmlhttp.status == 200) {
            //on traite les donne recu 
            console.log(xmlhttp.responseText)
        } else {
            console.log(xmlhttp.statusText)
        }
    }

}

xmlhttp.open("GET", "https://localhost:44339/User/Inscription");

xmlhttp.send(null);

//convertir adress to matitude longitude
//function getMyLocation() {
//    fetch("https://eu1.locationiq.com/v1/search.php?key=b45059544453b6&q=17+rue+curnonsky&format=json%22)
//        .then(function (response) {
//            return response.json()
//        }).then(function (data) {
//        })
//       console.log(data);
//}
