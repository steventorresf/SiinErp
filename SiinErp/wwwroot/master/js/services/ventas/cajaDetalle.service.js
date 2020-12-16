(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenCajaDetService', VenCajaDetService);

    VenCajaDetService.$inject = ['$http', '$q'];

    function VenCajaDetService($http, $q) {
        var nameSpace = '/Ventas/api/CajaDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            getCantidadDetalleCaja: getCantidadDetalleCaja,
        };

        return service;

        function getAll(idCaja) {
            return $http.get(nameSpace + idCaja)
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

        function getCantidadDetalleCaja(idCaja) {
            return $http.get(nameSpace + 'GetCantDetCaja/' + idCaja)
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