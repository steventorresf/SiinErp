using Newtonsoft.Json.Linq;
using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
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
        string CambiarClave(JObject data);
    }
}