(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenFacturasService', VenFacturasService);

    VenFacturasService.$inject = ['$http', '$q'];

    function VenFacturasService($http, $q) {
        var nameSpace = '/Ventas/api/FacturasVen/';

        var service = {
            getLastAlm: getLastAlm,
            getPendientesCli: getPendientesCli,
            getByFecha: getByFecha,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getLastAlm(idUsu) {
            return $http.get(nameSpace + 'LastAlm/' + idUsu)
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

        function getPendientesCli(idCli) {
            return $http.get(nameSpace + 'PenCli/' + idCli)
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

        function getByFecha(idEmp, fecha) {
            return $http.get(nameSpace + 'ByFecha/' + idEmp + '/' + fecha)
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

        function remove(id) {
            return $http.delete(nameSpace + id)
                .then(
                    function (response) {
                        return response;
                        window.location.reload();
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }
    }
})();