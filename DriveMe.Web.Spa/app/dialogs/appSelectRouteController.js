(function () {
    'use strict';

    angular
        .module('app')
        .controller('appSelectRouteController',appSelectRouteController);

    appSelectRouteController.$inject = ['$rootScope','$scope','$mdDialog','dataService']; 

    function appSelectRouteController($rootScope,$scope, $mdDialog, dataService){

        dataService.getRoutes()
            .then(function(data){
                $scope.routes = data;
            });
        $scope.saveSettings = function (){
            console.log($scope.routeId);
            dataService.getRoute($scope.routeId).then(function (data){
                console.log(data);
               $scope.route = data;
            });

            $mdDialog.hide();
        };
        $scope.cancel = function(){
            $mdDialog.cancel();
        };
    }
})();
