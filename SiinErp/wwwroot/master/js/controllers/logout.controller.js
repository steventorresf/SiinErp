(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies'];

    function AppController($location, $cookies) {
        var vm = this;

        vm.title = '';
        vm.init = init;

        function init() {
            $cookies.putObject('UsuApp', null);
            window.location.href = url + 'Login';
        }
    }
})();