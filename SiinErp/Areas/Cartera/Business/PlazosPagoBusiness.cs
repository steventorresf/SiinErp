using SiinErp.Models;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.Cartera.Business
{
    public class PlazosPagoBusiness
    {
        public List<PlazosPago> GetPlazosPagos()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<PlazosPago> Lista = context.PlazosPagos.OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPlazosPagos", ex.Message, null);
                throw;
            }
        }

        public void Create(PlazosPago entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.PlazosPagos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreatePlazoPago", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdPlazoPago, PlazosPago entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                PlazosPago ob = context.PlazosPagos.Find(IdPlazoPago);
                ob.Descripcion = entity.Descripcion;
                ob.Cuotas = entity.Cuotas;
                ob.PcInicial = entity.PcInicial;
                ob.PlazoDias = entity.PlazoDias;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdatePlazoPago", ex.Message, null);
                throw;
            }
        }
    }
}
