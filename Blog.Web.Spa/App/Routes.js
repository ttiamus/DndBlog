//Define an angular module for our app
var blogApp = angular.module("dndBlog", []);

//Define Routing for app
//Uri /AddNewOrder -> template AddOrder.html and Controller AddOrderController
//Uri /ShowOrders -> template ShowOrders.html and Controller AddOrderController

//controllers must be defined in the same app as the routes, but if I load the route file first, I can use the module sampleApp from this file to call sampleApp.controller from another file

blogApp.config(["$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider.
    when("/AddNewOrder", {
        templateUrl: "/Templates/add_order.html",
        controller: "AddOrderController"
    }).
    when("/ShowOrders", {
        templateUrl: "/Templates/show_orders.html",
        controller: "ShowOrdersController"
    }).
    when("/test", {
        templateUrl: "/Templates/testPage.html",
        controller: "TestController"
    }).
    when("/", {
        templateUrl: "/Templates/testPage.html",
        controller: "TestController"
    }).
    otherwise({
        redirectTo: "/test"
    });

    
}]);


blogApp.controller("AddOrderController", function ($scope) {

    $scope.message = "This is Add new order screen";

});


blogApp.controller("ShowOrdersController", function ($scope) {

    $scope.message = "This is Show orders screen";

});
