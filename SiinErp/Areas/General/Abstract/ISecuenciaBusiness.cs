﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Areas.General.Abstract
{
    public interface ISecuenciaBusiness
    {
        string GetPrefijoSecuencia(string Prefijo, int IdEmpresa);
    }
}
