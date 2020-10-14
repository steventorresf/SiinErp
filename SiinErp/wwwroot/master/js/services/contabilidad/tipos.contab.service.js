(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContTiposDocService', ContTiposDocService);

    ContTiposDocService.$inject = ['$http', '$q'];

    function ContTiposDocService($http, $q) {
        var nameSpace = '/Contabilidad/api/TiposContab/';

        var service = {
            getAll: getAll,
            getTipoDoc: getTipoDoc,
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

       
        function getTipoDoc(idEmp, tipoDoc) {
            return $http.get(nameSpace + 'Get/' + idEmp + '/' + tipoDoc)
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