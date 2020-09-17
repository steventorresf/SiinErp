(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenTercerosService', 'CarConceptosService', 'InvMovimientosService', 'CarMovimientosService', 'GenTiposDocService'];

    function AppController($location, $cookies, $scope, terService, conService, movInvService, movService, tipdocService) {
        var vm = this;
        var fecha = new Date();

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.onChangeTipoDoc = onChangeTipoDoc;
        vm.nuevo = nuevo;
        vm.anular = anular;
        vm.cancelar = cancelar;
        vm.guardar = guardar;
        vm.regresar = regresar;
        vm.buscarPendientesCli = buscarPendientesCli;

        vm.gridMov = true;
        vm.formMov = false;
        vm.gridVisible = false;

        vm.fechaInicial = fecha.addDays(fecha.getDate() > 1 ? (fecha.getDate() - 1) * -1 : 0);
        vm.fechaFinal = fecha.addDays(0);

        function init() {
            getAll();
            getClientes();
            getTiposDoc();
        }

        function getAll() {
            var response = movService.getAll(vm.userApp.idEmpresa, vm.fechaInicial.DateSiin(true), vm.fechaFinal.DateSiin(true));
            response.then(
                function (response) {
                    vm.gridOptionsMov.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsMov = {
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
                    name: 'tipoDoc',
                    field: 'tipoDoc',
                    displayName: 'TipoDoc',
                    headerCellClass: 'bg-header',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumeDoc',
                    headerCellClass: 'bg-header',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'fechaDoc',
                    field: 'fechaDoc',
                    displayName: 'FechaDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    type: 'date',
                    cellFilter: 'date: \'dd/MM/yyyy\'',
                },
                {
                    name: 'nombreTercero',
                    field: 'nombreTercero',
                    displayName: 'NombreCliente',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'nombreConcepto',
                    field: 'nombreConcepto',
                    displayName: 'NombreConcepto',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'valorTotal',
                    field: 'valorTotal',
                    displayName: 'V. Total',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 2',
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
                        "<span><a href='' ng-click='grid.appScope.vm.anular(row.entity)' tooltip='Anular' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 80,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiMov = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    rowEntity.vrBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    rowEntity.vrNeto = rowEntity.vrBruto - (rowEntity.vrBruto * rowEntity.pcDscto / 100) + (rowEntity.vrBruto * rowEntity.pcIva / 100);
                    CalcularTotales();
                });
            },
        };

        function anular(entity) {
            var response = movService.anular(entity.idMovimiento, vm.userApp.nombreUsuario);
            response.then(
                function (response) {
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelar() {
            vm.formMov = false;
            vm.gridMov = true;
        }

        function nuevo() {
            vm.entity = {
                idEmpresa: vm.userApp.idEmpresa,
                afectaCartera: true,
                creadoPor: vm.userApp.nombreUsuario,
                estado: Estados.Activo,
                valorRestante: 0,
            };

            vm.gridMov = false;
            vm.formMov = true;
        }

        function getClientes() {
            var response = terService.getActCli(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listClientes = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposDoc() {
            var response = tipdocService.getByModulo(vm.userApp.idEmpresa, Modulo.Cartera);
            response.then(
                function (response) {
                    vm.listTiposDoc = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeTipoDoc($item, $model) {
            var response = conService.getByTipDoc($item.idTipoDoc);
            response.then(
                function (response) {
                    vm.listConceptos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function buscarPendientesCli() {
            vm.formMov = false;
            vm.gridVisible = true;

            var response = movInvService.getPendientesTercero(vm.userApp.idEmpresa, vm.entity.idCliente);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                    vm.entity.valorRestante = vm.entity.valorConcepto;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function guardar() {
            var listDetalleFac = vm.gridOptions.data.filter(function (ob) {
                return ob.vrPagar > 0;
            });

            if (listDetalleFac.length > 0) {
                var data = {
                    entity: vm.entity,
                    listDetalleFac: listDetalleFac,
                }

                var response = movService.create(data);
                response.then(
                    function (response) {
                        window.location.reload();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function regresar() {
            vm.gridVisible = false;
            vm.formMov = true;
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
                    name: 'tipoDoc',
                    field: 'tipoDoc',
                    displayName: 'Tp',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'Factura',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'fechaDoc',
                    field: 'fechaDoc',
                    displayName: 'Fecha Doc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'fechaVencimiento',
                    field: 'fechaVencimiento',
                    displayName: 'Fecha Ven.',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'valorSaldo',
                    field: 'valorSaldo',
                    displayName: 'Saldo',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'vrPagar',
                    field: 'vrPagar',
                    displayName: 'Vr. Pag',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                },
                {
                    name: 'valorDscto',
                    field: 'valorDscto',
                    displayName: 'Vr. Dscto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                },
                {
                    name: 'valorNeto',
                    field: 'valorNeto',
                    displayName: 'Vr. Neto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
                gridApi.selection.on.rowSelectionChanged($scope, function (row) {

                });

                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (newValue < 0) {
                        rowEntity.vrPagar = oldValue;
                    }

                    rowEntity.valorNeto = rowEntity.vrPagar - rowEntity.valorDscto;

                  
                    var vrTotal = 0;
                    vm.gridOptions.data.forEach(function (row, index) {
                        vrTotal += row.valorNeto;
                    });

                 /*   for (var i = 0; i < vm.gridOptions.data.length; i++) {
                        vrTotal += rowEntity.valorNeto;
                    } */

                    vm.entity.valorRestante = vm.entity.valorConcepto - vrTotal;

                });

            },
        };

    }
})();