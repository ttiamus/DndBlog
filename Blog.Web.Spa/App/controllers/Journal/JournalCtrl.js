function JournalCtrl($http) {
    var vm = this;

    vm.postsOnPage = 0;

    vm.recentEntries = [
        { "Id": "1", "Date": "01/01/1000", "LastEdited": "01/01/1000", "Character": "Character1", "Body": "Normally, both your asses would be dead as fucking fried chicken, but you happen to pull this shit while I'm in a transitional period so I don't wanna kill you, I wanna help you. But I can't give you this case, it don't belong to me. Besides, I've already been through too much shit this morning over this case to hand it over to your dumb ass." },
        { "Id": "2", "Date": "02/02/2000", "LastEdited": "01/01/1000", "Character": "Character2", "Body": "Well, the way they make shows is, they make one show. That show's called a pilot. Then they show that show to the people who make shows, and on the strength of that one show they decide if they're going to make more shows. Some pilots get picked and become television programs. Some don't, become nothing. She starred in one of the ones that became nothing." },
        { "Id": "3", "Date": "03/03/3000", "LastEdited": "01/01/1000", "Character": "Character3", "Body": "My money's in that office, right? If she start giving me some bullshit about it ain't there, and we got to go someplace else and get it, I'm gonna shoot you in the head then and there. Then I'm gonna shoot that bitch in the kneecaps, find out where my goddamn money is. She gonna tell me too. Hey, look at me when I'm talking to you, motherfucker. You listen: we go in there, and that nigga Winston or anybody else is in there, you the first motherfucker to get shot. You understand?" },
        { "Id": "4", "Date": "04/04/4000", "LastEdited": "01/01/1000", "Character": "Character4", "Body": "You think water moves fast? You should see ice. It moves like it has a mind. Like it knows it killed the world once and got a taste for murder. After the avalanche, it took us a week to climb out. Now, I don't know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. Now we took an oath, that I'm breaking now. We said we'd say it was the snow that killed the other two, but it wasn't. Nature is lethal but it doesn't hold a candle to man." },
        { "Id": "5", "Date": "05/05/5000", "LastEdited": "01/01/1000", "Character": "Character5", "Body": "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that's what you see at a toy store. And you must think you're in a toy store, because you're here shopping for an infant named Jeb." }
    ];

    vm.getNextFiveEntries = function() {
        $http({
            method: "GET",
            url: "/api/Journal"
        }).then(function successCallback(response) {
            vm.recentEntries = response.data;
        }, function errorCallback(response) {
            console.log("error");
        });
    }
}

blogApp.controller("JournalCtrl", JournalCtrl); 