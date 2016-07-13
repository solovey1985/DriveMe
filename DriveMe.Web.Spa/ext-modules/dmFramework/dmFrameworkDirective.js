angular.module('dmFramework')
.directive('dmFramework',[ function(){
    return {
        transclude: false,
        scope: {
            title: '@',
            subtitle: '@',
            logo:'@'
        },
        controller: 'dmFrameworkController',
        templateUrl:'ext-modules/dmFramework/dmFrameworkTemplate.html',
            link: function(scope, el, attr){
                
            }
        }
    }]);