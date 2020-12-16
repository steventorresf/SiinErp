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
            getIdCajaActiva: getIdCajaActiva,
            imprimirCaja: imprimirCaja,
        };

        return service;

        function getAll(idEmp) {
            return $http.get(nameSpace + idEmp)
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

        function getIdCajaActiva(idEmp) {
            return $http.get(nameSpace + 'GetIdCajaAc/' + idEmp)
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

            var tablaResumen = [
                [
                    { text: 'Saldo Inicial', bold: true, },
                    { text: entity.saldoInicial, bold: true, alignment: 'right', },
                ]
            ];

            var saldoTotal = entity.saldoInicial,
                saldoEnCaja = entity.saldoInicial;

            for (var i = 0; i < dataR.length; i++) {
                var d = dataR[i];
                tablaResumen.push(
                    [
                        { text: d.nombreFormaPago },
                        { text: d.valor, alignment: 'right', },
                    ]
                );

                saldoTotal += d.valor;
                saldoEnCaja += d.nombreFormaPago.includes('Efectivo') || d.valor < 0 ? d.valor : 0;
            }

            tablaResumen.push(
                [
                    { text: 'Saldo Total', bold: true, },
                    { text: saldoTotal, bold: true, alignment: 'right', },
                ]
            );
            tablaResumen.push(
                [
                    { text: 'Saldo En Caja', bold: true, },
                    { text: saldoEnCaja, bold: true, alignment: 'right', },
                ]
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
                        style: 'estilo',
                        alignment: 'center',
                        table: {
                            widths: ['20%', '15%'],
                            body: tablaResumen
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [50, 0, 0, 15],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 8,
                    },
                },
            };

            pdfMake.createPdf(Documento).open();
        }
    }
})();