(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenPeriodosService', GenPeriodosService);

    GenPeriodosService.$inject = ['$http', '$q'];

    function GenPeriodosService($http, $q) {
        var nameSpace = '/General/api/Periodos/';

        var service = {
            getAll: getAll,
            create: create,
        };

        return service;

        function getAll(idEmp) {
            return $http.get(nameSpace + idEmp)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function create(data) {
            return $http.post(nameSpace, data)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }
    }
})();