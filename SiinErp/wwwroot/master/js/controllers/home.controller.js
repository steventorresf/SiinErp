﻿(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies'];

    function AppController($location, $cookies) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;

        function init() {
            console.log($cookies.getObject('UsuApp'));
        }
    }
})();