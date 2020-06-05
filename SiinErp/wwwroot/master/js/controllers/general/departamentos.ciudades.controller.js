(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', 'GenPaisesService', 'GenDepartamentosService', 'GenCiudadesService'];

    function AppController($location, $scope, paisService, depService, ciuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.formVisible = false;
        vm.formModify = false;
        vm.formVisibleCiu = false;
        vm.formModifyCiu = false;
        vm.entity = {};

        vm.init = init;
        vm.getDepartamentos = getDepartamentos;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.getCiudades = getCiudades;
        $scope.editar = editar;

        $scope.getCiudades = getCiudades;
        vm.nuevoCiu = nuevoCiu;
        vm.editarCiu = editarCiu;
        vm.guardarCiu = guardarCiu;
        vm.cancelarCiu = cancelarCiu;
        vm.regresarCiu = regresarCiu;
        $scope.editarCiu = editarCiu;

        vm.modoCiu = false;

        function init() {
            getDepartamentos();
            getPaises();
        }


        function getDepartamentos() {
            var response = depService.getAll();
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                    vm.listDepartamentos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getPaises() {
            var response = paisService.getAll();
            response.then(
                function (response) {
                    vm.listPaises = response.data;
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
            vm.entity.idPais = angular.copy(entity.idPais).toString();
            console.log(vm.entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = depService.update(vm.entity.idDepartamento, vm.entity); }
            else { response = depService.create(vm.entity); }

            response.then(
                function (response) {
                    cancelar();
                    getDepartamentos();
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
                    name: 'codigoDane',
                    field: 'codigoDane',
                    displayName: 'CódigoDane',
                    headerCellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreDepartamento',
                    field: 'nombreDepartamento',
                    displayName: 'Nombre Departamento',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'nombrePais',
                    field: 'nombrePais',
                    displayName: 'Nombre País',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 150,
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
                        "<i class='fa fa-edit'></i></a></span>" +
                        "<span><a href='' ng-click='grid.appScope.getCiudades(row.entity)' tooltip='Ciudades' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-book text-info'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        vm.gridOptionsCiu = {
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
                    name: 'codigoDane',
                    field: 'codigoDane',
                    displayName: 'CódigoDane',
                    headerCellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreCiudad',
                    field: 'nombreCiudad',
                    displayName: 'Nombre Ciudad',
                    headerCellClass: 'text-center',
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
                        "<span><a href='' ng-click='grid.appScope.editarCiu(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiCiu = gridApi;
            },
        };

        function regresarCiu() {
            vm.modoCiu = false;
        }

        function getCiudades(entity) {
            vm.entity = angular.copy(entity);
            vm.modoCiu = true;
            getAllCiu();
        }

        function getAllCiu() {
            var response = ciuService.getAll(vm.entity.idDepartamento);
            response.then(
                function (response) {
                    vm.gridOptionsCiu.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevoCiu() {
            vm.entityCiu = {};
            vm.entityCiu.idDepartamento = angular.copy(vm.entity.idDepartamento).toString();
            vm.formModifyCiu = false;
            vm.formVisibleCiu = true;
        }

        function editarCiu(entity) {
            vm.entityCiu = angular.copy(entity);
            vm.entityCiu.idDepartamento = angular.copy(entity.idDepartamento).toString();
            vm.formModifyCiu = true;
            vm.formVisibleCiu = true;
        }

        function guardarCiu() {
            var response = null;
            if (vm.formModifyCiu) { response = ciuService.update(vm.entityCiu.idCiudad, vm.entityCiu); }
            else { response = ciuService.create(vm.entityCiu); }

            response.then(
                function (response) {
                    cancelarCiu();
                    getAllCiu();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelarCiu() {
            vm.formVisibleCiu = false;
        }
    }
})();
