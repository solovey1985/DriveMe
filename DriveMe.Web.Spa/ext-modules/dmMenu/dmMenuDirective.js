'use strict';
angular.module('dmMenu')
.directive('dmMenu', [
    
    function(){
        return {
            restrict:'AE',
            transclude: true,
            templateUrl: 'ext-modules/dmMenu/dmMenuTemplate.html',
            controller: 'dmMenuController',
            scope: {
                title:'@'
            },
            link:function (scope, el, attr){}
        }

    }]);