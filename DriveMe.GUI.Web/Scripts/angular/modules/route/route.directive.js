angular.module("RouteApp")
    .directive('googleMap', function () {
        return {
            restrict: 'A',
            //template: '<div id="map"></div>',
            templateUrl: "/Scripts/angular/modules/route/maptemplate.html",
            link: function() {
                var mapDiv = document.getElementById('map');
                var map = new google.maps.Map(mapDiv, {
                    center: { lat: 44.540, lng: -78.546 },
                    zoom: 8
                });
            },
        };
    });
