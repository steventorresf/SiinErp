using SiinErp.Desktop.Forms.Ventas;
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
        public FormHome()
        {
            InitializeComponent();
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPuntoDeVenta form = new FormPuntoDeVenta();
            form.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes();
            form.ShowDialog();
        }
    }
}
