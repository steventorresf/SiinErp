(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablasDetService', GenTablasDetService);

    GenTablasDetService.$inject = ['$http', '$q'];

    function GenTablasDetService($http, $q) {
        var nameSpace = '/api/TablasDetalle/';

        var service = {
            getAll: getAll,
            getAllById: getAllById,
            create: create,
            update: update,
            updateOrden: updateOrden,
        };

        return service;

        function getAll(cod) {
            return $http.get(nameSpace + cod)
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

        function getAllById(id) {
            return $http.get(nameSpace + 'ByIdTab/' + id)
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

        function updateOrden(id, orden) {
            return $http.put(nameSpace + 'UpOrd/' + id + '/' + orden)
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