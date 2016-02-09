angular.module('app')
    .factory('stockPriceFactory', ['$http', function ($http) {
        var urlBase = '/api/stock';
        var stockFactory = {};

        stockFactory.upload = function (addStockRequest) {
            $http.post('/api/IndexData', addStockRequest);
        };

        return stockFactory;
    }]);