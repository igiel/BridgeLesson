(function () {
    'use strict';

    var BiddingSystemController = function (biddingSystemService) {

        var biddingSystemCtrl = this;

        //NESW
        //in answer bbo tokens for color symbols should be converted from S!,H!,C!,D! 
        
        biddingSystemService.getBiddingSystems()
            .then(function (allSystems) {
                biddingSystemCtrl.allSystems = allSystems.data;
            });
                

        biddingSystemCtrl.updateSystem = function () {
            if (biddingSystemCtrl.selectedSystem == undefined)
            {
                biddingSystemCtrl.biddingExamples = null;
                return;
            }

        biddingSystemService.getBiddingSystem(biddingSystemCtrl.selectedSystem.Id)
            .then(function (sequences) {
                biddingSystemCtrl.biddingExamples = sequences.data;
            })
        };

        biddingSystemService.getBiddingSequences()
            .then(function (sequences) {
                biddingSystemCtrl.allBiddingExamples = sequences.data;
            });
        

          
        biddingSystemCtrl.submit = function () {
            var biddingSequence = { sequence: biddingSystemCtrl.newSequence, answer: biddingSystemCtrl.newAnswer};
            biddingSystemService.addBiddingSequence(biddingSequence)
            .then(function (savedBiddingSequence) {
                biddingSystemCtrl.newSequence = '';
                biddingSystemCtrl.newAnswer = '';
                var selectedSystemId = biddingSystemCtrl.selectedSystem != undefined ? biddingSystemCtrl.selectedSystem.Id : null;
                if (selectedSystemId == undefined)
                    biddingSystemCtrl.allBiddingExamples.push(savedBiddingSequence.data);
                else
                    biddingSystemCtrl.addSequenceToSystem(savedBiddingSequence.data);
               
            });
        };

        biddingSystemCtrl.displayName = function (biddingSequence) {
            if (biddingSequence == undefined)
                return "";
            return (biddingSequence.Sequence + " -> " + biddingSequence.Answer)
        }

        biddingSystemCtrl.addSequenceToSystem = function (biddingSequenceToAdd) {
            if (biddingSequenceToAdd == undefined || biddingSystemCtrl.selectedSystem == undefined)
                return;
            biddingSystemService.addBiddingSequenceToSystem(biddingSystemCtrl.selectedSystem.Id, biddingSequenceToAdd.Id)
                .then(function (success)
                {
                    biddingSystemCtrl.biddingExamples.push(biddingSequenceToAdd);
                    biddingSystemCtrl.selectedBiddingSequenceToAdd = '';
                });
        }
    };

    BiddingSystemController.$inject = ['biddingSystemService'];

    angular.module('BridgeLessonModule').controller('BiddingSystemController', BiddingSystemController);

})();
