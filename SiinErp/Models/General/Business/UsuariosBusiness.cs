using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class UsuariosBusiness
    {
        public Usuarios GetByUsuario(string NomUsu, string Clave)
        {
            try
            {
                BaseContext context = new BaseContext();
                Usuarios obUsu = context.Usuarios.FirstOrDefault(x => x.NombreUsuario.Equals(NomUsu) && x.Clave.Equals(Clave));
                return obUsu;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetByUsuario", ex.Message, null);
                throw;
            }
        }
    }
}
