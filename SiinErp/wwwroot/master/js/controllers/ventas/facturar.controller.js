﻿(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'VenVendedorService', 'CarPlazoPagoService', 'GenTablaDetService', 'InvArticuloService', 'GenTipoDocService', 'InvMovimientoService', 'InvMovimientoDetalleService', 'GenTerceroService', 'VenListaPrecioDetalleService'];

    function AppController($location, $cookies, $scope, venService, ppaService, tabdetService, artService, tipdocService, movService, movdetService, terService, lisdetService) {
        var vm = this;
        var fecha = new Date();

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.getClientes = getClientes;
        vm.imprimir = imprimir;
        vm.guardar = guardar;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.anular = anular;
        vm.cancelar = cancelar;
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];
        vm.onChangeFecha = getAll;
        vm.onChangeCliente = onChangeCliente;
        vm.onChangePlazoPago = onChangePlazoPago;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.removeArt = removeArt;
        vm.entityMov = {};
        vm.formFact = false;

        vm.fechaInicial = fecha.addDays(fecha.getDate() > 1 ? (fecha.getDate() - 1) * -1 : 0);
        vm.fechaFinal = fecha.addDays(0);

        vm.clicTipoBusqueda = clicTipoBusqueda;
        vm.busquedaArtTexto = true;
        vm.busquedaArtCodigo = false;

        function init() {
            getAll();
            getClientes();
            getPlazosPago();
            getAlmacens();
            getVendedores();
        }

        function getAll() {
            //var response = movService.getByModificable(vm.entity.fecha.DateSiin(true));
            var response = movService.getAll(vm.userApp.idEmpresa, "VEN", vm.fechaInicial.DateSiin(true), vm.fechaFinal.DateSiin(true));
            response.then(
                function (response) {
                    vm.gridOptionsFac.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }




        vm.gridOptionsFac = {
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
                    displayName: 'TipoDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    enableCellEdit: false,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    enableCellEdit: false,
                },
                {
                    name: 'fechaDoc',
                    field: 'fechaDoc',
                    displayName: 'Fecha',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 150,
                    type: 'date',
                    cellFilter: 'date: \'dd/MM/yyyy\'',
                },
                {
                    name: 'nombreTercero',
                    field: 'nombreTercero',
                    displayName: 'NombreCliente',
                    headerCellClass: 'bg-header',
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
                        "<i class='fa fa-edit'></i></a></span>" +
                        "<span><a href='' ng-click='grid.appScope.vm.imprimir(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 80,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFac = gridApi;
            },
        };

        function clicTipoBusqueda(tipo) {
            if (tipo === 'Texto') {
                vm.entityMov.idArticulo = null;
                vm.busquedaArtCodigo = false;
                vm.busquedaArtTexto = true;
            }

            if (tipo === 'Codigo') {
                vm.entityMov.busquedaCodigo = null;
                vm.busquedaArtTexto = false;
                vm.busquedaArtCodigo = true;
            }
        }

        function refreshArticulo(prefix) {
            if (prefix.length > 2 && $scope.formApp.$valid) {
                var data = {
                    idEmp: vm.userApp.idEmpresa,
                    idListaPrecio: vm.entityMov.idListaPrecio,
                    prefix: prefix,
                };

                var response = lisdetService.getAllByPrefix(data);
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

        function imprimir(entity) {
            if (entity.idTercero > 0) {
                movService.imprimirFC(entity.idMovimiento);
            }

            if (entity.idTercero === null) {
                movService.imprimirFA(entity.idMovimiento);
            }
        }

        function getClientes() {
            var response = terService.getActCli(vm.userApp.idEmpresa);

            response.then(
                function (response) {
                    vm.listTerceros = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function onChangeCliente($item, $model) {
            vm.entityMov.idVendedor = $item.idVendedor;
            vm.entityMov.idPlazoPago = $item.idPlazoPago;
            vm.entityMov.plazoPago = $item.plazoPago;
            vm.entityMov.idListaPrecio = $item.idListaPrecio;
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

        function onChangePlazoPago($item, $model) {
            vm.entityMov.plazoPago = $item;
        }

        function onChangeArticulo($item, $model) {
            var val = ValidarArticulo($item);
            if (val) {
                var entity = {
                    idDetalleOrden: 0,
                    idArticulo: $item.idArticulo,
                    articulo: $item.articulo,
                    cantidad: 1,
                    margen: 0,
                    cantidadEje: 0,
                    vrUnitario: $item.vrUnitario,
                    pcDscto: $item.pcDscto,
                    pcIva: $item.pcIva,
                    vrBruto: 0,
                    vrNeto: 0,
                    estado: Estados.Pendiente,
                };

                vm.gridOptions.data.push(entity);
                vm.entityMov.idArticulo = null;
            }
        }

        function ValidarArticulo(entity) {
            var resp = true;
            var data = vm.gridOptions.data;
            for (var i = 0; i < data.length; i++) {
                if (data[i].idArticulo === entity.idArticulo) {
                    resp = false;
                    break;
                }
            }
            return resp;
        }

        function getTipoDoc() {
            var response = tipdocService.getByCod(vm.userApp.idEmpresa, GenTiposDoc.FacturaVenta);
            response.then(
                function (response) {
                    var data = response.data;
                    vm.entityMov.tipoDoc = data.tipoDoc;
                    vm.entityMov.numDoc = data.numDoc + 1;
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
            //    vm.entityMov.fechaVencimiento = vm.entityFac.fechaDoc + vm.entityFac.plazoDias;
            vm.entityFac.FechaPago = vm.entityFac.plazoDias > 0 ? null : vm.entityFac.FechaDoc;

            if (!$scope.modify) {
                guardarNuevo();
            }
            else {
                guardarEdicion();
            }
        }

        function guardarNuevo() {
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

        function guardarEdicion() {
            var response = facService.update(vm.entityFac.idFactura, vm.entityFac);
            response.then(
                function (response) {
                    window.location.reload();
                },
                function (response) {
                    console.log(response);
                }
            );
        }



        function anular() {
            var response = movService.remove(vm.entityMov.idMovimiento);
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
                  //      "<span ng-if='!grid.appScope.modify'><a href='' ng-click='grid.appScope.removeArt(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                  //      "<i class='fa fa-remove text-danger'></i></a></span>",
                        "<a href='' ng-click='grid.appScope.vm.removeArt(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
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
            console.log("elimino");
            vm.gridOptions.data = vm.gridOptions.data.filter(function (ob) {
                return ob.idArticulo != entity.idArticulo;
            });
        }

        function CalcularTotales() {
            vm.entityMov.valorBruto = 0;
            vm.entityMov.valorDscto = 0;
            vm.entityMov.valorIva = 0;
            vm.entityMov.valorNeto = 0;

            for (var i = 0; i < vm.gridOptions.data.length; i++) {
                vm.gridOptions.data[i].vrBruto = vm.gridOptions.data[i].vrUnitario * vm.gridOptions.data[i].cantidad;
                var data = vm.gridOptions.data[i];
                vm.entityMov.valorBruto += data.vrBruto;
                vm.entityMov.valorDscto += data.vrBruto * data.pcDscto / 100;
                vm.entityMov.valorIva += data.vrBruto * data.pcIva / 100;
                vm.entityMov.valorNeto += data.vrBruto - (data.vrBruto * data.pcDscto / 100) + (data.vrBruto * data.pcIva / 100);

                vm.gridOptions.data[i].vrNeto = data.vrUnitario - (data.vrBruto * data.pcDscto / 100) + (data.vrBruto * data.pcIva / 100);
            }
        }

        function nuevo() {
            vm.entityFac = {};
            vm.entityMov = {
                idEmpresa: vm.userApp.idEmpresa,
                fecha: fecha.addDays(fecha.getDate() > 1 ? (fecha.getDate() - 1) * -1 : 0),
                valorBruto: 0,
                valorDscto: 0,
                valorIva: 0,
                valorNeto: 0,
                creadoPor: vm.userApp.nombreUsuario,
                estado: Estados.Activo,
                periodo: '-',
            };
            getTipoDoc();
            vm.modify = false;
            $scope.modify = false;
            vm.formFact = true;
        }


        function editar(entity) {
            vm.entityFac = angular.copy(entity);
            vm.entityMov = angular.copy(entity);

            if ((typeof vm.entityMov.fechaDoc !== 'undefined') && (typeof vm.entityMov.fechaDoc === 'string')) {
                vm.entityMov.fechaDoc = new Date(new Date(vm.entityMov.fechaDoc).toUTCString());
            }

            vm.entityMov.idDetAlmacen = angular.copy(entity.idDetAlmacen);
            if (vm.entityMov.idVendedor != null) {
                vm.entityMov.idVendedor = angular.copy(entity.idVendedor);
            }

            vm.entityMov.idPlazoPago = angular.copy(entity.plazoPago.idPlazoPago);

            getClientes();
            getDetalleMov();

            vm.modify = true;
            $scope.modify = true;
            vm.formFact = true;
        }

        function getDetalleMov() {
            var response = movdetService.getAll(vm.entityMov.idMovimiento);
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

        function cancelar() {
            vm.formFact = false;
        }

    }
})();