using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IUsuarioBusiness
    {
        Usuario GetByUsuario(string NomUsu, string Clave);

        List<Usuario> GetUsuarios();

        void Create(Usuario entity);

        void Update(int IdUsuario, Usuario entity);

        void UpdateEstado(int IdUsuario, string Estado);

        void ResetearClave(int IdUsuario);

        int? GetUltimoIdAlmacenPuntoVenta(int IdUsuario);
    }
}
