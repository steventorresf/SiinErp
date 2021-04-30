using SiinErp.Model.Abstract.General;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly SiinErpContext context;

        public UsuarioBusiness(IErrorBusiness errorBusiness, SiinErpContext context)
        {
            this.errorBusiness = errorBusiness;
            this.context = context;
        }

        public Usuario GetByUsuario(string NomUsu, string Clave)
        {
            try
            {
                Usuario obUsu = context.Usuarios.FirstOrDefault(x => x.NombreUsuario.Equals(NomUsu) && x.Clave.Equals(Clave));
                return obUsu;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetByUsuario", ex.Message, null);
                throw;
            }
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                List<Usuario> Lista = (from us in context.Usuarios
                                       select new Usuario()
                                       {
                                           IdUsuario = us.IdUsuario,
                                           NombreCompleto = us.NombreCompleto,
                                           NombreUsuario = us.NombreUsuario,
                                           EstadoFila = us.EstadoFila,
                                           NombreEstado = us.EstadoFila.Equals(Constantes.EstadoActivo) ? "ACTIVO" : "INACTIVO",
                                           Clave = ".",
                                       }).OrderBy(x => x.NombreCompleto).OrderBy(x => x.EstadoFila).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetUsuarios", ex.Message, null);
                throw;
            }
        }

        public void Create(Usuario entity)
        {
            try
            {
                entity.Clave = Seguridad.EncriptarMD5(Constantes.ClavePredeterminada);
                context.Usuarios.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateUsuarios", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdUsuario, Usuario entity)
        {
            try
            {
                Usuario obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.NombreCompleto = entity.NombreCompleto;
                obUsu.NombreUsuario = entity.NombreUsuario;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateUsuarios", ex.Message, null);
                throw;
            }
        }

        public void UpdateEstado(int IdUsuario, string Estado)
        {
            try
            {
                Usuario obUsu = context.Usuarios.Find(IdUsuario);
                obUsu.EstadoFila = Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateEstadoUsuario", ex.Message, null);
                throw;
            }
        }

        public void ResetearClave(int IdUsuario)
        {
            try
            {
                Usuario entity = context.Usuarios.Find(IdUsuario);
                entity.Clave = Seguridad.EncriptarMD5(Constantes.ClavePredeterminada);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("ResetearClaveUsuario", ex.Message, null);
                throw;
            }
        }

        public int? GetUltimoIdAlmacenPuntoVenta(int IdUsuario)
        {
            try
            {
                Usuario entity = context.Usuarios.Find(IdUsuario);
                return entity.UltimoAlmacen;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetUltimoIdAlmacenPuntoVenta", ex.Message, null);
                throw;
            }
        }
    }
}