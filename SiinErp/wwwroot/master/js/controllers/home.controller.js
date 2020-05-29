(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', 'GenUsuariosService'];

    function AppController($location, usuService) {
        var vm = this;

        vm.title = 'Home Page';

        function init() {
            
        }
        init();
    }
})();