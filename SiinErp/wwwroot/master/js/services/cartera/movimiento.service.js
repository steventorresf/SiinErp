(function () {
    'use strict';

    angular
        .module('app')
        .factory('CarMovimientoService', CarMovimientoService);

    CarMovimientoService.$inject = ['$http', '$q'];

    function CarMovimientoService($http, $q) {
        var nameSpace = '/Cartera/api/Movimiento/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            anular: anular,
        };

        return service;

        function getAll(idEmp, fechaIni, fechaFin) {
            return $http.get(nameSpace + idEmp + '/' + fechaIni + '/' + fechaFin + '/')
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

        function anular(idMov, nomUsu) {
            return $http.put(nameSpace + 'An/' + idMov + '/' + nomUsu)
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