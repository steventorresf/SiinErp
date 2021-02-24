using System;

namespace SiinErp.Model.Common.Exceptions
{
    [Serializable]
    public class NonEqualObjectException : SystemException
    {
        public NonEqualObjectException() : base(Constantes.NonEqualObject_Exception_Message)
        {
        }
    }
}
