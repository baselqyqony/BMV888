   
var x, y;
function setLocation(altitude, longitude) {

 x = document.getElementById("altitude");
    
 y = document.getElementById("longitude");
  

getLocation();
    }
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.value = "0.0";
        y.value = "0.0";
    }
}

function showPosition(position) {
    x.value = "" + position.coords.latitude;
    y.value = "" + position.coords.longitude;

     
}