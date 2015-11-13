blogApp.factory("journalService", function($http, $q)
{
    var service = {};

    //Make entries into an object instead of an array with each author as as child of entries
    //access with bracket notation
    //try binding directly to the get method
    var entries = {};
    
    //postsOnPage == entries.length

    var getNextEntries = function(selectedCharacter) {
        var startingIndex;

        if (!entries[selectedCharacter]) {
            startingIndex = 0;
            entries[selectedCharacter] = [];
        } else {
            startingIndex = entries[selectedCharacter].length;
        }

        var nextUrl = "/api/Journal/?character=" + selectedCharacter + "&startingIndex=" + startingIndex;
        
        var defferedEntries = $q.defer();

        $http({
            method: "GET",
            url: nextUrl
        }).then(function successCallback(response) {
            entries[selectedCharacter] = entries[selectedCharacter].concat(response.data);
            defferedEntries.resolve(entries[selectedCharacter]);
        }, function errorCallback(error) {
            defferedEntries.reject(error.status);
            //Handle when there are no posts for a given character
            //Also needs to handle when all posts are shown for a character
        });

        return defferedEntries.promise;
    }

    service.getEntries = function (selectedCharacter) {
        if (!entries[selectedCharacter]) {
            return getNextEntries(selectedCharacter);
        }

        var defferedEntries = $q.defer();
        defferedEntries.resolve(entries[selectedCharacter]);
        return defferedEntries.promise;
    }

    service.getNextEntries = function (selectedCharacter) {
        return getNextEntries(selectedCharacter);
    }

    return service;
});