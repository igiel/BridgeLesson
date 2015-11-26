(function () {
    'use strict';

    var conventionController = function ($scope, biddingSystemService) {
        var ctrl = this;
        
        clearConvention();

        ctrl.newSequence = { Sequence: '', Answer: '' };

        ctrl.AddSequence = function() {
            ctrl.newConvention.BiddingSequences.push(ctrl.newSequence);
            ctrl.newSequence = { Sequence: '', Answer: '' };
        }


        ctrl.AddConvention = function () {
            biddingSystemService.addConvention(ctrl.newConvention)
                .then(function (success) {
                    clearConvention();
                    ctrl.msg = 'Convention added!';
                });
        }
        ctrl.removeSequence = function(seq) {
            var indexToRemove = ctrl.newConvention.BiddingSequences.indexOf(seq);
            if (indexToRemove > -1)
                ctrl.newConvention.BiddingSequences.splice(indexToRemove, 1);
        }

        function clearConvention() { 
            ctrl.newConvention = {
                Name: '', Description: '', BiddingSequences:[]
            }
        };

    };

    conventionController.$inject = ['$scope', 'biddingSystemService'];

    angular.module('BridgeLessonModule').controller('ConventionController', conventionController);

    })();