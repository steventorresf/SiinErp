using SiinErp.Areas.General.Entities;
using SiinErp.Models;
using SiinErp.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Business
{
    public class TercerosBusiness
    {
        public List<Terceros> GetTerceros(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Terceros> Lista = (from t in context.Terceros.Where(x => x.IdEmpresa == IdEmpresa)
                                        join c in context.Ciudades on t.IdCiudad equals c.IdCiudad
                                        join d in context.Departamentos on c.IdDepartamento equals d.IdDepartamento
                                        select new Terceros()
                                        {
                                            IdTercero = t.IdTercero,
                                            IdEmpresa = t.IdEmpresa,
                                            NitCedula = t.NitCedula,
                                            DgVerificacion = t.DgVerificacion,
                                            IdDetTipoPersona = t.IdDetTipoPersona,
                                            NombreTercero = t.NombreTercero,
                                            IdCiudad = t.IdCiudad,
                                            Direccion = t.Direccion,
                                            Telefono = t.Telefono,
                                            FechaCreacion = t.FechaCreacion,
                                            CreadoPor = t.CreadoPor,
                                            Estado = t.Estado,
                                            NombreCiudad = c.NombreCiudad + " - " + d.NombreDepartamento,
                                            IdDepartamento = d.IdDepartamento,
                                        }).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTerceros", ex.Message, null);
                throw;
            }
        }

        public List<Terceros> GetTercerosActivos(int IdEmpresa)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Terceros> Lista = context.Terceros.Where(x => x.IdEmpresa == IdEmpresa && x.Estado.Equals(Constantes.EstadoActivo)).OrderBy(x => x.NombreTercero).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetTercerosActivos", ex.Message, null);
                throw;
            }
        }

        public void Create(Terceros entity)
        {
            try
            {
                entity.FechaCreacion = DateTimeOffset.Now;
                SiinErpContext context = new SiinErpContext();
                context.Terceros.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTercero", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdTercero, Terceros entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Terceros ob = context.Terceros.Find(IdTercero);
                ob.NitCedula = entity.NitCedula;
                ob.DgVerificacion = entity.DgVerificacion;
                ob.IdDetTipoPersona = entity.IdDetTipoPersona;
                ob.NombreTercero = entity.NombreTercero;
                ob.IdCiudad = entity.IdCiudad;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.Estado = entity.Estado;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateTercero", ex.Message, null);
                throw;
            }
        }
    }
}
