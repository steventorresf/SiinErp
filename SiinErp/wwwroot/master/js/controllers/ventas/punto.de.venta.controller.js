(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'GenTerceroService', 'VenListaPrecioService', 'InvArticuloService', 'InvMovimientoService', 'GenTablaDetService', 'VenCajaService', 'CarPlazoPagoService', 'VenVendedorService', 'GenDepartamentoService', 'GenCiudadService', 'CarPlazoPagoService', 'GenTipoDocService'];

    function AppController($location, $cookies, $scope, growl, terService, lisService, artService, movService, tabdetService, cajaService, ppaService, venService, depService, ciuService, ppaService, tipdocService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.btnGuardar = btnGuardar;
        vm.btnAnular = btnAnular;
        vm.entityMov = {
            tipoDoc: GenTiposDoc.FacturaVenta,
            idEmpresa: vm.userApp.idEmpresa,
            valorBruto: 0,
            valorDscto: 0,
            valorIva: 0,
            valorNeto: 0,
            vrRestante: 0,
            creadoPor: vm.userApp.nombreUsuario,
            modify: false,
        };

        vm.clicAntSig = clicAntSig;
        vm.refreshCliente = refreshCliente;
        vm.onChangeCliente = onChangeCliente;
        vm.getClienteByIden = getClienteByIden;
        vm.getArticuloByCod = getArticuloByCod;
        vm.clicTipoBusqueda = clicTipoBusqueda;
        vm.busquedaArtCodigo = true;
        vm.busquedaArtTexto = false;
        vm.quitarArticulo = quitarArticulo;
        vm.bloquearInput = bloquearInput;
        vm.onChangeFormaDePago = onChangeFormaDePago;
        vm.onChangeCuenta = onChangeCuenta;
        vm.agregarFp = agregarFp;
        vm.quitarFp = quitarFp;

        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.crearCliente = crearCliente;
        vm.guardarCliente = guardarCliente;
        vm.cancelarCliente = cancelarCliente;
        vm.getCiudades = getCiudades;

        vm.onChangeListaPrecios = onChangeListaPrecios;
        vm.onChangePlazoPago = onChangePlazoPago;
        vm.onChangeCajero = onChangeCajero;

        vm.imprimirFact = imprimirFact;
        vm.imprimirPVen = imprimirPVen;
        vm.terminarFact = terminarFact;

        vm.last = {
            idDetAlmacen: null,
            idDetCajero: null,
        };


        function init() {
            vm.gridPrincipal = true;
            vm.entityMov.sFechaDoc = new Date();

            getTipoDocFacturaVenta();
            getPlazosPago();
            getListasPrecios();
            getAlmacens();
            getCajeros();
            getFormsPagos();
            getCuentasBan();

            getVendedores();
            getZonas();
            getDepartamentos();
            getTiposPersona();
        }


        function getTipoDocFacturaVenta() {
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

        function clicAntSig(tipo) {
            if (tipo === 'A' && vm.entityMov.numDoc > 1) {
                vm.entityMov.numDoc--;
            }

            if (tipo === 'S') {
                vm.entityMov.numDoc++;
            }

            getByDocumento();
        }

        function refreshCliente(prefix) {
            if (prefix.length > 2) {
                var data = {
                    idEmpresa: vm.userApp.idEmpresa,
                    prefix: prefix,
                };
                
                var response = terService.getCliByPrefix(data);
                response.then(
                    function (response) {
                        vm.listClientes = response.data;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function onChangeCliente($item, $model) {
            if ($item.nitCedula === '999') {
                vm.entityMov.idTercero = null;
                vm.entityMov.nombreTercero = null;
                vm.entityMov.direccionTercero = null;
                vm.entityMov.telefonoTercero = null;
                vm.entityMov.idPlazoPago = null;
                vm.entityMov.plazoPago = null;
                vm.entityMov.idListaPrecio = null;
                vm.entityMov.listaPrecios = null;
            }
            else {
                vm.entityMov.idTercero = $item.idTercero;
                vm.entityMov.nombreTercero = $item.nombreTercero;
                vm.entityMov.direccionTercero = $item.direccion;
                vm.entityMov.telefonoTercero = $item.telefono;
                vm.entityMov.idPlazoPago = $item.idPlazoPago;
                vm.entityMov.plazoPago = $item.plazoPago;
                vm.entityMov.idListaPrecio = $item.idListaPrecio;
                vm.entityMov.listaPrecios = $item.listaPrecios;
            }
        }

        function getByDocumento() {
            var data = {
                idEmpresa: vm.userApp.idEmpresa,
                tipoDoc: vm.entityMov.tipoDoc,
                numDoc: vm.entityMov.numDoc,
            };

            var response = movService.getByDocumento(data);
            response.then(
                function (response) {
                    vm.entityMov = {
                        tipoDoc: data.tipoDoc,
                        numDoc: data.numDoc,
                        idDetAlmacen: angular.copy(vm.last.idDetAlmacen),
                        idDetCajero: angular.copy(vm.last.idDetCajero),
                        creadoPor: vm.userApp.nombreUsuario,
                        vrRestante: 0,
                        modify: false,
                    };

                    vm.gridOptions.data = [];
                    vm.gridOptionsPag.data = [];


                    var dataR = response.data;
                    if (dataR.entity != null) {

                        if (dataR.listCli != undefined) {
                            vm.listClientes = dataR.listCli;
                        }
                        else { vm.listClientes = []; }

                        vm.entityMov = dataR.entity;
                        vm.entityMov.sFechaDoc = new Date(vm.entityMov.sFechaFormatted);
                        vm.entityMov.modificadoPor = vm.userApp.nombreUsuario;
                        vm.entityMov.vrRestante = 0;
                        vm.entityMov.modify = true;

                        vm.gridOptions.data = dataR.entity.listaDetalle;
                        vm.gridOptionsPag.data = dataR.entity.listaFormaPago;

                        if (vm.gridOptionsPag.data.length > 0) {
                            vm.entityMov.vrRestante = angular.copy(vm.entityMov.valorNeto);
                            for (var i = 0; i < vm.gridOptionsPag.data.length; i++) {
                                vm.entityMov.vrRestante -= vm.gridOptionsPag.data[i].valor;
                            }
                        }
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getClienteByIden() {
            vm.entityMov.idTercero = null;
            vm.entityMov.nombreTercero = null;
            vm.entityMov.direccionTercero = null;
            vm.entityMov.telefonoTercero = null;
            vm.entityMov.idPlazoPago = null;
            vm.entityMov.plazoPago = null;
            vm.entityMov.idListaPrecio = null;
            vm.entityMov.listaPrecios = null;

            if (vm.entityMov.nitCedula != '') {
                var data = {
                    idEmpresa: vm.userApp.idEmpresa,
                    nitCedula: vm.entityMov.nitCedula,
                };

                var response = terService.getCliByIden(data);
                response.then(
                    function (response) {
                        var dataCli = response.data.entity;
                        if (dataCli != null) {
                            vm.entityMov.idTercero = dataCli.idTercero;
                            vm.entityMov.nombreTercero = dataCli.nombreTercero;
                            vm.entityMov.direccionTercero = dataCli.direccion;
                            vm.entityMov.telefonoTercero = dataCli.telefono;
                            vm.entityMov.idPlazoPago = dataCli.idPlazoPago;
                            vm.entityMov.plazoPago = dataCli.plazoPago;
                            vm.entityMov.idListaPrecio = dataCli.idListaPrecio;
                            vm.entityMov.listaPrecios = dataCli.listaPrecios;
                        }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }


        function getListasPrecios() {
            var response = lisService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listListasPrecios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeListaPrecios($item, $model) {
            vm.entityMov.listaPrecios = $item;
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

        function getCajeros() {
            var response = tabdetService.getAll(Tab.Cajeros, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listCajeros = response.data;
                    getLastCaja();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeCajero($item, $model) {
            var response = cajaService.getIdCajaActiva(vm.entityMov.idDetCajero);
            response.then(
                function (response) {
                    vm.entityMov.idCaja = response.data;
                    if (vm.entityMov.idCaja === 0) {
                        alert('La caja NO se encuentra Abierta.');
                    }
                    if (vm.entityMov.idCaja < 0) {
                        alert('La caja se encuentra Abierta más de una vez.');
                    }
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
                    vm.listFormasDePago = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getCuentasBan() {
            var response = tabdetService.getAll(Tab.VenCuentas, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    console.log(response.data);
                    vm.listCuentasBan = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }
        
        function getLastAlm() {
            var response = movService.getLastAlm(vm.userApp.nombreUsuario, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    if (response.data > 0) {
                        vm.last.idDetAlmacen = response.data;
                        vm.entityMov.idDetAlmacen = response.data;
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }
        
        function getLastCaja() {
            var response = cajaService.getLastIdDetCajeroByUsu(vm.userApp.nombreUsuario, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    if (response.data > 0) {
                        vm.last.idDetCajero = response.data;
                        vm.entityMov.idDetCajero = response.data;
                        onChangeCajero();
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

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
            if (prefix.length > 2) {
                var data = {
                    idEmpresa: vm.userApp.idEmpresa,
                    idListaPrecio: vm.entityMov.idListaPrecio,
                    prefix: prefix,
                };

                var response = artService.GetByPrefixListaP(data);
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

        function getArticuloByCod() {
            if (vm.entityMov.busquedaCodigo != undefined && vm.entityMov.busquedaCodigo != null && vm.entityMov.busquedaCodigo != '') {
                var data = {
                    idEmpresa: vm.userApp.idEmpresa,
                    idListaPrecio: vm.entityMov.idListaPrecio,
                    codigo: vm.entityMov.busquedaCodigo,
                };

                var response = artService.getByCodigoAndListaP(data);
                response.then(
                    function (response) {
                        var entity = response.data;
                        if (entity != null && entity != undefined && entity != '') {
                            onChangeArticulo(entity, null);
                        }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function validarArticulo($item) {
            var val = true;

            var data = vm.gridOptions.data.filter(function (e) {
                return e.idArticulo === $item.idArticulo;
            });

            if (data.length > 0) {
                val = false;
            }

            return val;
        }

        function onChangeArticulo($item, $model) {
            var val = validarArticulo($item);
            if (val) {
                var entity = {
                    idArticulo: $item.idArticulo,
                    codArticulo: $item.codArticulo,
                    nombreArticulo: $item.nombreArticulo,
                    cantidad: 1,
                    vrUnitario: $item.vrVenta,
                    vrCosto: $item.vrCosto,
                    pcDscto: 0,
                    pcIva: $item.pcIva,
                    incluyeIva: $item.incluyeIva,
                    vrBruto: 0,
                    vrNeto: 0,
                    vrDscto: 0,
                    vrIva: 0,
                    estado: Estados.Pendiente,
                };
                vm.gridOptions.data.push(entity);
                vm.entityMov.idArticulo = null;
                vm.entityMov.busquedaCodigo = null;
                CalcularTotales();
            }
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
                    displayName: 'Cant',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 80,
                    type: 'number',
                    cellFilter: 'number: 0',
                },
                {
                    name: 'vrUnitario',
                    field: 'vrUnitario',
                    displayName: 'Vr Unit',
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
                        "<span><a href='' ng-click='grid.appScope.vm.quitarArticulo(row.entity)' tooltip='Quitar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 50,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    //rowEntity.vrBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    //rowEntity.vrDscto = (rowEntity.vrBruto * rowEntity.pcDscto / 100);
                    //if (rowEntity.incluyeIva) {
                    //    var valSinIva = parseFloat(rowEntity.vrBruto / ((rowEntity.pcIva / 100) + 1));
                    //    rowEntity.vrIva = rowEntity.vrBruto - valSinIva;
                    //    rowEntity.vrNeto = rowEntity.vrBruto - rowEntity.vrDscto;
                    //}
                    //else {
                    //    rowEntity.vrIva = (rowEntity.vrBruto * rowEntity.pcIva / 100);
                    //    rowEntity.vrNeto = rowEntity.vrBruto - rowEntity.vrDscto + rowEntity.vrIva;
                    //}
                    
                    CalcularTotales();
                });
            },
        };

        function quitarArticulo(entity) {
            var data = vm.gridOptions.data.filter(function (e) {
                return e.idArticulo != entity.idArticulo;
            });

            vm.gridOptions.data = data;
            CalcularTotales();
        }

        function CalcularTotales() {
            vm.entityMov.valorBruto = 0;
            vm.entityMov.valorDscto = 0;
            vm.entityMov.valorIva = 0;
            vm.entityMov.valorNeto = 0;

            for (var i = 0; i < vm.gridOptions.data.length; i++) {
                vm.gridOptions.data[i].vrBruto = (vm.gridOptions.data[i].vrUnitario * vm.gridOptions.data[i].cantidad);
                vm.gridOptions.data[i].vrDscto = (vm.gridOptions.data[i].vrBruto * vm.gridOptions.data[i].pcDscto / 100);

                if (vm.gridOptions.data[i].incluyeIva) {
                    var valSinIva = parseFloat((vm.gridOptions.data[i].vrBruto - vm.gridOptions.data[i].vrDscto) / ((vm.gridOptions.data[i].pcIva / 100) + 1));
                    vm.gridOptions.data[i].vrIva = vm.gridOptions.data[i].vrBruto - vm.gridOptions.data[i].vrDscto - valSinIva;
                    vm.gridOptions.data[i].vrNeto = vm.gridOptions.data[i].vrBruto - vm.gridOptions.data[i].vrDscto;
                }
                else {
                    vm.gridOptions.data[i].vrIva = (vm.gridOptions.data[i].vrBruto - vm.gridOptions.data[i].vrDscto) * vm.gridOptions.data[i].pcIva / 100;
                    vm.gridOptions.data[i].vrNeto = vm.gridOptions.data[i].vrBruto - vm.gridOptions.data[i].vrDscto + vm.gridOptions.data[i].vrIva;
                }

                vm.entityMov.valorBruto += vm.gridOptions.data[i].vrBruto - vm.gridOptions.data[i].vrIva;
                vm.entityMov.valorDscto += vm.gridOptions.data[i].vrDscto;
                vm.entityMov.valorIva += vm.gridOptions.data[i].vrIva;
                vm.entityMov.valorNeto += vm.gridOptions.data[i].vrNeto;
            }

            calcularFormaPago();
        }

        function bloquearInput(event) {
            //var code = event.which || event.keyCode;
            event.preventDefault();
        }

        function onChangeFormaDePago($item, $model) {
            vm.entityFp = $item;
            vm.entityCuenta = null;
            vm.idCuenta = null;
        }

        function onChangeCuenta($item, $model) {
            vm.entityCuenta = $item;
        }

        function agregarFp() {
            var data = vm.gridOptionsPag.data.filter(function (e) {
                return e.idDetFormaDePago === vm.idFormaDePago && e.idDetCuenta === vm.idCuenta;
            });

            if (data.length > 0) {
                alert("Dato duplicado");
            }
            else {
                vm.gridOptionsPag.data.push({
                    idDetFormaDePago: vm.idFormaDePago,
                    idDetCuenta: vm.idCuenta,
                    descripcion: vm.entityFp.descripcion,
                    descripcionCuenta: vm.idCuenta != null ? vm.entityCuenta.descripcion : '',
                    valor: vm.valorFp,
                    creadoPor: vm.userApp.nombreUsuario,
                });

                vm.idFormaDePago = null;
                vm.entityFp = null;
                vm.valorFp = null;
                vm.entityCuenta = null;
                vm.idCuenta = null;

                calcularFormaPago();
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
                    name: 'descripcionCuenta',
                    field: 'descripcionCuenta',
                    displayName: 'Cuenta Bancaria',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
                {
                    name: 'valor',
                    field: 'valor',
                    displayName: 'Valor',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
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
                        "<span><a href='' ng-click='grid.appScope.vm.quitarFp(row.entity)' tooltip='Quitar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 50,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiPag = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (newValue < 0) {
                        rowEntity.valor = oldValue;
                    }

                    calcularFormaPago();
                });
            },
        };

        function quitarFp(entity) {
            var data = vm.gridOptionsPag.data.filter(function (e) {
                return e.idDetFormaDePago != entity.idDetFormaDePago || e.idDetCuenta != entity.idDetCuenta;
            });

            vm.gridOptionsPag.data = data;

            calcularFormaPago();
        }

        function calcularFormaPago() {
            if (!vm.entityMov.modify || vm.entityMov.idDetCajero != null) {
                vm.entityMov.vrRestante = vm.entityMov.valorNeto;
                for (var i = 0; i < vm.gridOptionsPag.data.length; i++) {
                    vm.entityMov.vrRestante -= vm.gridOptionsPag.data[i].valor;
                }
            }
        }

        function btnGuardar() {
            var val = true;
            vm.entityMov.fechaDoc = vm.entityMov.sFechaDoc.DateSiin(true);
            vm.entityMov.valorSaldo = 0;
            vm.entityMov.tpPago = Constantes.TpPago_Contado;

            var length = vm.gridOptionsPag.data.filter(function (e) {
                return e.descripcion.toUpperCase() === 'A CREDITO' && e.valor > 0;
            });

            if (length.length > 0) {
                vm.entityMov.valorSaldo = length[0].valor;
                vm.entityMov.tpPago = Constantes.TpPago_Credito;
                if (vm.entityMov.idTercero === null || vm.entityMov.idTercero === undefined || vm.entityMov.idTercero <= 0) {
                    val = false;
                }
            }

            if (val) {
                if (vm.entityMov.modify === false) {
                    var response = cajaService.getIdCajaActiva(vm.entityMov.idDetCajero);
                    response.then(
                        function (response) {
                            vm.entityMov.idCaja = response.data;
                            if (vm.entityMov.idCaja > 0) {
                                guardar();
                            }
                            if (vm.entityMov.idCaja === 0) {
                                alert('La caja NO se encuentra Abierta.');
                            }
                            if (vm.entityMov.idCaja < 0) {
                                alert('La caja se encuentra Abierta más de una vez.');
                            }
                        },
                        function (response) {
                            console.log(response);
                        }
                    );
                }
                else {
                    guardar();
                }
            }
            else {
                alert('No puede asignar un valor "A Credito", porque no selecciona cliente. ');
            }
        }


        function guardar() {
            vm.listDetallePag = [];
            
            if (vm.entityMov.idTercero <= 0) {
                vm.entityMov.idTercero = null;
            }

            var data = {
                entityMov: vm.entityMov,
                listDetalleMov: vm.gridOptions.data,
                listDetallePag: vm.gridOptionsPag.data,
            };

            if (!vm.entityMov.modify) {
                var response = movService.createByPuntoDeVenta(data);
                response.then(
                    function (response) {
                        vm.entityMov.idMovimiento = response.data;
                        vm.gridPrincipal = false;
                        vm.gridTerminado = true;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else {
                var response = movService.updateByPuntoDeVenta(data);
                response.then(
                    function (response) {
                        vm.entityMov.idMovimiento = response.data;
                        vm.gridPrincipal = false;
                        vm.gridTerminado = true;
                    },
                    function (response) {
                        console.log(response);
                        alert("Ha ocurrido un error inesperado.\rPuede ser que la factura no se pueda modificar, porque ya tiene abono.")
                    }
                );
            }            
        }

        function btnAnular() {
            var response = movService.remove(vm.entityMov.idMovimiento);
            response.then(
                function (response) {
                    alert("¡La factura ha sido ANULADA correctamente!")
                    window.location.reload();
                },
                function (response) {
                    console.log(response);
                    alert("Ha ocurrido un error inesperado.\rPuede ser que la factura no se pueda anular, porque ya tiene abono.")
                }
            );
        }

        function imprimirPVen() {
            movService.imprimirPVen(vm.entityMov.idMovimiento);
        }

        function imprimirFact() {
            movService.imprimirFA(vm.entityMov.idMovimiento);
        }

        function terminarFact() {
            window.location.reload();
        }


        // Cliente
        function crearCliente() {
            vm.entityCli = {
                nitCedula: angular.copy(vm.entityMov.nitCedula),
                idEmpresa: vm.userApp.idEmpresa,
                tipoTercero: TipoTercero.Cliente,
                estado: Estados.Activo,
                creadoPor: vm.userApp.nombreUsuario,
            };

            vm.gridPrincipal = false;
            vm.gridCliente = true;
        }

        function getVendedores() {
            var response = venService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listVendedores = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getZonas() {
            var response = tabdetService.getAll(Tab.Zonas, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listZonas = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposPersona() {
            var response = tabdetService.getAll(Tab.TiposPer, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTiposPer = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getDepartamentos() {
            var response = depService.getAll();
            response.then(
                function (response) {
                    vm.listDepartamentos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getCiudades() {
            vm.entityCli.idCiudad = null;
            var response = ciuService.getAll(vm.entityCli.idDepartamento);
            response.then(
                function (response) {
                    vm.listCiudades = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function cancelarCliente() {
            vm.gridCliente = false;
            vm.gridPrincipal = true;
        }

        function guardarCliente() {
            vm.entityCli.nombreBusqueda = vm.entityCli.nitCedula + ' - ' + vm.entityCli.nombreTercero;

            var response = terService.create(vm.entityCli);
            response.then(
                function (response) {
                    cancelarCliente();
                    //getClienteByIden();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();