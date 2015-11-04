﻿(function () {
    angular.module('BridgeLessonModule').factory('biddingSystemService', ['$http',
        function biddingSystemFactory($http) {

            var biddingSystemUrlBase = '/api/BiddingSystem/';
            var biddingSequenceUrlBase = '/api/BiddingSequence/';

            var dataFactory = {};

            //Bidding format:
            //{ sequence: 'N:pass;E:1H;S:1P;N:1NT', answer: '7-9 with stopper' }
            dataFactory.getBiddingSystems = function () {
                return $http.get(biddingSystemUrlBase);
            };

            dataFactory.addBiddingSequence = function (newBiddingSequence) {
                return $http.post(biddingSequenceUrlBase, newBiddingSequence);
            };

            dataFactory.getBiddingSystem = function (systemId) {
                return $http.get(biddingSystemUrlBase+systemId);
            };

            dataFactory.getBiddingSequences = function () {
                return $http.get(biddingSequenceUrlBase);
            };

            dataFactory.addBiddingSequenceToSystem = function (biddingSystemId, biddingSequenceId) {
                return $http({
                    method: 'PUT',
                    url: biddingSystemUrlBase + 'AddBiddingSequenceToSystem/' + biddingSystemId + '/' + biddingSequenceId
                });
            };

            dataFactory.removeBiddingSequenceFromSystem = function (biddingSystemId, biddingSequenceId) {
                return $http({
                    method: 'DELETE',
                    url: biddingSystemUrlBase + 'RemoveBiddingSequenceFromSystem/' + biddingSystemId + '/' + biddingSequenceId
                });
            };

            dataFactory.CreateBiddingSystem = function (biddingSystem, systemToCopy) {
                var systemToCopyId = systemToCopy ? systemToCopy.Id : null;
                return $http.post(
                    biddingSystemUrlBase + systemToCopyId,  biddingSystem
                );
            };

            return dataFactory;
            //return $http({
            //    url: '/api/BiddingSystem',
            //    method: 'get',
            //}).then(function (resp) {
            //    return resp.data;
            //});

            //return $resource('/api/BiddingSystem/');
            
            //var myApi = {};

            //myApi.abc = function () {
            //    return $http.get();
            //}
            //$scope.GetHometownFromApi = function () {
            //    var hometownResult = $http({
            //        method: 'GET',
            //        url: 'api/BiddingSystem'
            //    }).then(function successCallback(response) {
            //        $scope.Hometown = response.data;
            //    }, function errorCallback(response) {
            //        $scope.Hometown = "Error on retrieving hometown: " + response.statusText;
            //    });
            //}
            //return $resource('/api/heroes', {}, {
            //    query: { method: 'GET', params: {}, isArray: true }
            //})
            //return [{ sequence: 'N:pass;E:1H;S:1P;N:1NT', answer: '7-9 with stopper' },
            //{ sequence: 'N:1H;E:dbl;S:2NT', answer: '10-12 4+ H!' },
            //{ sequence: 'N:pass;E:1H;S:1P;N:1NT;E:2C!;S:2D!', answer: '7-9 without stopper' }];
            //;
        }
    ]);

}());
