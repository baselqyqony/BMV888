//map.js
//Set up some of our variables.
var map; //Will contain map object.
var marker = false; ////Has the user plotted their location marker?
var latInputName;
var longInputName;
var useInputsInitialValues;
var centerOfMap;

//Function called to initialize / create the map.
//This is called when the page has loaded.

function setInputsNames() {

};
function initMap() {

    //The center location of our map.
    if (useInputsInitialValues)
        centerOfMap = new google.maps.LatLng(document.getElementById(latInputName).value, document.getElementById(longInputName).value);
    else
        centerOfMap = new google.maps.LatLng(47.52688647869142, 19.009681349993343);

    //Map options.
    var options = {
        center: centerOfMap, //Set center.
        zoom: 15 //The zoom value.
    };

    //Create the map object.
    map = new google.maps.Map(document.getElementById('map'), options);

    //Listen for any clicks on the map.
    google.maps.event.addListener(map, 'click', function (event) {
        //Get the location that the user clicked.
        var clickedLocation = event.latLng;
        //If the marker hasn't been added.
        if (marker === false) {
            //Create the marker.
            marker = new google.maps.Marker({
                position: clickedLocation,
                map: map,
                draggable: true //make it draggable
            });
            //Listen for drag events!
            google.maps.event.addListener(marker, 'dragend', function (event) {
                markerLocation();
            });
        } else {
            //Marker has already been added, so just change its location.
            marker.setPosition(clickedLocation);
        }
        //Get the marker's location.
        markerLocation();
    });
}

function startMapPlugin(lati, longi, UseInitialinpurValues) {
    useInputsInitialValues = UseInitialinpurValues;
    latInputName = lati;
    longInputName = longi;
    google.maps.event.addDomListener(window, 'load', initMap);

}
//This function will get the marker's current location and then add the lat/long
//values to our textfields so that we can save the location.
function markerLocation() {

    //Get location.
    var currentLocation = marker.getPosition();
    //Add lat and lng values to a field that we can save.
    document.getElementById(latInputName).value = currentLocation.lat(); //latitude
    document.getElementById(longInputName).value = currentLocation.lng(); //longitude
}


//Load the map when the page has finished loading.
