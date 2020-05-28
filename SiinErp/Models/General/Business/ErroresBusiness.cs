using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
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

                BaseContext context = new BaseContext();
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
