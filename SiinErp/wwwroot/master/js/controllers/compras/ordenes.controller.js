(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'ComOrdenesService', 'ComOrdenesDetService', 'ComProveedoresService', 'CarPlazosPagoService', 'GenTablasDetService', 'InvArticulosService', 'GenTiposDocService'];

    function AppController($location, $cookies, $scope, ordService, orddetService, proService, ppaService, tabdetService, artService, tipdocService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getProveedores = getProveedores;
        vm.guardar = guardar;
        vm.nuevo = nuevo;
        vm.editar = editar;
        $scope.editar = editar;
        vm.regresar = regresar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.onChangeProveedor = onChangeProveedor;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.entity = {
            idEmpresa: vm.userApp.idEmpresa,
            estado: Estados.Pendiente,
            periodo: '.',
        };

        function init() {
            getAll();
            getProveedores();
            getPlazosPago();
            getAlmacens();
            getCentrosCosto();
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

        function getAll() {
            var response = ordService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptionsPro.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsPro = {
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
                    displayName: 'Tipo Doc',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: '# Orden',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'proveedor.nombreProveedor',
                    field: 'proveedor.nombreProveedor',
                    displayName: 'NombreProveedor',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 80,
                },
                {
                    name: 'valorNeto',
                    field: 'valorNeto',
                    displayName: 'VrNeto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
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
                    width: 80,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiPro = gridApi;
            },
        };

        function nuevo() {
            vm.entity = {
                idEmpresa: vm.userApp.idEmpresa,
                estado: Estados.Pendiente,
                periodo: '.',
                idUsuario: vm.userApp.IdUsu,
            };
            vm.gridOptions.data = [];
            getTipoDoc();

            vm.modify = false;
            vm.form = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.fechaDoc = angular.copy(entity.fechaDoc).toString().substring(0, 10);
            vm.entity.idDetAlmacen = angular.copy(entity.idDetAlmacen);
            vm.entity.idDetCenCosto = angular.copy(entity.idDetCenCosto);
            getDetalle();
            vm.modify = true;
            vm.form = true;
        }

        function getDetalle() {
            var response = orddetService.getAll(vm.entity.idOrden);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
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
            vm.entity.idPlazoPago = $item.idPlazoPago;
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
                idArticulo: $item.idArticulo,
                articulo: $item,
                cantidad: 0,
                vrUnitario: $item.vrCosto,
                pcDscto: 0,
                pcIva: $item.pcIva,
                vrBruto: 0,
                vrNeto: 0,
                estado: Estados.Pendiente,
            });
            vm.entity.idArticulo = null;
        }

        function getTipoDoc() {
            var response = tipdocService.getByCod(GenTiposDoc.OrdenCompra);
            response.then(
                function (response) {
                    var data = response.data;
                    vm.entity.tipoDoc = data.tipoDoc;
                    vm.entity.numDoc = data.numDoc;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getAlmacens() {
            var response = tabdetService.getAll(Tab.InvAlm);
            response.then(
                function (response) {
                    vm.listAlmacens = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getCentrosCosto() {
            var response = tabdetService.getAll(Tab.InvCenCos);
            response.then(
                function (response) {
                    vm.listCentrosCosto = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        


        function guardar() {
            vm.entity.listDetalle = angular.copy(vm.gridOptions.data);
            var response = ordService.create(vm.entity);
            response.then(
                function (response) {
                    window.location.href = url + 'Compras/Home/Ordenes';
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function regresar() {
            vm.form = false;
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
                    field: 'articulo.codArticulo',
                    displayName: 'Código',
                    headerCellClass: 'text-center',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreArticulo',
                    field: 'articulo.nombreArticulo',
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
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'vrUnitario',
                    field: 'vrUnitario',
                    displayName: 'VrUnitario',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'pcDscto',
                    field: 'pcDscto',
                    displayName: 'Dscto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 50,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'pcIva',
                    field: 'pcIva',
                    displayName: 'Iva',
                    headerCellClass: 'text-center',
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
                    headerCellClass: 'text-center',
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
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
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
                    width: 80,
                    enableCellEdit: false,
                }
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
            vm.entity.valorBruto = 0;
            vm.entity.valorDscto = 0;
            vm.entity.valorIva = 0;
            vm.entity.valorNeto = 0;

            for (var i = 0; i < vm.gridOptions.data.length; i++) {
                var data = vm.gridOptions.data[i];
                vm.entity.valorBruto += data.vrBruto;
                vm.entity.valorDscto += data.vrBruto * data.pcDscto / 100;
                vm.entity.valorIva += data.vrBruto * data.pcIva / 100;
                vm.entity.valorNeto += data.vrBruto - (data.vrBruto * data.pcDscto / 100) + (data.vrBruto * data.pcIva / 100);
            }
        }

    }
})();