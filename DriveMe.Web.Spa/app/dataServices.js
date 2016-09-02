angular.module('Service', []);
angular.module('Service').factory('dataService',['$http','$timeout',dataService]);

function dataService($http, $timeout){
    var routes = [
        {
            id: 1001,
            title: 'Home - Work',
            start: {
                address: 'Luji, 1, Kyiv',
                lat: 50.3333,
                lng: 30.5555
            },
            end: {
                address: 'Ijul, 99, Kyiv',
                lat: 50.44444,
                lng: 30.66666
            }
        },
        {
            id: 1002,
            title: 'Work - Home ',
            end: {
                address: 'Luji, 1, Kyiv',
                lat: 50.3333,
                lng: 30.5555
            },
            start: {
                address: 'Ijul, 99, Kyiv',
                lat: 50.44444,
                lng: 30.66666
            }
        },
        {
            id: 1003,
            title: 'Home - Gym',
            start: {
                address: 'Luji, 1, Kyiv',
                lat: 50.3333,
                lng: 30.5555
            },
            end: {
                address: 'Juli, 19, Kyiv',
                lat: 50.363636,
                lng: 30.636363
            }
        },
    ];
    var settings = {
        onlyFriends: true,
        facebook: true,
        googleplus: false,
        twitter: false,
        onlyNeibours:false
    };
    var profileInfo = {
        name: 'Jilu',
        lastname: 'Ilju',
        login:'Uilj'
    };

    function getRoutes(){
       return $timeout(function(){
            return routes;
        },500);
    }
    function getRoute(id){
        return $timeout(() =>{
            var r;
            routes.forEach(function (item){
                    if (item.id == id)
                       { r = item; }

                });
                return r;
            },
            500);

    }
    function getProfileinfo(){
        return profileInfo;
    }
    function getSettings(){
        return settings;
    }
    return {
        getRoutes: getRoutes,
        getRoute: getRoute,
        getProfileInfo: getProfileinfo,
        getSettings:getSettings
    };
}