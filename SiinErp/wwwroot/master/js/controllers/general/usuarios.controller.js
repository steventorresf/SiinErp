(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'GenUsuariosService'];

    function AppController($location, $scope, $cookies, usuService) {
        
        var vm = this;

        vm.title = 'Home Page';
        vm.formVisible = false;
        vm.formModify = false;
        vm.entity = {
            clave: '.',
            estado: 'A',
        };

        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;
        $scope.inactivarUsu = inactivarUsu;
        $scope.activarUsu = activarUsu;
        $scope.resetClave = resetClave;
        

        function init() {
            getAll();
        }


        function getAll() {
            var response = usuService.getAll();
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
            vm.entity = {
                clave: '.',
                estado: 'A',
            };

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
            if (!vm.formModify) { response = usuService.create(vm.entity); }
            else { response = usuService.update(vm.entity.idUsuario, vm.entity); }

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

        function inactivarUsu(entity) {
            var data = {
                IdUsuario: entity.idUsuario,
                Estado: 'I',
            }

            var response = usuService.upEstado(data);
            response.then(
                function (response) {
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function activarUsu(entity) {
            var data = {
                IdUsuario: entity.idUsuario,
                Estado: 'A',
            }

            var response = usuService.upEstado(data);
            response.then(
                function (response) {
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function resetClave(entity) {
            var response = usuService.resetClave(entity.idUsuario);
            response.then(
                function (response) {
                    
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
                    name: 'nombreCompleto',
                    field: 'nombreCompleto',
                    displayName: 'Nombre Completo',
                },
                {
                    name: 'nombreUsuario',
                    field: 'nombreUsuario',
                    displayName: 'Nombre Usuario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 200,
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
                        "<span class='mr-1'><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit'></i></a></span>" +

                        "<span class='mr-1' ng-if='row.entity.estado === \"A\"'><a href='' ng-click='grid.appScope.resetClave(row.entity)' tooltip='Resetear Clave' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-lock text-black-50'></i></a></span>" +

                        "<span ng-if='row.entity.estado === \"A\"'><a href='' ng-click='grid.appScope.inactivarUsu(row.entity)' tooltip='Inactivar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-user-times text-danger'></i></a></span>" +

                        "<span ng-if='row.entity.estado === \"I\"'><a href='' ng-click='grid.appScope.activarUsu(row.entity)' tooltip='Activar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-user-plus text-info'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };
    }
})();
