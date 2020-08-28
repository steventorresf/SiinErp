(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'InvArticulosService', 'InvMovimientosService', 'GenTablasEmpresaDetService', 'VenFacturasService'];

    function AppController($location, $cookies, $scope, growl, artService, movService, tabdetService, factService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.guardar = guardar;
        vm.entity = {
            valorBruto: 0,
            valorDscto: 0,
            valorIva: 0,
            valorNeto: 0,
            vrRestante: 0,
        };
        vm.entityMov = {};


        function init() {
            vm.entityMov.fechaDoc = new Date();
            getAlmacens();
            getFormsPagos();
        }


        function getAlmacens() {
            var response = tabdetService.getAll(Tab.InvAlm, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listAlmacens = response.data;
                    getLastAlm();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getFormsPagos() {
            var response = tabdetService.getAll(Tab.FormPago, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    var data = [];

                    for (var i = 0; i < response.data.length; i++) {
                        data.push({ idDetFormaDePago: response.data[i].idDetalle, descripcion: response.data[i].descripcion, valor: 0 });
                    }
                    
                    vm.gridOptionsPag.data = data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getLastAlm() {
            var response = factService.getLastAlm(vm.userApp.idUsu);
            response.then(
                function (response) {
                    vm.entityMov.idDetAlmacen = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function refreshArticulo(prefix) {
            if (prefix.length > 2) {
                var data = {
                    IdEmp: vm.userApp.idEmpresa,
                    Prefix: prefix,
                };

                var response = artService.getAllByPrefix(data);
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
            var entity = {
                idArticulo: $item.idArticulo,
                codArticulo: $item.codArticulo,
                nombreArticulo: $item.nombreArticulo,
                cantidad: 1,
                vrUnitario: $item.vrVenta,
                vrCosto: $item.vrCosto,
                pcDscto: 0,
                pcIva: $item.pcIva,
                vrBruto: $item.vrVenta,
                vrNeto: $item.vrVenta + ($item.vrVenta * $item.pcIva / 100),
                estado: Estados.Pendiente,
            };
            vm.gridOptions.data.push(entity);
            vm.entity.idArticulo = null;
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
                    width: 350,
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
                    enableCellEdit: false,
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
                    enableCellEdit: false,
                },
                {
                    name: 'vrBruto',
                    field: 'vrBruto',
                    displayName: 'VrBruto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
                },
                {
                    name: 'vrNeto',
                    field: 'vrNeto',
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
                    rowEntity.vrBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    rowEntity.vrNeto = rowEntity.vrBruto - (rowEntity.vrBruto * rowEntity.pcDscto / 100) + (rowEntity.vrBruto * rowEntity.pcIva / 100);
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
                vm.entityMov.valorBruto += data.vrBruto;
                vm.entityMov.valorDscto += data.vrBruto * data.pcDscto / 100;
                vm.entityMov.valorIva += data.vrBruto * data.pcIva / 100;
                vm.entityMov.valorNeto += data.vrBruto - (data.vrBruto * data.pcDscto / 100) + (data.vrBruto * data.pcIva / 100);
            }
        }

        vm.gridOptionsPag = {
            data: [],
            enableSorting: true,
            enableRowSelection: false,
            enableFullRowSelection: false,
            multiSelect: false,
            enableRowHeaderSelection: false,
            enableColumnMenus: false,
            enableFiltering: false,
            columnDefs: [
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'FormaDePago',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
                {
                    name: 'valor',
                    field: 'valor',
                    displayName: 'Valor',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiPag = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (newValue < 0) {
                        rowEntity.valor = oldValue;
                    }

                    vm.entity.vrRestante = vm.entityMov.valorNeto;
                    for (var i = 0; i < vm.gridOptionsPag.data.length; i++) {
                        vm.entity.vrRestante -= vm.gridOptionsPag.data[i].valor;
                    }
                    
                });
            },
        };


        function guardar() {
            vm.listDetallePag = [];
            var data = vm.gridOptionsPag.data;
            var pagoTotal = 0;

            for (var i = 0; i < data.length; i++) {
                if (data[i].valor > 0) {
                    pagoTotal += data[i].valor;
                    vm.listDetallePag.push(data[i]);
                }
            }

            if ((vm.entityMov.valorNeto - pagoTotal) === 0) {
                vm.entityMov.idEmpresa = vm.userApp.idEmpresa;
                vm.entityMov.idUsuario = vm.userApp.idUsu;

                var data = {
                    entityMov: vm.entityMov,
                    listDetalleMov: vm.gridOptions.data,
                    listDetallePag: vm.listDetallePag,
                };

                var response = movService.createByPuntoDeVenta(data);
                response.then(
                    function (response) {
                        window.location.reload();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else {

            }

            
        }

    }
})();