function JournalCtrl($http) {
    var vm = this;

    vm.charactersInCampaign = [
        { "Id": "1", "Name": "Atyr" },
        { "Id": "2", "Name": "Ttiamus" },
        { "Id": "3", "Name": "Ovella" },
        { "Id": "4", "Name": "Anpan" }
    ];
    vm.selectedCharacter = ""; 

    vm.postsOnPage = 0;

    vm.recentEntries = [];

    vm.getNextFiveEntries = function () {
        //TODO: Consider if no character is selected to show posts from all characters
        if (vm.selectedCharacter !== "") {
            var nextUrl = "/api/Journal/?character=" + vm.selectedCharacter + "&startingIndex=" + vm.postsOnPage;

            $http({
                method: "GET",
                url: nextUrl
            }).then(function successCallback(response) {
                vm.recentEntries = vm.recentEntries.concat(response.data);
                vm.postsOnPage += 5;
            }, function errorCallback(response) {
                //Handle when there are no posts for a given character
                //Also needs to handle when all posts are shown for a character
                console.log("error");
            });
        } else {
            console.log("No characterSelected");
        }
    }
}

blogApp.controller("JournalCtrl", JournalCtrl); 