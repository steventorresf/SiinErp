(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'ComOrdenesService', 'ComOrdenesDetService', 'GenTercerosService', 'CarPlazosPagoService', 'GenTablasEmpresaDetService', 'InvArticulosService', 'GenTiposDocService'];

    function AppController($location, $cookies, $scope, ordService, orddetService, terService, ppaService, tabdetService, artService, tipdocService) {
        var vm = this;
        var fecha = new Date();

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.getProveedores = getProveedores;
        vm.guardar = guardar;
        vm.nuevo = nuevo;
        vm.editar = editar;
        
        vm.regresar = regresar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.onChangeProveedor = onChangeProveedor;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.removeArt = removeArt;

        vm.fechaInicial = fecha.addDays(fecha.getDate() > 1 ? (fecha.getDate() - 1) * -1 : 0);
        vm.fechaFinal = fecha.addDays(0);

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
            vm.gridOptionsPro.data = [];

            var response = ordService.getAll(vm.userApp.idEmpresa, vm.fechaInicial.DateSiin(true), vm.fechaFinal.DateSiin(true));
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
                    name: 'nombreTercero',
                    field: 'proveedor.nombreTercero',
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
                    cellFilter: 'date: \'dd/MM/yyyy\'',
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
                        "<span><a href='' ng-click='grid.appScope.vm.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
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
                creadoPor: vm.userApp.nombreUsuario,
            };
            vm.gridOptions.data = [];
            getTipoDoc();

            vm.modify = false;
            vm.form = true;

            vm.i = 0;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.fechaDoc = new Date(new Date(vm.entity.fechaDoc).toUTCString());
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
                    CalcularTotales();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getProveedores() {
            var response = terService.getActPro(vm.userApp.idEmpresa);
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
                cantidad: 1,
                margen: 0,
                cantidadEje: 0,
                vrUnitario: $item.vrCosto,
                pcDscto: 0,
                pcIva: $item.pcIva,
                vrBruto: 0,
                vrNeto: 0,
                estado: Estados.Pendiente,
            };

            var val = ValidarArticulo(entity.idArticulo);
            if (val) {
                if (vm.modify) {
                    entity.idDetalleOrden = 0;
                    entity.idOrden = vm.entity.idOrden;
                    var response = orddetService.create(entity);
                    response.then(
                        function (response) {
                            getDetalle();
                        },
                        function (response) {
                            console.log(response);
                        }
                    );
                }
                else {
                    vm.gridOptions.data.push(entity);
                    CalcularTotales();
                }
            }

            vm.entity.idArticulo = null;
        }

        function ValidarArticulo(idArt) {
            var val = true;
            var data = vm.gridOptions.data;
            for (var i = 0; i < data.length; i++) {
                if (data[i].idArticulo === idArt) {
                    val = false;
                    break;
                }
            }
            return val;
        }

        function getTipoDoc() {
            var response = tipdocService.getByCod(GenTiposDoc.OrdenCompra);
            response.then(
                function (response) {
                    var data = response.data;
                    vm.entity.tipoDoc = data.tipoDoc;
                    vm.entity.numDoc = data.numDoc + 1;
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

        function getCentrosCosto() {
            var response = tabdetService.getAll(Tab.InvCenCos, vm.userApp.idEmpresa);
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
            console.log("grabando ", vm.entity);
            var response = null;
            if (!vm.modify) { response = ordService.create(vm.entity); }
            else { response = ordService.update(vm.entity.idOrden, vm.entity); }
            response.then(
                function (response) {
                    vm.form = false;
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function regresar() {
            vm.form = false;
            getAll();
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
                    name: 'margen',
                    field: 'margen',
                    displayName: 'Margen',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
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
                        "<span ng-if='row.entity.cantidadEje === 0'><a href='' ng-click='grid.appScope.vm.removeArt(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
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
                    if (vm.modify) {
                        updateArt(rowEntity);
                    }
                    CalcularTotales();
                });
            },
        };

        function updateArt(entity) {
            var response = orddetService.update(entity.idDetalleOrden, entity);
            response.then(
                function (response) {
                    
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function removeArt(entity) {
            if (vm.modify) {
                var response = orddetService.remove(entity.idDetalleOrden);
                response.then(
                    function (response) {
                        getDetalle();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else {
                vm.gridOptions.data = vm.gridOptions.data.filter(function (ob) {
                    return ob.idDetalleOrden != entity.idDetalleOrden;
                });

                CalcularTotales();
            }
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