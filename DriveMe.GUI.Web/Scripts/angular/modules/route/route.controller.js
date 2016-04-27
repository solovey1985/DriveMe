/// <reference path="../../../angular.js" />
angular.module("RouteApp")
    .controller("RouteController", [
        '$http', '$scope', 'DirectionService', 'addressService', "mapsService",
        function($http, $scope, DirectionService, addressService, mapsService){

            $scope.route = {
                waypoints: [{ lat: 50.23254, lng: 30.50245 }],
                name: 'First Route',
                startTime: new Date('05.04.2016 12:00:03')
            }

            $scope.startDate = '';
            $scope.startTime = '';
            $scope.endDate = '';
            $scope.endTime = '';

            $scope.TripRequest = {
                StartPoint: {
                    Address: '',
                    Position: {
                        Latitude: '',
                        Longitude: ''
                    }
                },
                EndPoint: {
                    Address: '',
                    Position: {
                        Latitude: '',
                        Longitude: ''
                    }
                },
                StartDateTime: '04/04/2015',
                EndDateTime: $scope.endDate + ' ' + $scope.endTime
            }

            $scope.setMap = function(m){
                mapsService.setMap(m);
            }

            $scope.requestTrip = function(){
                console.log($scope.TripRequest);
            
                $http.post('http://localhost:58265/api/triprequests/trip', JSON.stringify($scope.TripRequest),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).success(function(data, status){
                    console.log(data);
                }).error(function(data, status){
                });
            }

            var setMarkerByAddress = function(place){
                mapsService.setMarker(place.geometry.location.lat(), place.geometry.location.lng(), place.formatted_address, true);
            }

            $scope.fillInStartAddress = function(){
                var myEl = $('#startAddressPicker');

                addressService.getAddress(myEl[0], function(place){
                    setMarkerByAddress(place);
                    $scope.TripRequest.StartPoint.Position.Latitude = place.geometry.location.lat();
                    $scope.TripRequest.StartPoint.Position.Longitude = place.geometry.location.lng();
                    $scope.TripRequest.StartPoint.Address = place.formatted_address;
                });

            };
            $scope.fillInEndAddress = function(){
                var el = $('#endAddressPicker');

                $scope.endPlace = addressService.getAddress(el[0], function(place){
                    setMarkerByAddress(place);
                    $scope.TripRequest.EndPoint.Position.Latitude = place.geometry.location.lat();
                    $scope.TripRequest.EndPoint.Position.Longitude = place.geometry.location.lng();
                    $scope.TripRequest.EndPoint.Address = place.formatted_address;
                });

            };

            $scope.startAddress = "";

            $scope.getRoute = function(){
                console.log($scope.startAddress);
                DirectionService.getRoute($scope.startAddress);

            };

            $scope.calculateRoute = function(){
                var start = mapsService.getStart();
                var end = mapsService.getEnd();
                console.log(end);
                DirectionService.setMap(gMap);
                DirectionService.calculateRoute(start.position, end.position);
            }
        }
    ]);

/* Координаты точек маршрута
      Start
      End
Сервисы
    Поиска адресса
    Отображения точек на карте, получения координат по клику
    Построение и редактирование маршрута
    Работа с сервером: отправка заявки на сервер
         
         
*/