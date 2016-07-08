angular.module("Services")
    .factory("mapsService", ['addressService',
        function (addressService) {
            var map;
            var markers = [];

            var removeMarker = function(marker) {
                var index = markers.indexOf(marker);
                markers.splice(index, 1);
                marker.setMap(null);
            }

            var removeMarkerFromMap = function (e, r){
                removeMarker(this);
            }
            //SET MARKER
            var createMarker = function(lat, lng, title, dragable) {

                var marker = new google.maps.Marker({
                    position: { lat: lat, lng: lng },
                    draggable: dragable,
                    map: map
                });
                map.setCenter(marker.getPosition());
                marker.addListener('dblclick', removeMarkerFromMap);
                google.maps.event.addListener(marker, 'dragend', function (e) {
                        addressService.getAddressByLatLng(marker.getPosition())
                            .then(function(data){
                                marker.address = marker.title = data;
                            });
                    });

                addressService.getAddressByLatLng(marker.getPosition()).then(function(data){
                    marker.address = marker.title = data;
                });

                if (markers.length === 2) {
                    var shiftedMarker = markers[0];
                    removeMarker(shiftedMarker);
                }
                markers.push(marker);
            }
            //ADD MARKER TO MAP
            var addMarkerToMap = function (e){
                var title = markers.length.toString();
                createMarker(e.latLng.lat(), e.latLng.lng(), title, true);
                console.log(markers);
            };

            var fitMapBounds = function() {
                map.panToBounds();
            }

            var setMap = function(m) {
                map = m;
                map.addListener('click', addMarkerToMap);
            }

            var getStart = function () {
                return markers[0];
            }

            var getEnd = function() {
                return markers[markers.length-1];
            }

            return {
                setMap: setMap,
                createMarker: createMarker,
                removeMarker: removeMarker,
                fitToBounds: fitMapBounds,
                getStart: getStart,
                getEnd:getEnd
            }
        }
    ]);

