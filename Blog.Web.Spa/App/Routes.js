
//Define Routing for app
//Uri /AddNewOrder -> template AddOrder.html and Controller AddOrderController
//Uri /ShowOrders -> template ShowOrders.html and Controller AddOrderController

//controllers must be defined in the same app as the routes, but if I load the route file first, I can use the module sampleApp from this file to call sampleApp.controller from another file

// Code goes here

var blogApp = angular.module("dndBlog", ["ngRoute", "infinite-scroll"]);

blogApp.config(["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider.
        when("/", {
            templateUrl: "/Templates/About/About.html",
            controller: "AboutCtrl",
            controllerAs: "aboutCtrl"
        }).
        when("/Journal/Entries", {
            templateUrl: "/Templates/Journal/Journal.html",
            controller: "JournalCtrl",
            controllerAs: "journalCtrl"
        }).
        when("/Journal/NewEntry", {
            templateUrl: "/Templates/Journal/NewEntry.html",
            controller: "NewEntryCtrl",
            controllerAs: "newEntryCtrl"
        }).
        when("/Items/Quartermaster", {
            templateUrl: "/Templates/Items/Quartermaster.html",
            controller: "QuartermasterCtrl",
            controllerAs: "quartermasterCtrl"
        }).
        otherwise({
            redirectTo: "/"
        });
    }]);