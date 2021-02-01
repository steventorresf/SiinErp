(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'CarPlazoPagoService'];

    function AppController($location, $cookies, $scope, ppaService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        function init() {
            getAll();
        }

        function getAll() {
            var response = ppaService.getAll(vm.userApp.idEmpresa);
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
            vm.entity.idUsuario = vm.userApp.idUsu;
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
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
            if (vm.formModify) { response = ppaService.update(vm.entity.idPlazoPago, vm.entity); }
            else { response = ppaService.create(vm.entity); }

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
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripción',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'plazoDias',
                    field: 'plazoDias',
                    displayName: 'PlazoDias',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'cuotas',
                    field: 'cuotas',
                    displayName: 'Cuotas',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'pcInicial',
                    field: 'pcInicial',
                    displayName: 'Pc. Inicial',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
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