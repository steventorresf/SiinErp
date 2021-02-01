(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenPeriodoService', GenPeriodoService);

    GenPeriodoService.$inject = ['$http', '$q'];

    function GenPeriodoService($http, $q) {
        var nameSpace = '/General/api/Periodo/';

        var service = {
            getAll: getAll,
            getSig: getSig,
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

        function getSig(idEmp, codMod) {
            return $http.get(nameSpace + 'GetSig/' + idEmp + '/' + codMod)
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