using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiinErp.Desktop.Common
{
    public class PDF
    {
        private static Paragraph Cadena(string cadena, int tamaño, int estilo, BaseColor color)
        {
            string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            BaseFont bf = BaseFont.CreateFont(arialuniTff, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font fuente = new Font(bf, tamaño, estilo, color);
            Paragraph p = new Paragraph(cadena, fuente);
            return p;
        }

        private static PdfPCell Celda(string cadena, int tamaño, int estilo, BaseColor color, int alineacion, int border)
        {
            Paragraph p = Cadena(cadena, tamaño, estilo, color);
            PdfPCell celda = new PdfPCell(p);
            celda.HorizontalAlignment = alineacion;
            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            celda.Border = border;
            celda.BorderColor = BaseColor.LIGHT_GRAY;
            celda.PaddingBottom = 4;
            return celda;
        }

        private static PdfPCell obtCeldaPadding(string cadena, int tamaño, int estilo, BaseColor color, int alineacion, int border)
        {
            Paragraph p = Cadena(cadena, tamaño, estilo, color);
            PdfPCell celda = new PdfPCell(p);
            celda.HorizontalAlignment = alineacion;
            celda.VerticalAlignment = Element.ALIGN_TOP;
            celda.Border = border;
            celda.BorderColor = BaseColor.LIGHT_GRAY;
            celda.Padding = 1f;
            return celda;
        }

        private static PdfPCell Imagen(float i, float j, string nomImg)
        {
            PdfPCell celda;
            try
            {
                nomImg = "";// HttpContext.Current.Server.MapPath("~/") + "Imagenes/" + nomImg;
                Image img = Image.GetInstance(nomImg);
                img.ScaleToFit(i, j);
                img.Alignment = Element.ALIGN_CENTER;

                celda = new PdfPCell(img);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Border = 0;
            }
            catch (Exception) { celda = new PdfPCell(); celda.Border = 0; }
            return celda;
        }
    }
}
