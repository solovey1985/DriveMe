angular.module("RouteApp")
    .directive('dmGoogleMap', function() {
            return {
                restrict: 'A',
                replace: false,
                scope:true,
                templateUrl: function(elem, attr){
                    return "/Scripts/angular/templates/route/map-template.html";
                },
                link: function (scope) {
                    console.log(scope.route.waypoints[0].lat);
                var mapDiv = document.getElementById('map');
                var map = new google.maps.Map(mapDiv, {
                    center: { lat: 50.32323, lng: 30.545456 },
                    zoom: 8
                });
                var marker = new google.maps.Marker({
                    position: scope.route.waypoints[0],
                    map: map
                });
                
            }
            };
    });
