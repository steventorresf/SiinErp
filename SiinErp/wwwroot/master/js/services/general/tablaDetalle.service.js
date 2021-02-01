(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablaDetService', GenTablaDetService);

    GenTablaDetService.$inject = ['$http', '$q'];

    function GenTablaDetService($http, $q) {
        var nameSpace = '/General/api/TablaDetalle/';

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

        function getAllById(idTab, idEmp) {
            return $http.get(nameSpace + 'ByIdTabEmp/' + idTab + '/' + idEmp)
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