(function() {
    'use strict';

    angular
        .module('dmMenu')
        .directive('dmMenuItem', dmMenuItemDirective);
    
    function dmMenuItemDirective () {
       return {
            require: '^dmMenu',
            link: link,
            templateUrl: "ext-modules/dmMenu/dmMenuItemTemplate.html",
            scope: {
                title: '@',
                subtitle: '@',
                icon: '@',
                route:'@'
            }
        };
         
       function link(scope, el, attr, ctrl) {
           scope.isActive = function(){
               return el === ctrl.getActiveElement();
           }
            el.on('click',
                function (event){
                    event.stopPropagation();
                    event.preventDefault();

                    scope.$apply(function () {
                        ctrl.setActiveElement(el);
                        ctrl.setRoute(scope.route);
                    });
                });
        }
    }

})();