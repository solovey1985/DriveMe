(function () {
    'use strict';

    angular
        .module('dmMenu')
        .controller('dmMenuController', dmMenuController);

    dmMenuController.$inject = ['$rootScope', '$scope', '$mdSidenav'];


    function dmMenuController($rootScope, $scope, $mdSidenav) {
    
        var vm = this;
        $scope.isMenuVisible = function () {
            return $mdSidenav('left').isOpen();
        }
        $scope.isMenuVertical = true;
        $scope.activeElement = {};
        vm.title = 'dmMenuController';
        vm.getActiveElement = function(){
            return $scope.activeElement;
        }
        vm.setActiveElement = function(el){
            $scope.activeElement = el;
        }

        vm.setRoute = function(route){
            $rootScope.$broadcast('dm-menu-item-selected-event', {route:route});
        }
        $scope.swapMenu = function(){
            $scope.isMenuVertical = !$scope.isMenuVertical;
         
            $rootScope.$broadcast('dm-menu-swapped-event', { isMenuVertical: $scope.isMenuVertical});
        }

        
    }
})();
