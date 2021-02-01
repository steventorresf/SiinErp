using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class ErrorBusiness : IErrorBusiness
    {
        public void Create(string Metodo, string MensajeError, int? IdUsuario)
        {
            try
            {
                Error entity = new Error();
                entity.Metodo = Metodo;
                entity.MensajeError = MensajeError;
                entity.IdUsuario = IdUsuario;
                entity.FechaError = DateTimeOffset.Now;

                SiinErpContext context = new SiinErpContext();
                context.Errores.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
