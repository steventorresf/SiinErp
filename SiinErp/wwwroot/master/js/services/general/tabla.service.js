﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablaService', GenTablaService);

    GenTablaService.$inject = ['$http', '$q'];

    function GenTablaService($http, $q) {
        var nameSpace = '/General/api/Tabla/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
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

        function update(cod, data) {
            return $http.put(nameSpace + cod, data)
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