using Newtonsoft.Json.Linq;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface ITerceroBusiness
    {
        List<Tercero> GetTerceros(int IdEmpresa);
        List<Tercero> GetTercerosActivos(int IdEmpresa);
        void Create(Tercero entity);
        void Update(int IdTercero, Tercero entity);

        //
        List<Tercero> GetProveedores(int IdEmpresa);
        List<Tercero> GetProveedoresActivos(int IdEmpresa);
        void UpdateProveedor(int IdProveedor, Tercero entity);

        //
        List<Tercero> GetClientes(int IdEmpresa);
        List<Tercero> GetClienteListById(int IdTercero);
        Tercero GetClienteByIden(JObject data);
        List<Tercero> GetClientesByPrefix(JObject data);
        List<Tercero> GetClientesActivos(int IdEmpresa);
        void UpdateCliente(int IdCliente, Tercero entity);
    }
}
