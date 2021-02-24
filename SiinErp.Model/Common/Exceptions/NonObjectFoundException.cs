using System;

namespace SiinErp.Model.Common.Exceptions
{
    [Serializable]
    public class NonObjectFoundException : SystemException
    {
        public NonObjectFoundException() : base(Constantes.NonObjectFound_Exception_Message)
        {
        }
    }
}