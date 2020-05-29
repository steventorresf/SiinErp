(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenEmpresasService', GenEmpresasService);

    GenEmpresasService.$inject = ['$http', '$q'];

    function GenEmpresasService($http, $q) {
        var nameSpace = '/api/Empresas/';
        var service = {
            getAll: getAll,
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

    }
})();