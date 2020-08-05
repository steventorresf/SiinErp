(function () {
    'use strict';

    angular
        .module('app')
        .factory('InvMovimientosDetalleService', InvMovimientosDetalleService);

    InvMovimientosDetalleService.$inject = ['$http', '$q'];

    function InvMovimientosDetalleService($http, $q) {
        var nameSpace = '/Inventario/api/MovimientosDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idMov) {
            return $http.get(nameSpace + idMov)
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