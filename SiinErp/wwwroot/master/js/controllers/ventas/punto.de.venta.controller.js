(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'GenTercerosService', 'VenListaPreciosService', 'InvArticulosService', 'InvMovimientosService', 'GenTablasDetService', 'VenCajaService', 'CarPlazosPagoService', 'VenVendedoresService', 'GenDepartamentosService', 'GenCiudadesService', 'CarPlazosPagoService', 'GenTiposDocService'];

    function AppController($location, $cookies, $scope, growl, terService, lisService, artService, movService, tabdetService, cajaService, ppaService, venService, depService, ciuService, ppaService, tipdocService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.btnGuardar = btnGuardar;
        vm.entityMov = {
            idEmpresa: vm.userApp.idEmpresa,
            valorBruto: 0,
            valorDscto: 0,
            valorIva: 0,
            valorNeto: 0,
            vrRestante: 0,
            creadoPor: vm.userApp.nombreUsuario,
        };

        vm.getClienteByIden = getClienteByIden;
        vm.getArticuloByCod = getArticuloByCod;
        vm.clicTipoBusqueda = clicTipoBusqueda;
        vm.busquedaArtCodigo = true;
        vm.busquedaArtTexto = false;

        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.crearCliente = crearCliente;
        vm.guardarCliente = guardarCliente;
        vm.cancelarCliente = cancelarCliente;
        vm.getCiudades = getCiudades;

        vm.onChangeListaPrecios = onChangeListaPrecios;
        vm.onChangePlazoPago = onChangePlazoPago;

        vm.imprimirFact = imprimirFact;
        vm.terminarFact = terminarFact;


        function init() {
            vm.gridPrincipal = true;
            vm.entityMov.fechaDoc = new Date();

            getTipoDocFacturaVenta();
            getPlazosPago();
            getListasPrecios();
            getAlmacens();
            getCajeros();
            getFormsPagos();

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
                        console.log(dataCli);
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
        
        function getLastListaPrecioByUsuarioAndSinCliente() {
            var response = movService.getLastListaPrecioByUsuarioAndSinCliente(vm.userApp.nombreUsuario, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    if (response.data > 0) {
                        vm.entityMov.idDetAlmacen = response.data;
                    }
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
                        vm.entityMov.idDetCajero = response.data;
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
            vm.entityMov.idArticulo = null;
            vm.entityMov.busquedaCodigo = null;
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

                    vm.entityMov.vrRestante = vm.entityMov.valorNeto;
                    for (var i = 0; i < vm.gridOptionsPag.data.length; i++) {
                        vm.entityMov.vrRestante -= vm.gridOptionsPag.data[i].valor;
                    }
                });
            },
        };

        function btnGuardar() {
            var val = true;
            vm.entityMov.valorSaldo = 0;
            vm.entityMov.tpPago = Constantes.TpPago_Contado;

            var length = vm.gridOptionsPag.data.filter(function (e) {
                return e.descripcion === 'A Credito' && e.valor > 0;
            });
            
            if (length.length > 0) {
                vm.entityMov.valorSaldo = length[0].valor;
                vm.entityMov.tpPago = Constantes.TpPago_Credito;
                if (vm.entityMov.idTercero === null || vm.entityMov.idTercero === undefined || vm.entityMov.idTercero <= 0) {
                    val = false;
                }
            }

            if (val) {
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
                alert('No puede asignar un valor "A Credito", porque no selecciona cliente. ');
            }
        }


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
                if (vm.entityMov.idTercero <= 0) {
                    vm.entityMov.idTercero = null;
                }

                var data = {
                    entityMov: vm.entityMov,
                    listDetalleMov: vm.gridOptions.data,
                    listDetallePag: vm.listDetallePag,
                };

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

            }

            
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
            var response = terService.create(vm.entityCli);
            response.then(
                function (response) {
                    vm.entityMov.nitCedula = angular.copy(vm.entityCli.nitCedula);

                    cancelarCliente();
                    getClienteByIden();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();