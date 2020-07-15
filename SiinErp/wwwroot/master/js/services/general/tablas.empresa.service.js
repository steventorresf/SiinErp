(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablasEmpresaService', GenTablasEmpresaService);

    GenTablasEmpresaService.$inject = ['$http', '$q'];

    function GenTablasEmpresaService($http, $q) {
        var nameSpace = '/General/api/TablasEmpresa/';

        var service = {
            getAll: getAll,
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