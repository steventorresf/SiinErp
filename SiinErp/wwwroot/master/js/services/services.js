(function () {
    'use strict';

    angular
        .module('app')
        .factory('CarConceptosService', CarConceptosService);

    CarConceptosService.$inject = ['$http', '$q'];

    function CarConceptosService($http, $q) {
        var nameSpace = '/Cartera/api/Conceptos/';

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
        .factory('CarMovimientosService', CarMovimientosService);

    CarMovimientosService.$inject = ['$http', '$q'];

    function CarMovimientosService($http, $q) {
        var nameSpace = '/Cartera/api/Movimientos/';

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
        .factory('CarPlazosPagoService', CarPlazosPagoService);

    CarPlazosPagoService.$inject = ['$http', '$q'];

    function CarPlazosPagoService($http, $q) {
        var nameSpace = '/Cartera/api/PlazosPago/';

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
        .factory('ComOrdenesDetService', ComOrdenesDetService);

    ComOrdenesDetService.$inject = ['$http', '$q'];

    function ComOrdenesDetService($http, $q) {
        var nameSpace = '/Compras/api/OrdenesDetalle/';

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
        .factory('ComOrdenesService', ComOrdenesService);

    ComOrdenesService.$inject = ['$http', '$q'];

    function ComOrdenesService($http, $q) {
        var nameSpace = '/Compras/api/Ordenes/';

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
        .factory('ComProveedoresService', ComProveedoresService);

    ComProveedoresService.$inject = ['$http', '$q'];

    function ComProveedoresService($http, $q) {
        var nameSpace = '/Compras/api/Proveedores/';

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
        .factory('ContComprobantesService', ContComprobantesService);

    ContComprobantesService.$inject = ['$http', '$q'];

    function ContComprobantesService($http, $q) {
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
        .factory('ContComprobantesDetService', ContComprobantesDetService);

    ContComprobantesDetService.$inject = ['$http', '$q'];

    function ContComprobantesDetService($http, $q) {
        var nameSpace = '/Contabilidad/api/ComprobantesDetalle/';

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
        var nameSpace = '/Contabilidad/api/PlanDeCuentas/';

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
        var nameSpace = '/Contabilidad/api/Retenciones/';

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
        .factory('ContTiposDocService', ContTiposDocService);

    ContTiposDocService.$inject = ['$http', '$q'];

    function ContTiposDocService($http, $q) {
        var nameSpace = '/Contabilidad/api/TiposContab/';

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
        .factory('GenCiudadesService', GenCiudadesService);

    GenCiudadesService.$inject = ['$http', '$q'];

    function GenCiudadesService($http, $q) {
        var nameSpace = '/General/api/Ciudades/';

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
        .factory('GenDepartamentosService', GenDepartamentosService);

    GenDepartamentosService.$inject = ['$http', '$q'];

    function GenDepartamentosService($http, $q) {
        var nameSpace = '/General/api/Departamentos/';

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
        .factory('GenEmpresasService', GenEmpresasService);

    GenEmpresasService.$inject = ['$http', '$q'];

    function GenEmpresasService($http, $q) {
        var nameSpace = '/General/api/Empresas/';

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
        .factory('GenModulosService', GenModulosService);

    GenModulosService.$inject = ['$http', '$q'];

    function GenModulosService($http, $q) {
        var nameSpace = '/General/api/Modulos/';

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
        .factory('GenPaisesService', GenPaisesService);

    GenPaisesService.$inject = ['$http', '$q'];

    function GenPaisesService($http, $q) {
        var nameSpace = '/General/api/Paises/';

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
        .factory('GenParametrosService', GenParametrosService);

    GenParametrosService.$inject = ['$http', '$q'];

    function GenParametrosService($http, $q) {
        var nameSpace = '/General/api/Parametros/';

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
        .factory('GenPeriodosService', GenPeriodosService);

    GenPeriodosService.$inject = ['$http', '$q'];

    function GenPeriodosService($http, $q) {
        var nameSpace = '/General/api/Periodos/';

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
        .factory('GenTablasService', GenTablasService);

    GenTablasService.$inject = ['$http', '$q'];

    function GenTablasService($http, $q) {
        var nameSpace = '/General/api/Tablas/';

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
        .factory('GenTablasDetService', GenTablasDetService);

    GenTablasDetService.$inject = ['$http', '$q'];

    function GenTablasDetService($http, $q) {
        var nameSpace = '/General/api/TablasDetalle/';

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
        .factory('GenTercerosService', GenTercerosService);

    GenTercerosService.$inject = ['$http', '$q'];

    function GenTercerosService($http, $q) {
        var nameSpace = '/General/api/Terceros/';

        var service = {
            create: create,
            getAll: getAll,
            getAct: getAct,
            update: update,

            getAllPro: getAllPro,
            getActPro: getActPro,
            updatePro: updatePro,

            getAllCli: getAllCli,
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
        .factory('GenTiposDocService', GenTiposDocService);

    GenTiposDocService.$inject = ['$http', '$q'];

    function GenTiposDocService($http, $q) {
        var nameSpace = '/General/api/TiposDocumento/';

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

        function getByCod(cod) {
            return $http.get(nameSpace + 'ByCod/' + cod)
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
        .factory('GenUsuariosService', GenUsuariosService);

    GenUsuariosService.$inject = ['$http', '$q'];

    function GenUsuariosService($http, $q) {
        var nameSpace = '/General/api/Usuarios/';
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
        .factory('InvArticulosService', InvArticulosService);

    InvArticulosService.$inject = ['$http', '$q'];

    function InvArticulosService($http, $q) {
        var nameSpace = '/Inventario/api/Articulos/';

        var service = {
            getAll: getAll,
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
        .factory('InvMovimientosDetalleService', InvMovimientosDetalleService);

    InvMovimientosDetalleService.$inject = ['$http', '$q'];

    function InvMovimientosDetalleService($http, $q) {
        var nameSpace = '/Inventario/api/MovimientosDetalle/';

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
        .factory('InvMovimientosService', InvMovimientosService);

    InvMovimientosService.$inject = ['$http', '$q'];

    function InvMovimientosService($http, $q) {
        var nameSpace = '/Inventario/api/Movimientos/';

        var service = {
            getAll: getAll,
            getLastAlm: getLastAlm,
            getAct: getAct,
            create: create,
            createByEntradaCompra: createByEntradaCompra,
            createByPuntoDeVenta: createByPuntoDeVenta,
            createByFacturaDeVenta: createByFacturaDeVenta,
            update: update,
            remove: remove,
            getPendientesTercero: getPendientesTercero,
            imprimir: imprimir,
            imprimirFC: imprimirFC,
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

        function imprimirFC(id) {
            return $http.get(nameSpace + '/Imp/' + id)
                .then(
                    function (response) {
                        fnImprimirFC(response.data);
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
                        layout: 'noBorders',
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

        function fnImprimirFA(entity) {
            var data = entity.listaDetalle;

            var tablaDet = [
                [
                    { text: 'Código', bold: true, alignment: 'left', },
                    { text: 'Articulo', bold: true, alignment: 'left', },
                    { text: 'Cant', bold: true, alignment: 'left', },
                    { text: 'VrNeto', bold: true, alignment: 'left', },
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
                        { text: d.vrNeto, alignment: 'right', },
                    ]
                );

                pcDscto += d.pcDscto;
                pcIva += d.pcIva;
                vrBruto += d.vrBruto;
                vrNeto += d.vrNeto;
            }

            var Documento = {
                pageSize: 'A4',
                //header: function (currentPage, pageCount, pageSize) {
                //    return [
                //        {
                //            text: 'Página ' + currentPage.toString() + '/' + pageCount,
                //            alignment: 'right',
                //            margin: [0, 15, 40, 0],
                //            style: 'estilo',
                //        },
                //    ]
                //},
                content: [
                    {
                        style: 'estilo',
                        table: {
                            widths: ['20%', '40%', '20%', '20%'],
                            body: [
                                [
                                    {
                                        text: entity.nombreEmpresa,
                                        colSpan: 4,
                                        alignment: 'center',
                                        bold: true,
                                        margin: [0, 0, 0, 15],
                                    },
                                    {},
                                    {},
                                    {},
                                ],
                                [
                                    { text: 'Fecha:', bold: true },
                                    { text: entity.sFechaFormatted },
                                    { text: 'No. ' + entity.tipoDoc, bold: true },
                                    { text: entity.numDoc },
                                ],
                                [
                                    { text: 'Usuario:', bold: true },
                                    { text: entity.creadoPor, colSpan: 3 },
                                    {},
                                    {},
                                ],
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['25%', '75%'],
                            body: [
                                [
                                    { text: 'Cliente:', bold: true },
                                    { text: entity.nombreTercero },
                                ],
                                [
                                    { text: 'Vendedor:', bold: true },
                                    entity.nombreVendedor,
                                ],
                            ]
                        },
                        layout: 'noBorders',
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
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['85%', '15%'],
                            body: [
                                //[
                                //    { text: 'SubTotal:', bold: true, alignment: 'right', },
                                //    { text: '$ ' + vrBruto, bold: true, },
                                //],
                                //[
                                //    { text: 'Dscto:', bold: true, alignment: 'right', },
                                //    { text: '$ ' + pcDscto, bold: true, },
                                //],
                                //[
                                //    { text: 'Iva:', bold: true, alignment: 'right', },
                                //    { text: '$ ' + pcIva, bold: true, },
                                //],
                                [
                                    { text: 'Total:', bold: true, alignment: 'right', },
                                    { text: '$ ' + vrNeto, bold: true, alignment: 'right', },
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
        .factory('InvTiposDocService', InvTiposDocService);

    InvTiposDocService.$inject = ['$http', '$q'];

    function InvTiposDocService($http, $q) {
        var nameSpace = '/Inventario/api/TiposDoc/';

        var service = {
            getAll: getAll,
            getByAlmacen: getByAlmacen,
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

        function getByAlmacen(idDetAlm, idEmp) {
            return $http.get(nameSpace + 'GetByAlm/' + idDetAlm + '/' + idEmp)
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
        .factory('TesPagosService', TesPagosService);

    TesPagosService.$inject = ['$http', '$q'];

    function TesPagosService($http, $q) {
        var nameSpace = '/Tesoreria/api/Pagos/';

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
                saldoEnCaja += d.nombreFormaPago.includes('Efectivo') || d.valor < 0 ? d.valor : 0;
            }

            tablaResumen.push(
                [
                    { text: 'Saldo Total', bold: true, },
                    { text: PonerPuntosDouble(saldoTotal), bold: true, alignment: 'right', },
                ],
                [
                    { text: 'Saldo En Caja', bold: true, },
                    { text: PonerPuntosDouble(saldoEnCaja), bold: true, alignment: 'right', },
                ]
            );
            

            var tablaDetalle = [
                [
                    { text: 'TipoDoc', bold: true, alignment: 'center', },
                    { text: 'NoDoc', bold: true, alignment: 'center', },
                    { text: 'Descripción', bold: true, alignment: 'center', },
                    { text: 'Ingresos', bold: true, alignment: 'center', },
                    { text: 'Egresos', bold: true, alignment: 'center', },
                ],
                [
                    { text: '' },
                    { text: '' },
                    { text: 'Saldo Inicial', },
                    { text: PonerPuntosDouble(entity.saldoInicial), alignment: 'right', },
                    { text: '' },
                ]
            ];

            var vrIngresos = entity.saldoInicial,
                vrEnCaja = entity.saldoInicial,
                vrEgresos = 0;

            for (var i = 0; i < dataR.length; i++) {
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
                        { text: ingresos, alignment: 'right', },
                        { text: egresos, alignment: 'right', },
                    ]
                );
            }

            var vrSaldoTotal = vrIngresos + vrEgresos;

            tablaDetalle.push(
                [
                    { text: ' ', colSpan: 3, },
                    {},
                    {},
                    { text: vrIngresos > 0 ? PonerPuntosDouble(vrIngresos) : '', bold: true, alignment: 'right', },
                    { text: vrEgresos > 0 || vrEgresos < 0 ? PonerPuntosDouble(vrEgresos) : '', bold: true, alignment: 'right', },
                ],
                [
                    { text: 'Saldo Total:', bold: true, alignment: 'right', colSpan: 3, },
                    {},
                    {},
                    { text: '$ ' + (vrSaldoTotal > 0 ? PonerPuntosDouble(vrSaldoTotal) : ''), bold: true, alignment: 'right', colSpan: 2, },
                    {},
                ],
                [
                    { text: 'Saldo En Caja:', bold: true, alignment: 'right', colSpan: 3, },
                    {},
                    {},
                    { text: '$ ' + (vrEnCaja > 0 ? PonerPuntosDouble(vrEnCaja) : ''), bold: true, alignment: 'right', colSpan: 2, },
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
                            widths: ['10%', '10%', '50%', '15%', '15%'],
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
        .factory('VenClientesService', VenClientesService);

    VenClientesService.$inject = ['$http', '$q'];

    function VenClientesService($http, $q) {
        var nameSpace = '/Ventas/api/Clientes/';

        var service = {
            getAll: getAll,
            getByIden: getByIden,
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

        function getByIden(data) {
            return $http.post(nameSpace + 'ByIden/', data)
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
        .factory('VenFacturasService', VenFacturasService);

    VenFacturasService.$inject = ['$http', '$q'];

    function VenFacturasService($http, $q) {
        var nameSpace = '/Ventas/api/FacturasVen/';

        var service = {
            getLastAlm: getLastAlm,
            getPendientesCli: getPendientesCli,
            getByFecha: getByFecha,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getLastAlm(idUsu) {
            return $http.get(nameSpace + 'LastAlm/' + idUsu)
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

        function getPendientesCli(idCli) {
            return $http.get(nameSpace + 'PenCli/' + idCli)
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

        function getByFecha(idEmp, fecha) {
            return $http.get(nameSpace + 'ByFecha/' + idEmp + '/' + fecha)
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
                        window.location.reload();
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
        .factory('VenListaPreciosDetalleService', VenListaPreciosDetalleService);

    VenListaPreciosDetalleService.$inject = ['$http', '$q'];

    function VenListaPreciosDetalleService($http, $q) {
        var nameSpace = '/Ventas/api/ListaPreciosDetalle/';

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
        .factory('VenListaPreciosService', VenListaPreciosService);

    VenListaPreciosService.$inject = ['$http', '$q'];

    function VenListaPreciosService($http, $q) {
        var nameSpace = '/Ventas/api/ListaPrecios/';

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
        .factory('VenVendedoresService', VenVendedoresService);

    VenVendedoresService.$inject = ['$http', '$q'];

    function VenVendedoresService($http, $q) {
        var nameSpace = '/Ventas/api/Vendedores/';

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