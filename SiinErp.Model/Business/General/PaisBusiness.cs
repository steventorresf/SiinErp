using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Business.General
{
    public class PaisBusiness : AbstractBusiness<int, Pais>, IPaisBusiness
    {
        public PaisBusiness(SiinErpContext context) : base(context)
        {
        }

        public void Create(Pais entity)
        {
            throw new System.NotImplementedException();
        }

        public Pais Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Pais> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}