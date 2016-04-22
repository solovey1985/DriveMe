angular.module("Services")
    .factory("DirectionService", ['$http', function ($http) {
    	var directionsService = new google.maps.DirectionsService;
    	var directionsDisplay = new google.maps.DirectionsRenderer;

    	var setMap = function(map) {
	        directionsDisplay.setMap(map);
	    }
        var calculateAndDisplayRoute = function(start, end) {

        	directionsService.route({
                origin: start,
                destination: end,
                travelMode: google.maps.TravelMode.DRIVING
        	},
            function (response, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                } else {
                    window.alert('Directions request failed due to ' + status);
                }
            });
        }
        return {
        	calculateRoute: calculateAndDisplayRoute,
            setMap:setMap
        };
    }]);
