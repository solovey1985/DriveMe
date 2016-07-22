angular.module('app')
    .directive('appProfileSettings',[ function(){
        return {
          
            restrict: 'AE',
            scope: {
                
            },
            template:'<h1>Profile Settings Page</h1>'
        }
    }]);