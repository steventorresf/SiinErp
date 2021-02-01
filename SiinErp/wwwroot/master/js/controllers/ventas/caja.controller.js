(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'VenCajaService', 'VenCajaDetService', 'GenTablaDetService'];

    function AppController($location, $cookies, $scope, cajaService, cajadetService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.onSelectCajero = onSelectCajero;
        vm.getAll = getAll;
        vm.abrirCaja = abrirCaja;
        vm.cerrarCaja = cerrarCaja;
        vm.btnGuardar = btnGuardar;
        vm.cancelar = cancelar;
        vm.regresar = regresar;
        vm.egresoCaja = egresoCaja;
        vm.guardarEgreso = guardarEgreso;
        vm.cancelarEgIn = cancelarEgIn;
        vm.ingresoCaja = ingresoCaja;
        vm.guardarIngreso = guardarIngreso;
        vm.imprimir = imprimir;
        vm.imprimirCaja = imprimirCaja;

        vm.modoDet = false;

        function init() {
            getCajeros();
            getTurnos();

            vm.gridVisible = true;
        }

        function getCajeros() {
            var response = tabdetService.getAll(Tab.Cajeros, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listCajeros = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onSelectCajero($item, $model) {
            vm.gridOptions.data = [];
            vm.entityCaj = $item;
            getAll();
        }

        function getAll() {
            vm.cajaCerrada = true;

            var response = cajaService.getAll(vm.entityCaj.idDetalle);
            response.then(
                function (response) {
                    var data = response.data;
                    vm.cajaCerrada = true;
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].estado === 'A') {
                            vm.cajaCerrada = false;
                            break;
                        }
                    }
                    vm.gridOptions.data = data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTurnos() {
            var response = tabdetService.getAll(Tab.Turnos, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTurnos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function abrirCaja() {
            vm.entity = {
                idEmpresa: vm.userApp.idEmpresa,
                idDetCajero: vm.entityCaj.idDetalle,
                periodo: '-',
                idTurno: null,
                saldoInicial: null,
                creadoPor: vm.userApp.nombreUsuario,
                estado: 'A',
            };

            vm.gridVisible = false;
            vm.formOpen = true;
            vm.formVisible = true;
        }

        function cerrarCaja(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.saldoFinal = null;
            vm.entity.modificadoPor = vm.userApp.nombreUsuario;
            vm.entity.estado = 'C';

            vm.gridVisible = false;
            vm.formOpen = false;
            vm.formVisible = true;
        }

        function btnGuardar() {
            if (vm.formOpen) {
                guardar();
            }

            if (!vm.formOpen) {
                var response = cajadetService.getCantidadDetalleCaja(vm.entity.idCaja);
                response.then(
                    function (response) {
                        var cant = response.data;
                        if (cant > 0) {
                            guardar();
                        }
                        if (cant <= 0) {
                            alert('No puede cerrar la caja sin movimientos.');
                        }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function guardar() {
            var response = null;
            if (vm.formOpen) { response = cajaService.create(vm.entity); }
            else { response = cajaService.update(vm.entity.idCaja, vm.entity); }

            response.then(
                function (response) {
                    if (!vm.formOpen) {
                        vm.formVisible = false;
                        vm.postCerrado = true;
                    }

                    cancelar();
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelar() {
            vm.formVisible = false;
            vm.gridVisible = true;
        }

        function regresar() {
            vm.postCerrado = false;
            vm.gridVisible = true;
        }

        function imprimir(entity) {
            vm.entity = angular.copy(entity);
            imprimirCaja();
        }

        function imprimirCaja() {
            cajaService.imprimirCaja(vm.entity.idCaja);
        }

        function ingresoCaja(entity) {
            var response = cajaService.getSaldoEnCajaActual(entity.idCaja);
            response.then(
                function (response) {
                    vm.entityEgIn = {
                        idCaja: angular.copy(entity.idCaja),
                        tipoDoc: 'IN',
                        efectivo: true,
                        saldoEnCaja: response.data,
                        transaccion: 1,
                        estado: 'A',
                        creadoPor: vm.userApp.nombreUsuario,
                    };

                    vm.gridVisible = false;
                    vm.formEgIn = true;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function guardarIngreso() {
            if (vm.entityEgIn.saldoEnCaja >= vm.entityEgIn.valor && vm.entityEgIn.valor > 0) {
                var response = cajadetService.create(vm.entityEgIn);
                response.then(
                    function (response) {
                        cancelarEgIn();
                        alert('¡El ingreso ha sido regisrado exitosamente!');
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else {
                alert('El egreso debe ser menor que el saldo en caja.');
            }
        }



        function egresoCaja(entity) {
            var response = cajaService.getSaldoEnCajaActual(entity.idCaja);
            response.then(
                function (response) {
                    vm.entityEgIn = {
                        idCaja: angular.copy(entity.idCaja),
                        tipoDoc: 'EG',
                        efectivo: true,
                        saldoEnCaja: response.data,
                        transaccion: -1,
                        estado: 'A',
                        creadoPor: vm.userApp.nombreUsuario,
                    };

                    vm.gridVisible = false;
                    vm.formEgIn = true;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function guardarEgreso() {
            if (vm.entityEgIn.saldoEnCaja >= vm.entityEgIn.valor && vm.entityEgIn.valor > 0) {
                var response = cajadetService.create(vm.entityEgIn);
                response.then(
                    function (response) {
                        cancelarEgIn();
                        alert('¡El egreso ha sido regisrado exitosamente!');
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else {
                alert('El egreso debe ser menor que el saldo en caja.');
            }
        }

        function cancelarEgIn() {
            vm.formEgIn = false;
            vm.gridVisible = true;
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
                    name: 'sFechaDoc',
                    field: 'sFechaDoc',
                    displayName: 'Fecha',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 170,
                },
                {
                    name: 'nombreTurno',
                    field: 'nombreTurno',
                    displayName: 'Turno',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 170,
                },
                {
                    name: 'creadoPor',
                    field: 'creadoPor',
                    displayName: 'CreadoPor',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 180,
                },
                {
                    name: 'nombreEstado',
                    field: 'nombreEstado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 170,
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
                        "<span ng-if='row.entity.estado === \"C\"'><a href='' ng-click='grid.appScope.vm.imprimir(row.entity)' data-toggle='tooltip' title='Imprimir' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>" +
                        "<span ng-if='row.entity.estado === \"A\"' class='ml-1'><a href='' ng-click='grid.appScope.vm.cerrarCaja(row.entity)' title='Cerrar Caja' tooltip='Cerrar Caja' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-window-close text-info'></i></a></span>" +
                        "<span ng-if='row.entity.estado === \"A\"' class='ml-1'><a href='' ng-click='grid.appScope.vm.egresoCaja(row.entity)' title='Egreso' tooltip='Egreso' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-sign-out text-danger'></i></a></span>" +
                        "<span ng-if='row.entity.estado === \"A\"' class='ml-1'><a href='' ng-click='grid.appScope.vm.ingresoCaja(row.entity)' title='Ingreso' tooltip='Ingreso' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-sign-in text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

    }
})();
