//Check out this for binding service variables http://stackoverflow.com/questions/16023451/binding-variables-from-service-factory-to-controllers

function JournalCtrl($q, characterService, journalService) {
    var vm = this;

    vm.charactersInCampaign = characterService.getCharacters();
    vm.selectedCharacter = ""; 

    vm.recentEntries = [];

    vm.loadingEntries = false;

    vm.infiniteScrolling = function () {
        //TODO: Consider if no character is selected to show posts from all characters
        if (vm.loadingEntries || vm.selectedCharacter === "") {
            console.log("exit early");
            return;
        }
        //vm.loadingEntries = true;

        vm.getNextFiveEntries();
    }

    vm.getNextFiveEntries = function () {
        journalService.getNextEntries(characterService.getSelectedCharacter())
            .then(function(data) {
                vm.recentEntries = data;
            }, function(error) {
                console.log(error);
            });
    }

    vm.newSelectedCharacter = function() {
        characterService.setSelectedCharacter(vm.selectedCharacter);
        vm.getNextFiveEntries();
    }
}

blogApp.controller("JournalCtrl", JournalCtrl); 