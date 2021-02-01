(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ContTipoDocService', 'GenTablaDetService'];

    function AppController($location, $scope, $cookies, contipdocService, tabdetService) {
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
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

      
        function init() {
            getTiposDoc();
          
        }

        function getTiposDoc() {
            var response = contipdocService.getAll(vm.userApp.idEmpresa);
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
            vm.entity.idUsuario = vm.userApp.idUsuario;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            vm.entity.idEmpresa = vm.userApp.idEmpresa;

            var response = null;
            if (vm.formModify) { response = contipdocService.update(vm.entity.idTipoDoc, vm.entity); }
            else { response = contipdocService.create(vm.entity); }

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
                    width: 100,
                },
                {
                    name: 'numDoc',
                    field: 'numDoc',
                    displayName: 'NumDoc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'descripcion',
                    field: 'descripcion',
                    displayName: 'Descripcion',
                    headerCellClass: 'bg-header',
                    width: 400,
                },

                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
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
