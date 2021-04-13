using Newtonsoft.Json.Linq;
using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
{
    public interface ITerceroBusiness
    {
        List<Tercero> GetTerceros(int IdEmpresa);
        List<Tercero> GetTercerosActivos(int IdEmpresa);
        void Create(Tercero entity);
        void Update(int IdTercero, Tercero entity);
        List<Tercero> GetProveedores(int IdEmpresa);
        List<Tercero> GetProveedoresActivos(int IdEmpresa);
        void UpdateProveedor(int IdProveedor, Tercero entity);
        List<Tercero> GetClientes(int IdEmpresa);
        List<Tercero> GetClienteListById(int IdTercero);
        Tercero GetClienteByIden(JObject data);
        List<Tercero> GetClientesActivos(int IdEmpresa);
        void UpdateCliente(int IdCliente, Tercero entity);
    }
}