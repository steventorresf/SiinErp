using SiinErp.Areas.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface ITipoDocumentoBusiness
    {
        TipoDocumento GetTipoDocumento(int IdEmpresa, string TipoDoc);

        List<TipoDocumento> GetTiposDocumentos(int IdEmpresa);

        List<TipoDocumento> GetTiposDocumentosByModulo(int IdEmpresa, string CodModulo);

        void Create(TipoDocumento entity);

        void Update(int IdTipoDoc, TipoDocumento entity);
    }
}
