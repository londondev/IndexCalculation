angular.module('app')
    .controller('stockPriceController', ['$scope', 'stockPriceFactory',
        function ($scope, stockPriceFactory) {
            
            $scope.upload = function() {
                var file = $scope.stockData;
                var resultParts = file.split(',');
                var imageBase64 = '';
                if (resultParts.length === 2) {
                    imageBase64 = resultParts[1];
                }

                $scope.asText = $.base64.decode(imageBase64);
                
                var addStockRequest = {
                    FileName: $scope.stockDataFileName,
                    Data : $scope.asText
                };

                stockPriceFactory.upload(addStockRequest);


            };
        }]);