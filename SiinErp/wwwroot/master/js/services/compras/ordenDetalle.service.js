(function () {
    'use strict';

    angular
        .module('app')
        .factory('ComOrdenDetService', ComOrdenDetService);

    ComOrdenDetService.$inject = ['$http', '$q'];

    function ComOrdenDetService($http, $q) {
        var nameSpace = '/Compras/api/OrdenDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getAll(idOrd) {
            return $http.get(nameSpace + idOrd)
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
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }
    }
})();