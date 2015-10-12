(function () {
    var LeadLessonModule = angular.module('LeadLessonModule', []);

    var LeadController = function ($scope, $leadExamples) {
        var LeadDistributionDict = $leadExamples;

        $scope.LeadDistribution = LeadDistributionDict;

        $scope.submit = function () {
            $scope.validationMessage = '';
            var allExamplesCorrect = true;
            for (var i = 0; i < $scope.LeadDistribution.length; i++) {
                var distribution = $scope.LeadDistribution[i];
                distribution.correct = distribution.chosenValue == distribution.value;
                if (!distribution.correct)
                    allExamplesCorrect = false;
            }
            $scope.validationMessage = allExamplesCorrect ? 'Well done!' : 'Are you sure?';
        };
    };

    LeadController.$inject = ['$scope','leadExamples'];

    angular.module('LeadLessonModule').controller('LeadController', LeadController);

    angular.module('LeadLessonModule')
    .filter('Tto10', function () {
      return function (text) {
          return text ? text.replace('T', '10') : '';
      };
    });

    
    angular.module('LeadLessonModule').factory('leadExamples', [
        function leadExamplesFactory() {

            var myApi = {};

            myApi.abc = function () {
                return $http.get();
            }
            //return $resource('/api/heroes', {}, {
            //    query: { method: 'GET', params: {}, isArray: true }
            //})
            return [
                { key: 'AK', value: 'A' },
                { key: 'DWT43', value: 'D' },
                { key: 'T9', value: 'T' },
                { key: 'T954', value: '9' },
                { key: 'Q32', value: '3' },
                { key: 'T9432', value: '9' },
                { key: 'W987', value: '7' },
                { key: 'QT3', value: 'T' },
                { key: 'KDT42', value: 'K' },
                { key: 'KDT983', value: 'D' },
                { key: 'AKD', value: 'A' },
                { key: '97532', value: '7' },
                { key: '9754', value: '7' },
                { key: 'WT6543', value: 'W' },
                { key: 'KWT542', value: 'W' }
                ]
            ;
        }
    ]);

}());

