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
            getByCodigoAndListaP: getByCodigoAndListaP,
            GetByPrefixListaP: GetByPrefixListaP,
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

        function getByCodigoAndListaP(data) {
            return $http.post(nameSpace + 'ByCodListaP/', data)
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

        function GetByPrefixListaP(data) {
            return $http.post(nameSpace + 'PrefixListaP/', data)
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