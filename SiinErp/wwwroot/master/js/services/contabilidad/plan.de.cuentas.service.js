(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContPlanDeCuentaService', ContPlanDeCuentaService);

    ContPlanDeCuentaService.$inject = ['$http', '$q'];

    function ContPlanDeCuentaService($http, $q) {
        var nameSpace = '/Contabilidad/api/PlanDeCuentas/';

        var service = {
            getAll: getAll,
            getAllByNivel: getAllByNivel,
            getPlan: getPlan,
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

        function getAllByNivel(idEmp, nivel) {
            return $http.get(nameSpace + 'ByNivel/' + idEmp + '/' + nivel)
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

        function getPlan(idEmp, codCuenta) {
            return $http.get(nameSpace + 'Get/' + idEmp + '/' + codCuenta)
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