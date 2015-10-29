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

    //todo: directive and div xs-3 per each row?
    //format: 'N:1H;E:dbl,S:2NT'
    angular.module('BridgeLessonModule').filter('bidding', ['$sce',function ($sce) {
        return function (text) {
            var bids = text.split(';');
            var result = '<table><tbody><tr><th>N</th><th>E</th><th>S</th><th>W</th>'
            for (var i = 0; i < bids.length; i++) {
                if (i % 4 == 0)
                    result+='</tr><tr>';
                var bid = bids[i].split(':');
                result+='<td>' + bid[1] + '</td>';
            }
            result += '</tr></tbody></table>';

            return $sce.trustAsHtml(result); 
        };
    }]);
}());

