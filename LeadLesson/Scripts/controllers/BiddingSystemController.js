(function () {
    'use strict';

    var BiddingSystemController = function ($biddingSystemService, $http) {

        var biddingCtrl = this;

        $biddingSystemService.getBiddingSystem()
           .success(function (custs) {
               biddingCtrl.biddingExamples = custs;
           })
           .error(function (error) {
               $scope.status = 'Unable to load customer data: ' + error.message;
           });

       
        //NESW
        //in answer bbo tokens for color symbols S!,H!,C!,D! 
        //biddingCtrl.biddingExamples = $biddingSystemService;
        //[{ sequence: 'N:pass;E:1H;S:1P;N:1NT', answer: '7-9 with stopper' },
        //    { sequence: 'N:1H;E:dbl;S:2NT', answer: '10-12 4+ H!' },
        //    { sequence: 'N:pass;E:1H;S:1P;N:1NT;E:2C!;S:2D!', answer: '7-9 with stopper' }];

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
