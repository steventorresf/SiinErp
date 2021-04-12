using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface IMenuUsuarioBusiness
    {
        string GetMenuByIdUsuario(int IdUsuario);
        List<MenuUsuario> GetAllByIdUsuario(int IdUsuario);
        List<Menu> GetNotAllByIdUsuario(int IdUsuario);
        void Create(MenuUsuario entity);
        void Delete(int IdMenuUsuario);
    }
}
