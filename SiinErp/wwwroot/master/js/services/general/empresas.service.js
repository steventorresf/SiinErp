(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenEmpresasService', GenEmpresasService);

    GenEmpresasService.$inject = ['$http', '$q'];

    function GenEmpresasService($http, $q) {
        var nameSpace = '/General/api/Empresas/';

        var service = {
            getAll: getAll,
            getAct: getAct,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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

        function getAct() {
            return $http.get(nameSpace + 'Act/')
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