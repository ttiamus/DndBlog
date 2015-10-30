function NewEntryCtrl($scope, $http) {
    var vm = this;

    vm.newEntry =
    {
        "title": "",
        "body": "",
        "character": "Atyr"    //Default to Atyr for now. This will evenually come from a logged in value
    };

    vm.createNewEntry = function() {
        $scope.$broadcast("show-errors-check-validity");        //Broadcast is a method off scope, so we had to inject it here
        if ($scope.newEntryForm.$invalid) { return; }
        console.log(vm.newEntry);
        //Investigate setting up CORS for cross domain api call if want to run api on seperate website
        $http({
            method: "POST",
            url: "api/journal",
            data: vm.newEntry
        }).then(function success(response) {
            console.log("entry was created");
        }, function failure(resonse) {
            console.log("entry creation failed");
        });
    }
}

blogApp.controller("NewEntryCtrl", NewEntryCtrl);