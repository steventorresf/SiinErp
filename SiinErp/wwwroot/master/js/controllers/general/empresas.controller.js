(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', 'GenEmpresasService'];

    function AppController($location, empService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.getEmpresas = getEmpresas;

        function getEmpresas() {
            var response = empService.getAll();
            response.then(
                function (response) {
                    console.log(response.data);
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        getEmpresas();
    }
})();