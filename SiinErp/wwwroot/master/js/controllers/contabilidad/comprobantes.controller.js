(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ContTiposDocService', 'GenTercerosService', 'GenTablasEmpresaDetService', 'ContRetencionService', 'ContPlanDeCuentaService', 'ContComprobantesService', 'ContComprobantesDetService'];

    function AppController($location, $scope, $cookies, tdocService, terService, tabdetService, retService, cuentService, comprobService, comprobdetService) {
        var vm = this;
        var fecha = new Date();

        vm.gridVisible = true;

        vm.fechaInicial = fecha.addDays(fecha.getDate() > 1 ? (fecha.getDate() - 1) * -1 : 0);
        vm.fechaFinal = fecha.addDays(0);

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.regresar = regresar;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.anular = anular;
        vm.agregarDet = agregarDet;
        vm.editarDet = editarDet;
        vm.agDet = agDet;
        vm.edDet = edDet;
        vm.quitar = quitar;
        vm.cancelarDet = cancelarDet;
        vm.listDebCred = [
            { codigo: 'D', descripcion: 'Debito' },
            { codigo: 'C', descripcion: 'Credito' }
        ];

        vm.onChangeTipoDoc = onChangeTipoDoc;
        vm.onChangeFechaDoc = onChangeFechaDoc;
        vm.onChangeCuentaCont = onChangeCuentaCont;
        vm.onChangeTercero = onChangeTercero;
        vm.onChangeCentroCosto = onChangeCentroCosto;
        vm.onChangeRetencion = onChangeRetencion;

        vm.valorDebito = 0;
        vm.valorCredito = 0;


        function init() {
            getAll();
            getTiposDoc();
            getCuentasContable();
            getTerceros();
            getCentroCostos();
            getRetencion();
        }

        function getAll() {
            vm.gridOptions.data = [];

            var response = comprobService.getAll(vm.userApp.idEmpresa, vm.fechaInicial.DateSiin(true), vm.fechaFinal.DateSiin(true));
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
            enableRowSelection: true,
            enableFullRowSelection: true,
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
                    width: 120,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'sFechaDoc',
                    field: 'sFechaDoc',
                    displayName: 'FechaDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 150,
                },
                {
                    name: 'periodo',
                    field: 'periodo',
                    displayName: 'Periodo',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 150,
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
                vm.gridApi = gridApi;
            },
        };

        function regresar() {
            vm.gridVisible = true;
        }

        function nuevo() {
            vm.entity = {};
            vm.gridOptionsDet.data = [];
            vm.valorDebito = 0;
            vm.valorCredito = 0;

            vm.formModify = false;
            vm.gridVisible = false;

            vm.i = 0;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.fechaDoc = new Date(vm.entity.fechaDoc);
            getAllDet();
            vm.formModify = true;
            vm.gridVisible = false;
        }

        function getAllDet() {
            var response = comprobdetService.getAll(vm.entity.idComprobante);
            response.then(
                function (response) {
                    vm.gridOptionsDet.data = response.data;
                    CalcularValores();
                    vm.i = 0;
                    for (var i = 0; i < vm.gridOptionsDet.data.length; i++) {
                        vm.gridOptionsDet.data[i].modo = 'E';
                        if (vm.gridOptionsDet.data[i].idDetalleComprobante > vm.i) {
                            vm.i = vm.gridOptionsDet.data[i].idDetalleComprobante;
                        }
                    }

                    vm.gridDetalle = [];
                    vm.gridDetalle = angular.copy(vm.gridOptionsDet.data);
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposDoc() {
            var response = tdocService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTiposContab = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeTipoDoc($item, $model) {
            vm.entityTipoDoc = $item;
            vm.entity.numDoc = vm.entityTipoDoc.numDoc + 1;
        }

        function onChangeFechaDoc() {
            vm.entity.periodo = vm.entity.fechaDoc.DatePeriodo();
        }


        function getCuentasContable() {
            var response = cuentService.getAllByNivel(vm.userApp.idEmpresa, '5');
            response.then(
                function (response) {
                    vm.listCuentaCont = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeCuentaCont($item, $model) {
            vm.entityCuentaCont = $item;
        }

        function getTerceros() {
            var response = terService.getAct(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTerceros = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeTercero($item, $model) {
            vm.entityTercero = $item;
        }

        function getCentroCostos() {
            var response = tabdetService.getAll(Tab.InvCenCos, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listCenCosto = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeCentroCosto($item, $model) {
            vm.entityCenCosto = $item;
        }

        function getRetencion() {
            var response = retService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listRetencion = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeRetencion($item, $model) {
            vm.entityRetencion = $item;
        }



        function agDet() {
            vm.entityDet = {};
            vm.formVisibleDet = true;
            vm.formModifyDet = false;
        }

        function edDet(entity) {
            vm.entityDet = angular.copy(entity);
            vm.formVisibleDet = true;
            vm.formModifyDet = true;
        }

        function cancelarDet() {
            vm.formVisibleDet = false;
        }

        function agregarDet() {
            vm.i++;

            var data = {
                idDetalleComprobante: vm.i,
                detalle: vm.entityDet.detalle,
                idCuentaContable: vm.entityDet.idCuentaContable,
                nombreCuenta: vm.entityCuentaCont.nombreCuenta,
                idTercero: vm.entityDet.idTercero,
                nombreTercero: vm.entityTercero.nombreTercero,
                debCred: vm.entityDet.debCred,
                idDetCenCosto: vm.entityDet.idDetCenCosto,
                centroCosto: vm.entityCenCosto.descripcion,
                idRetencion: vm.entityDet.idRetencion,
                nombreRetencion: vm.entityRetencion.descripcion,
                valor: vm.entityDet.valor,
                estado: 'A',
                creadoPor: vm.userApp.nombreUsuario,
                modo: 'A',
            };

            vm.gridOptionsDet.data.push(data);

            if (vm.formModify) {
                vm.gridDetalle.push(data);
            }

            CalcularValores();

            vm.formVisibleDet = false;
        }

        function editarDet() {
            var entity = null;

            for (var i = 0; i < vm.gridOptionsDet.data.length; i++) {
                if (vm.gridOptionsDet.data[i].idDetalleComprobante === vm.entityDet.idDetalleComprobante) {
                    if (vm.gridOptionsDet.data[i].detalle != vm.entityDet.detalle) {
                        vm.gridOptionsDet.data[i].detalle = vm.entityDet.detalle;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }
                    if (vm.gridOptionsDet.data[i].idCuentaContable != vm.entityDet.idCuentaContable) {
                        vm.gridOptionsDet.data[i].idCuentaContable = vm.entityDet.idCuentaContable;
                        vm.gridOptionsDet.data[i].nombreCuenta = vm.entityCuentaCont.nombreCuenta;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }
                    if (vm.gridOptionsDet.data[i].idTercero != vm.entityDet.idTercero) {
                        vm.gridOptionsDet.data[i].idTercero = vm.entityDet.idTercero;
                        vm.gridOptionsDet.data[i].nombreTercero = vm.entityTercero.nombreTercero;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }
                    if (vm.gridOptionsDet.data[i].debCred != vm.entityDet.debCred) {
                        vm.gridOptionsDet.data[i].debCred = vm.entityDet.debCred;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }
                    if (vm.gridOptionsDet.data[i].idDetCenCosto != vm.entityDet.idDetCenCosto) {
                        vm.gridOptionsDet.data[i].idDetCenCosto = vm.entityDet.idDetCenCosto;
                        vm.gridOptionsDet.data[i].centroCosto = vm.entityCenCosto.descripcion;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }
                    if (vm.gridOptionsDet.data[i].idRetencion != vm.entityDet.idRetencion) {
                        vm.gridOptionsDet.data[i].idRetencion = vm.entityDet.idRetencion;
                        vm.gridOptionsDet.data[i].nombreRetencion = vm.entityRetencion.descripcion;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }
                    if (vm.gridOptionsDet.data[i].valor != vm.entityDet.valor) {
                        vm.gridOptionsDet.data[i].valor = vm.entityDet.valor;
                        vm.gridOptionsDet.data[i].modo = vm.gridOptionsDet.data[i].modo === 'E' ? 'E' : 'A';
                    }

                    entity = vm.gridOptionsDet.data[i];
                    break;
                }
            }

            for (var i = 0; i < vm.gridDetalle.length; i++) {
                if (vm.gridDetalle[i].idDetalleComprobante === vm.entityDet.idDetalleComprobante) {
                    vm.gridDetalle[i] = entity;
                    break;
                }
            }            

            CalcularValores();

            vm.formVisibleDet = false;
        }

        vm.gridOptionsDet = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: false,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'detalle',
                    field: 'detalle',
                    displayName: 'Detalle',
                    headerCellClass: 'bg-header',
                    width: 400,
                },
                {
                    name: 'nombreCuenta',
                    field: 'nombreCuenta',
                    displayName: 'cuentaContable',
                    headerCellClass: 'bg-header',
                    width: 350,
                },
                {
                    name: 'nombreTercero',
                    field: 'nombreTercero',
                    displayName: 'Tercero',
                    headerCellClass: 'bg-header',
                    width: 350,
                },
                {
                    name: 'debCred',
                    field: 'debCred',
                    displayName: 'Deb/Cred',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'centroCosto',
                    field: 'centroCosto',
                    displayName: 'CentroCosto',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'nombreRetencion',
                    field: 'nombreRetencion',
                    displayName: 'Retencion',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'valor',
                    field: 'valor',
                    displayName: 'V. Transacción',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 150,
                },
                {
                    name: 'toolE',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.edDet(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit text-info'></i></a></span>",
                    width: 80,
                    enableCellEdit: false,
                },
                {
                    name: 'toolX',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.quitar(row.entity)' tooltip='Quitar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 80,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiDet = gridApi;
            },
        };

        function CalcularValores() {
            vm.valorDebito = 0;
            vm.valorCredito = 0;

            var data = vm.gridOptionsDet.data;
            for (var i = 0; i < data.length; i++) {
                if (data[i].debCred === 'D') {
                    vm.valorDebito += data[i].valor;
                }
                else {
                    vm.valorCredito += data[i].valor;
                }
            }
        }

        function quitar(entity) {
            vm.gridOptionsDet.data = vm.gridOptionsDet.data.filter(function (e) {
                return e.idDetalleComprobante != entity.idDetalleComprobante;
            });

            for (var i = 0; i < vm.gridDetalle.length; i++) {
                if (vm.gridDetalle[i].idDetalleComprobante === entity.idDetalleComprobante) {
                    vm.gridDetalle[i].modo = 'X';
                    break;
                }
            }
            CalcularValores();
        }

        function guardar() {
            if (vm.formModify) {
                vm.entity.modificadoPor = vm.userApp.nombreUsuario;

                var data = {
                    entity: vm.entity,
                    listEntity: vm.gridDetalle,
                };

                var response = comprobService.update(vm.entity.idComprobante, data);
                response.then(
                    function (response) {
                        getAll();
                        regresar();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else {
                vm.entity.estado = 'A';
                vm.entity.idEmpresa = vm.userApp.idEmpresa;
                vm.entity.creadoPor = vm.userApp.nombreUsuario;

                var data = {
                    entity: vm.entity,
                    listEntity: vm.gridOptionsDet.data,
                };

                var response = comprobService.create(data);
                response.then(
                    function (response) {
                        getAll();
                        regresar();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function anular() {
            var response = comprobService.anular(vm.entity.idComprobante, vm.userApp.nombreUsuario);
            response.then(
                function (response) {
                    getAll();
                    regresar();
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();
