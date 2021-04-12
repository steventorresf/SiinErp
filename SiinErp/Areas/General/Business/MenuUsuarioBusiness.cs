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

        public List<MenuUsuario> GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<MenuUsuario> Lista = (from mu in context.MenuUsuario.Where(x => x.IdUsuario == IdUsuario)
                                           join me in context.Menu on mu.IdMenu equals me.IdMenu
                                           select new MenuUsuario()
                                           {
                                               IdMenuUsuario = mu.IdMenuUsuario,
                                               IdMenu = mu.IdMenu,
                                               IdUsuario = mu.IdUsuario,
                                               Menu = me
                                           }).OrderBy(x => x.Menu.Codigo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        public List<Menu> GetNotAllByIdUsuario(int IdUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Menu> Lista = (from me in context.Menu
                                    join mu in context.MenuUsuario.Where(x => x.IdUsuario == IdUsuario) on me.IdMenu equals mu.IdMenu into Joined
                                    from j in Joined.DefaultIfEmpty()
                                    where j == null
                                    select new Menu()
                                    {
                                        IdMenu = me.IdMenu,
                                        Codigo = me.Codigo,
                                        Nombre = me.Nombre,
                                        Descripcion = me.Descripcion,
                                        CodPadre = me.CodPadre,
                                    }).OrderBy(x => x.Codigo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetNotAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        public void Create(MenuUsuario entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                using (var tran = context.Database.BeginTransaction())
                {
                    context.MenuUsuario.Add(entity);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("MenuUsuarioCreate", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdMenuUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                MenuUsuario entity = context.MenuUsuario.Find(IdMenuUsuario);
                context.MenuUsuario.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("MenuUsuarioDelete", ex.Message, null);
                throw;
            }
        }

    }
}
