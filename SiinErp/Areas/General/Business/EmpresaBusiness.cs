using SiinErp.Models;
using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiinErp.Areas.General.Abstract;

namespace SiinErp.Areas.General.Business
{
    public class EmpresaBusiness : IEmpresaBusiness
    {
        private readonly IErrorBusiness errorBusiness;

        public EmpresaBusiness()
        {
            errorBusiness = new ErrorBusiness();
        }


        public List<Empresa> GetEmpresas()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Empresa> Lista = (from em in context.Empresas
                                       join re in context.TablasDetalles on em.IdDetRegimen equals re.IdDetalle
                                       select new Empresa()
                                       {
                                           IdEmpresa = em.IdEmpresa,
                                           NitEmpresa = em.NitEmpresa,
                                           RazonSocial = em.RazonSocial,
                                           Ciudad = em.Ciudad,
                                           Direccion = em.Direccion,
                                           Telefono = em.Telefono,
                                           CodEan = em.CodEan,
                                           Representante = em.Representante,
                                           IdDetRegimen = em.IdDetRegimen,
                                           NombreRegimen = re.Descripcion,
                                       }).OrderBy(x => x.RazonSocial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetEmpresas", ex.Message, null);
                throw;
            }
        }

        public List<Empresa> GetEmpresasAct()
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                List<Empresa> Lista = context.Empresas.OrderBy(x => x.RazonSocial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetEmpresas", ex.Message, null);
                throw;
            }
        }

        public void Create(Empresa entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                context.Empresas.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreateEmpresa", ex.Message, null);
                throw;
            }
        }

        public void Update(int IdEmpresa, Empresa entity)
        {
            try
            {
                SiinErpContext context = new SiinErpContext();
                Empresa ob = context.Empresas.Find(IdEmpresa);
                ob.RazonSocial = entity.RazonSocial;
                ob.NitEmpresa = entity.NitEmpresa;
                ob.Ciudad = entity.Ciudad;
                ob.Direccion = entity.Direccion;
                ob.Telefono = entity.Telefono;
                ob.CodEan = entity.CodEan;
                ob.Representante = entity.Representante;
                ob.IdDetRegimen = entity.IdDetRegimen;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("UpdateEmpresa", ex.Message, null);
                throw;
            }
        }

    }
}
