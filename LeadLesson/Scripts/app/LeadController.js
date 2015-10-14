(function () {
    'use strict';

    var LeadController = function ($scope, $leadExamples) {
        var LeadDistributionDict = $leadExamples;

        $scope.canProceedFurther = false;
        $scope.canProceedBack = false;
        $scope.currentPage = 0;
        $scope.pageSize = 7;

        $scope.LeadDistribution = LeadDistributionDict;

        $scope.submit = function () {
            $scope.validationMessage = '';
            var startValue = $scope.currentPage * $scope.pageSize;
            var endValue = $scope.LeadDistribution.length > startValue + $scope.pageSize ? startValue + $scope.pageSize : $scope.LeadDistribution.length;

            var allExamplesCorrect = true;
            for (var i = startValue; i < endValue; i++) {
                var distribution = $scope.LeadDistribution[i];
                distribution.correct = distribution.chosenValue == distribution.value;
                if (!distribution.correct)
                    allExamplesCorrect = false;
            }
            
            if(allExamplesCorrect && $scope.LeadDistribution.length <= startValue + $scope.pageSize)
            {
                $scope.validationMessage = 'Well done! You did it all corect. Now it is the time to send it to your partner and compare your scores.';
                return;
            }
            
            if(allExamplesCorrect)
            {
                $scope.validationMessage = 'Well done! Would it be so easy also for a next set?';
                $scope.canProceedFurther = allExamplesCorrect;
            }
            else
                $scope.validationMessage = 'Are you sure?';
        };

        $scope.proceedToTheNext = function () {
            $scope.currentPage++;
            setProceedBackAndFurther();
        }

        $scope.proceedBack = function () {
            $scope.currentPage--;
            setProceedBackAndFurther();
        }
        
        var setProceedBackAndFurther = function () {
            $scope.canProceedBack = $scope.currentPage > 0;

            var startValue = $scope.currentPage * $scope.pageSize;
            var endValue = $scope.LeadDistribution.length > startValue + $scope.pageSize ? startValue + $scope.pageSize : $scope.LeadDistribution.length;

            var allExamplesCorrect = true;
            for (var i = startValue; i < endValue; i++) {
                var distribution = $scope.LeadDistribution[i];
                if (!distribution.correct)
                    allExamplesCorrect = false;
            }
            $scope.canProceedFurther = allExamplesCorrect && $scope.LeadDistribution.length >= endValue;
        }
    };

    LeadController.$inject = ['$scope', 'leadExamples'];

    angular.module('LeadLessonModule').controller('LeadController', LeadController);

})();
