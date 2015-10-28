(function () {
    'use strict';

    var BiddingSystemController = function ($biddingSystem, $http) {
        var biddingCtrl = this;
        //NESW
        //in answer bbo tokens for color symbols S!,H!,C!,D! 
        biddingCtrl.biddingExamples = //$biddingSystem;
        [{ sequence: 'N:pass;E:1H,S:1P,N:1NT', answer: '7-9 with stopper' },
            { sequence: 'N:1H;E:dbl,S:2NT', answer: '10-12 4+ H!' },
            { sequence: 'N:pass;E:1H,S:1P,N:1NT', answer: '7-9 with stopper' }];

        biddingCtrl.canProceedFurther = false;
        biddingCtrl.canProceedBack = false;
        biddingCtrl.currentProblem = 0;
        biddingCtrl.isChecked = false;
        biddingCtrl.correctAnswerQuestionIsVisible = false;
        biddingCtrl.submitButtonIsVisible = true;
        
        biddingCtrl.submit = function () {
            biddingCtrl.correctAnswerQuestionIsVisible = true;
            biddingCtrl.isChecked = true;
            biddingCtrl.submitButtonIsVisible = false;

        };


        biddingCtrl.correctAnswer = function () {

            biddingCtrl.biddingExamples[biddingCtrl.currentProblem].isCorrect = true;
            biddingCtrl.currentProblem++;
            biddingCtrl.isChecked = false;
            setProceedBackAndFurther();
        };

        biddingCtrl.incorrectAnswer = function () {

            biddingCtrl.biddingExamples[biddingCtrl.currentProblem].isCorrect = false;
            biddingCtrl.currentProblem++;
            biddingCtrl.isChecked = false;
            setProceedBackAndFurther();
        };

        biddingCtrl.proceedBack = function () {
            biddingCtrl.currentProblem--;
            biddingCtrl.isChecked = false;
            setProceedBackAndFurther();
        };

        var setProceedBackAndFurther = function () {
            biddingCtrl.canProceedBack = biddingCtrl.currentProblem > 0;
            //biddingCtrl.canProceedFurther = biddingCtrl.biddingExamples[biddingCtrl.currentProblem].isCorrect != undefined && biddingCtrl.currentProblem < biddingCtrl.biddingExamples.Length;
            biddingCtrl.isLastProblem = isLastProblem();
        };

        function isLastProblem()
        {
            return biddingCtrl.currentProblem >= biddingCtrl.biddingExamples.length;
        }
    };

    BiddingSystemController.$inject = ['leadExamples', '$http'];

    angular.module('LeadLessonModule').controller('BiddingSystemController', BiddingSystemController);

})();
