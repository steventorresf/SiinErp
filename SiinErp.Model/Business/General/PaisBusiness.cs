using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using SiinErp.Model.Context;
using SiinErp.Model.Entities.General;

namespace SiinErp.Model.Business.General
{
    public class PaisBusiness : AbstractBusiness<int, Pais>, IPaisBusiness
    {
        public PaisBusiness(SiinErpContext context) : base(context)
        {
        }
    }
}