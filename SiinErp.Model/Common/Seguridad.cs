using System.Security.Cryptography;
using System.Text;

namespace SiinErp.Model.Common
{
    public class Seguridad
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
    }
}