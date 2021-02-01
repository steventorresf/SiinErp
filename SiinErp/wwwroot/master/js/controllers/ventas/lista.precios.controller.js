﻿(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', '$scope', 'VenListaPrecioService', 'VenListaPrecioDetalleService', 'InvArticuloService'];

    function AppController($location, $cookies, $scope, lisService, lisdetService, artService) {
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
        $scope.verDetalle = verDetalle;
        vm.listBool = [{ codigo: 'true', descripcion: 'Si' }, { codigo: 'false', descripcion: 'No' }];
        vm.listEstados = [{ codigo: 'A', descripcion: 'Activo' }, { codigo: 'I', descripcion: 'Inactivo' }];

        vm.modoDet = false;
        vm.refreshArticulo = refreshArticulo;
        vm.eliminarDet = eliminarDet;
        vm.agregarArticulo = agregarArticulo;
        vm.regresarDet = regresarDet;
        $scope.eliminarDet = eliminarDet;

        function init() {
            getAll();
        }

        function getAll() {
            var response = lisService.getAll(vm.userApp.idEmpresa);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function refreshArticulo(prefix) {
            if (prefix.length > 2) {
                var data = {
                    IdEmp: vm.userApp.idEmpresa,
                    Prefix: prefix,
                };

                var response = artService.getAllByPrefix(data);
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



        function nuevo() {
            vm.entity = {};
            vm.entity.idEmpresa = vm.userApp.idEmpresa;
            vm.entity.creadoPor = vm.userApp.nombreUsuario;
            vm.entity.estado = 'A';
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.modificadoPor = vm.userApp.nombreUsuario;
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = lisService.update(vm.entity.idListaPrecio, vm.entity); }
            else { response = lisService.create(vm.entity); }

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
                    name: 'nombreLista',
                    field: 'nombreLista',
                    displayName: 'Nombre Lista',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'estado',
                    field: 'estado',
                    displayName: 'Estado',
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
                        "<i class='fa fa-edit'></i></a></span>" +
                        "<span class='ml-1'><a href='' ng-click='grid.appScope.verDetalle(row.entity)' tooltip='Ver Detalle' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-search text-info'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };


        function regresarDet() {
            vm.modoDet = false;
        }

        function verDetalle(entity) {
            vm.entity = angular.copy(entity);
            vm.entityDet = {};
            vm.entityDet.idListaPrecio = angular.copy(entity.idListaPrecio);
            vm.listArticulos = [];
            getDetalle();
            vm.modoDet = true;
        }

        function getDetalle() {
            var response = lisdetService.getAll(vm.entity.idListaPrecio);
            response.then(
                function (response) {
                    vm.gridOptionsDet.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function agregarArticulo() {
            var resp = true;
            for (var i = 0; i < vm.gridOptionsDet.data.length; i++) {
                if (vm.entityDet.idArticulo === vm.gridOptionsDet.data[i].idArticulo) {
                    resp = false;
                    break;
                }
            }

            if (resp === true) {
                var response = lisdetService.create(vm.entityDet);
                response.then(
                    function (response) {
                        vm.entityDet = {};
                        getDetalle();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
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
                    name: 'articulo.nombreArticulo',
                    field: 'articulo.nombreArticulo',
                    displayName: 'Nombre Articulo',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'vrUnitario',
                    field: 'vrUnitario',
                    displayName: 'Vr Unitario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'pcDscto',
                    field: 'pcDscto',
                    displayName: '% Dscto',
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
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.eliminarDet(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiDet = gridApi;
            },
        };

        function eliminarDet(entity) {
            var response = lisdetService.remove(entity.idDetalleListaPrecio);
            response.then(
                function (response) {
                    getDetalle();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();
