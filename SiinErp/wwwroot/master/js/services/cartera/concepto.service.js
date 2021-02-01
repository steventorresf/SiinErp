(function () {
    'use strict';

    angular
        .module('app')
        .factory('CarConceptoService', CarConceptoService);

    CarConceptoService.$inject = ['$http', '$q'];

    function CarConceptoService($http, $q) {
        var nameSpace = '/Cartera/api/Concepto/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            getByTipDoc: getByTipDoc,
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

        function getByTipDoc(idTipDoc) {
            return $http.get(nameSpace + 'ByTipDoc/' + idTipDoc)
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