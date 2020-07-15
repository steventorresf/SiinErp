(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenTablasService', 'GenTablasEmpresaService', 'GenTablasEmpresaDetService'];

    function AppController($location, $cookies, $scope, tabService, tabempService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.formVisibleDet = false;
        vm.formModifyDet = false;
        vm.entityTab = {
            idEmpresa: vm.userApp.idEmpresa,
            creadoPor: vm.userApp.idUsu,
        };

        vm.init = init;
        vm.agregarTab = agregarTab;
        vm.getDetalle = getDetalle;

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
            getTablasNo();
            getTablasEmpresa();
        }


        function getTablasNo() {
            var response = tabService.getAllNo(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTablas = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTablasEmpresa() {
            var response = tabempService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function agregarTab() {
            var response = tabempService.create(vm.entityTab);
            response.then(
                function (response) {
                    vm.entityTab.idTabla = null;
                    getTablasNo();
                    getTablasEmpresa();
                },
                function (response) {
                    console.log(response);
                }
            );
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
                    name: 'codTabla',
                    field: 'tabla.codTabla',
                    displayName: 'Código',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'descripcion',
                    field: 'tabla.descripcion',
                    displayName: 'Descripción',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'nombreModulo',
                    field: 'modulo.descripcion',
                    displayName: 'Modulo',
                    headerCellClass: 'bg-header',
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
                    headerCellClass: 'bg-header',
                    cellClass:'text-center',
                    cellTemplate:
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
            enableRowSelection: false,
            enableFullRowSelection: false,
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
                    name: 'estado',
                    field: 'estado',
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
                        "<span><a href='' ng-click='grid.appScope.editarDet(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
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

        function regresarDet() {
            vm.modoDet = false;
        }

        function getDetalle(entity) {
            vm.entity = angular.copy(entity);
            vm.modoDet = true;
            getAllDet();
        }

        function getAllDet() {
            var response = tabdetService.getAllById(vm.entity.idTablaEmpresa);
            response.then(
                function (response) {
                    vm.gridOptionsDet.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

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
            vm.entityDet.idTablaEmpresa = vm.entity.idTablaEmpresa;
            vm.entityDet.estado = 'A';
            vm.entityDet.creadoPor = vm.userApp.idUsu;
            vm.formModifyDet = false;
            vm.formVisibleDet = true;
        }

        function editarDet(entity) {
            vm.entityDet = angular.copy(entity);
            vm.formModifyDet = true;
            vm.formVisibleDet = true;
        }

        function guardarDet() {
            vm.entityDet.idTabla = vm.entity.idTabla;

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