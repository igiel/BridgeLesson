(function () {
    'use strict';

    var BiddingQuizController = function (biddingSystemService, $http) {

        var biddingCtrl = this;

        //NESW
        //in answer bbo tokens for color symbols should be converted from S!,H!,C!,D! 
        biddingSystemService.getBiddingSystems()
            .then(function (allSystems) {
                biddingCtrl.allSystems = allSystems.data;
            });

        biddingCtrl.updateSystem = function () {
            if (biddingCtrl.selectedSystem == undefined) {
                biddingCtrl.biddingExamples = null;
                return;
            }

            biddingSystemService.getBiddingSystem(biddingCtrl.selectedSystem.Id)
                .then(function(sequences) {
                    biddingCtrl.biddingExamples = sequences.data;
                    if (biddingCtrl.biddingExamples) {
                        shuffleArray(biddingCtrl.biddingExamples);
                    }
                    resetValues();
                });
        };
          
        resetValues();
        
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

        var setProceedBackAndFurther = function () {
            biddingCtrl.canProceedBack = biddingCtrl.currentProblem > 0;
        };

        biddingCtrl.proceedBack = function () {
            biddingCtrl.currentProblem--;
            biddingCtrl.isChecked = false;
            setProceedBackAndFurther();
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

        function resetValues() {
            biddingCtrl.canProceedFurther = false;
            biddingCtrl.canProceedBack = false;
            biddingCtrl.currentProblem = 0;
            biddingCtrl.isChecked = false;
            biddingCtrl.correctAnswerQuestionIsVisible = false;
            biddingCtrl.submitButtonIsVisible = true;
            biddingCtrl.allProblemsSolved = isLastProblem();
        }

        function isLastProblem()
        {
            if (biddingCtrl.biddingExamples == undefined)
                return false;
            return biddingCtrl.currentProblem >= biddingCtrl.biddingExamples.length;
        }

        // -> Fisher–Yates shuffle algorithm
        function shuffleArray(array) {
            var m = array.length, t, i;

            // While there remain elements to shuffle
            while (m) {
                // Pick a remaining element…
                i = Math.floor(Math.random() * m--);

                // And swap it with the current element.
                t = array[m];
                array[m] = array[i];
                array[i] = t;
            }

            return array;
        }

    };

    BiddingQuizController.$inject = ['biddingSystemService', '$http'];

    angular.module('BridgeLessonModule').controller('BiddingQuizController', BiddingQuizController);

})();
