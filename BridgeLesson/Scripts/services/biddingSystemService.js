(function () {
    angular.module('BridgeLessonModule').factory('biddingSystemService', ['$http',
        function biddingSystemFactory($http) {

            var biddingSystemUrlBase = '/api/BiddingSystem/';
            var biddingSequenceUrlBase = '/api/BiddingSequence/';
            var biddingConventionUrlBase = '/api/BiddingConvention/';

            var dataFactory = {};

            //Bidding format:
            //{ sequence: 'N:pass;E:1H;S:1P;N:1NT', answer: '7-9 with stopper' }
            dataFactory.getBiddingSystems = function () {
                return $http.get(biddingSystemUrlBase);
            };

            dataFactory.updateBiddingSequence = function (newBiddingSequence) {
                return $http.put(biddingSequenceUrlBase + newBiddingSequence.Id, newBiddingSequence);
            };
            dataFactory.createBiddingSequence = function (newBiddingSequence) {
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
            dataFactory.addBiddingConventionToSystem = function (biddingSystemId, biddingConventionId) {
                return $http({
                    method: 'PUT',
                    url: biddingSystemUrlBase + 'AddBiddingConventionToSystem/' + biddingSystemId + '/' + biddingConventionId
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
            
            dataFactory.getBiddingConventions = function () {
                return $http.get(
                    biddingConventionUrlBase 
                );
            };

            dataFactory.getBiddingSystemAsParentChild = function (systemId) {
                return $http.get(biddingSystemUrlBase+'AsParentChild/'+systemId);
            };
            

            return dataFactory;
            
        }
    ]);

}());

