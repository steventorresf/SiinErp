(function () {
    'use strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'GenUsuarioService', 'MenuUsuarioService'];

    function AppController($location, $scope, $cookies, usuService, menusuService) {
        
        var vm = this;

        vm.title = 'Home Page';
        vm.formVisible = false;
        vm.formModify = false;
        vm.entity = {
            clave: '.',
            estadoFila: 'A',
            creadoPor: vm.userApp.nombreUsuario,
            modificadoPor: vm.userApp.nombreUsuario,
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
            vm.gridVisible = true;
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
                estadoFila: 'A',
                creadoPor: vm.userApp.nombreUsuario,
                modificadoPor: vm.userApp.nombreUsuario,
            };

            vm.formModify = false;
            vm.gridVisible = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.modificadoPor = vm.userApp.nombreUsuario;
            vm.formModify = true;
            vm.gridVisible = false;
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
            vm.gridVisible = true;
        }

        function inactivarUsu(entity) {
            var data = {
                idUsuario: entity.idUsuario,
                estadoFila: 'I',
                modificadoPor: vm.userApp.nombreUsuario,
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
                idUsuario: entity.idUsuario,
                estadoFila: 'A',
                modificadoPor: vm.userApp.nombreUsuario,
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
                    width: 150,
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
                        "<i class='fa fa-edit'></i></a></span>" +

                        "<span class='ml-1' ng-if='row.entity.estado === \"A\"'><a href='' ng-click='grid.appScope.resetClave(row.entity)' tooltip='Resetear Clave' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-lock text-black-50'></i></a></span>" +

                        "<span class='ml-1' ng-if='row.entity.estado === \"A\"'><a href='' ng-click='grid.appScope.inactivarUsu(row.entity)' tooltip='Inactivar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-user-times text-danger'></i></a></span>" +

                        "<span class='ml-1' ng-if='row.entity.estado === \"I\"'><a href='' ng-click='grid.appScope.activarUsu(row.entity)' tooltip='Activar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-user-plus text-info'></i></a></span>" +

                        "<span class='ml-1'><a href='' ng-click='grid.appScope.vm.menuUsuario(row.entity)' tooltip='Activar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-key text-success'></i></a></span>",
                    width: 150,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        vm.regresarMenuUsu = regresarMenuUsu;
        vm.menuUsuario = menuUsuario;
        vm.agregarMenuUsuario = agregarMenuUsuario;
        vm.quitarMenuUsu = quitarMenuUsu;

        function menuUsuario(entity) {
            vm.entityUsu = angular.copy(entity);

            getAllByIdUsuario();
            getNotAllByIdUsuario();

            vm.gridVisible = false;
            vm.gridMenuUsuVisible = true;
        }

        function getAllByIdUsuario() {
            vm.gridOptionsMenu.data = [];

            var response = menusuService.getAllByIdUsuario(vm.entityUsu.idUsuario);
            response.then(
                function (response) {
                    vm.gridOptionsMenu.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getNotAllByIdUsuario() {
            vm.listMenu = [];

            var response = menusuService.getNotAllByIdUsuario(vm.entityUsu.idUsuario);
            response.then(
                function (response) {
                    vm.listMenu = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function regresarMenuUsu() {
            vm.gridMenuUsuVisible = false;
            vm.gridVisible = true;
        }

        function agregarMenuUsuario() {
            var data = {
                idMenu: vm.idMenu,
                idUsuario: vm.entityUsu.idUsuario,
                estadoFila: 'A',
                creadoPor: vm.userApp.nombreUsuario,
                modificadoPor: vm.userApp.nombreUsuario,
            };

            var response = menusuService.create(data);
            response.then(
                function (response) {
                    vm.idMenu = null;
                    getAllByIdUsuario();
                    getNotAllByIdUsuario();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsMenu = {
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
                    name: 'menu.descripcion',
                    field: 'menu.descripcion',
                    displayName: 'Descripción',
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
                        "<span><a href='' ng-click='grid.appScope.vm.quitarMenuUsu(row.entity)' tooltip='Quitar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiMenu = gridApi;
            },
        };

        function quitarMenuUsu(entity) {
            var response = menusuService.remove(entity.idMenuUsuario);
            response.then(
                function (response) {
                    getAllByIdUsuario();
                    getNotAllByIdUsuario();
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();
