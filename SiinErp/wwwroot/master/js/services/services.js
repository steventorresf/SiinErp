(function () {
    'use strict';

    angular
        .module('app')
        .factory('CarConceptoService', CarConceptoService);

    CarConceptoService.$inject = ['$http', '$q'];

    function CarConceptoService($http, $q) {
        var nameSpace = '/Cartera/api/Concepto/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            getByTipDoc: getByTipDoc,
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

        function getByTipDoc(idTipDoc) {
            return $http.get(nameSpace + 'ByTipDoc/' + idTipDoc)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('CarMovimientoService', CarMovimientoService);

    CarMovimientoService.$inject = ['$http', '$q'];

    function CarMovimientoService($http, $q) {
        var nameSpace = '/Cartera/api/Movimiento/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            anular: anular,
        };

        return service;

        function getAll(idEmp, fechaIni, fechaFin) {
            return $http.get(nameSpace + idEmp + '/' + fechaIni + '/' + fechaFin + '/')
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

        function anular(idMov, nomUsu) {
            return $http.put(nameSpace + 'An/' + idMov + '/' + nomUsu)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('CarPlazoPagoService', CarPlazoPagoService);

    CarPlazoPagoService.$inject = ['$http', '$q'];

    function CarPlazoPagoService($http, $q) {
        var nameSpace = '/Cartera/api/PlazoPago/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ComOrdenService', ComOrdenService);

    ComOrdenService.$inject = ['$http', '$q'];

    function ComOrdenService($http, $q) {
        var nameSpace = '/Compras/api/Orden/';

        var service = {
            getAll: getAll,
            getPen: getPen,
            create: create,
            update: update,
        };

        return service;

        function getAll(idEmp, fechaIni, fechaFin) {
            return $http.get(nameSpace + idEmp + '/' + fechaIni + '/' + fechaFin)
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

        function getPen(idEmp) {
            return $http.get(nameSpace + 'GetPen/' + idEmp)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ComOrdenDetService', ComOrdenDetService);

    ComOrdenDetService.$inject = ['$http', '$q'];

    function ComOrdenDetService($http, $q) {
        var nameSpace = '/Compras/api/OrdenDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getAll(idOrd) {
            return $http.get(nameSpace + idOrd)
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

        function remove(id) {
            return $http.delete(nameSpace + id)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContComprobanteService', ContComprobanteService);

    ContComprobanteService.$inject = ['$http', '$q'];

    function ContComprobanteService($http, $q) {
        var nameSpace = '/Contabilidad/api/Comprobantes/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            anular: anular,
        };

        return service;

        function getAll(idEmp, fechaI, fechaF) {
            return $http.get(nameSpace + idEmp + '/' + fechaI + '/' + fechaF)
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

        function anular(id, modificadoPor) {
            return $http.delete(nameSpace + id + '/' + modificadoPor)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContComprobanteDetService', ContComprobanteDetService);

    ContComprobanteDetService.$inject = ['$http', '$q'];

    function ContComprobanteDetService($http, $q) {
        var nameSpace = '/Contabilidad/api/ComprobanteDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idComp) {
            return $http.get(nameSpace + idComp)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContPlanDeCuentaService', ContPlanDeCuentaService);

    ContPlanDeCuentaService.$inject = ['$http', '$q'];

    function ContPlanDeCuentaService($http, $q) {
        var nameSpace = '/Contabilidad/api/PlanDeCuenta/';

        var service = {
            getAll: getAll,
            getAllByNivel: getAllByNivel,
            getPlan: getPlan,
            create: create,
            update: update,
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

        function getAllByNivel(idEmp, nivel) {
            return $http.get(nameSpace + 'ByNivel/' + idEmp + '/' + nivel)
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

        function getPlan(idEmp, codCuenta) {
            return $http.get(nameSpace + 'Get/' + idEmp + '/' + codCuenta)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContRetencionService', ContRetencionService);

    ContRetencionService.$inject = ['$http', '$q'];

    function ContRetencionService($http, $q) {
        var nameSpace = '/Contabilidad/api/Retencion/';

        var service = {
            getAll: getAll,
            getRetencion: getRetencion,
            create: create,
            update: update,
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

        function getRetencion(idEmp, tipoDoc) {
            return $http.get(nameSpace + 'Get/' + idEmp + '/' + tipoDoc)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContTipoDocService', ContTipoDocService);

    ContTipoDocService.$inject = ['$http', '$q'];

    function ContTipoDocService($http, $q) {
        var nameSpace = '/Contabilidad/api/TipoContab/';

        var service = {
            getAll: getAll,
            getTipoDoc: getTipoDoc,
            create: create,
            update: update,
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

       
        function getTipoDoc(idEmp, tipoDoc) {
            return $http.get(nameSpace + 'Get/' + idEmp + '/' + tipoDoc)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenCiudadService', GenCiudadService);

    GenCiudadService.$inject = ['$http', '$q'];

    function GenCiudadService($http, $q) {
        var nameSpace = '/General/api/Ciudad/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idDep) {
            return $http.get(nameSpace + idDep)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenDepartamentoService', GenDepartamentoService);

    GenDepartamentoService.$inject = ['$http', '$q'];

    function GenDepartamentoService($http, $q) {
        var nameSpace = '/General/api/Departamento/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenEmpresaService', GenEmpresaService);

    GenEmpresaService.$inject = ['$http', '$q'];

    function GenEmpresaService($http, $q) {
        var nameSpace = '/General/api/Empresa/';

        var service = {
            getAll: getAll,
            getAct: getAct,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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

        function getAct() {
            return $http.get(nameSpace + 'Act/')
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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenModuloService', GenModuloService);

    GenModuloService.$inject = ['$http', '$q'];

    function GenModuloService($http, $q) {
        var nameSpace = '/General/api/Modulo/';

        var service = {
            getAll: getAll,
            getAllPer: getAllPer,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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

        function getAllPer() {
            return $http.get(nameSpace + 'Per/')
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

        function update(cod, data) {
            return $http.put(nameSpace + cod, data)
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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenPaisService', GenPaisService);

    GenPaisService.$inject = ['$http', '$q'];

    function GenPaisService($http, $q) {
        var nameSpace = '/General/api/Pais/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenParametroService', GenParametroService);

    GenParametroService.$inject = ['$http', '$q'];

    function GenParametroService($http, $q) {
        var nameSpace = '/General/api/Parametro/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenPeriodoService', GenPeriodoService);

    GenPeriodoService.$inject = ['$http', '$q'];

    function GenPeriodoService($http, $q) {
        var nameSpace = '/General/api/Periodo/';

        var service = {
            getAll: getAll,
            getSig: getSig,
            create: create,
            update: update,
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

        function getSig(idEmp, codMod) {
            return $http.get(nameSpace + 'GetSig/' + idEmp + '/' + codMod)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablaService', GenTablaService);

    GenTablaService.$inject = ['$http', '$q'];

    function GenTablaService($http, $q) {
        var nameSpace = '/General/api/Tabla/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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

        function update(cod, data) {
            return $http.put(nameSpace + cod, data)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablaDetService', GenTablaDetService);

    GenTablaDetService.$inject = ['$http', '$q'];

    function GenTablaDetService($http, $q) {
        var nameSpace = '/General/api/TablaDetalle/';

        var service = {
            getAll: getAll,
            getAllById: getAllById,
            create: create,
            update: update,
            updateOrden: updateOrden,
        };

        return service;

        function getAll(cod, idEmp) {
            return $http.get(nameSpace + 'ByCod/' + cod + '/' + idEmp)
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

        function getAllById(idTab, idEmp) {
            return $http.get(nameSpace + 'ByIdTabEmp/' + idTab + '/' + idEmp)
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

        function updateOrden(id, orden) {
            return $http.put(nameSpace + 'UpOrd/' + id + '/' + orden)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTerceroService', GenTerceroService);

    GenTerceroService.$inject = ['$http', '$q'];

    function GenTerceroService($http, $q) {
        var nameSpace = '/General/api/Tercero/';

        var service = {
            create: create,
            getAll: getAll,
            getAct: getAct,
            update: update,

            getAllPro: getAllPro,
            getActPro: getActPro,
            updatePro: updatePro,

            getAllCli: getAllCli,
            getCliByPrefix: getCliByPrefix,
            getCliByIden: getCliByIden,
            getActCli: getActCli,
            updateCli: updateCli,
        };

        return service;

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

        function getAct(idEmp) {
            return $http.get(nameSpace + 'Act/' + idEmp)
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

        // Proveedores
        function getAllPro(idEmp) {
            return $http.get(nameSpace + 'Prov/' + idEmp)
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

        function getActPro(idEmp) {
            return $http.get(nameSpace + 'Prov/Act/' + idEmp)
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

        function updatePro(id, data) {
            return $http.put(nameSpace + 'Prov/' + id, data)
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

        // Clientes
        function getAllCli(idEmp) {
            return $http.get(nameSpace + 'Cli/' + idEmp)
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

        function getCliByIden(data) {
            return $http.post(nameSpace + 'CliByIden/', data)
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

        function getCliByPrefix(data) {
            return $http.post(nameSpace + 'CliByPrefix/', data)
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

        function getActCli(idEmp) {
            return $http.get(nameSpace + 'Cli/Act/' + idEmp)
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

        function updateCli(id, data) {
            return $http.put(nameSpace + 'Cli/' + id, data)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTipoDocService', GenTipoDocService);

    GenTipoDocService.$inject = ['$http', '$q'];

    function GenTipoDocService($http, $q) {
        var nameSpace = '/General/api/TipoDocumento/';

        var service = {
            getAll: getAll,
            getByCod: getByCod,
            getByModulo: getByModulo,
            create: create,
            update: update,
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

        function getByCod(idEmp, cod) {
            return $http.get(nameSpace + 'ByCod/' + idEmp + '/' + cod)
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

        function getByModulo(idEmp, codMod) {
            return $http.get(nameSpace + 'ByCodMod/' + idEmp + '/' + codMod)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenUsuarioService', GenUsuarioService);

    GenUsuarioService.$inject = ['$http', '$q'];

    function GenUsuarioService($http, $q) {
        var nameSpace = '/General/api/Usuario/';
        var service = {
            Login: Login,
            getAll: getAll,
            create: create,
            update: update,
            upEstado: upEstado,
            resetClave: resetClave,
            getLastAlm: getLastAlm,
        };

        return service;

        function Login(data) {
            return $http.post(nameSpace + 'Login/', data)
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

        function getAll() {
            return $http.get(nameSpace)
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

        function upEstado(data) {
            return $http.post(nameSpace + 'UpEst/', data)
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

        function resetClave(id) {
            return $http.put(nameSpace + 'Reset/' + id + '/')
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

        function getLastAlm(id) {
            return $http.get(nameSpace + 'UltAlm/' + id + '/')
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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('InvArticuloService', InvArticuloService);

    InvArticuloService.$inject = ['$http', '$q'];

    function InvArticuloService($http, $q) {
        var nameSpace = '/Inventario/api/Articulo/';

        var service = {
            getAll: getAll,
            getAllByPrefix: getAllByPrefix,
            getByCodigoAndListaP: getByCodigoAndListaP,
            GetByPrefixListaP: GetByPrefixListaP,
            getAllByAlmPrefix: getAllByAlmPrefix,
            create: create,
            update: update,
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

        function getAllByPrefix(data) {
            return $http.post(nameSpace + 'ByPrefix/', data)
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

        function getByCodigoAndListaP(data) {
            return $http.post(nameSpace + 'ByCodListaP/', data)
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

        function GetByPrefixListaP(data) {
            return $http.post(nameSpace + 'PrefixListaP/', data)
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

        function getAllByAlmPrefix(data) {
            return $http.post(nameSpace + 'ByAlmPrefix/', data)
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
    }
})();
(function () {
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('InvMovimientoDetalleService', InvMovimientoDetalleService);

    InvMovimientoDetalleService.$inject = ['$http', '$q'];

    function InvMovimientoDetalleService($http, $q) {
        var nameSpace = '/Inventario/api/MovimientoDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idMov) {
            console.log("detal", idMov);
            return $http.get(nameSpace + idMov)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('TesPagoService', TesPagoService);

    TesPagoService.$inject = ['$http', '$q'];

    function TesPagoService($http, $q) {
        var nameSpace = '/Tesoreria/api/Pago/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
        };

        return service;

        function getAll(idEmp, fechaIni, fechaFin) {
            return $http.get(nameSpace + idEmp + '/' + fechaIni + '/' + fechaFin)
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
    }
})();
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenCajaDetService', VenCajaDetService);

    VenCajaDetService.$inject = ['$http', '$q'];

    function VenCajaDetService($http, $q) {
        var nameSpace = '/Ventas/api/CajaDetalle/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            getCantidadDetalleCaja: getCantidadDetalleCaja,
        };

        return service;

        function getAll(idCaja) {
            return $http.get(nameSpace + idCaja)
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
            return $http.post(nameSpace + 'Create/', data)
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

        function getCantidadDetalleCaja(idCaja) {
            return $http.get(nameSpace + 'GetCantDetCaja/' + idCaja)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenListaPrecioService', VenListaPrecioService);

    VenListaPrecioService.$inject = ['$http', '$q'];

    function VenListaPrecioService($http, $q) {
        var nameSpace = '/Ventas/api/ListaPrecio/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenListaPrecioDetalleService', VenListaPrecioDetalleService);

    VenListaPrecioDetalleService.$inject = ['$http', '$q'];

    function VenListaPrecioDetalleService($http, $q) {
        var nameSpace = '/Ventas/api/ListaPrecioDetalle/';

        var service = {
            getAll: getAll,
            getAllByPrefix: getAllByPrefix,
            create: create,
            update: update,
            remove: remove,
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

        function getAllByPrefix(data) {
            return $http.post(nameSpace + 'ByPrefix/', data)
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

        function remove(id) {
            console.log(id);
            return $http.delete(nameSpace + id)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('VenVendedorService', VenVendedorService);

    VenVendedorService.$inject = ['$http', '$q'];

    function VenVendedorService($http, $q) {
        var nameSpace = '/Ventas/api/Vendedor/';

        var service = {
            getAll: getAll,
            getAct: getAct,
            create: create,
            update: update,
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

        function getAct(idEmp) {
            return $http.get(nameSpace + 'Act/' + idEmp)
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
    }
})();