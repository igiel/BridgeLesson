(function () {
    angular.module('BridgeLessonModule').directive('biddingQuiz', function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/bidding-quiz.cshtml'
        };
    });

    angular.module('BridgeLessonModule').directive('biddingQuizResults', function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/bidding-quiz-results.cshtml'
        };
    });

    angular.module('BridgeLessonModule').directive('addNewSystemControl', function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/add-new-system-control.cshtml'
        };
    });

    angular.module('BridgeLessonModule').directive('addNewBiddingSequence', function () {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/add-new-bidding-sequence.html'
        };
    });

}());

