﻿using SiinErp.Models._DAL;
using SiinErp.Models.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Models.General.Business
{
    public class EmpresasBusiness
    {
        public List<Empresas> GetEmpresas()
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Empresas> Lista = (from em in context.Empresas
                                        join ci in context.Ciudades on em.IdCiudad equals ci.IdCiudad
                                        join de in context.Departamentos on ci.IdDepartamento equals de.IdDepartamento
                                        join re in context.TablasDetalles on em.IdDetRegimen equals re.IdDetalle
                                        select new Empresas()
                                        {
                                            IdEmpresa = em.IdEmpresa,
                                            NitEmpresa = em.NitEmpresa,
                                            RazonSocial = em.RazonSocial,
                                            IdCiudad = em.IdCiudad,
                                            Direccion = em.Direccion,
                                            Telefono = em.Telefono,
                                            CodEan = em.CodEan,
                                            Representante = em.Representante,
                                            IdDetRegimen = em.IdDetRegimen,
                                            IdDepartamento = de.IdDepartamento,
                                            NombreCiudad = ci.NombreCiudad + " - " + de.NombreDepartamento,
                                            NombreRegimen = re.Descripcion,
                                        }).OrderBy(x => x.RazonSocial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetEmpresas", ex.Message, null);
                throw;
            }
        }

        public void Create(Empresas entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Empresas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreateEmpresa", ex.Message, null);
                throw;
            }
        }
        public void Update(int IdEmpresa, Empresas entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                Empresas ob = context.Empresas.Find(IdEmpresa);
                ob.RazonSocial = entity.RazonSocial;
                ob.NitEmpresa = entity.NitEmpresa;
                ob.IdCiudad = entity.IdCiudad;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.CodEan = entity.CodEan;
                ob.Representante = entity.Representante;
                ob.IdDetRegimen = entity.IdDetRegimen;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("UpdateEmpresa", ex.Message, null);
                throw;
            }
        }

    }
}