using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class ErroresBusiness
    {
        public static void Create(string Metodo, string MensajeError, int? IdUsuario)
        {
            try
            {
                Errores entity = new Errores();
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
