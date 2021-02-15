using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;

namespace SiinErp.Model.Business.General
{
    public class ErrorBusiness : IErrorBusiness
    {
        private readonly SiinErpContext context;

        public ErrorBusiness(SiinErpContext context)
        {
            this.context = context;
        }

        public void Create(string Metodo, string MensajeError, int? IdUsuario)
        {
            try
            {
                Error entity = new Error
                {
                    Metodo = Metodo,
                    MensajeError = MensajeError,
                    IdUsuario = IdUsuario,
                    FechaError = DateTimeOffset.Now
                };
                context.Errores.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}