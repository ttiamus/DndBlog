//Define an angular module for our app
var sampleApp = angular.module("sampleApp", []);

//Define Routing for app
//Uri /AddNewOrder -> template AddOrder.html and Controller AddOrderController
//Uri /ShowOrders -> template ShowOrders.html and Controller AddOrderController

//controllers must be defined in the same app as the routes, but if I load the route file first, I can use the module sampleApp from this file to call sampleApp.controller from another file

sampleApp.config(["$routeProvider",
  function ($routeProvider) {
      $routeProvider.
        when("/AddNewOrder", {
            templateUrl: "/Templates/add_order.html",
            controller: "AddOrderController"
        }).
        when("/ShowOrders", {
            templateUrl: "/Templates/show_orders.html",
            controller: "ShowOrdersController"
        }).
        otherwise({
            redirectTo: "/AddNewOrder"
        });
  }]);


sampleApp.controller("AddOrderController", function ($scope) {

    $scope.message = "This is Add new order screen";

});


sampleApp.controller("ShowOrdersController", function ($scope) {

    $scope.message = "This is Show orders screen";

});
