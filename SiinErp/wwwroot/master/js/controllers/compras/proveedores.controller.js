(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'ComProveedoresService', 'CarPlazosPagoService', 'GenTablasDetService', 'GenDepartamentosService', 'GenCiudadesService'];

    function AppController($location, $cookies, $scope, proService, ppaService, tabdetService, depService, ciuService) {
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
        $scope.editar = editar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        function init() {
            getAll();
            getDepartamentos();
            getTiposProv();
            getPlazosPago();
        }

        function getAll() {
            var response = proService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposProv() {
            var response = tabdetService.getAll(Tab.TiposProv);
            response.then(
                function (response) {
                    vm.listTiposProv = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getPlazosPago() {
            var response = ppaService.getAll();
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
            vm.entity = {};
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
            vm.entity.idUsuario = vm.userApp.idUsu;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            getCiudades();
            vm.entity.idDetTipoProv = angular.copy(entity.idDetTipoProv).toString();
            vm.entity.idPlazoPago = angular.copy(entity.idPlazoPago).toString();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = proService.update(vm.entity.idProveedor, vm.entity); }
            else { response = proService.create(vm.entity); }

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
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'nitCedula',
                    field: 'nitCedula',
                    displayName: 'NitCedula',
                    headerCellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'dgVerificacion',
                    field: 'dgVerificacion',
                    displayName: 'DgVerif',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreProveedor',
                    field: 'nombreProveedor',
                    displayName: 'Nombre Proveedor',
                    headerCellClass: 'text-center',
                    width: 350,
                },
                {
                    name: 'nombreTipoProv',
                    field: 'nombreTipoProv',
                    displayName: 'TipoProv',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'representanteLegal',
                    field: 'representanteLegal',
                    displayName: 'RepresentanteLegal',
                    headerCellClass: 'text-center',
                    width: 150,
                },
                {
                    name: 'nombreCiudad',
                    field: 'nombreCiudad',
                    displayName: 'Ciudad',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'direccion',
                    field: 'direccion',
                    displayName: 'Dirección',
                    headerCellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'eMail',
                    field: 'eMail',
                    displayName: 'EMail',
                    headerCellClass: 'text-center',
                    width: 220,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'Teléfono',
                    headerCellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'idCuentaContable',
                    field: 'idCuentaContable',
                    displayName: 'CuentaContable',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'plazoPago.descripcion',
                    field: 'plazoPago.descripcion',
                    displayName: 'PlazoPago',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'fechaUltCompra',
                    field: 'fechaUltCompra',
                    displayName: 'FechaUltCompra',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 200,
                },
                {
                    name: 'fechaUltPago',
                    field: 'fechaUltPago',
                    displayName: 'FechaUltPago',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 200,
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
