(function () {
    'use strict';

    var biddingSystemController = function ($scope, biddingSystemService) {

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
                .then(function(sequences) {
                    biddingSystemCtrl.biddingExamples = sequences.data;
                    biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();
                });

           biddingSystemService.getBiddingSystemAsParentChild(biddingSystemCtrl.selectedSystem.Id)
                .then(function (rootBid) {
                biddingSystemCtrl.allBiddingExamplesAsParentChild = rootBid.data;
           });

        };
        
        biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem = function () {
            return biddingSystemCtrl.allBiddingExamples.filter(function (current_a) { return biddingSystemCtrl.biddingExamples.filter(function (current_b) { return current_a.Id == current_b.Id }).length == 0 });
        }
          
        biddingSystemCtrl.createNewSequence = function () {
            var biddingSequence = { sequence: biddingSystemCtrl.newSequence, answer: biddingSystemCtrl.newAnswer};
            biddingSystemService.createBiddingSequence(biddingSequence)
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

                    $("#sequence").focus();
                    
                });
        };
          
        biddingSystemCtrl.endEditingBid = function () {
            biddingSystemCtrl.selectedSequenceMode = null;
        }

        biddingSystemCtrl.cancelCurrentAnswerEditing = function () {
            biddingSystemCtrl.selectedSequenceMode = null;
        }

        biddingSystemCtrl.updateSequence = function (biddingSequence) {
            biddingSystemService.updateBiddingSequence(biddingSequence)
            .then(function (savedBiddingSequence)
            {
                biddingSystemCtrl.selectedSequenceMode = null;
            });
        };

        biddingSystemCtrl.displayName = function (biddingSequence) {
            if (biddingSequence == undefined)
                return "";
            return (biddingSequence.Sequence + " -> " + biddingSequence.Answer);
        }

        biddingSystemCtrl.addSequenceToSystem = function (biddingSequenceToAdd) {
            if (biddingSequenceToAdd == undefined || biddingSystemCtrl.selectedSystem == undefined)
                return;
            biddingSystemService.addBiddingSequenceToSystem(biddingSystemCtrl.selectedSystem.Id, biddingSequenceToAdd.Id)
                .then(function (addedSequence) {
                    biddingSystemCtrl.updateSystem();
                    
                    //biddingSystemCtrl.biddingExamples.push(biddingSequenceToAdd);
                    //biddingSystemCtrl.selectedBiddingSequenceToAdd = '';
                    //biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();

                    //addBiddingSequence(addedSequence.data);
                });
        }

        biddingSystemCtrl.removeBiddingSequenceFromSystem = function (biddingSequenceToRemove) {
            if (biddingSequenceToRemove == undefined || biddingSystemCtrl.selectedSystem == undefined)
                return;
            biddingSystemService.removeBiddingSequenceFromSystem(biddingSystemCtrl.selectedSystem.Id, biddingSequenceToRemove.Id)
                .then(function (success) {
                    biddingSystemCtrl.updateSystem();
                    //var indexToRemove = biddingSystemCtrl.biddingExamples.indexOf(biddingSequenceToRemove);
                    //if (indexToRemove > -1)
                    //    biddingSystemCtrl.biddingExamples.splice(indexToRemove, 1);
                    //biddingSystemCtrl.biddingExamplesNotUsedInSystem = biddingSystemCtrl.diffAllExamplesAndExamplesFromTheCurrentSystem();
                });
        }

        biddingSystemCtrl.CreateBiddingSystem = function () {
            biddingSystemService.CreateBiddingSystem(biddingSystemCtrl.newSystem, biddingSystemCtrl.selectedPrototypeOfNewSystem)
                .then(function(newSystemResponse) {
                    biddingSystemCtrl.allSystems.push(newSystemResponse.data);
                });
        };

        function addBiddingSequence(sequenceToAdd) {
            //splitSequence = sequenceToAdd.BidSequence.split(';');
            //for (var i = 0; i < splitSequence.length; i++)
            //    biddingSystemCtrl.allBiddingExamplesAsParentChild
            biddingSystemCtrl.allBiddingExamplesAsParentChild.RootBid.NextBids.push(sequenceToAdd);

        }
    };

    biddingSystemController.$inject = ['$scope', 'biddingSystemService'];

    angular.module('BridgeLessonModule').controller('BiddingSystemController', biddingSystemController);

})();
