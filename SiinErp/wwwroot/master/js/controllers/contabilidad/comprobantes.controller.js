(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ContTiposDocService', 'GenTercerosService', 'GenTablasEmpresaDetService', 'ContRetencionService', 'ContPlanDeCuentaService', 'ContComprobantesService'];

    function AppController($location, $scope, $cookies, tdocService, terService, tabdetService, retService, cuentService, comprobService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.guardar = guardar;
        vm.agregarDet = agregarDet;
        vm.agDet = agDet;
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
            getTiposDoc();
            getCuentasContable();
            getTerceros();
            getCentroCostos();
            getRetencion();
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
            var response = cuentService.getAll(vm.userApp.idEmpresa);
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
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function cancelarDet() {
            vm.formVisibleDet = false;
        }

        function agregarDet() {
            var data = {
                detalle: vm.entityDet.detalle,
                idCuentaContable: vm.entityDet.idCuentaContable,
                cuentaContable: vm.entityCuentaCont.nombreCuenta,
                idTercero: vm.entityDet.idTercero,
                nombreTercero: vm.entityTercero.nombreTercero,
                debCred: vm.entityDet.debCred,
                idDetCenCosto: vm.entityDet.idDetCenCosto,
                centroCosto: vm.entityCenCosto.descripcion,
                idRetencion: vm.entityDet.idRetencion,
                retencion: vm.entityRetencion.descripcion,
                valor: vm.entityDet.valor,
            };

            vm.gridOptionsDet.data.push(data);
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
                    name: 'cuentaContable',
                    field: 'cuentaContable',
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
                    name: 'retencion',
                    field: 'retencion',
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

        function guardar() {
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
                    //cancelar();
                    window.location.href = url + 'Contabilidad/Home/Comprobantes';
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();
