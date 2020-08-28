(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'GenTercerosService', 'CarConceptosService', 'InvMovimientosService', 'GenTiposDocService', 'TesPagosService']; // 'TesPagosService' tespagService,

    function AppController($location, $cookies, $scope, terService, conService, facService, tipdocService, tespagService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        listDetallePag = {};
        listDetalleFac = {};
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.onChangeTipoDoc = onChangeTipoDoc;
        vm.guardar = guardar;
        vm.regresar = regresar;
        vm.buscarPendientesTercero = buscarPendientesTercero;
        vm.entity = {
            idEmpresa: vm.userApp.idEmpresa,
            afectaCartera: true,
            creadoPor: vm.userApp.idUsu,
            estado: Estados.Activo,
            valorRestante: 0,
        };

        function init() {
            getProveedores();
            getTiposDoc();
        }

        function getProveedores() {
            var response = terService.getAllPro(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listProveedor = response.data;
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

        function buscarPendientesTercero() {

            var response = facService.getPendientesTercero(vm.userApp.idEmpresa, vm.entity.idTercero);

            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                    vm.gridVisible = true;
                    vm.entity.valorRestante = vm.entity.valorTotal;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function guardar() {
            listDetallePag = vm.gridOptions.data.filter(function (ob) {
                return ob.vrPagar > 0;
            });

            var array = [];
            listDetallePag.forEach(function (entry) {
                var obj = {
                    idDetallePago: 0,
                    idPago: 0,
                    tipoDocAfectado: entry.tipoDoc,
                    numDocAfectado: entry.numDoc,
                    valorCargo: entry.vrPagar,
                    valorDscto: entry.valorDscto
                };

              //  vm.listDetalleFac = [];
              //  vm.listDetalleFac.push(obj);
                  array.push(obj);
                  listDetalleFac = array;
               
            });


            if (listDetalleFac.length > 0) {
                var data = {
                    entity: vm.entity,
                    listDetalleFac: listDetalleFac,
                }

                var response = tespagService.create(data);
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
                    name: 'numFactura',
                    field: 'numFactura',
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

                    vm.entity.valorRestante = vm.entity.valorTotal - vrTotal;


                });

            },
        };

    }
})();