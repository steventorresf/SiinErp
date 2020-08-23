using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class UsuariosBusiness
    {
        public Usuarios GetByUsuario(string NomUsu, string Clave)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Usuarios obUsu = context.Usuarios.FirstOrDefault(x => x.NombreUsuario.Equals(NomUsu) && x.Clave.Equals(Clave));
                return obUsu;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetByUsuario", ex.Message, null);
                throw;
            }
        }

        public List<Usuarios> GetUsuarios()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Usuarios> Lista = (from us in context.Usuarios
                                        select new Usuarios()
                                        {
                                            IdUsuario = us.IdUsuario,
                                            NombreCompleto = us.NombreCompleto,
                                            NombreUsuario = us.NombreUsuario,
                                            Estado = us.Estado,
                                            NombreEstado = us.Estado.Equals(Constantes.EstadoActivo) ? "ACTIVO" : "INACTIVO",
                                            Clave = ".",
                                        }).OrderBy(x => x.NombreCompleto).OrderBy(x => x.Estado).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetUsuarios", ex.Message, null);
                throw;
            }
        }

        public void Create(Usuarios entity)
        {
            try
            {
                entity.Clave = Util.EncriptarMD5(Constantes.ClavePredeterminada);
                SiinErpContext context = new SiinErpContext();
                context.Usuarios.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateUsuarios", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdUsuario, Usuarios entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Usuarios obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.NombreCompleto = entity.NombreCompleto;
                obUsu.NombreUsuario = entity.NombreUsuario;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateUsuarios", ex.Message, null);
                throw;
            }
        }

        public void UpdateEstado(int IdUsuario, string Estado)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Usuarios obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.Estado = Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateEstadoUsuario", ex.Message, null);
                throw;
            }
        }

        public void ResetearClave(int IdUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Usuarios entity = context.Usuarios.Find(IdUsuario);
                entity.Clave = Util.EncriptarMD5(Constantes.ClavePredeterminada);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ResetearClaveUsuario", ex.Message, null);
                throw;
            }
        }


        public int? GetUltimoIdAlmacenPuntoVenta(int IdUsuario)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Usuarios entity = context.Usuarios.Find(IdUsuario);
                return entity.UltimoAlmacen;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetUltimoIdAlmacenPuntoVenta", ex.Message, null);
                throw;
            }
        }

    }
}
