(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', 'GenTablasService', 'GenModulosService'];

    function AppController($location, $scope, tabService, modService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.formVisible = false;
        vm.formModify = false;
        vm.entity = {};
        vm.listModulos = [{codModulo:'ABC',descripcion:'Steven'}];

        vm.init = init;
        vm.getModulos = getModulos;
        vm.getTablas = getTablas;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;

        function init() {
            getTablas();
            getModulos();
        }


        function getModulos() {
            var response = modService.getAll();
            response.then(
                function (response) {
                    vm.listModulos = response.data;
                    console.log(vm.listModulos);
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTablas() {
            var response = tabService.getAll();
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
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar (entity) {
            vm.entity = angular.copy(entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        $scope.editar = editar;

        function guardar() {

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
                    name: 'codTabla',
                    field: 'codTabla',
                    displayName: 'Código',
                    width: 200,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripción',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    cellClass:'text-center',
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