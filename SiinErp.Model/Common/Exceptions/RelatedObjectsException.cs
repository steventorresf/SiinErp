using System;

namespace SiinErp.Model.Common.Exceptions
{
    [Serializable]
    public class RelatedObjectsException : SystemException
    {
        public RelatedObjectsException() : base(Constantes.RelatedObjects_Exception_Message)
        {
        }
    }
}