// eventConfirmController.js
(function () {
    
    "use strict";
    
    // Using the existing module
    angular.module("app-booking")
    .controller("eventConfirmController", eventConfirmController);

    function eventConfirmController($routeParams, $http)
    {
        var
            vm = this,
            unavailableDates = [];

        vm.eventKey = $routeParams.eventKey;
        vm.healthProblems = [];
        vm.event = {};
        

        $http.get("/API/HealthProblems/")
        .then(function (response) {
            //success
            angular.copy(response.data, vm.healthProblems);
        }, function (error) {
            //failure
            vm.errorMessage = "Failed to load health problems";
        })
        
        $http.get("/API/UnavailableDates/", {
            params: { eventName: vm.eventKey }
        })
        .then(function (response) {
            //success
            angular.copy(response.data, unavailableDates);
        }, function (error) {
            //failure
            vm.errorMessage = "Failed to load unavailable dates";
        })

        $http.get("/API/Event/", {
            params: { eventName: vm.eventKey }
        })
        .then(function (response) {
            //success
            angular.copy(response.data, vm.event);
            vm.minDate = new Date(vm.event.startDate);
            vm.maxDate = new Date(vm.event.endDate);
        }, function (error) {
            //failure
            vm.errorMessage = "Failed to load event";
        })

        vm.validateDatePredicate = function(date) {
            
            return unavailableDates.indexOf(+date) === -1;
        }

        vm.confirmBooking = function () {

            vm.booking.eventKey = vm.eventKey;

            $http.post("/API/Event/", vm.booking)
            .then(function (response) {
                // Success
                alert("Event Confirmed!");
                vm.booking = {};
            }, function (error) {
                // Failure
                vm.errorMessage = "Failed to confirm the event: " + error;
            })
        };
    }

})();
