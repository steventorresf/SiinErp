const Tab = {
    Regimen: 'GenRegimen',
    Transac: 'GenTrans',
    ClaseDoc: 'GenClaseDoc',
    Zonas: 'GenZonas',
    TiposProv: 'ComTiposProv',
    TiposArt: 'InvTiposArt',
    UnidadMed: 'InvUnidadMed',
    InvAlm: 'InvAlmacen',
    InvCenCos: 'InvCenCos',
    InvTrans: 'InvTrans',
    TiposCli: 'VenTiposCli',
    FormPago: 'VenFormPago',
}

const GenTiposDoc = {
    OrdenCompra: 'OC',
    OrdenVenta: 'OV',
    ReciboCaja: 'RC',
};

const InvTiposDoc = {
    FacturaVenta: 'FC',
    FacturaPuntoVenta: 'FA',
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