(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenTablaService', 'GenTablaDetService'];

    function AppController($location, $cookies, $scope, tabService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.formVisibleDet = false;
        vm.formModifyDet = false;
        vm.entityTab = {
            idEmpresa: vm.userApp.idEmpresa,
            estadoFila: 'A',
            creadoPor: vm.userApp.nombreUsuario,
            modificadoPor: vm.userApp.nombreUsuario,
        };

        vm.init = init;
        vm.onChangeTabla = onChangeTabla;
        vm.getAllDet = getAllDet;

        vm.nuevoDet = nuevoDet;
        vm.editarDet = editarDet;
        vm.guardarDet = guardarDet;
        vm.cancelarDet = cancelarDet;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        function init() {
            getTablas();
        }


        function getTablas() {
            var response = tabService.getAll();
            response.then(
                function (response) {
                    vm.listTablas = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeTabla($item, $model) {
            vm.entity = angular.copy($item);
            getAllDet();
        }

        function getAllDet() {
            vm.gridOptionsDet.data = [];

            var response = tabdetService.getAllById(vm.entity.idTabla, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptionsDet.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsDet = {
            data: [],
            enableSorting: true,
            enableRowSelection: false,
            enableFullRowSelection: false,
            multiSelect: false,
            enableRowHeaderSelection: false,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'codigo',
                    field: 'codigo',
                    displayName: 'Código',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                    width: 100,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripción',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
                {
                    name: 'orden',
                    type: 'number',
                    field: 'orden',
                    displayName: 'Orden',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    cellFilter: 'number: 0',
                    enableCellEdit: true,
                    width: 100,
                },
                {
                    name: 'estadoFila',
                    field: 'estadoFila',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    enableCellEdit: false,
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
                        "<span><a href='' ng-click='grid.appScope.vm.editarDet(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 100,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiDet = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (colDef.name === 'orden') {
                        updateOrdenDet(rowEntity.idDetalle, newValue);
                    }
                });
            },
        };

        function updateOrdenDet(idDetalle, orden) {
            var response = tabdetService.updateOrden(idDetalle, orden);
            response.then(
                function (response) {
                    
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevoDet() {
            vm.entityDet = {};
            vm.entityDet.idTabla = vm.entity.idTabla;
            vm.entityDet.idEmpresa = vm.userApp.idEmpresa;
            vm.entityDet.estado = 'A';
            vm.entityDet.creadoPor = vm.userApp.nombreUsuario;
            vm.entityDet.modificadoPor = vm.userApp.nombreUsuario;
            vm.formModifyDet = false;
            vm.formVisibleDet = true;
        }

        function editarDet(entity) {
            vm.entityDet = angular.copy(entity);
            vm.formModifyDet = true;
            vm.formVisibleDet = true;
        }

        function guardarDet() {
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