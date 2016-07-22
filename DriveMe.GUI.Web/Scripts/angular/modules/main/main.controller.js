angular.module("MainApp").controller('MainController', ['$scope', '$mdSidenav', 'routeProvider', MainController]);
angular.module("MainApp").controller('LeftController', ['$scope', '$mdSidenav', LeftController]);
angular.module("MainApp").controller('RightController', ['$scope', '$mdSidenav', RightController]);

function MainController($scope, $mdSidenav, routeProvider) {
    var self = this;
    $scope.tabIndex = 0;
    var now = new Date();
    $scope.start = { address:'',date: '' };
    $scope.end = { address: '', date: '' };
    $scope.toggleLeft = function () {
        $mdSidenav('left').toggle();
    }
    $scope.toggleRight = function(){
        $mdSidenav('right').toggle();
    }
    

    $scope.init = function (){
            $scope.routes = routeProvider.getRoutes();
            $scope.current = $scope.routes[0];    
    }

}

function LeftController($scope, $mdSidenav) {
    var self = this;
    $scope.close = function () {
        $mdSidenav('left').close();
    }
    
}

function RightController($scope, $mdSidenav) {
    var self = this;
    $scope.close = function(){
        $mdSidenav('right').close();
    }

   
}