using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Model.Business.General
{
    public class MenuUsuarioBusiness : IMenuUsuarioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public MenuUsuarioBusiness(IErrorBusiness _errorBusiness, SiinErpContext _context)
        {
            this.errorBusiness = _errorBusiness;
            this.context = _context;
        }


        public string GetMenuByIdUsuario(int IdUsuario)
        {
            try
            {
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

        public void Creates(List<MenuUsuario> Listado)
        {
            try
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    context.MenuUsuario.AddRange(Listado);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                errorBusiness.Create("MenuUsuarioCreates", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdMenuUsuario)
        {
            try
            {
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
