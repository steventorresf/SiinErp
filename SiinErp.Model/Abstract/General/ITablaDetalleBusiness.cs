using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
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