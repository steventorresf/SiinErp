(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenCiudadService', GenCiudadService);

    GenCiudadService.$inject = ['$http', '$q'];

    function GenCiudadService($http, $q) {
        var nameSpace = '/General/api/Ciudad/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idDep) {
            return $http.get(nameSpace + idDep)
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