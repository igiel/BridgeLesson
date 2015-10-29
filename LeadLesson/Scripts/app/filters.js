(function () {
    angular.module('BridgeLessonModule').filter('Tto10', function () {
      return function (text) {
          return text ? text.replace('T', '10') : '';
      };
    });
        
    //We already have a limitTo filter built-in to angular,
    //let's make a startFrom filter
    angular.module('BridgeLessonModule').filter('startFrom', function () {
        return function (input, start) {
            start = +start; //parse to int
            return input.slice(start);
        }
    });
}());

