(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'VenClientesService', 'CarConceptosService', 'VenFacturasService', 'CarMovimientosService'];

    function AppController($location, $cookies, $scope, cliService, conService, facService, movService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.guardar = guardar;
        vm.regresar = regresar;
        vm.buscarPendientesCli = buscarPendientesCli;
        vm.entity = {
            idEmpresa: vm.userApp.idEmpresa,
            tipoDoc: GenTiposDoc.ReciboCaja,
            afectaCartera: true,
            creadoPor: vm.userApp.idUsu,
            estado: Estados.Activo,
            valorRestante: 0,
        };

        function init() {
            getClientes();
            getConceptos();
        }

        function getClientes() {
            var response = cliService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listClientes = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getConceptos() {
            var response = conService.getAll(vm.userApp.idEmpresa);
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
            var response = facService.getPendientesCli(vm.entity.idCliente);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                    vm.gridVisible = true;
                    vm.entity.valorRestante = vm.entity.valorConcepto;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function guardar() {
            var listDetalleFac = vm.gridOptions.data.filter(function (ob) {
                return ob.valorPagado > 0;
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
                    name: 'valorRestante',
                    field: 'valorRestante',
                    displayName: 'Saldo',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'valorPagado',
                    field: 'valorPagado',
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
                        rowEntity.valorPagado = oldValue;
                    }

                    rowEntity.valorNeto = rowEntity.valorPagado - rowEntity.valorDscto;

                    var vrTotal = 0;
                    for (var i = 0; i < vm.gridOptions.data.length; i++) {
                        vrTotal += rowEntity.valorNeto;
                    }

                    vm.entity.valorRestante = vm.entity.valorConcepto - vrTotal;
                });

            },
        };

    }
})();