using Microsoft.Extensions.DependencyInjection;
using SiinErp.Desktop.Controllers;
using SiinErp.Desktop.Forms.Ventas;
using SiinErp.Model.Abstract.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop
{
    public partial class FormHome : Form
    {
        public readonly IControllerBusiness controllerBusiness;

        public FormHome(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin(this.controllerBusiness);
            string Respuesta = form.IniciarSesion();
            if (Respuesta.Equals("TodoOkey"))
            {
                
            }
        }

        private void toolStripPuntoDeVenta_Click(object sender, EventArgs e)
        {
            FormPuntoDeVenta formPuntoDeVenta = new FormPuntoDeVenta(this.controllerBusiness);
            //formPuntoDeVenta.ShowDialog();
            this.IsMdiContainer = true;
            formPuntoDeVenta.MdiParent = this;
            formPuntoDeVenta.Show();
        }

        private void toolStripCajas_Click(object sender, EventArgs e)
        {
            FormCaja formCaja = new FormCaja(this.controllerBusiness);
            //formPuntoDeVenta.ShowDialog();
            this.IsMdiContainer = true;
            formCaja.MdiParent = this;
            formCaja.Show();
        }

    }
}
