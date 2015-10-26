// Code goes here

var app = angular.module('app', ['ngRoute']);

app.config(['$routeProvider', '$locationProvider',
  function ($routeProvider) {
      $routeProvider

        .when('/', {
            template: '<div>This should be visible:{{ ctrl.one }}</div><div>This should not:{{ one }}</div>',
            controller: 'Ctrl',
            controllerAs: 'ctrl',
        });
  }]);

app.controller('Ctrl', function () {
    this.one = 'actual';  //changed $scope -> this
});
