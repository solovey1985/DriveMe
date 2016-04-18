angular.module("Services")
    .service("DirectionService", ['$http', function ($http, map) {
        var directionServiceInstance = {
			
        	startAddress: '',
            endAndress: '',
			setAddresses:function(start, end) {
			    startAddress = start;
			    endAndress = end;

			},
			getRoute: function(route) {
                alert("route");
            }

        }
        return directionServiceInstance;

    }]);
;

var DirectionService = function($http) {
	function GetRoute(route) {
	    alert("route");
	}
};