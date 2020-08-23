(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTercerosService', GenTercerosService);

    GenTercerosService.$inject = ['$http', '$q'];

    function GenTercerosService($http, $q) {
        var nameSpace = '/General/api/Terceros/';

        var service = {
            create: create,
            getAll: getAll,
            getAct: getAct,
            update: update,

            getAllPro: getAllPro,
            getActPro: getActPro,
            updatePro: updatePro,

            getAllCli: getAllCli,
            getActCli: getActCli,
            updateCli: updateCli,
        };

        return service;

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

        function getAct(idEmp) {
            return $http.get(nameSpace + 'ByAct/' + idEmp)
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

        // Proveedores
        function getAllPro(idEmp) {
            return $http.get(nameSpace + 'Prov/' + idEmp)
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

        function getActPro(idEmp) {
            return $http.get(nameSpace + 'Prov/ByAct/' + idEmp)
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

        function updatePro(id, data) {
            return $http.put(nameSpace + 'Prov/' + id, data)
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

        // Clientes
        function getAllCli(idEmp) {
            return $http.get(nameSpace + 'Cli/' + idEmp)
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

        function getActCli(idEmp) {
            return $http.get(nameSpace + 'Cli/ByAct/' + idEmp)
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

        function updateCli(id, data) {
            return $http.put(nameSpace + 'Cli/' + id, data)
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