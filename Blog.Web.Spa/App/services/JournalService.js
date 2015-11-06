function journalService($http) {
    var entries = [];   //Private

    var findIndex = function(id) {
        for (var i = 0; i < entries.length; i++) {
            if (entries[i].Id === id) {
                return i;
            }
        }
    }

    return {            //public
        entries: function () {
            return entries;
        },
        getNextEntries: function() {
            //call api to update list
            return entries;
        },
        addEntry: function (entry) {
            entries.push(entry);
        },
        deleteEntry: function (id) {
            entries.delete(findIndex(id));
        }
    };
}

blogApp.service("journalService", journalService);

