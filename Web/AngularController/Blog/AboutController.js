var app = angular.module('About', []);
app.controller('AboutController', function ($scope, $http) {
    $scope.greeting = "hello world!";
});