var Entry = function () {
    return {
        restrict: "A",
        replace: "false",
        templateUrl: "/../Templates/Journal/Entry.html"
    };
}

blogApp.directive("entry", Entry);