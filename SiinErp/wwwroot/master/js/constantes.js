﻿const Tab = {
    Regimen: 'GenRegimen',
    Transac: 'GenTrans',
    ClaseDoc: 'GenClaseDoc',
    Zonas: 'GenZonas',
    TiposArt: 'InvTiposArt',
    UnidadMed: 'InvUnidadMed',
    InvAlm: 'InvAlmacen',
    InvCenCos: 'InvCenCos',
    InvTrans: 'InvTrans',
    TiposPer: 'GenTiposPer',
    FormPago: 'VenFormPago',
    InvConceptos: 'InvConceptos',
}

const GenTiposDoc = {
    OrdenCompra: 'OC',
    OrdenVenta: 'OV',
    ReciboCaja: 'RC',
};

const InvTiposDoc = {
    FacturaVenta: 'FC',
    FacturaPuntoVenta: 'FA',
    Traslados: 'TB',
};

const Estados = {
    Pendiente: 'P',
    Activo: 'A',
    Inactivo: 'I',
};

const Modulo = {
    Cartera: 'CAR',
    Compras: 'COM',
    General: 'GEN',
    Inventario: 'INV',
    Ventas: 'VEN',
}

const TipoTercero = {
    Cliente: 'CL',
    Proveedor: 'PR',
    Otro: 'OT',
};


function FormatNumber(number, element) {
    var numberText = number.toString();
    var index = numberText.length - 3;
    var insert = ",";
    while (index > 0) {
        numberText = numberText.replace(new RegExp(`^(.{${index}})(.)`), `$1${insert}$2`);
        index -= 3;
    }
    element.value = numberText;
}

Date.prototype.DateSiin = function (sep) {
    var date = new Date(this.valueOf());

    var year = date.getFullYear();
    var month = (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1);
    var day = (date.getDate() >= 10 ? '' : '0') + date.getDate();
    var dateFormatted = '';

    if (sep) { dateFormatted = year + '-' + month + '-' + day; }
    else { dateFormatted = year + '' + month + '' + day; }
    return dateFormatted;
}

Date.prototype.DatePeriodo = function () {
    var date = new Date(this.valueOf());

    var year = date.getFullYear();
    var month = (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1);
    var dateFormatted = '';

    dateFormatted = year + '' + month;
    return dateFormatted;
}

Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}

Date.prototype.addMonths = function (months) {
    var date = new Date(this.valueOf());
    date.setDate(date.getMonth() + months);
    return date;
}
