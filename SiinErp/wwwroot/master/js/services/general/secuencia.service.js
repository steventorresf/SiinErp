(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenSecuenciaService', GenSecuenciaService);

    GenSecuenciaService.$inject = ['$http', '$q'];

    function GenSecuenciaService($http, $q) {
        var nameSpace = '/General/api/Secuencia/';

        var service = {
            getStrSecuencia: getStrSecuencia,
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getStrSecuencia(prefijo, idEmpresa) {
            return $http.get(nameSpace + 'GetSec/' + prefijo + '/' + idEmpresa)
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