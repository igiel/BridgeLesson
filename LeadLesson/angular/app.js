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
                { key: 'QJT43', value: 'Q' },
                { key: 'T9', value: 'T' },
                { key: 'T954', value: '9' },
                { key: 'Q32', value: '3' },
                { key: 'T9432', value: '9' },
                { key: 'J987', value: '7' },
                { key: 'QT3', value: 'T' },
                { key: 'KQT42', value: 'K' },
                { key: 'KQT983', value: 'Q' },
                { key: 'AKQ', value: 'A' },
                { key: '97532', value: '7' },
                { key: '9754', value: '7' },
                { key: 'JT6543', value: 'J' },
                { key: 'KJT542', value: 'J' },
                { key: 'T93', value: '9' },
                { key: 'QT9542', value: 'T' },
                { key: 'T842', value: '8' }
                ]
            ;
        }
    ]);

}());

