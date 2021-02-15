namespace SiinErp.Model.Abstract.General
{
    public interface IErrorBusiness
    {
        void Create(string Metodo, string MensajeError, int? IdUsuario);
    }
}