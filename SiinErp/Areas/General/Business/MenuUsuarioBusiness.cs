using SiinErp.Areas.General.Abstract;
using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class MenuUsuarioBusiness : IMenuUsuarioBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public MenuUsuarioBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public string GetMenuByIdUsuario(int IdUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Menu> Lista = (from mu in context.MenuUsuario.Where(x => x.IdUsuario == IdUsuario)
                                    join me in context.Menu on mu.IdMenu equals me.IdMenu
                                    select new Menu()
                                    {
                                        IdMenu = me.IdMenu,
                                        Codigo = me.Codigo,
                                        Nombre = me.Nombre,
                                        Descripcion = me.Descripcion,
                                        CodPadre = me.CodPadre,
                                    }).ToList();

                string MenuHtml = "";
                foreach (Menu m in Lista)
                {
                    MenuHtml += "|" + m.Codigo + "|";
                }
                
                return MenuHtml;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }
    }
}
