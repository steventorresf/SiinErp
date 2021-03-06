﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('InvMovimientoService', InvMovimientoService);

    InvMovimientoService.$inject = ['$http', '$q'];

    function InvMovimientoService($http, $q) {
        var nameSpace = '/Inventario/api/Movimiento/';

        var service = {
            getAll: getAll,
            getByDocumento: getByDocumento,
            getLastAlm: getLastAlm,
            getAct: getAct,
            create: create,
            createByEntradaCompra: createByEntradaCompra,
            createByPuntoDeVenta: createByPuntoDeVenta,
            updateByPuntoDeVenta: updateByPuntoDeVenta,
            createByFacturaDeVenta: createByFacturaDeVenta,
            update: update,
            remove: remove,
            getPendientesTercero: getPendientesTercero,
            imprimir: imprimir,
            imprimirPVen: imprimirPVen,
            imprimirFA: imprimirFA,
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

        function getByDocumento(data) {
            return $http.post(nameSpace + 'ByDoc/', data)
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

        function getLastAlm(nomUsuario, idEmpresa) {
            return $http.get(nameSpace + 'LastAlm/' + nomUsuario + '/' + idEmpresa)
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

        function updateByPuntoDeVenta(data) {
            return $http.put(nameSpace + 'ByPuntoDeVenta/', data)
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

        function imprimirPVen(id) {
            return $http.get(nameSpace + '/Imp/' + id)
                .then(
                    function (response) {
                        fnImprimirPVen(response.data);
                    },
                    function (errResponse) {
                        return $q.reject(errResponse);
                    }
                );
        }

        function imprimirFA(id) {
            return $http.get(nameSpace + '/Imp/' + id)
                .then(
                    function (response) {
                        fnImprimirFA(response.data);
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
                                        rowSpan: 3,
                                        alignment: 'center',
                                        bold: true,
                                        fontSize: 25,
                                    },
                                    { text: 'No. ' + entity.tipoDoc, bold: true },
                                    { text: entity.numDoc },
                                ],
                                [
                                    {},
                                    { text: 'Fecha:', bold: true },
                                    { text: entity.sFechaFormatted }
                                ],
                                [
                                    {},
                                    { text: 'Usuario:', bold: true },
                                    { text: entity.creadoPor }
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

            pdfMake.createPdf(Documento).open();
        }


        function fnImprimirFC(entity) {
            var data = entity.listaDetalle;

            var tablaDet = [
                [
                    { text: 'Código', bold: true, alignment: 'center', },
                    { text: 'NombreArticulo', bold: true, alignment: 'center', },
                    { text: 'Cant', bold: true, alignment: 'center', },
                    { text: 'VrUnit', bold: true, alignment: 'center', },
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
                        { text: d.vrNeto, alignment: 'right', },
                    ]
                );

                pcDscto += d.pcDscto;
                pcIva += d.pcIva;
                vrBruto += d.vrBruto;
                vrNeto += d.vrNeto;
            }

            var Documento = {
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
                                        rowSpan: 3,
                                        alignment: 'center',
                                        bold: true,
                                        fontSize: 25,
                                    },
                                    { text: 'No. ' + entity.tipoDoc, bold: true },
                                    { text: entity.numDoc },
                                ],
                                [
                                    {},
                                    { text: 'Fecha:', bold: true },
                                    { text: entity.sFechaFormatted }
                                ],
                                [
                                    {},
                                    { text: 'Usuario:', bold: true },
                                    { text: entity.creadoPor }
                                ],
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo8',
                        table: {
                            widths: ['10%', '45%', '15%', '30%'],
                            body: [
                                [
                                    { text: 'Cliente:', bold: true },
                                    { text: entity.nombreTercero },
                                    { text: 'Almacen:', bold: true },
                                    { text: entity.nombreAlmacen }
                                ],
                                [
                                    { text: 'Vendedor:', bold: true },
                                    entity.nombreVendedor,
                                    { text: 'Fecha Venc.:', bold: true },
                                    entity.sFechaVen
                                ],
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
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
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
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
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
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

            pdfMake.createPdf(Documento).open();
        }

        function fnImprimirFA(entity) {
            var data = entity.listaDetalle;

            var tablaDet = [
                [
                    { text: 'Código', bold: true, alignment: 'left', },
                    { text: 'Articulo', bold: true, alignment: 'left', },
                    { text: 'Cant', bold: true, alignment: 'center', },
                    { text: 'VrNeto', bold: true, alignment: 'right', },
                ]
            ];

            var pcDscto = 0, pcIva = 0, vrBruto = 0, vrNeto = 0;

            for (var i = 0; i < data.length; i++) {
                var d = data[i];
                tablaDet.push(
                    [
                        { text: d.codArticulo },
                        { text: d.nombreArticulo },
                        { text: PonerPuntosDouble(d.cantidad), alignment: 'center', },
                        { text: PonerPuntosDouble(d.vrNeto), alignment: 'right', },
                    ]
                );

                pcDscto += d.pcDscto;
                pcIva += d.pcIva;
                vrBruto += d.vrBruto;
                vrNeto += d.vrNeto;
            }

            var Documento = {
                pageSize: 'A4',
                header: function (currentPage, pageCount, pageSize) {
                    return [
                        {
                            text: 'Página ' + currentPage.toString() + '/' + pageCount,
                            alignment: 'right',
                            margin: [0, 15, 35, 0],
                            style: 'estilo',
                        },
                    ]
                },
                content: [
                    {
                        style: 'estilo',
                        table: {
                            widths: ['40%', '30%', '30%'],
                            body: [
                                [
                                    { text: entity.empresa.razonSocial, },
                                    { text: 'NIT  ' + entity.empresa.nitEmpresa, },
                                    { text: 'TEL  ' + entity.empresa.telefono, },
                                ],
                                [
                                    { text: entity.empresa.representante, },
                                    { text: entity.empresa.direccion, colSpan: 2, },
                                    {},
                                ],
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 2; },
                            paddingRight: function (i, node) { return 2; },
                            paddingTop: function (i, node) { return 2; },
                            paddingBottom: function (i, node) { return 2; },
                        },
                        margin: [0, 0, 0, 2],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['40%', '20%', '20%', '20%'],
                            body: [
                                [
                                    { text: 'Datos Del Cliente', bold: true, alignment: 'center', colSpan: 4, },
                                    {}, {}, {},
                                ],
                                [
                                    { text: entity.tercero === null ? '' : entity.tercero.nombreTercero, colSpan: 2, },
                                    {},
                                    { text: 'Factura No. ', bold: true, },
                                    { text: entity.numDoc, bold: true, },
                                ],
                                [
                                    { text: entity.tercero === null ? '' : entity.tercero.nitCedula, },
                                    { text: entity.tercero === null ? '' : 'Tel:  ' + entity.tercero.telefono },
                                    { text: 'Fecha Factura' },
                                    { text: entity.sFechaFormatted },
                                ],
                                [
                                    { text: entity.tercero === null ? '' : entity.tercero.direccion, colSpan: 2, },
                                    {},
                                    { text: 'Plazo De Pago' },
                                    { text: entity.plazoPago === null ? '' : entity.plazoPago.descripcion },
                                ],
                                [
                                    { text: entity.tercero === null ? '' : entity.tercero.nombreCiudad, colSpan: 2, },
                                    {},
                                    { text: 'Fecha Vence' },
                                    { text: entity.sFechaVen },
                                ],
                            ]
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                            //hLineWidth: function (i, node) {
                            //    if (i === 0 || i === node.table.body.length) {
                            //        return 0;
                            //    }
                            //    return (i === node.table.headerRows) ? 2 : 1;
                            //},
                            //vLineWidth: function (i) {
                            //    return 0;
                            //},
                            paddingLeft: function (i, node) { return 2; },
                            paddingRight: function (i, node) { return 2; },
                            paddingTop: function (i, node) { return 2; },
                            paddingBottom: function (i, node) { return 2; },
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['25%', '50%', '10%', '15%'],
                            body: tablaDet
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                            paddingLeft: function (i, node) { return 2; },
                            paddingRight: function (i, node) { return 2; },
                            paddingTop: function (i, node) { return 2; },
                            paddingBottom: function (i, node) { return 2; },
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['25%', '25%', '25%', '25%'],
                            body: [
                                [
                                    { text: 'SubTotal:  $' + PonerPuntosDouble(entity.valorBruto), alignment: 'left', },
                                    { text: 'Dscto:  $' + PonerPuntosDouble(entity.valorDscto), alignment: 'left', },
                                    { text: 'Iva:  $' + PonerPuntosDouble(entity.valorIva), alignment: 'left', },
                                    { text: 'Total:  $' + PonerPuntosDouble(entity.valorNeto), alignment: 'left', },
                                ],
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 45],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['30%', '70%'],
                            body: [
                                [
                                    { text: '___________________________________', alignment: 'left', },
                                    { text: 'RESOLUCION DIAN No  ' + entity.resolucion.noResolucion + '   FECHA  ' + entity.resolucion.sFecha, alignment: 'center', },
                                ],
                                [
                                    { text: 'Acepto', alignment: 'left', },
                                    { text: 'AUTORIZADA POR COMPUTADOR DEL ' + entity.resolucion.numeroInicio + ' AL ' + entity.resolucion.numeroFin, alignment: 'center', },
                                ],
                                [
                                    { text: ' ', },
                                    { text: 'SOMOS RESPONSABLES DE IVA', bold: true, alignment: 'center', },
                                ]
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 5],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 9,
                    },
                },
            };

            pdfMake.createPdf(Documento).open();
        }

        function fnImprimirPVen(entity) {
            var data = entity.listaDetalle;

            var tablaDet = [
                [
                    { text: 'NOMBREPRODUCTO', bold: true, alignment: 'left', colSpan: 2, },
                    {},
                ]
            ];

            var pcDscto = 0, pcIva = 0, vrBruto = 0, vrNeto = 0;

            for (var i = 0; i < data.length; i++) {
                var d = data[i];
                tablaDet.push(
                    [
                        { text: d.nombreArticulo, colSpan: 2 },
                        {},
                    ],
                    [
                        { text: PonerPuntosDouble(d.cantidad), alignment: 'center', },
                        { text: PonerPuntosDouble(d.vrNeto), alignment: 'right', },
                    ]
                );

                pcDscto += d.pcDscto;
                pcIva += d.pcIva;
                vrBruto += d.vrBruto;
                vrNeto += d.vrNeto;
            }

            var Documento = {
                pageSize: {
                    width: 110,
                    height: 'auto'
                },
                //pageSize: 'A8',
                pageMargins: [10, 10, 10, 10],
                content: [
                    {
                        style: 'estilo',
                        table: {
                            widths: ['100%'],
                            body: [
                                [
                                    { text: entity.nombreEmpresa, alignment: 'center', },
                                ],
                                [
                                    { text: entity.empresa.nitEmpresa, alignment: 'center', },
                                ],
                                [
                                    { text: entity.empresa.direccion, alignment: 'center', },
                                ],
                                [
                                    { text: 'FACTURA DE VENTA', alignment: 'center', },
                                ],
                                [
                                    { text: entity.numDoc + ' ' + entity.sFechaFormatted, alignment: 'center', },
                                ],
                                [
                                    { text: entity.tercero === null ? '' : 'FACT A: ' + entity.tercero.nitCedula, alignment: 'center', },
                                ],
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 5],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['30%', '70%'],
                            body: tablaDet
                        },
                        layout: {
                            //hLineColor: 'lightgray',
                            //vLineColor: 'noBorders',
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 5],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['70%', '30%'],
                            body: [
                                [
                                    { text: 'SubTotal:', alignment: 'right', },
                                    { text: '$ ' + PonerPuntosDouble(entity.valorBruto), alignment: 'right', },
                                ],
                                [
                                    { text: 'Dscto:', alignment: 'right', },
                                    { text: '$ ' + PonerPuntosDouble(entity.valorDscto), alignment: 'right', },
                                ],
                                [
                                    { text: 'Iva:', alignment: 'right', },
                                    { text: '$ ' + PonerPuntosDouble(entity.valorIva), alignment: 'right', },
                                ],
                                [
                                    { text: 'Total:', alignment: 'right', },
                                    { text: '$ ' + PonerPuntosDouble(entity.valorNeto), alignment: 'right', },
                                ]
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 5],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['100%'],
                            body: [
                                [
                                    { text: 'RESOLUCION DIAN No.', alignment: 'center', },
                                ],
                                [
                                    { text: entity.resolucion.noResolucion, alignment: 'center', },
                                ],
                                [
                                    { text: 'FECHA  ' + entity.resolucion.sFecha, alignment: 'center', },
                                ],
                                [
                                    { text: 'AUTORIZADA POR COMPUTADOR', alignment: 'center', },
                                ],
                                [
                                    { text: 'DEL ' + entity.resolucion.numeroInicio + ' AL ' + entity.resolucion.numeroFin, alignment: 'center', },
                                ],
                                [
                                    { text: 'SOMOS RESPONSABLES DE IVA', bold: true, alignment: 'center', },
                                ]
                            ]
                        },
                        layout: {
                            defaultBorder: false,
                            paddingLeft: function (i, node) { return 0; },
                            paddingRight: function (i, node) { return 0; },
                            paddingTop: function (i, node) { return 0; },
                            paddingBottom: function (i, node) { return 0; },
                        },
                        margin: [0, 0, 0, 5],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 4,
                    },
                },
            };

            pdfMake.createPdf(Documento).open();
        }
    }
})();