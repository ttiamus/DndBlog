blogApp.factory("characterService", function($http, $q)
{
    var service = {};
    
    var characters = [];
    var selectedCharacter = "";

    var getCharacters = function() {
        //get characters from the server later
        var charactersFromServer = [
            { "Id": "1", "Name": "Atyr" },
            { "Id": "2", "Name": "Ttiamus" },
            { "Id": "3", "Name": "Ovella" },
            { "Id": "4", "Name": "Anpan" }
        ];
        characters = charactersFromServer;
    }

    service.getCharacters = function () {
        getCharacters();
        return characters;
    }

    service.getSelectedCharacter = function() {
        return selectedCharacter;
    }

    service.setSelectedCharacter = function(character) {
        selectedCharacter = character;
    }

    return service;
});