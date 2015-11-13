//Check out this for binding service variables http://stackoverflow.com/questions/16023451/binding-variables-from-service-factory-to-controllers

function JournalCtrl($q, characterService, journalService) {
    var vm = this;

    vm.charactersInCampaign = characterService.getCharacters();
    
    vm.recentEntries = [];

    vm.loadingEntries = false;

    vm.infiniteScrolling = function () {
        //TODO: Consider if no character is selected to show posts from all characters
        if (vm.loadingEntries || !vm.selectedCharacter) {
            return;
        }

        vm.getNextFiveEntries();
    }

    vm.getNextFiveEntries = function () {
        vm.loadingEntries = true;

        journalService.getNextEntries(characterService.getSelectedCharacter())
            .then(function(entries) {
                vm.recentEntries = entries;
                vm.loadingEntries = false;
            }, function(error) {
                if (error !== 404) {
                    vm.recentEntries = error;
                    //vm.loadingEntries = false;
                }
            });
    }

    vm.newSelectedCharacter = function() {
        characterService.setSelectedCharacter(vm.selectedCharacter);

        if (vm.selectedCharacter === null) {
            vm.recentEntries = [];
        } else {
            journalService.getEntries(vm.selectedCharacter)
                .then(function(entries) {
                    vm.recentEntries = entries;
                }, function(error) {
                    vm.recentEntries = "No posts found for character " + vm.selectedCharacter;
                });
        }
    }

    vm.updateEntry = function(entry) {
        entry.LastEdited = new Date().toDateString();
        console.log(entry);
    }
}

blogApp.controller("JournalCtrl", JournalCtrl); 