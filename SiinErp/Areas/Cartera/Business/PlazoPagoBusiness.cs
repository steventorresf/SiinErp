using SiinErp.Models;
using SiinErp.Areas.Cartera.Entities;
using SiinErp.Areas.General.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.Cartera.Abstract;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.Cartera.Business
{
    public class PlazoPagoBusiness : IPlazoPagoBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public PlazoPagoBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<PlazoPago> GetPlazosPagos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<PlazoPago> Lista = context.PlazosPagos.OrderBy(x => x.Descripcion).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetPlazosPagos", ex.Message, null);
                throw;
            }
        }

        public void Create(PlazoPago entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.PlazosPagos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatePlazoPago", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdPlazoPago, PlazoPago entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                PlazoPago ob = context.PlazosPagos.Find(IdPlazoPago);
                ob.Descripcion = entity.Descripcion;
                ob.Cuotas = entity.Cuotas;
                ob.PcInicial = entity.PcInicial;
                ob.PlazoDias = entity.PlazoDias;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdatePlazoPago", ex.Message, null);
                throw;
            }
        }
    }
}
