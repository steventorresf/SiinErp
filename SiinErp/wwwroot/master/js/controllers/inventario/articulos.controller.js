(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'InvArticuloService', 'GenTablaDetService'];

    function AppController($location, $cookies, $scope, artService, tabdetService) {
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

        function init() {
            getAll();
            getTiposArt();
            getUnidadMed();
        }

        function getAll() {
            var response = artService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposArt() {
            var response = tabdetService.getAll(Tab.TiposArt, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTiposArt = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getUnidadMed() {
            var response = tabdetService.getAll(Tab.UnidadMed, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listUnidadMed = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }



        function nuevo() {
            vm.entity = {
                idEmpresa: vm.userApp.idEmpresa,
                peso: 0,
                stkMin: 0,
                stkMax: 0,
                esLinea: 'true',
                estadoFila: 'A',
                afectaInventario: 'true',
                creadoPor: vm.userApp.nombreUsuario,
                modificadoPor: vm.userApp.nombreUsuario,
                nombreBusqueda: '-',
            };

            if (vm.listUnidadMed.length === 1) {
                vm.entity.idDetUnidadMed = vm.listUnidadMed[0].idDetalle.toString();
            }
            
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.idDetTipoArticulo = angular.copy(entity.idDetTipoArticulo).toString();
            vm.entity.idDetUnidadMed = angular.copy(entity.idDetUnidadMed).toString();
            vm.entity.esLinea = angular.copy(entity.esLinea).toString();
            vm.entity.incluyeIva = angular.copy(entity.incluyeIva).toString();
            vm.entity.afectaInventario = angular.copy(entity.afectaInventario).toString();
            vm.entity.modificadoPor = vm.userApp.nombreUsuario;
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            console.log(vm.entity);
            var response = null;
            if (vm.formModify) { response = artService.update(vm.entity.idArticulo, vm.entity); }
            else { response = artService.create(vm.entity); }

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
                    name: 'codArticulo',
                    field: 'codArticulo',
                    displayName: 'Código',
                    headerCellClass: 'bg-header',
                    width: 120,
                },
                //{
                //    name: 'referencia',
                //    field: 'referencia',
                //    displayName: 'Referencia',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    width: 100,
                //},
                {
                    name: 'nombreArticulo',
                    field: 'nombreArticulo',
                    displayName: 'Nombre Articulo',
                    headerCellClass: 'bg-header',
                    width: 350,
                },
                {
                    name: 'nombreTipoArticulo',
                    field: 'nombreTipoArticulo',
                    displayName: 'Tipo Articulo',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'existencia',
                    field: 'existencia',
                    displayName: 'Existencia',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'vrCosto',
                    field: 'vrCosto',
                    displayName: 'VrCosto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'vrVenta',
                    field: 'vrVenta',
                    displayName: 'VrVenta',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'pcIva',
                    field: 'pcIva',
                    displayName: 'PcIva',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                },
                //{
                //    name: 'nombreUnidadMed',
                //    field: 'nombreUnidadMed',
                //    displayName: 'UnidadMed',
                //    headerCellClass: 'bg-header',
                //    width: 150,
                //},
                //{
                //    name: 'descEsLinea',
                //    field: 'descEsLinea',
                //    displayName: '¿EsLinea?',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    width: 100,
                //},
                //{
                //    name: 'peso',
                //    field: 'peso',
                //    displayName: 'Peso',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-right',
                //    width: 100,
                //},
                {
                    name: 'stkMin',
                    field: 'stkMin',
                    displayName: 'StockMin',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'stkMax',
                    field: 'stkMax',
                    displayName: 'StockMax',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                //{
                //    name: 'indCosto',
                //    field: 'indCosto',
                //    displayName: 'IndCosto',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    width: 100,
                //},
                //{
                //    name: 'indConsumo',
                //    field: 'indConsumo',
                //    displayName: 'IndConsumo',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    width: 100,
                //},
                //{
                //    name: 'fechaUEntrada',
                //    field: 'fechaUEntrada',
                //    displayName: 'FechaUEntrada',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    cellFilter: 'date:\'yyyy-MM-dd\'',
                //    width: 200,
                //},
                //{
                //    name: 'fechaUSalida',
                //    field: 'fechaUSalida',
                //    displayName: 'FechaUSalida',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    cellFilter: 'date:\'yyyy-MM-dd\'',
                //    width: 200,
                //},
                //{
                //    name: 'fechaUPedida',
                //    field: 'fechaUPedida',
                //    displayName: 'FechaUPedida',
                //    headerCellClass: 'bg-header',
                //    cellClass: 'text-center',
                //    cellFilter: 'date:\'yyyy-MM-dd\'',
                //    width: 200,
                //},
                {
                    name: 'estadoFila',
                    field: 'estadoFila',
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

      //boton reporte  window.open('http://c-gomez/Reports/report/SiinErp/ReporteArticulos?Costo=' + vm.costo)

    }
})();
