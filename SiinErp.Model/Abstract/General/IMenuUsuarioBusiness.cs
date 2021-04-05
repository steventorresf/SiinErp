using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Abstract.General
{
    public interface IMenuUsuarioBusiness
    {
        string GetMenuByIdUsuario(int IdUsuario);
        List<MenuUsuario> GetAllByIdUsuario(int IdUsuario);
        List<Menu> GetGrupoMenuByIdUsuario(int IdUsuario);
        List<Menu> GetNotAllByIdUsuario(int IdUsuario);
        void Creates(List<MenuUsuario> Listado);
        void Delete(int IdMenuUsuario);
    }
}
