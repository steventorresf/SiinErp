(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'GenTiposDocService', 'GenTablasDetService'];

    function AppController($location, $scope, $cookies, tipdocService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.getTiposDoc = getTiposDoc;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;

        function init() {
            getTiposDoc();
            getTransaccionGen();
            getClasesDoc();
        }

        function getTiposDoc() {
            var response = tipdocService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTransaccionGen() {
            var response = tabdetService.getAll(Tab.Transac);
            response.then(
                function (response) {
                    vm.listTransaccions = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getClasesDoc() {
            var response = tabdetService.getAll(Tab.ClaseDoc);
            response.then(
                function (response) {
                    vm.listClasesDoc = response.data;
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
            vm.entity.idDetTransaccion = angular.copy(entity.idDetTransaccion).toString();
            vm.entity.idDetClaseDoc = angular.copy(entity.idDetClaseDoc).toString();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            vm.entity.idEmpresa = vm.userApp.idEmpresa;

            var response = null;
            if (vm.formModify) { response = tipdocService.update(vm.entity.idTipoDoc, vm.entity); }
            else { response = tipdocService.create(vm.entity); }

            response.then(
                function (response) {
                    cancelar();
                    getTiposDoc();
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
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'tipoDoc',
                    field: 'tipoDoc',
                    displayName: 'TipoDoc',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumDoc',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripcion',
                    headerCellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'nomTransaccion',
                    field: 'nomTransaccion',
                    displayName: 'Transacción',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'nomClaseDoc',
                    field: 'nomClaseDoc',
                    displayName: 'ClaseDocumento',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'idCuentaDoc',
                    field: 'idCuentaDoc',
                    displayName: 'CuentaDoc',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'idCuentaCargo',
                    field: 'idCuentaCargo',
                    displayName: 'CuentaCargo',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'idCuentaOtro',
                    field: 'idCuentaOtro',
                    displayName: 'CuentaOtro',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'idCuentaReteFuente',
                    field: 'idCuentaReteFuente',
                    displayName: 'CuentaReteFuente',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
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
