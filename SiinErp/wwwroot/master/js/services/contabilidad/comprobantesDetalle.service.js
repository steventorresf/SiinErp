(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContComprobantesDetService', ContComprobantesDetService);

    ContComprobantesDetService.$inject = ['$http', '$q'];

    function ContComprobantesDetService($http, $q) {
        var nameSpace = '/Contabilidad/api/ComprobantesDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idComp) {
            return $http.get(nameSpace + idComp)
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