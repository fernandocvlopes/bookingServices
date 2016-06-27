// app-booking.js
(function () {

    "use strict";
    // Creating the module
    angular.module("app-booking", ["ngRoute", "ngMaterial", "ngMessages"])
    .config(function ($routeProvider) {

        // Setting routes
        $routeProvider.when("/", {
            templateUrl: "/views/homeView.html"
        });

        $routeProvider.when("/event/:eventKey", {
            controller: "eventController",
            controllerAs: "vm",
            templateUrl: "/views/eventView.html"
        });


        $routeProvider.when("/confirm/:eventKey", {
            controller: "eventConfirmController",
            controllerAs: "vm",
            templateUrl: "/views/eventConfirmView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });

    });

})();
