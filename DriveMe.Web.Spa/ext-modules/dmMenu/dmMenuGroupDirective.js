(function() {
    'use strict';

    angular
        .module('dmMenu')
        .directive('dmMenuGroup', dmMenuGroupDirective);

    dmMenuGroupDirective.$inject = ['$window'];
    
    function dmMenuGroupDirective ($window) {
     
      var directive = {
            require:'^dmMenu',
            link: link,
            transclude:true,
            restrict: 'EA',
            scope: {
                title: '@',
                icon:'@'
    },
            templateUrl:'ext-modules/dmMenu/dmMenuGroupTemplate.html'
        };
        return directive;

        function link(scope, element, attrs, ctrl){
            scope.isExpanded = false;

            scope.toggleGroup = function (){
               scope.isExpanded = !scope.isExpanded;
            }
        }
    }

})();