'use strict';
angular.module('app')
    .directive('appRouteWidget', [
        'dataService',
        function (dataService) {
            function link(scope,el, attrs){
              
                dataService.getRoute(scope.item.id)
                    .then(function (data){
                        console.log(scope.item);
                        scope.route = data;
                    });
            }
            return {
                link: link,
                templateUrl: 'app/widgets/appRoutes/appRouteWidgetTemplate.html'
            }
        }
    ]);