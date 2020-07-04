(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenParametrosService'];

    function AppController($location, $cookies, $scope, parService) {
        var vm = this;

        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.cancelar = cancelar;
        vm.guardar = guardar;
        $scope.editar = editar;

        function init() {
            vm.userApp = $cookies.getObject('UsuApp');
            getAll();
        }


        function getAll() {
            var response = parService.getAll();
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevo() {
            vm.entity = {};
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) {
                response = parService.update(vm.entity.idParametro, vm.entity);
            }
            else {
                response = parService.create(vm.entity);
            }

            response.then(
                function (response) {
                    cancelar();
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelar() {
            vm.formVisible = false;
        }



        vm.gridOptions = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: false,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'codigoParam',
                    field: 'codigoParam',
                    displayName: 'Código',
                    headerCellClass: 'bg-header',
                    width: 100,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripción',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'valorParam',
                    field: 'valorParam',
                    displayName: 'Valor',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };
    }
})();
