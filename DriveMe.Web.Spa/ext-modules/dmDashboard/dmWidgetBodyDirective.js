"use strict";
angular.module("dmDashboard")
    .directive("dmWidgetBody",
    [
        "$compile", "$mdDialog",
        function($compile, $mdDialog){

            function link(scope, el, attrs){
                var newElement = angular.element(scope.item.template);
                el.append(newElement);
                $compile(newElement)(scope);
                  

                scope.close = function(){
                    scope.widgets.splice(scope.widgets.indexOf(scope.item), 1);
                };

                scope.settings = function(){
                    var options = {
                        templateUrl: scope.item.widgetSettings.dialogTemplate,
                        controller: scope.item.widgetSettings.controller,
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