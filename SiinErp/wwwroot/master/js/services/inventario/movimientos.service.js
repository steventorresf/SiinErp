(function () {
    'use strict';

    angular
        .module('app')
        .factory('InvMovimientosService', InvMovimientosService);

    InvMovimientosService.$inject = ['$http', '$q'];

    function InvMovimientosService($http, $q) {
        var nameSpace = '/Inventario/api/Movimientos/';

        var service = {
            getAll: getAll,
            getAct: getAct,
            create: create,
            createByEntradaCompra: createByEntradaCompra,
            createByPuntoDeVenta: createByPuntoDeVenta,
            createByFacturaDeVenta: createByFacturaDeVenta,
            update: update,
            remove: remove,
            getPendientesTercero: getPendientesTercero,
            imprimir: imprimir,
        };

        return service;

        function getAll(idEmp, modulo, fechaIni, FechaFin) {
            return $http.get(nameSpace + idEmp + '/' + modulo + '/' + fechaIni + '/' + FechaFin)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function getAct(idEmp, modulo, fechaIni, fechaFin) {
            return $http.get(nameSpace + 'ByFecha/' + idEmp +'/' + modulo + '/' + fechaIni + '/' + fechaFin)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function getPendientesTercero(idEmp, idTercero) {
            return $http.get(nameSpace + 'Pendientes/' + idEmp + '/' + idTercero)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function create(data) {
            return $http.post(nameSpace, data)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function createByEntradaCompra(data) {
            return $http.post(nameSpace + 'ByEntradaCompra/', data)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function createByPuntoDeVenta(data) {
            return $http.post(nameSpace + 'ByPuntoDeVenta/', data)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function createByFacturaDeVenta(data) {
            return $http.post(nameSpace + 'ByFacturaDeVenta/', data)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function update(id, data) {
            return $http.put(nameSpace + id, data)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function remove(id) {
            return $http.delete(nameSpace + '/' + id)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        return $q.reject(errResponse);
                    }
                );
        }

        // Impresión
        function imprimir(id) {
            return $http.get(nameSpace + '/Imp/' + id)
                .then(
                    function (response) {
                        fnImprimirMov(response.data);
                    },
                    function (errResponse) {
                        return $q.reject(errResponse);
                    }
                );
        }

        function fnImprimirMov(entity) {
            var data = entity.listaDetalle;

            var tablaDet = [
                [
                    { text: 'Código', bold: true, alignment: 'center', },
                    { text: 'NombreArticulo', bold: true, alignment: 'center', },
                    { text: 'Cant', bold: true, alignment: 'center', },
                    { text: 'VrUnit', bold: true, alignment: 'center', },
                    //{ text: 'Dscto', bold: true, alignment: 'center', },
                    //{ text: 'Iva', bold: true, alignment: 'center', },
                    //{ text: 'VrBruto', bold: true, alignment: 'center', },
                    { text: 'VrNeto', bold: true, alignment: 'center', },
                ]
            ];

            var pcDscto = 0, pcIva = 0, vrBruto = 0, vrNeto = 0;

            for (var i = 0; i < data.length; i++) {
                var d = data[i];
                tablaDet.push(
                    [
                        { text: d.codArticulo },
                        { text: d.nombreArticulo },
                        { text: d.cantidad, alignment: 'center', },
                        { text: d.vrUnitario, alignment: 'right', },
                        //{ text: data[i].pcDscto, alignment: 'center', },
                        //{ text: data[i].pcIva, alignment: 'center', },
                        //{ text: data[i].vrBruto, alignment: 'right', },
                        { text: d.vrNeto, alignment: 'right', },
                    ]
                );

                pcDscto += d.pcDscto;
                pcIva += d.pcIva;
                vrBruto += d.vrBruto;
                vrNeto += d.vrNeto;
            }

            var Documento = {
                //footer: function (currentPage, pageCount) { return currentPage.toString() + ' of ' + pageCount; },
                header: function (currentPage, pageCount, pageSize) {
                    return [
                        {
                            text: 'Página ' + currentPage.toString() + '/' + pageCount,
                            alignment: 'right',
                            margin: [0, 15, 40, 0],
                            style: 'estilo8',
                        },
                    ]
                },
                content: [
                    {
                        style: 'estilo8',
                        table: {
                            widths: ['70%', '10%', '20%'],
                            body: [
                                [
                                    {
                                        text: entity.nombreEmpresa,
                                        rowSpan: 2,
                                        alignment: 'center',
                                        bold: true,
                                        fontSize: 20,
                                    },
                                    { text: 'No. ' + entity.tipoDoc, bold: true },
                                    { text: entity.numDoc },
                                ],
                                [
                                    {},
                                    { text: 'Fecha:', bold: true },
                                    { text: entity.sFechaFormatted }
                                ],
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo8',
                        table: {
                            widths: ['10%', '45%', '15%', '30%'],
                            body: [
                                [
                                    { text: 'Tercero:', bold: true },
                                    { text: entity.nombreTercero },
                                    { text: 'Almacen Origen:', bold: true },
                                    { text: entity.nombreAlmacen }
                                ],
                                [
                                    { text: 'Concepto:', bold: true },
                                    entity.nombreConcepto,
                                    { text: 'Centro Costo:', bold: true },
                                    entity.nombreCentroCosto
                                ],
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo8',
                        table: {
                            widths: ['20%', '50%', '10%', '10%', '10%'],
                            body: tablaDet
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo8',
                        table: {
                            widths: ['10%', '15%', '10%', '15%', '10%', '15%', '10%', '15%'],
                            body: [
                                [
                                    { text: 'SubTotal:', bold: true, alignment: 'right', },
                                    { text: '$ ' + vrBruto, bold: true, },
                                    { text: 'Dscto:', bold: true, alignment: 'right', },
                                    { text: '$ ' + pcDscto, bold: true, },
                                    { text: 'Iva:', bold: true, alignment: 'right', },
                                    { text: '$ ' + pcIva, bold: true, },
                                    { text: 'Total:', bold: true, alignment: 'right', },
                                    { text: '$ ' + vrNeto, bold: true, },
                                ]
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 15],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 9,
                    },
                    estilo8: {
                        fontSize: 8,
                    }
                },
            };

            pdfMake.createPdf(Documento).download(entity.noDoc.replace(' ', ''));
        }
    }
})();