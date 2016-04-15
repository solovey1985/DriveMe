angular.module("RouteApp")
    .directive('dmGoogleMap', function() {
            return {
                restrict: 'A',
                scope: {
                    center: '=location'
                },
                
                templateUrl: function(elem, attr){
                    return "/Scripts/angular/templates/route/map-template.html";
                },
            link: function () {
                var mapDiv = document.getElementById('map');
                var map = new google.maps.Map(mapDiv, {
                    center: { lat: 54.32323, lng: 30.545456 },
                    zoom: 8
                });
                var marker = new google.maps.marker({ position: center });
                marker.setMap(map);
            }
            };
    });
