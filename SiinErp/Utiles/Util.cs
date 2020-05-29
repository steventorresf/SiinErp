using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Utiles
{
    public class Util
    {
        public static string EncriptarMD5(string Texto)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(Texto);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string Conversion = s.ToString();
            return Conversion;
        }

        public static bool ValidarUsu(HttpContext context)
        {
            if (context.Session.GetString("IdUsu") != null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
