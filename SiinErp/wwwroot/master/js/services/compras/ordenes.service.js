(function () {
    'use strict';

    angular
        .module('app')
        .factory('ComOrdenesService', ComOrdenesService);

    ComOrdenesService.$inject = ['$http', '$q'];

    function ComOrdenesService($http, $q) {
        var nameSpace = '/Compras/api/Ordenes/';

        var service = {
            getAll: getAll,
            getPen: getPen,
            create: create,
            update: update,
        };

        return service;

        function getAll(idEmp, fechaIni, fechaFin) {
            return $http.get(nameSpace + idEmp + '/' + fechaIni + '/' + fechaFin)
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

        function getPen(idEmp) {
            return $http.get(nameSpace + 'GetPen/' + idEmp)
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

        function update(id, data) {
            return $http.put(nameSpace + id, data)
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