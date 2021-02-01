(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContComprobanteService', ContComprobanteService);

    ContComprobanteService.$inject = ['$http', '$q'];

    function ContComprobanteService($http, $q) {
        var nameSpace = '/Contabilidad/api/Comprobantes/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            anular: anular,
        };

        return service;

        function getAll(idEmp, fechaI, fechaF) {
            return $http.get(nameSpace + idEmp + '/' + fechaI + '/' + fechaF)
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

        function anular(id, modificadoPor) {
            return $http.delete(nameSpace + id + '/' + modificadoPor)
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