angular.module('app').config([
    '$routeProvider', function($routeProvider){
        var routes = [
            {
                url: '/dashboard',
                config: {
                    template: '<app-dashboard></app-dashboard>'
                }

            },
            {
                url: '/routes',
                config: {
                    template: '<app-routes></app-routes>'
                }
            },
            {
                url: '/profile/info',
                config: {
                    template: '<app-profile-info></app-profile-info>'
                }
            },
            {
                url: '/profile/settings',
                config: {
                    template: '<app-profile-settings></app-profile-settings>'
                }
            },
        ];
        routes.forEach(function (route){
            $routeProvider.when(route.url, route.config);
        });
        $routeProvider.otherwise({ redirectTo: '/dashboard' });
    }
]);