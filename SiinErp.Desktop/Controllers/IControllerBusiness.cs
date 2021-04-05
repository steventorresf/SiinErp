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
    public interface IControllerBusiness
    {
        #region Cartera
        public IPlazoPagoBusiness plazoPagoBusiness { get; }
        #endregion

        #region General
        public IEmpresaBusiness empresaBusiness { get; }
        public ICiudadBusiness ciudadBusiness { get; }
        public IMenuUsuarioBusiness menuUsuarioBusiness { get; }
        public ISecuenciaBusiness secuenciaBusiness { get; }
        public ITablaBusiness tablaBusiness { get; }
        public ITablaDetalleBusiness tablaDetalleBusiness { get; }
        public ITerceroBusiness terceroBusiness { get; }
        public ITipoDocumentoBusiness tipoDocumentoBusiness { get; }
        public IUsuarioBusiness usuarioBusiness { get; }
        #endregion

        #region Inventario
        public IArticuloBusiness articuloBusiness { get; }
        public IMovimientoBusiness movimientoBusiness { get; }
        public IMovimientoDetalleBusiness movimientoDetalleBusiness { get; }
        public IMovimientoFormaPagoBusiness movimientoFormaPagoBusiness { get; }
        #endregion

        #region Ventas
        public ICajaBusiness cajaBusiness { get; }
        public ICajaDetalleBusiness cajaDetalleBusiness { get; }
        public IListaPrecioBusiness listaPrecioBusiness { get; }
        public IListaPrecioDetalleBusiness listaPrecioDetalleBusiness { get; }
        public IVendedorBusiness vendedorBusiness { get; }
        #endregion
    }
}
