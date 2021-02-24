using System;

namespace SiinErp.Model.Abstract.General
{
    public interface IErrorBusiness
    {
        void Create(string Metodo, string MensajeError, int? IdUsuario);
        void Create(string Metodo, Exception ex, int? IdUsuario);
    }
}