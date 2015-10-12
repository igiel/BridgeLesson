(function () {
    var LeadLessonModule = angular.module('LeadLessonModule', []);

   
    angular.module('LeadLessonModule').filter('Tto10', function () {
      return function (text) {
          return text ? text.replace('T', '10') : '';
      };
    });
        
    //We already have a limitTo filter built-in to angular,
    //let's make a startFrom filter
    angular.module('LeadLessonModule').filter('startFrom', function () {
        return function (input, start) {
            start = +start; //parse to int
            return input.slice(start);
        }
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

