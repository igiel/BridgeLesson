(function () {
    'use strict';

    var editSequenceController = function ($scope) {

        var Bid = function(_value, _level, _color) {
            this.value = _value;
            this.level = _level;
            this.color = _color;
            this.active = true;
        };

        var ctrl = this;
        var colors = ['C!', 'D!', 'H!', 'S!', 'NT'];
        var levels = [1, 2, 3, 4, 5, 6, 7];
        
        $scope.allBids = [];
        for (var i = 0; i < levels.length; i++) {
            var bids = [];
            for (var j = 0; j < colors.length; j++) {
                bids.push(new Bid(levels[i] + colors[j], levels[i], colors[j]));
            }
            $scope.allBids.push(bids);
        }
        $scope.allBids.push([new Bid('pass'), new Bid('dbl'), new Bid('rdbl')]);

        ctrl.SymbolClicked = function(bid) {
            if (!$scope.sequence.Sequence)
                $scope.sequence.Sequence = bid.value;
            else {

                if ($scope.sequence.Sequence.slice(-1) !== ';')
                    $scope.sequence.Sequence += ';';

                $scope.sequence.Sequence += bid.value;
            }
        }

    };

    editSequenceController.$inject = ['$scope'];

    angular.module('BridgeLessonModule').controller('EditSequenceController', editSequenceController);

})();
