function init_map(){
    var myOptions = {zoom:18,center:new google.maps.LatLng(30.51206259320296,-90.46507195680846),
    mapTypeId: google.maps.MapTypeId.SATELLITE};map = new google.maps.Map(document.getElementById("gmap_canvas"), 
        myOptions);marker = new google.maps.Marker({map: map,position: new google.maps.LatLng(30.51206259320296, -90.46507195680846)});
        infowindow = new google.maps.InfoWindow({content:"<b>Mims Hall</b><br/>2400 North Oak Street<br/>70401 Hammond" });
        google.maps.event.addListener(marker, "click", function(){infowindow.open(map,marker);});infowindow.open(map,marker);}
        google.maps.event.addDomListener(window, 'load', init_map);