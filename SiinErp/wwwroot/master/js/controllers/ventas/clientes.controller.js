(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenTercerosService', 'CarPlazosPagoService', 'VenVendedoresService', 'VenListaPreciosService', 'GenTablasEmpresaDetService', 'GenDepartamentosService', 'GenCiudadesService'];

    function AppController($location, $cookies, $scope, terService, ppaService, venService, lisService, tabdetService, depService, ciuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        
        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.getCiudades = getCiudades;

        function init() {
            getAll();
            getPlazosPago();
            getVendedores();
            getListaPrecios();
            getZonas();
            getTiposPersona();
            getDepartamentos();
        }

        function getAll() {
            var response = terService.getAllCli(vm.userApp.idEmpresa);
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
            var response = tabdetService.getAll(Tab.Zonas, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listZonas = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposPersona() {
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
            vm.entity = {
                tipoTercero: TipoTercero.Cliente,
                idEmpresa: vm.userApp.idEmpresa,
                idUsuario: vm.userApp.idUsu,
                estado: Estados.Activo,
            };
            
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.idDetTipoPersona = angular.copy(entity.idDetTipoPersona).toString();
            vm.entity.idPlazoPago = angular.copy(entity.idPlazoPago).toString();
            vm.entity.idDetZona = angular.copy(entity.idDetZona).toString();
            vm.entity.iva = angular.copy(entity.iva).toString();
            
            getCiudades();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = terService.updateCli(vm.entity.idTercero, vm.entity); }
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
                    width: 80,
                },
                {
                    name: 'nombreTercero',
                    field: 'nombreTercero',
                    displayName: 'Nombre Cliente',
                    headerCellClass: 'bg-header',
                    width: 350,
                },
                {
                    name: 'nombreTipoPersona',
                    field: 'nombreTipoPersona',
                    displayName: 'TipoCliente',
                    headerCellClass: 'bg-header',
                    width: 200,
                },
                {
                    name: 'direccion',
                    field: 'direccion',
                    displayName: 'Dirección',
                    headerCellClass: 'bg-header',
                    width: 300,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'telefono',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'nombreCiudad',
                    field: 'nombreCiudad',
                    displayName: 'Ciudad',
                    headerCellClass: 'bg-header',
                    width: 300,
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
