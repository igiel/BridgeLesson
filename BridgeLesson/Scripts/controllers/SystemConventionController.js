(function () {
    'use strict';

    var systemConventionController = function ($scope, biddingSystemService) {
        var ctrl = this;
        ctrl.selectedSystem = $scope.$parent.$parent.biddingSystemCtrl.selectedSystem;

        biddingSystemService.getBiddingConventions()
            .then(function (allConventions) {
                ctrl.allConventions = allConventions.data;
            });

        biddingSystemService.getBiddingConventionsFromSystem(ctrl.selectedSystem.Id)
            .then(function(systemConventions) {
                ctrl.systemConventions = systemConventions.data;
            });

    };

    systemConventionController.$inject = ['$scope', 'biddingSystemService'];

    angular.module('BridgeLessonModule').controller('SystemConventionController', systemConventionController);

    })();