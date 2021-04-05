using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop.Common
{
    public static class Util
    {
        public static byte[] GetImageByte(string Icono)
        {
            Image image = Image.FromFile(Icono);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, image.RawFormat);
            return memoryStream.ToArray();
        }

        public static Image GetImage(string Icono)
        {
            byte[] vs = GetImageByte(Icono);
            MemoryStream memoryStream = new MemoryStream(vs);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        public static Bitmap GetBitmap(string Icono)
        {
            Image image = GetImage(Icono);
            Bitmap bitmap = new Bitmap(image, 25, 25);
            return bitmap;
        }
    }
}
