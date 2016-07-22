
(function(){
    angular.module('dmFramework', ['dmMenu', 'dmDashboard']);
})();
angular.module('dmFramework').run(['$templateCache', function($templateCache) {$templateCache.put('ext-modules/dmFramework/dmFrameworkTemplate.html','<md-toolbar class="dm-top-panel" layout="row" layout-align="space-around center" flex>\r\n    <div flex>\r\n\r\n        <div class="dm-logo-area" layout="row" hide-sm>\r\n            <img alt="DriveMe Logo" class="dm-icon-logo" ng-src="{{logo}}"/>\r\n            <div>\r\n                <p class="dm-logo-title">{{title}}</p>\r\n                <div>\r\n                    <p class="dm-logo-subtitle">{{subtitle}}</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class="dm-logo-area" show-sm hide-gt-sm>\r\n            <md-button class="" layout-align="center center" ng-click="toggleMenu()">\r\n                <md-icon>\r\n                    <div>\r\n                        <i class="fa fa-2x ion-social-windows-outline"></i>\r\n\r\n                    </div>\r\n                </md-icon>\r\n            </md-button>\r\n        </div>\r\n    </div>\r\n    <div flex>\r\n        <md-fab-toolbar md-open="false" md-direction="left">\r\n            <md-fab-trigger class="align-with-text">\r\n                <md-button aria-label="menu" layout layout-align="center center" class="md-fab md-primary">\r\n                    <md-icon><i class="fa fa-2x fa-list"></i></md-icon>\r\n                </md-button>\r\n            </md-fab-trigger>\r\n            <md-toolbar>\r\n                <md-fab-actions class="md-toolbar-tools">\r\n                    <md-button aria-label="comment" class="md-icon-button">\r\n                        <md-icon><i class="fa fa-2x fa-edit"></i></md-icon>\r\n                    </md-button>\r\n                    <md-button aria-label="comment" class="md-icon-button">\r\n                        <md-icon><i class="fa fa-2x fa-info"></i></md-icon>\r\n                    </md-button>\r\n                    <md-button aria-label="comment" class="md-icon-button">\r\n                        <md-icon><i class="fa fa-2x fa-user"></i></md-icon>\r\n                    </md-button>\r\n                </md-fab-actions>\r\n            </md-toolbar>\r\n        </md-fab-toolbar>\r\n    </div>\r\n</md-toolbar>\r\n<div ng-transclude></div>   \r\n<div ng-view class="dm-view" ng-class="{\'dm-view-full-width\':!isMenuVisible()}"></div> \r\n\r\n');}]);
angular.module('dmFramework')
.directive('dmFramework',[function(){
    return {
        transclude: true,
        scope: {
            title: '@',
            subtitle: '@',
            logo:'@'
        },
        controller: 'dmFrameworkController',
        templateUrl:'ext-modules/dmFramework/dmFrameworkTemplate.html',
            link: function(scope, el, attr){
                
            }
        }
    }]);

angular.module('dmFramework')
    .controller('dmFrameworkController',
    [
        '$scope', '$mdSidenav','$mdMedia', '$location',
        function ($scope, $mdSidenav, $mdMedia, $location){

            $scope.isMenuVertical = true;
            
            $scope.toggleMenu = function(){
                $mdSidenav('left').toggle();
            }

            $scope.$on('dm-menu-item-selected-event',
                function(event, data){
                    $scope.routeString = data.route;
                    $location.path(data.route);
                    $mdSidenav('left').isOpen() && ($mdMedia('sm') || $mdMedia('xs')) && $mdSidenav('left').close();
                });
             $scope.$on('dm-menu-swapped-event', function (event, data){
             $scope.isMenuVertical = data.isMenuVertical;
            });
        }
    ]);

angular.module('dmDashboard', ['gridster']);
angular.module('dmDashboard').run(['$templateCache', function($templateCache) {$templateCache.put('ext-modules/dmDashboard/dmDashboardTemplate.html','<div class="dm-dashboard-header">\r\n    <span>{{title}}</span>\r\n\r\n    <div class="btn-group pull-right dm-dashboard-controls">\r\n        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">\r\n            <i class="fa fa-plus"></i>&nbsp;Add widget&nbsp;<span class="caret"></span>\r\n        </button>\r\n        <ul class="dropdown-menu">\r\n            <li ng-repeat="widget in widgetsDefinition">\r\n                <a role="menuitem" ng-click="addNewWidget(widget)">{{widget.title}}</a>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</div>\r\n\r\n<div gridster="gridsterOpts">\r\n    <ul>\r\n        <li gridster-item="item" ng-repeat="item in widgets">\r\n            <dm-widget-body></dm-widget-body>\r\n        </li>\r\n    </ul>\r\n</div>');
$templateCache.put('ext-modules/dmDashboard/dmWidgetBodyTemplate.html','<div class="dm-widget-body">\r\n  \r\n\r\n    <div class="dm-widget-menu-area btn-group pull-right">\r\n        <a class="dropdown-toggle" data-toggle="dropdown" ng-click="iconClicked()" aria-haspopup="true" aria-expanded="false">\r\n            <i class="fa fa-list"></i>\r\n        </a>\r\n        <ul class="dropdown-menu" role="menu">\r\n            <li ng-click="close()"><i class="fa fa-2x fa-close"></i></li>\r\n            <li ng-click="settings()"><i class="fa fa-2x fa-gear"></i></li>\r\n        </ul>\r\n\r\n    </div>\r\n</div>');}]);

angular.module("dmDashboard")
    .directive("dmWidgetBody",
    [
        "$compile", "$mdDialog",
        function($compile, $mdDialog){

            function link(scope, el, attrs){
                const newElement = angular.element(scope.item.template);
                el.append(newElement);
                $compile(newElement)(scope);

                scope.close = function(){
                    scope.widgets.splice(scope.widgets.indexOf(scope.item), 1);
                };
                scope.settings = function(){
                    console.log(scope.item);
                    const options = {
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
(function() {


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
                console.log(widget);
                var newWidget = angular.copy(widget.settings);
                scope.widgets.push(newWidget);
            };
        }
    }

})();

angular.module('dmMenu', ['ngAnimate','dmDashboard']);
angular.module('dmMenu').run(['$templateCache', function($templateCache) {$templateCache.put('ext-modules/dmMenu/dmMenuGroupTemplate.html','<md-button class="dm-menu-group" layout-align="space-between center" layout="row" layouy-fill ng-click="toggleGroup()">\r\n    <div class="dm-menu-icon">\r\n        <i class="fa fa-3x {{icon}}"></i>\r\n    </div>\r\n    <span flex>{{title}}</span>\r\n    \r\n    <div flex class="md-menu-expand-button">\r\n        <i class="fa fa-2x" ng-class="isExpanded ?\'fa-angle-up\':\'fa-angle-down\'"></i>\r\n    </div>\r\n</md-button>\r\n<div ng-show="isExpanded" class="dm-fade-in-animation">\r\n    <ul ng-transclude></ul>\r\n</div>');
$templateCache.put('ext-modules/dmMenu/dmMenuItemTemplate.html','<md-button ng-click="toggleMenu()" ng-class="{\'active-menu-item\':isActive()}" layout="row" layput-align="center center" class="dm-menu-button">\r\n    \r\n        <md-icon flex="25" style="margin-top: 10px;" class="dm-menu-icon">\r\n            <i class="fa fa-3x {{icon}}"></i>\r\n        </md-icon>\r\n    \r\n    <div flex layout="column" layout-align="start center" style="margin-left: 5px; ">\r\n        <h4>{{title}}</h4>\r\n        <p class="dm-menu-subtitle" style="text-transform: none; text-overflow: ellipsis-word;">{{subtitle}}</p>\r\n    </div>\r\n</md-button>\r\n<md-divider></md-divider>');
$templateCache.put('ext-modules/dmMenu/dmMenuTemplate.html','<md-sidenav class="md-sidenav-left dm-menu-area" layout-align="center center"\r\n            md-component-id="left"\r\n            md-is-locked-open="$mdMedia(\'gt-sm\')"\r\n            md-disable-backdrop\r\n            md-whiteframe="4"\r\n            ng-class="{\'dm-menu-area-visible\': isMenuVisible()}">\r\n    <md-toolbar class="md-theme-indigo dm-menu-header">\r\n        <h1 class="md-toolbar-tools">{{title}}</h1>\r\n    </md-toolbar>\r\n    <md-content layout-padding style="width: 100%;">\r\n        <div ng-transclude></div>\r\n    </md-content>\r\n</md-sidenav>\r\n');}]);
(function() {


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
(function() {


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

angular.module('dmMenu')
.directive('dmMenu', [
    
    function(){
        return {
            restrict:'AE',
            transclude: true,
            templateUrl: 'ext-modules/dmMenu/dmMenuTemplate.html',
            controller: 'dmMenuController',
            scope: {
                title:'@'
            },
            link:function (scope, el, attr){}
        }

    }]);
(function () {


    angular
        .module('dmMenu')
        .controller('dmMenuController', dmMenuController);

    dmMenuController.$inject = ['$rootScope', '$scope', '$mdSidenav'];


    function dmMenuController($rootScope, $scope, $mdSidenav) {
    
        var vm = this;
        $scope.isMenuVisible = function () {
            return $mdSidenav('left').isOpen();
        }
        $scope.isMenuVertical = true;
        $scope.activeElement = {};
        vm.title = 'dmMenuController';
        vm.getActiveElement = function(){
            return $scope.activeElement;
        }
        vm.setActiveElement = function(el){
            $scope.activeElement = el;
        }

        vm.setRoute = function(route){
            $rootScope.$broadcast('dm-menu-item-selected-event', {route:route});
        }
        $scope.swapMenu = function(){
            $scope.isMenuVertical = !$scope.isMenuVertical;
         
            $rootScope.$broadcast('dm-menu-swapped-event', { isMenuVertical: $scope.isMenuVertical});
        }

        
    }
})();
