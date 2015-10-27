function NavCtrl($location) {
    var vm = this;

    vm.isActiveTab = function (route) {
        return route === $location.path();
    }
}

blogApp.controller("NavCtrl", NavCtrl);