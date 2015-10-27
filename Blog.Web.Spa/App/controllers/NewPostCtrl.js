function NewPostCtrl() {
    var vm = this;

    vm.title = "test";
    vm.body = "";

    vm.isValidTitle = function() {
        if (vm.title.length > 0) {
            return true;
        } else {
            return false;
        }
    }

    vm.isValidBody = function() {
        if (vm.body.length > 0) {
            return true;
        } else {
            return false;
        }
    }

    vm.isValidPost = function() {
        if (vm.isValidTitle() && vm.isValidBody) {
            return true;
        } else {
            return false;
        }
    }
}

blogApp.controller("NewPostCtrl", NewPostCtrl);