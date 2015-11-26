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
            templateUrl: '/Home/addNewBiddingSequence'
        };
    });

    //todo: modal id should be {{targetModalName}}, not hardcoded editSequenceForm :/
    angular.module('BridgeLessonModule').directive('editSequence', function () {
        return {
            scope: {
                sequence: '=',
                targetModalName: '@',
                finish: '&'
            },
            restrict: 'E',
            templateUrl: '/Scripts/templates/edit-sequence.html'
        };
    });


}());

