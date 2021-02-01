using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IErrorBusiness
    {
        void Create(string Metodo, string MensajeError, int? IdUsuario);
    }
}
