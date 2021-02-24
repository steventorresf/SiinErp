using System;

namespace SiinErp.Model.Common.Exceptions
{
    [Serializable]
    public class DuplicatedException : SystemException
    {
        public DuplicatedException() : base(Constantes.Duplicated_Exception_Message)
        {
        }
    }
}
