angular.module("Services")
    .factory("mapsService", [
        function() {
            var map;
            var markers = [];

            var removeMarker = function(marker) {
                markers.splice(marker.id, 1);
            }

            var removeMarkerFromMap = function(e, r) {
                this.setMap(null);
                removeMarker(this);
                console.log(markers);

            }
            var setMarker = function(lat, lng, title, dragable) {

                var marker = new google.maps.Marker({
                    position: { lat: lat, lng: lng },

                    title: title,
                    draggable: dragable,
                    map: map
                });
                marker.addListener('dblclick', removeMarkerFromMap);
                marker.id = markers.length;
                markers.push(marker);
            }

            var addMarkerToMap = function(e) {
                setMarker(e.latLng.lat(), e.latLng.lng(), markers.length.toString(), true);
            };

            var fitBounds = function() {
                _m.panToBounds();
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
                setMarker: setMarker,
                removemarker: removeMarker,
                fitToBounds: fitBounds,
                getStart: getStart,
                getEnd:getEnd
            }
        }
    ]);
