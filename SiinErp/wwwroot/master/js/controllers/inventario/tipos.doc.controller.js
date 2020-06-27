﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'InvTiposDocService', 'GenTablasDetService'];

    function AppController($location, $scope, $cookies, tipdocService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.getTiposDoc = getTiposDoc;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;

        vm.listTransaccions = [
            { idDetalle: '1', descripcion: "Entrada" },
            { idDetalle: '-1', descripcion: "Salida" }
        ];

        function init() {
            getTiposDoc();
        //  getTransaccionInv();
            getAlmInv();
           
        }

        function getTiposDoc() {
            var response = tipdocService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTransaccionInv() {
            var response = tabdetService.getAll("InvTrans");//Tab.InvTrans
            response.then(
                function (response) {
                    vm.listTransaccions = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getAlmInv() {
            
            var response = tabdetService.getAll("InvAlmacen"); //Tab.InvAlm);
            response.then(
                function (response) {
                    vm.listAlmacen = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

       

        function nuevo() {
            vm.entity = {};
            vm.entity.idUsuario = vm.userApp.idUsuario;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.transaccion = angular.copy(entity.transaccion).toString();
            vm.entity.idDetAlmacen = angular.copy(entity.idDetAlmacen).toString();
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            vm.entity.idEmpresa = vm.userApp.idEmpresa;

            var response = null;
            if (vm.formModify) { response = tipdocService.update(vm.entity.idTipoDoc, vm.entity); }
            else { response = tipdocService.create(vm.entity); }

            response.then(
                function (response) {
                    cancelar();
                    getTiposDoc();
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
                    name: 'nomAlmacen',
                    field: 'nomAlmacen',
                    displayName: 'Almacen',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'tipoDoc',
                    field: 'tipoDoc',
                    displayName: 'TipoDoc',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumDoc',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripcion',
                    headerCellClass: 'text-center',
                    width: 300,
                },
                {
                    name: 'nomTransaccion',
                    field: 'nomTransaccion',
                    displayName: 'Transacción',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 120,
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