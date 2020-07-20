(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'VenClientesService', 'VenVendedoresService', 'CarPlazosPagoService', 'GenTablasEmpresaDetService', 'InvArticulosService', 'InvTiposDocService', 'InvMovimientosService'];

    function AppController($location, $cookies, $scope, cliService, venService, ppaService, tabdetService, artService, tipdocService, movService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getClientes = getClientes;
        vm.guardar = guardar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.onChangeCliente = onChangeCliente;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.removeArt = removeArt;
        $scope.removeArt = removeArt;
        vm.entityFac = {};

        function init() {
            getTipoDoc();
            getClientes();
            getPlazosPago();
            getAlmacens();
            getVendedores();
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

        function onChangeCliente($item, $model) {
            vm.entityFac.idPlazoPago = $item.idPlazoPago;
            vm.entityFac.idVendedor = $item.idVendedor;
            vm.entityFac.idListaPrecio = $item.idListaPrecio;
            vm.entityFac.numCuotas = $item.plazoPago.cuotas;
            vm.entityFac.plazoDias = $item.plazoPago.plazoDias;
        }

        function getPlazosPago() {
            var response = ppaService.getAll(vm.userApp.idEmpresa);
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
            vm.i++;
            var entity = {
                idDetalleOrden: vm.i,
                idArticulo: $item.idArticulo,
                articulo: $item,
                cantidad: 0,
                margen: 0,
                cantidadEje: 0,
                vrUnitario: $item.vrCosto,
                pcDscto: 0,
                pcIva: $item.pcIva,
                vrBruto: 0,
                vrNeto: 0,
                estado: Estados.Pendiente,
            };

            vm.gridOptions.data.push(entity);
            vm.entity.idArticulo = null;
        }

        function getTipoDoc() {
            var response = tipdocService.getTipoDoc(vm.userApp.idEmpresa, InvTiposDoc.FacturaVenta);
            response.then(
                function (response) {
                    var data = response.data;
                    vm.entityFac.tipoDoc = data.tipoDoc;
                    vm.entityFac.numDoc = data.numDoc + 1;
                },
                function (response) {
                    console.log(response);
                }
            );
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

        function getVendedores() {
            var response = venService.getAct(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listVendedores = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }




        function guardar() {
            vm.entityMov.idEmpresa = vm.userApp.idEmpresa;
            vm.entityMov.idUsuario = vm.userApp.idUsu;

            vm.entityFac.idEmpresa = vm.userApp.idEmpresa;
            vm.entityFac.idDetAlmacen = angular.copy(vm.entityMov.idDetAlmacen);
            vm.entityFac.fechaDoc = angular.copy(vm.entityMov.fechaDoc);
            vm.entityFac.FechaPago = vm.entityFac.plazoDias > 0 ? null : vm.entityFac.FechaDoc;
            vm.entityFac.comentario = angular.copy(vm.entityMov.comentario);
            vm.entityFac.idUsuario = vm.userApp.idUsu;
            vm.entityFac.estado = Estados.Activo;

            var data = {
                entityFac: vm.entityFac,
                entityMov: vm.entityMov,
                listDetalleMov: vm.gridOptions.data,
            };

            var response = movService.createByFacturaDeVenta(data);
            response.then(
                function (response) {
                    window.location.reload();
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
                        "<span><a href='' ng-click='grid.appScope.removeArt(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
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

        function removeArt(entity) {
            vm.gridOptions.data = vm.gridOptions.data.filter(function (ob) {
                return ob.idDetalleOrden != entity.idDetalleOrden;
            });
        }

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