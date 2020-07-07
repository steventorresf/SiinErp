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
            create: create,
            update: update,
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