(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', 'GenEmpresasService', 'GenDepartamentosService', 'GenCiudadesService', 'GenTablasDetService'];

    function AppController($location, $scope, empService, depService, ciuService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.getEmpresas = getEmpresas;
        vm.getCiudades = getCiudades;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;

        function init() {
            getEmpresas();
            getDepartamentos();
            getRegimens();
        }

        function getEmpresas() {
            var response = empService.getAll();
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getDepartamentos() {
            var response = depService.getAll();
            response.then(
                function (response) {
                    vm.listDepartamentos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getCiudades() {
            var response = ciuService.getAll(vm.entity.idDepartamento);
            response.then(
                function (response) {
                    vm.listCiudades = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getRegimens() {
            var response = tabdetService.getAll(Tab.Regimen);
            response.then(
                function (response) {
                    vm.listRegimens = response.data;
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
            getCiudades();
            vm.entity.idDepartamento = angular.copy(entity.idDepartamento).toString();
            vm.entity.idCiudad = angular.copy(entity.idCiudad).toString();
            vm.entity.idDetRegimen = angular.copy(entity.idDetRegimen).toString();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = empService.update(vm.entity.idEmpresa, vm.entity); }
            else { response = empService.create(vm.entity); }
            console.log(vm.formModify);

            response.then(
                function (response) {
                    cancelar();
                    getEmpresas();
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
                    name: 'nitEmpresa',
                    field: 'nitEmpresa',
                    displayName: 'NitEmpresa',
                    headerCellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'razonSocial',
                    field: 'razonSocial',
                    displayName: 'RazonSocial',
                    headerCellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'nombreCiudad',
                    field: 'nombreCiudad',
                    displayName: 'Nombre Ciudad',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'direccion',
                    field: 'direccion',
                    displayName: 'Dirección',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'Teléfono',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'codEan',
                    field: 'codEan',
                    displayName: 'CodEan',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 80,
                },
                {
                    name: 'representante',
                    field: 'representante',
                    displayName: 'Representante',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'nombreRegimen',
                    field: 'nombreRegimen',
                    displayName: 'Regimen',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 200,
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