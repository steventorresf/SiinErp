using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiinErp.Model.Business.General
{
    public class CiudadBusiness : AbstractBusiness<int, Ciudad>, ICiudadBusiness
    {
        private readonly SiinErpContext _Context;

        public CiudadBusiness(SiinErpContext context) : base(context)
        {
            this._Context = context;
        }
/*
        public List<Ciudad> GetCiudades(int IdDep)
        {
            try
            {
                List<Ciudad> Lista = _Context.Ciudades.Where(x => x.IdDepartamento == IdDep).OrderBy(x => x.NombreCiudad).ToList();
                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
*/
        public List<Ciudad> ReadAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}