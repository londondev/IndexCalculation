(function () {
    'use strict';

    var app = angular.module('app', ['ngResource', 'ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.when('/stockPrice', {
            templateUrl: '/app/stockprice/templates/stockPrice.html',
            controller: 'stockPriceController',
            controllerAs: 'vm',
            caseInsensitiveMatch: true
        });
        $routeProvider.otherwise({
            redirectTo: '/stockPrice'
        });
    }]);
    
    app.directive("fileread", [
    function () {
        return {
            scope: {
                fileread: "="
            },
            link: function (scope, element, attributes) {
                element.bind("change", function (changeEvent) {
                    var reader = new FileReader();
                    reader.onload = function (loadEvent) {
                        scope.$apply(function () {
                            scope.fileread = loadEvent.target.result;
                        });
                    };
                    reader.readAsDataURL(changeEvent.target.files[0]);
                });
            }
        };
    }
    ]);

})();

