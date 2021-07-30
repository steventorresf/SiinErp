(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenListaPrecioDetalleService', VenListaPrecioDetalleService);

    VenListaPrecioDetalleService.$inject = ['$http', '$q'];

    function VenListaPrecioDetalleService($http, $q) {
        var nameSpace = '/Ventas/api/ListaPrecioDetalle/';
       

        var service = {
            getAll: getAll,
            getAllByPrefix: getAllByPrefix,
            create: create,
            update: update,
            remove: remove,
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

        function getAllByPrefix(data) {
            return $http.post(nameSpace + 'ByPrefix/', data)
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
            console.log("camiaaaaa",id, data);
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
            console.log(id);
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