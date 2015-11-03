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
                
        biddingSystemService.getBiddingSequences()
            .then(function (sequences) {
                biddingSystemCtrl.allBiddingExamples = sequences.data;
                biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.allBiddingExamples;
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
                    biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();
                })
        };
        
        biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem = function () {
            return biddingSystemCtrl.allBiddingExamples.filter(function (current_a) { return biddingSystemCtrl.biddingExamples.filter(function (current_b) { return current_a.Id == current_b.Id }).length == 0 });
        }
          
        biddingSystemCtrl.submit = function () {
            var biddingSequence = { sequence: biddingSystemCtrl.newSequence, answer: biddingSystemCtrl.newAnswer};
            biddingSystemService.addBiddingSequence(biddingSequence)
            .then(function (savedBiddingSequence) {
                biddingSystemCtrl.newSequence = '';
                biddingSystemCtrl.newAnswer = '';
                var selectedSystemId = biddingSystemCtrl.selectedSystem != undefined ? biddingSystemCtrl.selectedSystem.Id : null;
                biddingSystemCtrl.allBiddingExamples.push(savedBiddingSequence.data);
                if (selectedSystemId == undefined)
                {
                    biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();
                }
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
                    biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();
                });
        }

        biddingSystemCtrl.removeBiddingSequenceFromSystem = function (biddingSequenceToRemove) {
            if (biddingSequenceToRemove == undefined || biddingSystemCtrl.selectedSystem == undefined)
                return;
            biddingSystemService.removeBiddingSequenceFromSystem(biddingSystemCtrl.selectedSystem.Id, biddingSequenceToRemove.Id)
                .then(function (success) {
                    var indexToRemove = biddingSystemCtrl.biddingExamples.indexOf(biddingSequenceToRemove);
                    if (indexToRemove > -1)
                        biddingSystemCtrl.biddingExamples.splice(indexToRemove, 1);
                    biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();
                });
        }

        biddingSystemCtrl.CreateBiddingSystem = function () {
            biddingSystemService.CreateBiddingSystem(biddingSystemCtrl.newSystem, biddingSystemCtrl.selectedPrototypeOfNewSystem)
                .then(function (newSystemResponse) {
                    biddingSystemCtrl.allSystems.push(newSystemResponse.data);
                })
        };
    };

    BiddingSystemController.$inject = ['biddingSystemService'];

    angular.module('BridgeLessonModule').controller('BiddingSystemController', BiddingSystemController);

})();
