/// <reference path="../../../angular.js" />
angular.module("RouteApp")
    .controller("RouteController",
    [
        "$http", "$scope", "DirectionService", "addressService", "mapsService",
        function($http, $scope, DirectionService, addressService, mapsService){

            $scope.request = {
                StartTime: '',
                EndTime: '',
                StartLatitude: '',
                StartLongitude: '',
                StartAddress: '',
                EndLatitude: '',
                EndLongitude: '',
                EndAddress: ''
            };


            $scope.endDate = "";
            $scope.startDate = "";
            $scope.startTime = "";
            $scope.endTime = "";
          

            $scope.TripRequest = {
                StartPoint: {
                    Address: "",
                    Position: {
                        Latitude: "",
                        Longitude: ""
                    }
                },
                EndPoint: {
                    Address: "",
                    Position: {
                        Latitude: "",
                        Longitude: ""
                    }
                },
                StartDateTime: "",
                EndDateTime: ""
            };
            
            $scope.setMap = function(m){
                mapsService.setMap(m);
            };

            $scope.sendTripRequest = function (){

                var request = getRequest();
                console.log(request);
                $http.post("http://localhost:9090/api/triprequests", JSON.stringify(request))
                    .success(function (data, status) {
                    })
                    .error(function (data, status) {
                    });
            };

            $scope.fillInStartAddress = function () {
                const myEl = $("#startAddressPicker");

                addressService.getAddress(myEl[0],
                    function (place) {
                        setMarkerByAddress(place);
                    });

            };

            $scope.fillInEndAddress = function () {
                const el = $("#endAddressPicker");

                $scope.endPlace = addressService.getAddress(el[0],
                    function (place){
                        setMarkerByAddress(place);
                        $scope.TripRequest.EndPoint.Position.Latitude = place.geometry.location.lat();
                        $scope.TripRequest.EndPoint.Position.Longitude = place.geometry.location.lng();
                        $scope.TripRequest.EndPoint.Address = place.formatted_address;
                    });

            };

            $scope.getRoute = function () {
                DirectionService.getRoute($scope.startAddress);

            };

            $scope.calculateRoute = function () {
                const start = mapsService.getStart();
                const end = mapsService.getEnd();

                DirectionService.setMap(gMap);
                DirectionService.calculateRoute(start.position, end.position);
            };

           
            var setMarkerByAddress = function (place) {
                mapsService.createMarker(place.geometry.location.lat(),
                    place.geometry.location.lng(),
                    place.formatted_address,
                    true);
            };

            function getRequest(){
                var startPosition = mapsService.getStart();
                var endPosition = mapsService.getEnd();
           
                return {
                        StartTime:  $scope.startDate.toLocaleString(),
                        EndTime: $scope.endDate.toLocaleString(),
                        StartLatitude: startPosition.position.lat(),
                        StartLongitude: startPosition.position.lng(), 
                        StartAddress: startPosition.address,
                        EndLatitude: endPosition.position.lat(),
                        EndLongitude: endPosition.position.lng(),
                        EndAddress: endPosition.address
                    };
            }
            
            function transferTimeToDate(time, date){
                console.log(time);
                date.setHours(time.getHours(), time.getMinutes(), 0);
                return date.toLocaleString();
            }
            function isValid(){
                return true;
            }
            
            /*Date & Time*/
            $scope.today = function(){
                $scope.dt = new Date();
            };
            $scope.today();

            $scope.clear = function(){
                $scope.dt = null;
            };

            $scope.inlineOptions = {
                customClass: getDayClass,
                minDate: new Date(),
                showWeeks: true
            };

            $scope.dateOptions = {
                dateDisabled: disabled,
                formatYear: "yy",
                maxDate: new Date(2020, 5, 22),
                minDate: new Date(),
                startingDay: 1
            };

            // Disable weekend selection
            function disabled(data){
                const date = data.date;
                const mode = data.mode;
                return mode === "day" && (date.getDay() === 0 || date.getDay() === 6);
            }

            $scope.toggleMin = function(){
                $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
                $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
            };

            $scope.toggleMin();

            $scope.open1 = function(){
                $scope.popup1.opened = true;
            };

            $scope.open2 = function(){
                $scope.popup2.opened = true;
            };

            $scope.setDate = function(year, month, day){
                $scope.dt = new Date(year, month, day);
            };

            $scope.formats = ["dd-MMMM-yyyy", "yyyy/MM/dd", "dd.MM.yyyy", "shortDate"];
            $scope.format = $scope.formats[0];
            $scope.altInputFormats = ["M!/d!/yyyy"];

            $scope.popup1 = {
                opened: false
            };

            $scope.popup2 = {
                opened: false
            };

            const tomorrow = new Date();
            tomorrow.setDate(tomorrow.getDate() + 1);
            const afterTomorrow = new Date();
            afterTomorrow.setDate(tomorrow.getDate() + 1);
            $scope.events = [
                {
                    date: tomorrow,
                    status: "full"
                },
                {
                    date: afterTomorrow,
                    status: "partially"
                }
            ];

            function getDayClass(data){
                const date = data.date;
                const mode = data.mode;
                if (mode === "day") {
                    const dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                    for (let i = 0; i < $scope.events.length; i++) {
                        const currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                        if (dayToCheck === currentDay) {
                            return $scope.events[i].status;
                        }
                    }
                }

                return "";
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