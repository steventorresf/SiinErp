(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', 'GenUsuarioService', 'GenEmpresaService'];

    function AppController($location, $cookies, usuService, empService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.onChangeEmp = onChangeEmp;
        vm.loginUsu = loginUsu;
        vm.entity = {};

        function init() {
            getEmpresas();
        }

        function getEmpresas() {
            var response = empService.getAct();
            response.then(
                function (response) {
                    vm.listEmpresas = response.data;
                    if (vm.listEmpresas.length === 1) {
                        vm.entity.idEmp = angular.copy(vm.listEmpresas[0].idEmpresa).toString();
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeEmp($item) {
            console.log($item);
        }

        function loginUsu() {
            console.log(vm.entity);
            var response = usuService.Login(vm.entity);
            response.then(
                function (response) {
                    var data = response.data;
                    if (data.respuesta === 'TodoOkey') {
                        $cookies.putObject('UsuApp', data);
                        window.location.href = url + 'Home';
                    }
                    else { fnMessenger(data.respuesta, 'error'); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();