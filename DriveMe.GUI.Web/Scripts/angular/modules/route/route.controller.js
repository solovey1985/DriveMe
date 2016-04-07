/// <reference path="../../../angular.js" />
angular.module("RouteApp")
    .controller("RouteController", ['$http', '$scope', function ($http, $scope) {
        $scope.route = {
            waypoints: [{ Location: '54.32323,30.545456' }],
            name: 'First Route',
            startTime: new Date('05.04.2016 12:00:03'),
        }
    }]);