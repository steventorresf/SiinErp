(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', 'GenTablasService', 'GenTablasDetService', 'GenModulosService'];

    function AppController($location, $scope, tabService, tabdetService, modService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.formVisible = false;
        vm.formModify = false;
        vm.formVisibleDet = false;
        vm.formModifyDet = false;
        vm.entity = {};

        vm.init = init;
        vm.getModulos = getModulos;
        vm.getTablas = getTablas;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.getDetalle = getDetalle;
        $scope.editar = editar;

        $scope.getDetalle = getDetalle;
        vm.nuevoDet = nuevoDet;
        vm.editarDet = editarDet;
        vm.guardarDet = guardarDet;
        vm.cancelarDet = cancelarDet;
        vm.regresarDet = regresarDet;
        $scope.editarDet = editarDet;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        vm.modoDet = false;

        function init() {
            getTablas();
            getModulos();
        }


        function getModulos() {
            var response = modService.getAll();
            response.then(
                function (response) {
                    vm.listModulos = response.data;
                    console.log(vm.listModulos);
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTablas() {
            var response = tabService.getAll();
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

        function editar (entity) {
            vm.entity = angular.copy(entity);
            vm.codTabla = angular.copy(entity.codTabla);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = tabService.update(vm.codTabla, vm.entity); console.log(1); }
            else { response = tabService.create(vm.entity); console.log(2); }
            console.log(vm.formModify);

            response.then(
                function (response) {
                    cancelar();
                    getTablas();
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
                    name: 'codTabla',
                    field: 'codTabla',
                    displayName: 'Código',
                    headerCellClass: 'text-center',
                    width: 150,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripción',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'nombreModulo',
                    field: 'nombreModulo',
                    displayName: 'Modulo',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    cellClass:'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>" +
                        "<span><a href='' ng-click='grid.appScope.getDetalle(row.entity)' tooltip='Detalles' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-book text-info'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        vm.gridOptionsDet = {
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
                    name: 'codValor',
                    field: 'codValor',
                    displayName: 'Código',
                    headerCellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripción',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
                    headerCellClass: 'text-center',
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
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.editarDet(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiDet = gridApi;
            },
        };

        function regresarDet() {
            vm.modoDet = false;
        }

        function getDetalle(entity) {
            vm.entity = angular.copy(entity);
            vm.modoDet = true;
            getAllDet();
        }

        function getAllDet() {
            var response = tabdetService.getAll(vm.entity.codTabla);
            response.then(
                function (response) {
                    vm.gridOptionsDet.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevoDet() {
            vm.entityDet = {};
            vm.entityDet.estado = 'A';
            vm.formModifyDet = false;
            vm.formVisibleDet = true;
        }

        function editarDet(entity) {
            vm.entityDet = angular.copy(entity);
            vm.formModifyDet = true;
            vm.formVisibleDet = true;
        }

        function guardarDet() {
            vm.entityDet.codTabla = vm.entity.codTabla;

            var response = null;
            if (vm.formModifyDet) { response = tabdetService.update(vm.entityDet.idDetalle, vm.entityDet); }
            else { response = tabdetService.create(vm.entityDet); }

            response.then(
                function (response) {
                    cancelarDet();
                    getAllDet();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelarDet() {
            vm.formVisibleDet = false;
        }
    }
})();