angular.module('app')
    .controller('stockPriceController', ['$scope', 'stockPriceFactory',
        function ($scope, stockPriceFactory) {
            $scope.stockDataList = [];
            $scope.saveModel = function () {
                stockPriceFactory.saveModel($scope.stockData).
                then(function (response) {
                        $scope.stockDataList = response.dataTableData;
                    })}
        }]);