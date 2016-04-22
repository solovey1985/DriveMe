angular.module("Services")
    .factory("addressService", [function () {

        return {
                getAddress: function(inputField, callBack) {
                    var autocomplete = new google.maps.places.Autocomplete(inputField);
                    autocomplete.addListener('place_changed', function () {
                        callBack(autocomplete.getPlace());
                    });
                }
            }
        }
    ]);





