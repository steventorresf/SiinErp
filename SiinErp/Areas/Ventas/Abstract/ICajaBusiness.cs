using SiinErp.Areas.Ventas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Ventas.Abstract
{
    public interface ICajaBusiness
    {
        List<Caja> GetCajasById(int IdCajero);

        void Create(Caja entity);

        void Update(int IdCaja, Caja data);

        int GetIdCajaActiva(int IdCajero);

        int GetLastIdDetCajeroByUsu(string NombreUsuario, int IdEmpresa);

        decimal GetSaldoEnCajaActual(int IdCaja);

        Caja GetCajaImpresion(int IdCaja);
    }
}
