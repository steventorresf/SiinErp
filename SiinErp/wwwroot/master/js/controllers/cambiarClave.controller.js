(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', 'GenUsuarioService'];

    function AppController($location, $cookies, usuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.cambiarClave = cambiarClave;

        function init() {
            vm.entity = {
                idUsuario: vm.userApp.idUsu,
                modificadoPor: vm.userApp.nombreUsuario,
            };
        }

        function cambiarClave() {
            var response = usuService.cambiarClave(vm.entity);
            response.then(
                function (response) {
                    var data = response.data;
                    if (data === '1') {
                        alert("Su contraseña ha sido modificado correctamente.");
                        window.location.href = url + 'Home';
                    }
                    else {
                        alert(data);
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();