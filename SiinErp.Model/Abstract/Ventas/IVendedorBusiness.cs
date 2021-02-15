using SiinErp.Model.Entities.Ventas;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Ventas
{
    public interface IVendedorBusiness
    {
        List<Vendedor> GetVendedores(int IdEmp);

        List<Vendedor> GetVendedoresAct(int IdEmp);

        void Create(Vendedor entity);

        void Update(int IdVendedor, Vendedor entity);
    }
}