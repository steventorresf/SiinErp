(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenCajaService', VenCajaService);

    VenCajaService.$inject = ['$http', '$q'];

    function VenCajaService($http, $q) {
        var nameSpace = '/Ventas/api/Caja/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            anular: anular,
            getIdCajaActiva: getIdCajaActiva,
            getLastIdDetCajeroByUsu: getLastIdDetCajeroByUsu,
            getSaldoEnCajaActual: getSaldoEnCajaActual,
            imprimirCaja: imprimirCaja,
        };

        return service;

        function getAll(idCajero) {
            return $http.get(nameSpace + idCajero)
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

        function anular(data) {
            return $http.put(nameSpace + 'An/', data)
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

        function getIdCajaActiva(idCajero) {
            return $http.get(nameSpace + 'GetIdCajaAc/' + idCajero)
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

        function getLastIdDetCajeroByUsu(nombreUsuario, idEmpresa) {
            return $http.get(nameSpace + 'LastIdDetCajeroByUsu/' + nombreUsuario + '/' + idEmpresa)
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

        function getSaldoEnCajaActual(idCaja) {
            return $http.get(nameSpace + 'GetSaldoEnCajaActualIdCaja/' + idCaja)
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

        function imprimirCaja(idCaja) {
            return $http.get(nameSpace + 'Imp/' + idCaja)
                .then(
                    function (response) {
                        fnImprimirCaja(response.data);
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }


        function fnImprimirCaja(entity) {
            var dataR = entity.listaResumen;
            var dataD = entity.listaDetalle;

            var tablaResumen = [
                [
                    { text: 'Saldo Inicial', bold: true, },
                    { text: PonerPuntosDouble(entity.saldoInicial), bold: true, alignment: 'right', },
                ]
            ];

            var saldoTotal = entity.saldoInicial,
                saldoEnCaja = entity.saldoInicial;

            for (var i = 0; i < dataR.length; i++) {
                var d = dataR[i];
                tablaResumen.push(
                    [
                        { text: d.nombreFormaPago },
                        { text: PonerPuntosDouble(d.valor), alignment: 'right', },
                    ]
                );

                saldoTotal += d.valor;
                saldoEnCaja += d.nombreFormaPago.includes('Efectivo') || d.valor < 0 || d.nombreFormaPago.includes('Ingresos') ? d.valor : 0;
            }

            tablaResumen.push(
                [
                    { text: 'Saldo Total', bold: true, },
                    { text: PonerPuntosDouble(saldoTotal), bold: true, alignment: 'right', },
                ],
                [
                    { text: 'Saldo En Caja', bold: true, },
                    { text: PonerPuntosDouble(saldoEnCaja), bold: true, alignment: 'right', },
                ],
                [
                    { text: 'Saldo Final', bold: true, },
                    { text: PonerPuntosDouble(entity.saldoFinal), bold: true, alignment: 'right', },
                ]
            );
            

            var tablaDetalle = [
                [
                    { text: 'TipoDoc', bold: true, alignment: 'center', },
                    { text: 'NoDoc', bold: true, alignment: 'center', },
                    { text: 'Descripción', bold: true, alignment: 'center', },
                    { text: 'CuentaBanco', bold: true, alignment: 'center', },
                    { text: 'Ingresos', bold: true, alignment: 'center', },
                    { text: 'Egresos', bold: true, alignment: 'center', },
                ],
                [
                    { text: '' },
                    { text: '' },
                    { text: 'Saldo Inicial', },
                    { text: '' },
                    { text: PonerPuntosDouble(entity.saldoInicial), alignment: 'right', },
                    { text: '' },
                ]
            ];

            var vrIngresos = entity.saldoInicial,
                vrEnCaja = entity.saldoInicial,
                vrEgresos = 0;

            for (var i = 0; i < dataD.length; i++) {
                var d = dataD[i];

                var ingresos = "", egresos = "";
                if (d.transaccion >= 0) {
                    vrIngresos += d.valor;
                    vrEnCaja += d.efectivo === true ? d.valor : 0;
                    ingresos = PonerPuntosDouble(d.valor);
                }
                else {
                    vrEgresos += d.valor * d.transaccion;
                    vrEnCaja += d.valor * d.transaccion;
                    egresos = PonerPuntosDouble(d.valor * d.transaccion);
                }

                tablaDetalle.push(
                    [
                        { text: d.tipoDoc, alignment: 'center', },
                        { text: d.numDoc, alignment: 'center', },
                        { text: d.transaccion >= 0 ? d.nombreFormaPago : d.comentario, },
                        { text: d.nombreCuentaBanco, },
                        { text: ingresos, alignment: 'right', },
                        { text: egresos, alignment: 'right', },
                    ]
                );
            }

            var vrSaldoTotal = vrIngresos + vrEgresos;

            tablaDetalle.push(
                [
                    { text: ' ', colSpan: 4, },
                    {},
                    {},
                    {},
                    { text: vrIngresos > 0 ? PonerPuntosDouble(vrIngresos) : '', bold: true, alignment: 'right', },
                    { text: vrEgresos > 0 || vrEgresos < 0 ? PonerPuntosDouble(vrEgresos) : '', bold: true, alignment: 'right', },
                ],
                [
                    { text: 'Saldo Total:', bold: true, alignment: 'right', colSpan: 4, },
                    {},
                    {},
                    {},
                    { text: '$ ' + (vrSaldoTotal > 0 ? PonerPuntosDouble(vrSaldoTotal) : ''), bold: true, alignment: 'right', colSpan: 2, },
                    {},
                ],
                [
                    { text: 'Saldo En Caja:', bold: true, alignment: 'right', colSpan: 4, },
                    {},
                    {},
                    {},
                    { text: '$ ' + (vrEnCaja > 0 ? PonerPuntosDouble(vrEnCaja) : ''), bold: true, alignment: 'right', colSpan: 2, },
                    {},
                ],
                [
                    { text: 'Saldo Final:', bold: true, alignment: 'right', colSpan: 4, },
                    {},
                    {},
                    {},
                    { text: '$ ' + PonerPuntosDouble(entity.saldoFinal), bold: true, alignment: 'right', colSpan: 2, },
                    {},
                ],
            );

            var Documento = {
                header: function (currentPage, pageCount, pageSize) {
                    return [
                        {
                            text: 'Página ' + currentPage.toString() + '/' + pageCount,
                            alignment: 'right',
                            margin: [0, 15, 40, 0],
                            style: 'estilo',
                        },
                    ]
                },
                content: [
                    {
                        style: 'estilo',
                        table: {
                            widths: ['70%', '10%', '20%'],
                            body: [
                                [
                                    {
                                        text: entity.nombreEmpresa,
                                        rowSpan: 2,
                                        alignment: 'center',
                                        bold: true,
                                        fontSize: 25,
                                    },
                                    { text: 'Fecha:', bold: true },
                                    { text: entity.sFechaDoc }
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
                        style: 'estilo_9',
                        table: {
                            widths: ['20%', '20%'],
                            body: [
                                [
                                    { text: entity.nombreCaja, bold: true },
                                    { text: entity.nombreTurno, bold: true },
                                ]
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['20%', '15%'],
                            body: tablaResumen
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['8%', '8%', '30%', '34%', '10%', '10%'],
                            body: tablaDetalle
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 8,
                    },
                    estilo_9: {
                        fontSize: 9,
                    },
                },
            };

            pdfMake.createPdf(Documento).open();
        }
    }
})();