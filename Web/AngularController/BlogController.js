var app = angular.module('Blog', []);
app.controller('BlogController', function ($scope, $http) {
    $scope.greeting = "hello world!";
});