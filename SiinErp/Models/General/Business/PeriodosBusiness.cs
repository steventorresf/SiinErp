using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class PeriodosBusiness
    {
        public void Create(Periodos entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                BaseContext context = new BaseContext();
                context.Periodos.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTabla", ex.Message, null);
                throw;
            }
        }

        //public void Update(int IdTabla, Periodos entity)
        //{
        //    try
        //    {
        //        BaseContext context = new BaseContext();
        //        Periodos ob = context.Tablas.Find(IdTabla);
        //        ob.CodTabla = entity.CodTabla;
        //        ob.Descripcion = entity.Descripcion;
        //        ob.CodModulo = entity.CodModulo;
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErroresBusiness.Create("UpdateTabla", ex.Message, null);
        //        throw;
        //    }
        //}

        public List<Periodos> GetPeriodos(int IdEmpresa)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Periodos> Lista = context.Periodos.Where(x => x.IdEmpresa == IdEmpresa).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetPeriodos", ex.Message, null);
                throw;
            }
        }
    }
}
