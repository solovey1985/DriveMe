'use strict';
angular.module('app')
    .directive('appRouteWidget', [
        'dataService',
        function (dataService) {
            function link(scope,el, attrs){
              
                dataService.getRoute(scope.item.widgetSettings.id)
                    .then(function (data){
                        scope.route = data;
                    });
            }
            return {
                link: link,
                templateUrl: 'app/widgets/appRoutes/appRouteWidgetTemplate.html'
            };
        }
    ]);