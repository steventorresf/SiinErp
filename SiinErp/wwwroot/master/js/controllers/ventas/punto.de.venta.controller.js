(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'InvArticulosService', 'InvMovimientosService', 'GenTablasDetService', 'VenFacturasService'];

    function AppController($location, $cookies, $scope, growl, artService, movService, tabdetService, factService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.guardar = guardar;
        vm.entityMov = {};


        function init() {
            vm.entityMov.fechaDoc = new Date();
            getAlmacens();
        }


        function getAlmacens() {
            var response = tabdetService.getAll(Tab.InvAlm);
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
                vrNeto: 0,
                estado: Estados.Pendiente,
            };
            vm.gridOptions.data.push(entity);
            vm.entity.idArticulo = null;
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
            },
        };


        function guardar() {
            vm.entityMov.idEmpresa = vm.userApp.idEmpresa;
            vm.entityMov.idUsuario = vm.userApp.idUsu;

            var data = {
                entityMov: vm.entityMov,
                listDetalleMov: vm.gridOptions.data,
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

    }
})();