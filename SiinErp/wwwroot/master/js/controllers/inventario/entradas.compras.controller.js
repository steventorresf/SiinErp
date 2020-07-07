(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'ComOrdenesService', 'ComOrdenesDetService', 'InvMovimientosService'];

    function AppController($location, $cookies, $scope, growl, ordService, orddetService, movService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.verDetalle = verDetalle;
        vm.guardar = guardar;
        vm.regresar = regresar;
        $scope.verDetalle = verDetalle;

        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        
        function init() {
            getAll();
        }

        function getAll() {
            var response = ordService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
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
                    name: 'tipoDoc',
                    field: 'tipoDoc',
                    displayName: 'Tipo Doc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: '# Orden',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                },
                {
                    name: 'proveedor.nombreProveedor',
                    field: 'proveedor.nombreProveedor',
                    displayName: 'NombreProveedor',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'fechaDoc',
                    field: 'fechaDoc',
                    displayName: 'FechaDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    type: 'date',
                    cellFilter: 'date: \'yyyy-MM-dd\'',
                },
                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
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
                        "<span><a href='' ng-click='grid.appScope.verDetalle(row.entity)' tooltip='Detalle' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 80,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };


        function verDetalle(entity) {
            vm.entityMov = {};
            vm.entityMov.fechaDoc = '2020-01-30';
            vm.entity = {};
            vm.entityOrd = angular.copy(entity);
            getDetalle();
            vm.form = true;
            var config = { referenceId:2, title: 'gdgd', ttl: 6000 };
            console.log(growl);
            growl.success("steven", config);
            console.log(growl.error("torres", config));
        }

        function getDetalle() {
            var response = orddetService.getAll(vm.entityOrd.idOrden);
            response.then(
                function (response) {
                    vm.gridOptionsDet.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsDet = {
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
                    headerCellClass: 'bg-header',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreArticulo',
                    field: 'articulo.nombreArticulo',
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
                    enableCellEdit: false,
                },
                {
                    name: 'margen',
                    field: 'margen',
                    displayName: 'Margen',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
                },
                {
                    name: 'cantidadEje',
                    field: 'cantidadEje',
                    displayName: 'Cant. Entre',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
                },
                {
                    name: 'cantidadRecibida',
                    field: 'cantidadRecibida',
                    displayName: 'Cant. Rec.',
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
                    if (rowEntity.cantidad - rowEntity.cantidadEje >= newValue) {
                        rowEntity.vrBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                        rowEntity.vrNeto = rowEntity.vrBruto - (rowEntity.vrBruto * rowEntity.pcDscto / 100) + (rowEntity.vrBruto * rowEntity.pcIva / 100);
                        if (vm.modify) {
                            updateArt(rowEntity);
                        }
                    }
                    else { rowEntity.cantidadRecibida = oldValue; }
                });
            },
        };


        function guardar() {
            vm.listDetalleMov = [];
            for (var i = 0; i < vm.gridOptionsDet.data.length; i++) {
                var ob = vm.gridOptionsDet.data[i];
                if (ob.cantidadRecibida > 0) {
                    vm.listDetalleMov.push({
                        idArticulo: ob.idArticulo,
                        cantidad: ob.cantidadRecibida,
                        vrUnitario: ob.vrUnitario,
                        vrCosto: ob.vrUnitario,
                        pcDscto: ob.pcDscto,
                        pcIva: ob.pcIva,
                    });
                }
            }

            if (vm.listDetalleMov.length > 0) {
                vm.entityMov.idUsuario = vm.userApp.idUsu;

                var data = {
                    numFactura: vm.entity.numFactura,
                    entityOrd: vm.entityOrd,
                    entityMov: vm.entityMov,
                    listDetalleMov: vm.listDetalleMov,
                };

                var response = movService.createByEntradaCompra(data);
                response.then(
                    function (response) {
                        regresar();
                        getAll();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function regresar() {
            vm.form = false;
        }

    }
})();