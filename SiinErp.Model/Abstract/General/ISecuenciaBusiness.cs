using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Abstract.General
{
    public interface ISecuenciaBusiness
    {
        string GetPrefijoSecuencia(string Prefijo, int IdEmpresa);
    }
}
