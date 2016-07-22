angular.module('app')
    .directive('appProfileInfo',[ function(){
        return {
   
            restrict: 'AE',
            scope: {
                
            },
            template:'<h1>Profile Info Page</h1>'
        }
    }]);