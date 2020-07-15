(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablasEmpresaDetService', GenTablasEmpresaDetService);

    GenTablasEmpresaDetService.$inject = ['$http', '$q'];

    function GenTablasEmpresaDetService($http, $q) {
        var nameSpace = '/General/api/TablasEmpresaDetalle/';

        var service = {
            getAll: getAll,
            getAllById: getAllById,
            create: create,
            update: update,
            updateOrden: updateOrden,
        };

        return service;

        function getAll(cod, idEmp) {
            return $http.get(nameSpace + 'ByCod/' + cod + '/' + idEmp)
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
            return $http.get(nameSpace + 'ByIdTabEmp/' + id)
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