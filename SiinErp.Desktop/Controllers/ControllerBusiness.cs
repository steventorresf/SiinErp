using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Abstract.Inventario;
using SiinErp.Model.Abstract.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Desktop.Controllers
{
    public class ControllerBusiness : IControllerBusiness
    {
        #region Cartera Abstract
        public IConceptoBusiness conceptoBusiness { get; set; }
        public IMovimientoCarBusiness movimientoCarBusiness { get; set; }
        public IPlazoPagoBusiness plazoPagoBusiness { get; set; }
        #endregion

        #region General Abstract
        public ICiudadBusiness ciudadBusiness { get; }
        public IDepartamentoBusiness departamentoBusiness { get; }
        public IEmpresaBusiness empresaBusiness { get; }
        public IErrorBusiness errorBusiness { get; }
        public IMenuUsuarioBusiness menuUsuarioBusiness { get; }
        public IModuloBusiness moduloBusiness { get; }
        public IPaisBusiness paisBusiness { get; }
        public IParametroBusiness parametroBusiness { get; }
        public IPeriodoBusiness periodoBusiness { get; }
        public ISecuenciaBusiness secuenciaBusiness { get; }
        public ITablaBusiness tablaBusiness { get; }
        public ITablaDetalleBusiness tablaDetalleBusiness { get; }
        public ITerceroBusiness terceroBusiness { get; }
        public ITipoDocumentoBusiness tipoDocumentoBusiness { get; }
        public IUsuarioBusiness usuarioBusiness { get; }
        #endregion

        #region Inventario Abstract
        public IArticuloBusiness articuloBusiness { get; }
        public IMovimientoBusiness movimientoBusiness { get; }
        public IMovimientoDetalleBusiness movimientoDetalleBusiness { get; }
        public IMovimientoFormaPagoBusiness movimientoFormaPagoBusiness { get; }
        #endregion

        #region Ventas Abstract
        public ICajaBusiness cajaBusiness { get; }
        public ICajaDetalleBusiness cajaDetalleBusiness { get; }
        public IListaPrecioBusiness listaPrecioBusiness { get; }
        public IListaPrecioDetalleBusiness listaPrecioDetalleBusiness { get; }
        public IVendedorBusiness vendedorBusiness { get; }
        #endregion



        public ControllerBusiness
            (
                // Cartera
                IPlazoPagoBusiness _plazoPagoBusiness,

                // General
                ICiudadBusiness _ciudadBusiness,
                IDepartamentoBusiness _departamentoBusiness,
                IEmpresaBusiness _empresaBusiness,
                IErrorBusiness _errorBusiness,
                IMenuUsuarioBusiness _menuUsuarioBusiness,
                IModuloBusiness _moduloBusiness,
                IPaisBusiness _paisBusiness,
                IParametroBusiness _parametroBusiness,
                IPeriodoBusiness _periodoBusiness,
                ISecuenciaBusiness _secuenciaBusiness,
                ITablaBusiness _tablaBusiness,
                ITablaDetalleBusiness _tablaDetalleBusiness,
                ITerceroBusiness _terceroBusiness,
                ITipoDocumentoBusiness _tipoDocumentoBusiness,
                IUsuarioBusiness _usuarioBusiness,

                // Inventario
                IArticuloBusiness _articuloBusiness,
                IMovimientoBusiness _movimientoBusiness,
                IMovimientoDetalleBusiness _movimientoDetalleBusiness,
                IMovimientoFormaPagoBusiness _movimientoFormaPagoBusiness,

                // Ventas
                ICajaBusiness _cajaBusiness,
                ICajaDetalleBusiness _cajaDetalleBusiness,
                IListaPrecioBusiness _listaPrecioBusiness,
                IListaPrecioDetalleBusiness _listaPrecioDetalleBusiness,
                IVendedorBusiness _vendedorBusiness
            )
        {
            this.plazoPagoBusiness = _plazoPagoBusiness;

            this.ciudadBusiness = _ciudadBusiness;
            this.departamentoBusiness = _departamentoBusiness;
            this.empresaBusiness = _empresaBusiness;
            this.errorBusiness = _errorBusiness;
            this.menuUsuarioBusiness = _menuUsuarioBusiness;
            this.moduloBusiness = _moduloBusiness;
            this.paisBusiness = _paisBusiness;
            this.parametroBusiness = _parametroBusiness;
            this.periodoBusiness = _periodoBusiness;
            this.secuenciaBusiness = _secuenciaBusiness;
            this.tablaBusiness = _tablaBusiness;
            this.tablaDetalleBusiness = _tablaDetalleBusiness;
            this.terceroBusiness = _terceroBusiness;
            this.tipoDocumentoBusiness = _tipoDocumentoBusiness;
            this.usuarioBusiness = _usuarioBusiness;

            this.articuloBusiness = _articuloBusiness;
            this.movimientoBusiness = _movimientoBusiness;
            this.movimientoDetalleBusiness = _movimientoDetalleBusiness;
            this.movimientoFormaPagoBusiness = _movimientoFormaPagoBusiness;

            this.cajaBusiness = _cajaBusiness;
            this.cajaDetalleBusiness = _cajaDetalleBusiness;
            this.listaPrecioBusiness = _listaPrecioBusiness;
            this.listaPrecioDetalleBusiness = _listaPrecioDetalleBusiness;
            this.vendedorBusiness = _vendedorBusiness;
        }

    }
}
