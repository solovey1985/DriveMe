angular.module("RouteApp")
    .directive("dmGoogleMap", function() {
        return {
            restrict: "A",
            replace: true,
            scope: true,
            templateUrl: function(elem, attr) {
                return "/Scripts/angular/templates/route/map-template.html";
            },
            link: function(scope) {
                var mapDiv = document.getElementById("map");
                //Теперь карта доступна для всех скриптов на странице
                window.gMap = new google.maps.Map(mapDiv, {
                    center: { lat: 50.32323, lng: 30.545456 },
                    zoom: 8
                });
                scope.setMap(gMap);
            }
        };
    });
