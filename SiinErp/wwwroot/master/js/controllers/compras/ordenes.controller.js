(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'ComProveedoresService', 'CarPlazosPagoService', 'GenTablasDetService', 'InvArticulosService'];

    function AppController($location, $cookies, $scope, proService, ppaService, tabdetService, artService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getProveedores = getProveedores;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.onChangeProveedor = onChangeProveedor;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;

        function init() {
            getProveedores();
            getPlazosPago();
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

        function getProveedores() {
            var response = proService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listProveedores = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeProveedor($item, $model) {
            vm.entity.direccionDesp = $item.direccion;
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

        function onChangeArticulo($item, $model) {
            vm.gridOptions.data.push({
                codArticulo: $item.codArticulo,
                nombreArticulo: $item.nombreArticulo,
                cantidad: 0,
                vrUnitario: $item.vrCosto,
                pcDscto: 0,
                pcIva: $item.pcIva,
                vrBruto: 0,
                vrNeto: 0,
            });
            vm.entity.idArticulo = null;
        }

        


        function guardar() {
            var data = {
                entity: vm.entity,
                entityDet: vm.gridOptions.data,
            };

            var response = ordService.create(data);
            response.then(
                function (response) {
                    window.location.href = url + 'Compras/Home/Ordenes';
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
                    headerCellClass: 'text-center',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreArticulo',
                    field: 'nombreArticulo',
                    displayName: 'NombreArticulo',
                    headerCellClass: 'text-center',
                    width: 250,
                    enableCellEdit: false,
                },
                {
                    name: 'cantidad',
                    field: 'cantidad',
                    displayName: 'Cantidad',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
                    type: 'number',
                },
                {
                    name: 'vrUnitario',
                    field: 'vrUnitario',
                    displayName: 'VrUnitario',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 120,
                    type: 'number',
                },
                {
                    name: 'pcDscto',
                    field: 'pcDscto',
                    displayName: 'Dscto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 90,
                    type: 'number',
                },
                {
                    name: 'pcIva',
                    field: 'pcIva',
                    displayName: 'Iva',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 90,
                    type: 'number',
                    enableCellEdit: false,
                },
                {
                    name: 'vrBruto',
                    field: 'vrBruto',
                    displayName: 'VrBruto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 120,
                    type: 'number',
                    enableCellEdit: false,
                },
                {
                    name: 'vrNeto',
                    field: 'vrNeto',
                    displayName: 'VrNeto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 120,
                    type: 'number',
                    enableCellEdit: false,
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
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    rowEntity.vrBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    rowEntity.vrNeto = rowEntity.vrBruto - (rowEntity.vrBruto * rowEntity.pcDscto / 100) + (rowEntity.vrBruto * rowEntity.pcIva / 100);
                });
            },
        };

    }
})();