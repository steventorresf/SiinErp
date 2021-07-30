(function () {
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
        vm.updateDet = updateDet;
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
                    idEmpresa: vm.userApp.idEmpresa,
                    prefix: prefix,
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
            vm.entity = {
                idEmpresa: vm.userApp.idEmpresa,
                estadoFila: 'A',
                creadoPor: vm.userApp.nombreUsuario,
                modificadoPor: vm.userApp.nombreUsuario,
            };
            
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
            vm.entityDet = {
                idListaPrecio: angular.copy(vm.entity.idListaPrecio),
                estadoFila: 'A',
                creadoPor: vm.userApp.nombreUsuario,
                modificadoPor: vm.userApp.nombreUsuario,
            };
            
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
                        vm.entityDet = {
                            idListaPrecio: angular.copy(vm.entity.idListaPrecio),
                            estadoFila: 'A',
                            creadoPor: vm.userApp.nombreUsuario,
                            modificadoPor: vm.userApp.nombreUsuario,
                        };
                        getDetalle();
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
            else { alert('El articulo ya ha sido agregado previamente.'); }
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
                    name: 'articulo.codArticulo',
                    field: 'articulo.codArticulo',
                    displayName: 'Código',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                    width: 250,
                },
                {
                    name: 'articulo.nombreArticulo',
                    field: 'articulo.nombreArticulo',
                    displayName: 'Nombre Articulo',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
                {
                    name: 'vrUnitario',
                    field: 'vrUnitario',
                    displayName: 'Vr Unitario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                },
                {
                    name: 'pcDscto',
                    field: 'pcDscto',
                    displayName: '% Dscto',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 120,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    enableCellEdit: false,
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.eliminarDet(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiDet = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    updateDet(rowEntity);
                });
            },
        };

        function updateDet(entity) {
          
            entity.estadoFila = 'A';
            entity.creadoPor = vm.userApp.nombreUsuario;
            entity.modificadoPor = vm.userApp.nombreUsuario;
            entity.fechaModificado = Date;
            console.log("cambia", entity.idDetalleListaPrecio, entity);

            var response = lisdetService.update(entity.idDetalleListaPrecio, entity);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

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
