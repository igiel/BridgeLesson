(function () {
    'use strict';

    var BiddingSystemController = function (biddingSystemService) {

        var biddingCtrl = this;

        //NESW
        //in answer bbo tokens for color symbols should be converted from S!,H!,C!,D! 
        
        biddingSystemService.getBiddingSystem()
            .then(function (sequences) {
                biddingCtrl.biddingExamples = sequences.data;
            });

          
        biddingCtrl.submit = function () {
            var biddingSequence = { sequence: biddingCtrl.newSequence, answer: biddingCtrl.newAnswer };
            biddingSystemService.addBiddingSequence(biddingSequence)
            .then(function (sequences) {
                biddingCtrl.biddingExamples.push(biddingSequence);
                biddingCtrl.newSequence = '';
                biddingCtrl.newAnswer = '';
            });
        };

    };

    BiddingSystemController.$inject = ['biddingSystemService'];

    angular.module('BridgeLessonModule').controller('BiddingSystemController', BiddingSystemController);

})();
