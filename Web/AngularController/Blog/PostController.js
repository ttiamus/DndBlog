var app = angular.module('Post', []);
app.controller('PostController', function ($scope, $http) {
    $scope.greeting = "hello world!";
});