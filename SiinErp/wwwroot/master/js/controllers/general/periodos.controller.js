(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'GenPeriodoService', 'GenModuloService'];

    function AppController($location, $scope, $cookies, perService, modService) {
        
        var vm = this;
        vm.title = 'periodos';
        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.cancelar = cancelar;
        vm.guardar = guardar;
        vm.getSig = getSig;
        $scope.editar = editar;
        vm.listSituacion = [
            { codigo: 'A', descripcion: 'Abierto' },
            { codigo: 'C', descripcion: 'Cerrado' }
        ];

        function init() {
            vm.userApp = $cookies.getObject('UsuApp');
            getAll();
            getAllModulosPer();
        }
        

        function getAll() {
            var response = perService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getSig() {
            var response = perService.getSig(vm.userApp.idEmpresa, vm.entity.codModulo);
            response.then(
                function (response) {
                    var data = response.data;
                    vm.entity.periodoAnterior = data[0];
                    vm.entity.periodoActual = null;
                    vm.entity.periodoActual = data[1];
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getAllModulosPer() {
            var response = modService.getAllPer();
            response.then(
                function (response) {
                    vm.listModulos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevo() {
            vm.entity = {};
            vm.entity.situacion = 'A';
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
            vm.entity.idUsuario = vm.userApp.idUsu;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) {
                response = perService.update(vm.entity.idPeriodo, vm.entity);
            }
            else {
                vm.entity.fechaInicio = vm.entity.periodoActual.substring(0, 4) + '-' + vm.entity.periodoActual.substring(4) + '-01';
                response = perService.create(vm.entity);
            }

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
            enableRowHeaderSelection: false,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'nombreModulo',
                    field: 'nombreModulo',
                    displayName: 'Módulo',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'periodoActual',
                    field: 'periodoActual',
                    displayName: 'PeriodoActual',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'periodoAnterior',
                    field: 'periodoAnterior',
                    displayName: 'PeriodoAnterior',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'fechaInicio',
                    field: 'fechaInicio',
                    type: 'date',
                    displayName: 'FechaInicio',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 180,
                },
                {
                    name: 'fechaFin',
                    field: 'fechaFin',
                    type: 'date',
                    displayName: 'FechaFin',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                    width: 180,
                },
                {
                    name: 'situacion',
                    field: 'situacion',
                    displayName: 'Situacion',
                    headerCellClass: 'bg-header',
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
                    headerCellClass: 'bg-header',
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
