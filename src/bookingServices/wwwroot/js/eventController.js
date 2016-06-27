// eventController.js
(function () {

    "use strict";
    
    // Using the existing module
    angular.module("app-booking")
    .controller("eventController", eventController);

    function eventController($routeParams, $http) {
        
        var vm = this;
        
        vm.eventKey = $routeParams.eventKey;
        vm.event = {};

        $http.get("/API/Event/", {
            params: { eventName: vm.eventKey }
        })
        .then(function (response) {
            //success
            angular.copy(response.data, vm.event);
        }, function (error) {
            //failure
            vm.errorMessage = "Failed to load event";
        })
    }

})();