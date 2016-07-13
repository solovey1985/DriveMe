
angular.module("Directives")
    .directive("dmGoogleMap", ['mapsService', function (mapService) {
        function getLatLng(att){
            var position = { lat: parseFloat(att.lat), lng: parseFloat(att.lng) };
            return position;
        }
        return {
            restrict: "A",
            replace: true,
            scope: true,
            templateUrl: function(elem, attr) {
                return "/Scripts/angular/templates/route/map-template.html";
            },
            link: function(scope, el, attr) {
                var mapDiv = document.getElementById("map");
                console.log(parseFloat(attr.lat));
                //Теперь карта доступна для всех скриптов на странице
                window.gMap = new google.maps.Map(mapDiv, {
                    center: getLatLng(attr),
                    zoom: 8
                });
                mapService.setMap (window.gMap);
            }
        };
    }]);
