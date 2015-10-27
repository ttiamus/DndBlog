//Define an angular module for our app
var blogApp = angular.module("dndBlog", []);

//Define Routing for app
//Uri /AddNewOrder -> template AddOrder.html and Controller AddOrderController
//Uri /ShowOrders -> template ShowOrders.html and Controller AddOrderController

//controllers must be defined in the same app as the routes, but if I load the route file first, I can use the module sampleApp from this file to call sampleApp.controller from another file

// Code goes here

var blogApp = angular.module("dndBlog", ["ngRoute"]);

blogApp.config(["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider.
        when("/", {
            templateUrl: "/Templates/Post/Posts.html",
            controller: "PostCtrl",
            controllerAs: "postCtrl"
        }).
        when("/Posts", {
            redirectTo: "/"
        }).
        when("/CreatePost", {
            templateUrl: "/Templates/Post/CreateNewPost.html",
            controller: "NewPostCtrl",
            controllerAs: "newPostCtrl"
        }).
        when("/Test", {
            templateUrl: "/Templates/testPage.html",
            controller: "TestCtrl",
            controllerAs: "testCtrl"
        }).
        otherwise({
            redirectTo: "/"
        });
    }]);