(function () {
    'use strict';

    angular
        .module('app')
        .factory('MenuUsuarioService', MenuUsuarioService);

    MenuUsuarioService.$inject = ['$http', '$q'];

    function MenuUsuarioService($http, $q) {
        var nameSpace = '/General/api/MenuUsuario/';
        var service = {
            setMenuUsuario: setMenuUsuario,
            getAllByIdUsuario: getAllByIdUsuario,
            getNotAllByIdUsuario: getNotAllByIdUsuario,
            create: create,
            remove: remove
        };

        return service;

        function setMenuUsuario(idUsu) {
            return $http.get(nameSpace + 'GetMenu/' + idUsu)
                .then(
                    function (response) {
                        $("#MenuId").html(response.data);
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function getAllByIdUsuario(idUsu) {
            return $http.get(nameSpace + idUsu)
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

        function getNotAllByIdUsuario(idUsu) {
            return $http.get(nameSpace + 'Not/' + idUsu)
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

        function remove(idMenuUsu) {
            return $http.delete(nameSpace + idMenuUsu)
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