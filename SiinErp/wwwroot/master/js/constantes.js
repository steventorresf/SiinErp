const Tab = {
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
    Cajeros: 'VenCajeros',
    Turnos: 'GenTurnos',
    FormPago: 'VenFormPago',
    InvConceptos: 'InvConceptos',
    VenCuentas: 'VenCuentas',
}

const GenTiposDoc = {
    OrdenCompra: 'OC',
    OrdenVenta: 'OV',
    ReciboCaja: 'RC',
    FacturaVenta: 'FA',
};

const InvTiposDoc = {
    FacturaVenta: 'FV',
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

const Constantes = {
    TpPago_Contado: 'CO',
    TpPago_Credito: 'CR',
}


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

function PonerPuntosDouble(valor) {
    var cadena = valor.toString().replace(".", ",");
    var rescadena = "";

    var i = cadena.indexOf(',');
    if (i > 0) {
        rescadena = cadena.substring(i);
        cadena = cadena.substring(0, i);
    }


    var lon = cadena.length - 3;
    while (lon > 0) {
        cadena = cadena.substring(0, lon) + "." + cadena.substring(lon);
        lon -= 3;
    }
    return cadena + rescadena;
}
