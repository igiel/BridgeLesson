(function () {
    angular.module('BridgeLessonModule').directive('biddingQuiz',function()
    {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/bidding-quiz.html'
        };
    })
    
    angular.module('BridgeLessonModule').directive('biddingQuizResults', function () {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/bidding-quiz-results.html'
        };
    })
    angular.module('BridgeLessonModule').directive('addNewSystemControl', function () {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/templates/add-new-system-control.html'
        };
    })

}());

