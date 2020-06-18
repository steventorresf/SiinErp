(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'VenClientesService', 'CarPlazosPagoService', 'VenVendedoresService', 'VenListaPreciosService', 'GenTablasDetService', 'GenDepartamentosService', 'GenCiudadesService'];

    function AppController($location, $cookies, $scope, cliService, ppaService, venService, lisService, tabdetService, depService, ciuService) {
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
        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.getCiudades = getCiudades;

        function init() {
            getAll();
            getPlazosPago();
            getVendedores();
            getListaPrecios();
            getZonas();
            getTiposCliente();
            getDepartamentos();
        }

        function getAll() {
            var response = cliService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
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

        function getVendedores() {
            var response = venService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listVendedores = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getListaPrecios() {
            var response = lisService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listListaPrecios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getZonas() {
            var response = tabdetService.getAll(Tab.Zonas);
            response.then(
                function (response) {
                    vm.listZonas = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposCliente() {
            var response = tabdetService.getAll(Tab.TiposCli);
            response.then(
                function (response) {
                    vm.listTiposCli = response.data;
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



        function nuevo() {
            vm.entity = {};
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
            vm.entity.idUsuario = vm.userApp.idUsu;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.idDetTipoCliente = angular.copy(entity.idDetTipoCliente).toString();
            vm.entity.idPlazoPago = angular.copy(entity.idPlazoPago).toString();
            vm.entity.idDetZona = angular.copy(entity.idDetZona).toString();
            vm.entity.credito = angular.copy(entity.credito).toString();
            vm.entity.retencion = angular.copy(entity.retencion).toString();
            vm.entity.baseRetencion = angular.copy(entity.baseRetencion).toString();
            vm.entity.iva = angular.copy(entity.iva).toString();
            vm.entity.esCadena = angular.copy(entity.esCadena).toString();
            getCiudades();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = cliService.update(vm.entity.idCliente, vm.entity); }
            else { response = cliService.create(vm.entity); }

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
                    name: 'codCliente',
                    field: 'codCliente',
                    displayName: 'Código',
                    headerCellClass: 'text-center',
                    width: 100,
                },
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
                    width: 80,
                },
                {
                    name: 'nombreCliente',
                    field: 'nombreCliente',
                    displayName: 'Nombre Cliente',
                    headerCellClass: 'text-center',
                    width: 350,
                },
                {
                    name: 'nombreComercial',
                    field: 'nombreComercial',
                    displayName: 'Nombre Comercial',
                    headerCellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'representanteLegal',
                    field: 'representanteLegal',
                    displayName: 'Representante Legal',
                    headerCellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'nombreTipoCliente',
                    field: 'nombreTipoCliente',
                    displayName: 'TipoCliente',
                    headerCellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'direccion',
                    field: 'direccion',
                    displayName: 'Dirección',
                    headerCellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'telefono',
                    headerCellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'nombreCiudad',
                    field: 'nombreCiudad',
                    displayName: 'Ciudad',
                    headerCellClass: 'text-center',
                    width: 300,
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
                    name: 'puntosAcumulados',
                    field: 'puntosAcumulados',
                    displayName: 'PuntosAcumulados',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
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
