/// <reference path="../../../angular.js" />
angular.module("RouteApp")
    .controller("RouteController", ['$http', '$scope','DirectionService', function ($http, $scope, DirectionService) {
        $scope.route = {
            waypoints: [{lat: 50.23254, lng: 30.50245}],
            name: 'First Route',
            startTime: new Date('05.04.2016 12:00:03')
        }
        $scope.startAddress = "";
        $scope.getRoute = function() {
            console.log($scope.startAddress);
            DirectionService.getRoute($scope.startAddress);
        };

    }]);