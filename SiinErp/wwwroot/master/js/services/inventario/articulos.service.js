(function () {
    'use strict';

    angular
        .module('app')
        .factory('InvArticulosService', InvArticulosService);

    InvArticulosService.$inject = ['$http', '$q'];

    function InvArticulosService($http, $q) {
        var nameSpace = '/Inventario/api/Articulos/';

        var service = {
            getAll: getAll,
            getByCodigo: getByCodigo,
            getAllByPrefix: getAllByPrefix,
            getAllByAlmPrefix: getAllByAlmPrefix,
            create: create,
            update: update,
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

        function getByCodigo(data) {
            return $http.post(nameSpace + 'ByCod/', data)
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

        function getAllByPrefix(data) {
            return $http.post(nameSpace + 'Prefix/', data)
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

        function getAllByAlmPrefix(data) {
            return $http.post(nameSpace + 'ByAlmPrefix/', data)
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