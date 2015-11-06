blogApp.factory("journalService", function($http, $q)
{
    var service = {};

    //come up with a way to keep entries retrived stored by character so don't have to keep getting them
    var entries = [];
    
    //postsOnPage == entries.length

    var getNextEntries = function(selectedCharacter) {
        console.log(selectedCharacter);
        var nextUrl = "/api/Journal/?character=" + selectedCharacter + "&startingIndex=" + entries.length;

        var defferedEntries = $q.defer();

        $http({
            method: "GET",
            url: nextUrl
        }).then(function successCallback(response) {
            entries = entries.concat(response.data);
            defferedEntries.resolve(entries);
            //loadingEntries = false;
        }, function errorCallback(response) {
            defferedEntries.reject("There was an error");
            //loadingEntries = false;
            //Handle when there are no posts for a given character
            //Also needs to handle when all posts are shown for a character
        });

        return defferedEntries.promise;
    }

    service.getEntries = function (selectedCharacter) {
        if (entries.length === 0) {
            getNextEntries(selectedCharacter);
        }
        return entries;
    }

    service.getNextEntries = function (selectedCharacter) {
        return getNextEntries(selectedCharacter);
    }

    return service;
});