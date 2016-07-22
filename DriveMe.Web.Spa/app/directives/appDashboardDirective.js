angular.module('app')
    .directive('appDashboard',[ function(){
       
        return {
          
            template: '<dm-dashboard></dm-dashboard>',
            link: function (scope){
                scope.title = "Dashboard";
                scope.gridsterOpts = {
                    columns: 12,
                    gutter: 10,
                  
                };
                scope.widgetsDefinition = [
                {
                    title: 'Routes',
                    settings: {
                        sizeX: 3,
                        sizeY: 3,
                        row: 0,
                        col: 0,
                        template: '<app-route-widget></app-route-widget>',
                        widgetSettings: {
                            id: 1001,
                            dialogTemplate: 'app/dialogs/appRouteSelectDialog.html',
                            controller: 'appSelectRouteController'
                        }
                    }
                },
                {
                    title: 'Settings',
                    settings: {
                        sizeX: 3,
                        sizeY: 3,
                        row: 0,
                        col: 0,
                        template: '<app-settings-widget></app-settings-widget>',
                            widgetSettings: {
                                id:1001,
                                dialogTemplate: 'app/dialogs/appSettingsSelectDialog.html',
                                controller:'appSelectSettingsController'
                            }
                        }

                    }
                ];
                scope.widgets = [
                   {
                    title: 'Routes',
                    settings: {
                        sizeX: 3,
                        sizeY: 3,
                        row: 0,
                        col: 0,
                        template: '<app-route-widget></app-route-widget>',
                        widgetSettings: {
                            id: 1001,
                            dialogTemplate: 'app/dialogs/appRouteSelectDialog.html',
                            controller: 'appSelectRouteController'
                        }
                    }
                }
                ];
            }
        };

    }]);
    