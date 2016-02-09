(function () {
    'use strict';

    var app = angular.module('app', ['ngResource', 'ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.when('/stockPrice', {

            templateUrl: 'app/stockprice/templates/stockPrice.html',
            controller: 'stockPriceController',
            controllerAs: 'vm',
            caseInsensitiveMatch: true
        });
        $routeProvider.otherwise({
            redirectTo: '/stockPrice'
        });
    }]);
})();