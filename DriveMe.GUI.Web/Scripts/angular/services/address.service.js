angular.module("Services")
    .factory("addressService", ['$http',
        function($http){

            return {
                getAddress: function(inputField, callBack){
                    var autocomplete = new google.maps.places.Autocomplete(inputField);
                    autocomplete.addListener('place_changed',
                        function(){
                            callBack(autocomplete.getPlace());
                        });
                },
                getAddressByPosition: function (latLng, callBack){
             
                    var url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latLng.lat()+","+latLng.lng();
                    $http.get(url).then(function(result){
                        callBack(result.data);
                    });
              },
              getAddressByLatLng: function(latLng){
                  var url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + latLng.lat() + "," + latLng.lng();
                 
                return  $http.get(url).then(function (result){
                     return result.data.results[0].formatted_address;
                  },null);
               
              }
            }
        }
    ]);





