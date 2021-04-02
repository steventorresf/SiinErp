using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop.Forms.General
{
    public partial class FormTerceroBusqueda : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private List<Tercero> ListaTerceros;
        private Tercero Tercero;
        private string tipoTercero;

        public FormTerceroBusqueda(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void txtBusquedaTercero_KeyUp(object sender, KeyEventArgs e)
        {
            dgvTerceroBusqueda.Rows.Clear();

            string busqueda = txtBusquedaTercero.Text.Trim().ToUpper();
            List<Tercero> ListaBusqueda = this.ListaTerceros.Where(x => x.NombreBusqueda.ToUpper().Contains(busqueda)).ToList();
            foreach (Tercero t in ListaBusqueda)
            {
                dgvTerceroBusqueda.Rows.Add(t.IdTercero, t.NitCedula, t.NombreTercero);
            }
        }

        private void LlenarTerceros()
        {
            if (this.tipoTercero.Equals(Constantes.Cliente))
            {
                this.ListaTerceros = this.controllerBusiness.terceroBusiness.GetClientesActivos(Cookie.IdEmpresa);
            }

            if (this.tipoTercero.Equals(Constantes.Proveedor))
            {
                this.ListaTerceros = this.controllerBusiness.terceroBusiness.GetProveedoresActivos(Cookie.IdEmpresa);
            }

            if (this.tipoTercero.Equals(Constantes.Otros))
            {
                this.ListaTerceros = this.controllerBusiness.terceroBusiness.GetTercerosActivos(Cookie.IdEmpresa);
            }

            foreach(Tercero t in this.ListaTerceros)
            {
                dgvTerceroBusqueda.Rows.Add(t.IdTercero, t.NitCedula, t.NombreTercero);
            }
        }

        public Tercero GetTerceroSeleccionado(string _tipoTercero)
        {
            this.Tercero = null;
            this.tipoTercero = _tipoTercero;
            this.LlenarTerceros();
            this.ShowDialog();
            return this.Tercero;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvTerceroBusqueda.CurrentRow != null)
            {
                int idTercero = Convert.ToInt32(dgvTerceroBusqueda.CurrentRow.Cells["DgColIdTercero"].Value);
                this.Tercero = this.ListaTerceros.FirstOrDefault(x => x.IdTercero == idTercero);
            }

            this.Close();
        }

    }
}
