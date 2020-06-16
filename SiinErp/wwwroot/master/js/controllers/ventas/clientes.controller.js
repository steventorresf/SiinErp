﻿(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'InvArticulosService', 'GenTablasDetService'];

    function AppController($location, $cookies, $scope, artService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;
        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        function init() {
            getAll();
            getTiposArt();
            getUnidadMed();
        }

        function getAll() {
            var response = artService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposArt() {
            var response = tabdetService.getAll(Tab.TiposArt);
            response.then(
                function (response) {
                    vm.listTiposArt = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getUnidadMed() {
            var response = tabdetService.getAll(Tab.UnidadMed);
            response.then(
                function (response) {
                    vm.listUnidadMed = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }



        function nuevo() {
            vm.entity = {};
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
            vm.entity.idUsuario = vm.userApp.idUsu;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.idDetTipoArticulo = angular.copy(entity.idDetTipoArticulo).toString();
            vm.entity.idDetUnidadMed = angular.copy(entity.idDetUnidadMed).toString();
            vm.entity.esLinea = angular.copy(entity.esLinea).toString();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = artService.update(vm.entity.idArticulo, vm.entity); }
            else { response = artService.create(vm.entity); }

            response.then(
                function (response) {
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
        }

        vm.gridOptions = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'codArticulo',
                    field: 'codArticulo',
                    displayName: 'Código',
                    headerCellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'referencia',
                    field: 'referencia',
                    displayName: 'Referencia',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreArticulo',
                    field: 'nombreArticulo',
                    displayName: 'Nombre Articulo',
                    headerCellClass: 'text-center',
                    width: 350,
                },
                {
                    name: 'nombreTipoArticulo',
                    field: 'nombreTipoArticulo',
                    displayName: 'Tipo Articulo',
                    headerCellClass: 'text-center',
                    width: 250,
                },
                {
                    name: 'nombreUnidadMed',
                    field: 'nombreUnidadMed',
                    displayName: 'UnidadMed',
                    headerCellClass: 'text-center',
                    width: 150,
                },
                {
                    name: 'descEsLinea',
                    field: 'descEsLinea',
                    displayName: '¿EsLinea?',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'peso',
                    field: 'peso',
                    displayName: 'Peso',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'pcIva',
                    field: 'pcIva',
                    displayName: 'PcIva',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'stkMin',
                    field: 'stkMin',
                    displayName: 'StockMin',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'stkMax',
                    field: 'stkMax',
                    displayName: 'StockMax',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'vrVenta',
                    field: 'vrVenta',
                    displayName: 'VrVenta',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'vrCosto',
                    field: 'vrCosto',
                    displayName: 'VrCosto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'existencia',
                    field: 'existencia',
                    displayName: 'Existencia',
                    headerCellClass: 'text-center',
                    cellClass: 'text-right',
                    width: 100,
                },
                {
                    name: 'indCosto',
                    field: 'indCosto',
                    displayName: 'IndCosto',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'indConsumo',
                    field: 'indConsumo',
                    displayName: 'IndConsumo',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'fechaUEntrada',
                    field: 'fechaUEntrada',
                    displayName: 'FechaUEntrada',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 200,
                },
                {
                    name: 'fechaUSalida',
                    field: 'fechaUSalida',
                    displayName: 'FechaUSalida',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 200,
                },
                {
                    name: 'fechaUPedida',
                    field: 'fechaUPedida',
                    displayName: 'FechaUPedida',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 200,
                },
                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

    }
})();
