using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using SiinErp.Utiles;
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

        public List<Usuarios> GetUsuarios()
        {
            try
            {
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
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
                BaseContext context = new BaseContext();
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

    }
}
