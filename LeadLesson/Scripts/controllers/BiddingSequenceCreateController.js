(function () {
    'use strict';

    var biddingSequenceCreateController = function ($scope) {

        var Bid = function(_value, _level, _color) {
            this.value = _value;
            this.level = _level;
            this.color = _color;
            this.active = true;
        };

        var ctrl = this;
        var colors = ['C!', 'D!', 'H!', 'S!', 'NT'];
        var levels = [1, 2, 3, 4, 5, 6, 7];
        //var specialBids = ['pass', 'dbl', 'rdbl'];

        $scope.allBids = [];
        for (var i = 0; i < levels.length; i++) {
            var bids = [];
            for (var j = 0; j < colors.length; j++) {
                bids.push(new Bid(levels[i] + colors[j], levels[i], colors[j]));
            }
            $scope.allBids.push(bids);
        }
        $scope.allBids.push([new Bid('pass'), new Bid('dbl'), new Bid('rdbl')]);

        ctrl.SymbolClicked = function (bid) {
            if (!$scope.newSequence.Sequence)
                $scope.newSequence.Sequence = bid.value;
            else 
                $scope.newSequence.Sequence = $scope.newSequence.Sequence + ';' + bid.value;
        }
    };

    biddingSequenceCreateController.$inject = ['$scope'];

    angular.module('BridgeLessonModule').controller('BiddingSequenceCreateController', biddingSequenceCreateController);

})();
