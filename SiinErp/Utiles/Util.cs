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

        public static string GetPrefijoSecuencia(string Prefijo, int NoSecuencia, int Longitud)
        {
            string StrSecuencia = Prefijo;
            int lon = Longitud - Prefijo.Length - NoSecuencia.ToString().Length;

            for(int i = 1; i <= lon; i++)
            {
                StrSecuencia += "0";
            }

            StrSecuencia += NoSecuencia;
            return StrSecuencia;
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
