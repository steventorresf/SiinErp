(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTiposDocService', GenTiposDocService);

    GenTiposDocService.$inject = ['$http', '$q'];

    function GenTiposDocService($http, $q) {
        var nameSpace = '/General/api/TiposDocumento/';

        var service = {
            getAll: getAll,
            getByCod: getByCod,
            getByModulo: getByModulo,
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

        function getByCod(idEmp, cod) {
            return $http.get(nameSpace + 'ByCod/' + idEmp + '/' + cod)
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

        function getByModulo(idEmp, codMod) {
            return $http.get(nameSpace + 'ByCodMod/' + idEmp + '/' + codMod)
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