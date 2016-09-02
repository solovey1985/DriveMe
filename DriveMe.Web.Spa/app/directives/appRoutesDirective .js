angular.module('app')
    .directive('appRoutes',[ function(){
        function link() {
            
        }
        return {
                link:link,
                template:'<app-route-editor></app-route-editor>'
        };
    }]);