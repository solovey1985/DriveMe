﻿(function() {
    'use strict';

    angular
        .module('dmDashboard')
        .directive('dmDashboard', dmDashboardDirective);

    
    function dmDashboardDirective () {
       
        var directive = {
            link: link,
            templateUrl:'ext-modules/dmDashboard/dmDashboardTemplate.html'
        };
        return directive;

        function link(scope, element, attrs){
            scope.addNewWidget = function (widget){
                console.log("Add new widget");
                console.log(widget.settings);
                var newWidget = angular.copy(widget.settings);
                scope.widgets.push(newWidget);
            };
        }
    }

})();