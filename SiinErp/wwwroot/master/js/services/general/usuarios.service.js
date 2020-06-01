(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenUsuariosService', GenUsuariosService);

    GenUsuariosService.$inject = ['$http', '$q'];

    function GenUsuariosService($http, $q) {
        var nameSpace = 'api/Usuarios/';
        var service = {
            Login: Login,
        };

        return service;

        function Login(data) {
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

    }
})();