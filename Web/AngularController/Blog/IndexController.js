$(document).ready(function() {
    console.log("howdy ho");
});

//Define an angular module for our app
var app = angular.module('blogApp', []);

//Define Routing for app
//Uri /AddNewOrder -> template add_order.html and Controller AddOrderController
//Uri /ShowOrders -> template show_orders.html and Controller AddOrderController
app.config(["$routeProvider",
  function ($routeProvider) {
      $routeProvider.
        when("/Quartermaster", {
            templateUrl: "/Quartermaster.html",
            controller: "AddOrderController"
        }).
        when("/NewPost", {
            templateUrl: "/PostCreateNew.html",
            controller: "ShowOrdersController"
        }).
          when("/Post", {
              templateUrl: "/Post.html",
              controller: "ShowOrdersController"
          }).
        otherwise({
            redirectTo: "/About.html"
        });
  }]);


app.controller("AddOrderController", function ($scope) {

    $scope.message = "This is Add new order screen";

});


app.controller("ShowOrdersController", function ($scope) {

    $scope.message = "This is Show orders screen";

});
