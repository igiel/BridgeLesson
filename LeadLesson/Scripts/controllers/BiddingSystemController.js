(function () {
    'use strict';

    var BiddingSystemController = function (biddingSystemService, $http) {

        var biddingCtrl = this;

        //NESW
        //in answer bbo tokens for color symbols should be converted from S!,H!,C!,D! 
        
        biddingSystemService.getBiddingSystem()
            .then(function (sequences) {
                biddingCtrl.biddingExamples = sequences.data;
            });

          
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
            proceedToTheNext(true);
        };

        biddingCtrl.incorrectAnswer = function () {
            proceedToTheNext(false);
        };


        biddingCtrl.proceedBack = function () {
            biddingCtrl.currentProblem--;
            biddingCtrl.isChecked = false;
            setProceedBackAndFurther();
        };

        var setProceedBackAndFurther = function () {
            biddingCtrl.canProceedBack = biddingCtrl.currentProblem > 0;
            //biddingCtrl.canProceedFurther = biddingCtrl.biddingExamples[biddingCtrl.currentProblem].isCorrect != undefined && biddingCtrl.currentProblem < biddingCtrl.biddingExamples.Length;
        };

        biddingCtrl.solvedCount = function () {
            var correctCount = 0;
            for (var example in biddingCtrl.biddingExamples) {
                if (biddingCtrl.biddingExamples[example].isCorrect)
                    correctCount++;
            }
            return correctCount;
        }

        function proceedToTheNext(currentAnsweredCorrectly)
        {
            biddingCtrl.biddingExamples[biddingCtrl.currentProblem].isCorrect = currentAnsweredCorrectly;
            biddingCtrl.currentProblem++;
            biddingCtrl.isChecked = false;
            setProceedBackAndFurther();
            biddingCtrl.allProblemsSolved = isLastProblem();
        }

        function isLastProblem()
        {
            return biddingCtrl.currentProblem >= biddingCtrl.biddingExamples.length;
        }


    };

    BiddingSystemController.$inject = ['biddingSystemService', '$http'];

    angular.module('BridgeLessonModule').controller('BiddingSystemController', BiddingSystemController);

})();
