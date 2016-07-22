"use strict";
angular.module("dmDashboard")
    .directive("dmWidgetBody",
    [
        "$compile", "$mdDialog",
        function($compile, $mdDialog){

            function link(scope, el, attrs){
                console.log(scope);
                var newElement = angular.element(scope.item.template);
                el.append(newElement);
                $compile(newElement)(scope);
                  

                scope.close = function(){
                    scope.widgets.splice(scope.widgets.indexOf(scope.item), 1);
                };

                scope.settings = function(){
                    console.log(scope.item);
                    var options = {
                        templateUrl: scope.item.settings.widgetSettings.dialogTemplate,
                        controller: scope.item.settings.widgetSettings.controller,
                        parent: angular.element(document.body),
                        scope: scope,
                        clickOutsideToClose: true
                    };
                    $mdDialog.show(options);
                };
                scope.iconClicked = function () {

                };



            }

            return {
                templateUrl: "ext-modules/dmDashboard/dmWidgetBodyTemplate.html",
                link: link
            };
        }
    ]);