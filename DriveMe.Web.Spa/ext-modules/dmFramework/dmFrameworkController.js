'use strict';
angular.module('dmFramework')
    .controller('dmFrameworkController',
    [
        '$scope', '$mdSidenav','$mdMedia', '$location',
        function ($scope, $mdSidenav, $mdMedia, $location){

            $scope.isMenuVertical = true;
            
            $scope.toggleMenu = function(){
                $mdSidenav('left').toggle();
            }

            $scope.$on('dm-menu-item-selected-event',
                function(event, data){
                    $scope.routeString = data.route;
                    $location.path(data.route);
                    $mdSidenav('left').isOpen() && ($mdMedia('sm') || $mdMedia('xs')) && $mdSidenav('left').close();
                });
             $scope.$on('dm-menu-swapped-event', function (event, data){
             $scope.isMenuVertical = data.isMenuVertical;
            });
        }
    ]);