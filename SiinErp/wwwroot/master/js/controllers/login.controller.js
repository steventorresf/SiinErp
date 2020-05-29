(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', 'GenUsuariosService'];

    function AppController($location, usuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.loginUsu = loginUsu;

        function loginUsu() {
            var response = usuService.Login(vm.entity);
            response.then(
                function (response) {
                    var respuesta = response.data;
                    if (respuesta === 'TodoOkey') {
                        window.location.href = url + 'Home';
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();