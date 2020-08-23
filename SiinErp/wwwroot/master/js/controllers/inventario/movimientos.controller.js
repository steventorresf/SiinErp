(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'growl', 'InvMovimientosService', 'GenTablasEmpresaDetService', 'InvTiposDocService', 'InvArticulosService', 'GenTercerosService'];

    function AppController($location, $cookies, $scope, growl, movService, tabdetService, tipdocService, artService, terService) {
        var vm = this;
        var fecha = new Date();

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.nuevo = nuevo;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.anular = anular;
        vm.onChangeAlmacen = onChangeAlmacen;
        vm.onChangeTipoDoc = onChangeTipoDoc;
        vm.refreshArticulo = refreshArticulo;
        vm.onChangeArticulo = onChangeArticulo;
        vm.onChangeFecha = getAll;
        vm.almDestino = false;
        vm.formMov = false;
        vm.entity = {
            fecha: fecha.addDays(fecha.getDate() > 1 ? (fecha.getDate() - 1) * -1 : 0),
        };
        vm.entityMov = {};

        $scope.editar = editar;
        
        function init() {
            getAll();
            getAlmacens();
            getTerceros();
            getConceptos();
            getCenCostos();
        }

        function getAll() {
            var response = movService.getByModificable(vm.entity.fecha.DateSiin(true));
            response.then(
                function (response) {
                    vm.gridOptionsMov = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsMov = {
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
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumDoc',
                    headerCellClass: 'bg-header',
                    width: 100,
                    enableCellEdit: false,
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
                    name: 'nombreAlmacen',
                    field: 'nombreAlmacen',
                    displayName: 'NombreAlmacen',
                    headerCellClass: 'bg-header',
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
                        "<span><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 80,
                    enableCellEdit: false,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiMov = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    rowEntity.valorBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    rowEntity.valorNeto = rowEntity.valorBruto - (rowEntity.valorBruto * rowEntity.pcDscto / 100) + (rowEntity.valorBruto * rowEntity.pcIva / 100);
                    CalcularTotales();
                });
            },
        };

        function editar(entity) {
            vm.entityMov = angular.copy(entity);
            vm.entityMov.fechaDoc = new Date(angular.copy(entity.sFechaFormatted).toString());
            vm.entityMov.idDetAlmacen = angular.copy(entity.idDetAlmacen);

            getDetalleMov();

            vm.modify = true;
            $scope.modify = true;
            vm.formMov = true;
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

        function nuevo() {
            vm.entityMov = {};
            vm.idArticulo = null;
            vm.modify = false;
            $scope.modify = false;
            vm.formMov = true;
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

        function onChangeAlmacen($item, $model) {
            vm.gridOptions.data = [];
            vm.entityMov.tipoDoc = null;
            getTiposDocByAlmacen();
        }

        function getTiposDocByAlmacen() {
            var response = tipdocService.getByAlmacen(vm.entityMov.idDetAlmacen, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listTiposDoc = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeTipoDoc($item, $model) {
            if (vm.entityMov.transaccion != $item.transaccion) {
                vm.gridOptions.data = [];
            }

            vm.entityMov.numDoc = $item.numDoc;
            vm.entityMov.transaccion = $item.transaccion;

            if ($item.tipoDoc === InvTiposDoc.Traslados) {
                vm.almDestino = true;
                if (vm.entityMov.idDetAlmDestino === 0) {
                    vm.entityMov.idDetAlmDestino = null;
                }
            }
            else {
                vm.entityMov.idDetAlmDestino = 0;
                vm.almDestino = false;
            }
        }

        function getConceptos() {
            var response = tabdetService.getAll(Tab.InvConceptos, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listConceptos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getCenCostos() {
            var response = tabdetService.getAll(Tab.InvCenCos, vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.listCenCostos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function refreshArticulo(prefix) {
            if (prefix.length > 2) {
                var data = {
                    IdDetAlm: vm.entityMov.idDetAlmacen,
                    IdEmp: vm.userApp.idEmpresa,
                    Prefix: prefix,
                };

                var response = null;
                if (vm.entityMov.transaccion >= 0) {
                    response = artService.getAllByPrefix(data);
                }
                else {
                    response = artService.getAllByAlmPrefix(data);
                }

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

        function onChangeArticulo($item, $model) {
            vm.gridOptions.data.push({
                idArticulo: $item.idArticulo,
                codArticulo: $item.codArticulo,
                nombreArticulo: $item.nombreArticulo,
                cantidad: 1,
                vrUnitario: $item.vrVenta,
                vrCosto: $item.vrCosto,
                pcDscto: 0,
                pcIva: 0,
                valorBruto: $item.vrVenta,
                valorNeto: $item.vrVenta,
            });
            vm.idArticulo = null;
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
                },
                {
                    name: 'valorBruto',
                    field: 'valorBruto',
                    displayName: 'VrBruto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    width: 100,
                    type: 'number',
                    cellFilter: 'number: 0',
                    enableCellEdit: false,
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
                    enableCellEdit: false,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    rowEntity.valorBruto = (rowEntity.vrUnitario * rowEntity.cantidad);
                    rowEntity.valorNeto = rowEntity.valorBruto - (rowEntity.valorBruto * rowEntity.pcDscto / 100) + (rowEntity.valorBruto * rowEntity.pcIva / 100);
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
                vm.entityMov.valorBruto += data.valorBruto;
                vm.entityMov.valorDscto += data.valorBruto * data.pcDscto / 100;
                vm.entityMov.valorIva += (data.valorBruto * data.pcDscto / 100) * data.pcIva / 100;
                vm.entityMov.valorNeto += data.valorNeto;
            }
        }


        function guardar() {
            if (vm.gridOptions.data.length > 0) {
                vm.entityMov.idUsuario = vm.userApp.idUsu;
                vm.entityMov.idEmpresa = vm.userApp.idEmpresa;

                var data = {
                    entityMov: vm.entityMov,
                    listDetalleMov: vm.gridOptions.data,
                };

                var response = movService.create(data);
                response.then(
                    function (response) {
                        window.location.reload();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function cancelar() {
            vm.formMov = false;
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

    }
})();