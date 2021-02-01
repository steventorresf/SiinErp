using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Abstract
{
    public interface IVendedorBusiness
    {
        List<Vendedor> GetVendedores(int IdEmp);

        List<Vendedor> GetVendedoresAct(int IdEmp);

        void Create(Vendedor entity);

        void Update(int IdVendedor, Vendedor entity);
    }
}
