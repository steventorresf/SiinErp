(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenTercerosService', 'CarPlazosPagoService', 'GenTablasDetService', 'GenDepartamentosService', 'GenCiudadesService'];

    function AppController($location, $cookies, $scope, terService, ppaService, tabdetService, depService, ciuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.onChangeDepartamento = onChangeDepartamento;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        function init() {
            getAll();
            getDepartamentos();
            getTiposPer();
            getPlazosPago();
        }

        function getAll() {
            var response = terService.getAllPro(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposPer() {
            var response = tabdetService.getAll(Tab.TiposPer, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTiposPer = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getPlazosPago() {
            var response = ppaService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listPlazosPago = response.data;
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

        function onChangeDepartamento() {
            vm.entity.idCiudad = null;
            getCiudades();
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



        function nuevo() {
            vm.entity = {
                idEmpresa: vm.userApp.idEmpresa,
                tipoTercero: TipoTercero.Proveedor,
                creadoPor: vm.userApp.idUsu,
                estado: Estados.Activo,
            };
            
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            getCiudades();
            vm.entity.idDetTipoPersona = angular.copy(entity.idDetTipoPersona).toString();
            vm.entity.idPlazoPago = angular.copy(entity.idPlazoPago).toString();

            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = terService.updatePro(vm.entity.idTercero, vm.entity); }
            else { response = terService.create(vm.entity); }

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
                    name: 'nitCedula',
                    field: 'nitCedula',
                    displayName: 'NitCedula',
                    headerCellClass: 'bg-header',
                    width: 120,
                },
                {
                    name: 'dgVerificacion',
                    field: 'dgVerificacion',
                    displayName: 'DgVerif',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreTercero',
                    field: 'nombreTercero',
                    displayName: 'Nombre Proveedor',
                    headerCellClass: 'bg-header',
                    width: 350,
                },
                {
                    name: 'nombreTipoPersona',
                    field: 'nombreTipoPersona',
                    displayName: 'TipoProv',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'nombreCiudad',
                    field: 'nombreCiudad',
                    displayName: 'Ciudad',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'direccion',
                    field: 'direccion',
                    displayName: 'Dirección',
                    headerCellClass: 'bg-header',
                    width: 200,
                },
                {
                    name: 'eMail',
                    field: 'eMail',
                    displayName: 'EMail',
                    headerCellClass: 'bg-header',
                    width: 220,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'Teléfono',
                    headerCellClass: 'bg-header',
                    width: 120,
                },
                {
                    name: 'idCuentaContable',
                    field: 'idCuentaContable',
                    displayName: 'CuentaContable',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'plazoPago.descripcion',
                    field: 'plazoPago.descripcion',
                    displayName: 'PlazoPago',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
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
                        "<span><a href='' ng-click='grid.appScope.vm.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
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
