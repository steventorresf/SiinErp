using SiinErp.Model.Abstract.Cartera;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.Cartera;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.Cartera
{
    public class PlazoPagoBusiness : IPlazoPagoBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public PlazoPagoBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public List<PlazoPago> GetPlazosPagos(int IdEmpresa)
        {
            try
            {
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
                PlazoPago ob = context.PlazosPagos.Find(IdPlazoPago);
                ob.Descripcion = entity.Descripcion;
                ob.Cuotas = entity.Cuotas;
                ob.PcInicial = entity.PcInicial;
                ob.PlazoDias = entity.PlazoDias;
                ob.EstadoFila = entity.EstadoFila;
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