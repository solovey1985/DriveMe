angular.module('MainApp').factory('routeProvider', [RouteProvider]);

function RouteProvider(){
    var getRoutes = function(){
        return [
            {
                name: 'My route',
                order: 1,
                start: {
                    address: "Address 1",
                    lat: "50.23434",
                    lng: "30.544545"
                },
                end: {
                    address: "End Address",
                    lat: "50.443433",
                    lng: "30.565656"
                }
            },
            {
                name: 'Another 3 route',
                order: 1,
                start: {
                    address: "Address 211",
                    lat: "50.23434",
                    lng: "30.544545"
                },
                end: {
                    address: "End 2323 Address",
                    lat: "50.443433",
                    lng: "30.565656"
                }
            },
            {
                name: 'Some address',
                order: 1,
                start: {
                    address: "Address 221",
                    lat: "50.23434",
                    lng: "30.544545"
                },
                end: {
                    address: "End Address 332",
                    lat: "50.443433",
                    lng: "30.565656"
                }
            },
        ];
    };
    return {
        getRoutes: getRoutes
    };
}