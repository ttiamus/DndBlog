function NewPostCtrl($scope, $http) {
    var vm = this;

    vm.newPost =
    {
        "title": "",
        "body": ""
    };

    vm.createNewPost = function() {
        $scope.$broadcast("show-errors-check-validity");        //Broadcast is a method off scope, so we had to inject it here
        if ($scope.newPostForm.$invalid) { return; }

        //Investigate setting up CORS for cross domain api call if want to run api on seperate website
        $http({
            method: "POST",
            url: "api/post",
            data: vm.newPost
        }).then(function success(response) {
            console.log("post was created");
        }, function failure(resonse) {
            console.log("Post creation failed");
        });
    }
}

blogApp.controller("NewPostCtrl", NewPostCtrl);