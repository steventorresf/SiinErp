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
        #region General
        public IEmpresaBusiness empresaBusiness { get; }
        public ITerceroBusiness terceroBusiness { get; }
        public ITablaDetalleBusiness tablaDetalleBusiness { get; }
        public ITipoDocumentoBusiness tipoDocumentoBusiness { get; }
        public IUsuarioBusiness usuarioBusiness { get; }
        #endregion

        #region Inventario
        public IArticuloBusiness articuloBusiness { get; }
        #endregion

        #region Ventas
        public IListaPrecioBusiness listaPrecioBusiness { get; }
        #endregion
    }
}
