(function () {
    'use strict';

    var LeadController = function ($scope, $leadExamples) {
        var LeadDistributionDict = $leadExamples;

        $scope.currentPage = 0;
        $scope.pageSize = 5;

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
                $scope.validationMessage = 'Well done! You did it all corect. Now it is the time to send it to your partner.';
                return;
            }
            if (allExamplesCorrect && $scope.LeadDistribution.length > startValue )
                $scope.currentPage++;
            
            $scope.validationMessage = allExamplesCorrect ? 'Well done! And those?' : 'Are you sure?';
        };
    };

    LeadController.$inject = ['$scope', 'leadExamples'];

    angular.module('LeadLessonModule').controller('LeadController', LeadController);

})();
