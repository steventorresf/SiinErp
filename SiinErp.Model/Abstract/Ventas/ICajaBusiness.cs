using SiinErp.Model.Entities.Ventas;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.Ventas
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