using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface ITablaDetalleBusiness
    {
        void Create(TablaDetalle entity);

        void Update(int IdDetalle, TablaDetalle entity);

        void UpdateOrden(int IdDetalle, short Orden);

        List<TablaDetalle> GetAllTablaDetalleByIdTabEmp(int IdTabla, int IdEmpresa);

        List<TablaDetalle> GetTablaEmpresaDetalleByCod(string CodTabla, int IdEmpresa);
    }
}
