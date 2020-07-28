(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'InvMovimientosService', 'GenTablasEmpresaDetService', 'InvTiposDocService', 'InvArticulosService', 'GenTercerosService'];

    function AppController($location, $cookies, $scope, growl, movService, tabdetService, tipdocService, artService, terService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.guardar = guardar;
        vm.onChangeAlmacen = onChangeAlmacen;
        vm.onChangeTipoDoc = onChangeTipoDoc;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.almDestino = false;
        vm.entityMov = {};
        
        function init() {
            getAlmacens();
            getTerceros();
            getConceptos();
            getCenCostos();
        }

        function getAlmacens() {
            var response = tabdetService.getAll(Tab.InvAlm, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listAlmacens = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTerceros() {
            var response = terService.getAct(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTerceros = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeAlmacen($item, $model) {
            vm.gridOptions.data = [];
            vm.entityMov.tipoDoc = null;
            getTiposDocByAlmacen();
        }

        function getTiposDocByAlmacen() {
            var response = tipdocService.getByAlmacen(vm.entityMov.idDetAlmacen, vm.userApp.idEmpresa);
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
            if (vm.entityMov.transaccion != $item.transaccion) {
                vm.gridOptions.data = [];
            }

            vm.entityMov.numDoc = $item.numDoc;
            vm.entityMov.transaccion = $item.transaccion;

            if ($item.tipoDoc === InvTiposDoc.Traslados) {
                vm.almDestino = true;
                if (vm.entityMov.idDetAlmDestino === 0) {
                    vm.entityMov.idDetAlmDestino = null;
                }
            }
            else {
                vm.entityMov.idDetAlmDestino = 0;
                vm.almDestino = false;
            }
        }

        function getConceptos() {
            var response = tabdetService.getAll(Tab.InvConceptos, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listConceptos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getCenCostos() {
            var response = tabdetService.getAll(Tab.InvCenCos, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listCenCostos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function refreshArticulo(prefix) {
            if (prefix.length > 2) {
                var data = {
                    IdDetAlm: vm.entityMov.idDetAlmacen,
                    IdEmp: vm.userApp.idEmpresa,
                    Prefix: prefix,
                };

                var response = null;
                if (vm.entityMov.transaccion >= 0) {
                    response = artService.getAllByPrefix(data);
                }
                else {
                    response = artService.getAllByAlmPrefix(data);
                }

                response.then(
                    function (response) {
                        vm.listArticulos = response.data;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function onChangeArticulo($item, $model) {
            vm.gridOptions.data.push({
                idArticulo: $item.idArticulo,
                codArticulo: $item.codArticulo,
                nombreArticulo: $item.nombreArticulo,
                cantidad: 1,
                vrUnitario: $item.vrVenta,
                vrCosto: $item.vrCosto,
                pcDscto: 0,
                pcIva: 0,
                valorBruto: $item.vrVenta,
                valorNeto: $item.vrVenta,
            });
            vm.idArticulo = null;
            CalcularTotales();
        }

        vm.gridOptions = {
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
                    name: 'codArticulo',
                    field: 'codArticulo',
                    displayName: 'Código',
                    headerCellClass: 'bg-header',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreArticulo',
                    field: 'nombreArticulo',
                    displayName: 'NombreArticulo',
                    headerCellClass: 'bg-header',
                    width: 250,
                    enableCellEdit: false,
                },
                {
                    name: 'cantidad',
                    field: 'cantidad',
                    displayName: 'Cantidad',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'vrUnitario',
                    field: 'vrUnitario',
                    displayName: 'VrUnitario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
                },
                {
                    name: 'pcDscto',
                    field: 'pcDscto',
                    displayName: 'Dscto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 50,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'pcIva',
                    field: 'pcIva',
                    displayName: 'Iva',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 50,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'valorBruto',
                    field: 'valorBruto',
                    displayName: 'VrBruto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
                },
                {
                    name: 'valorNeto',
                    field: 'valorNeto',
                    displayName: 'VrNeto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    rowEntity.valorBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    rowEntity.valorNeto = rowEntity.valorBruto - (rowEntity.valorBruto * rowEntity.pcDscto / 100) + (rowEntity.valorBruto * rowEntity.pcIva / 100);
                    CalcularTotales();
                });
            },
        };

        function CalcularTotales() {
            vm.entityMov.valorBruto = 0;
            vm.entityMov.valorDscto = 0;
            vm.entityMov.valorIva = 0;
            vm.entityMov.valorNeto = 0;
            
            for (var i = 0; i < vm.gridOptions.data.length; i++) {
                var data = vm.gridOptions.data[i];
                vm.entityMov.valorBruto += data.valorBruto;
                vm.entityMov.valorDscto += data.valorBruto * data.pcDscto / 100;
                vm.entityMov.valorIva += (data.valorBruto * data.pcDscto / 100) * data.pcIva / 100;
                vm.entityMov.valorNeto += data.valorNeto;
            }
        }


        function guardar() {
            if (vm.gridOptions.data.length > 0) {
                vm.entityMov.idUsuario = vm.userApp.idUsu;
                vm.entityMov.idEmpresa = vm.userApp.idEmpresa;

                var data = {
                    entityMov: vm.entityMov,
                    listDetalleMov: vm.gridOptions.data,
                };

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

    }
})();