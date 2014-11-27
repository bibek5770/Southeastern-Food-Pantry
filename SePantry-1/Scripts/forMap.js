function init_map() {
    var myOptions = {
        zoom: 17, center: new google.maps.LatLng(30.512061074500057, -90.46511525879134),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("gmap_canvas"), myOptions);
    var image = 'http://localhost:51394/Content/images/forMap.png';
    marker = new google.maps.Marker({
        map: map,
        position: new google.maps.LatLng(30.512061074500057, -90.46511525879134),
     
        icon: image        
    });
    
    var contentString = '<b>Southeastern Pantry</b>' + '<br/>Mims Hall<br/>' + '70402 Hammond';
    infowindow = new google.maps.InfoWindow({ content: '<div class="scrollFix">'+contentString+'</div>'});

    google.maps.event.addListener(marker, "click", function () { infowindow.open(map, marker); });
    infowindow.open(map, marker);
}




google.maps.event.addDomListener(window, 'load', init_map);