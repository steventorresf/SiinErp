(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', 'GenPeriodosService'];

    function AppController($location, $cookies, perService) {
        
        var vm = this;
        vm.title = 'periodos';
        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.cancelar = cancelar;
        vm.guardar = guardar;

        function init() {
            vm.userApp = $cookies.getObject('UsuApp');
            getAll();
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


        function nuevo() {
            vm.entity = {};
            vm.entity.periodoAnterior = '-';
            vm.entity.periodoSiguiente = '-';
            vm.entity.situacion = 'A';
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
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
            if (vm.formModify) { response = perService.update(vm.entity.idPeriodo, vm.entity); }
            else { response = perService.create(vm.entity); }

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
                    name: 'codSist',
                    field: 'codSist',
                    displayName: 'Cod. Sistema',
                    headerCellClass: 'bg-header',
                    width: 100,
                },
                {
                    name: 'periodoActual',
                    field: 'periodoActual',
                    displayName: 'PeriodoActual',
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
                    width: 120,
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
