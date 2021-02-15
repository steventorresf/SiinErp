using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Model.Abstract.General
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