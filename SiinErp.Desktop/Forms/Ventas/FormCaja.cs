using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop.Forms.Ventas
{
    public partial class FormCaja : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private List<Caja> ListaCajas;
        private bool TraerCajas;

        public FormCaja(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
            this.ListaCajas = new List<Caja>();
            this.TraerCajas = false;
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            this.LlenarCajeros();
        }

        private void LlenarCajeros()
        {
            cboCajero.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabCajeros, Cookie.IdEmpresa);
            cboCajero.ValueMember = "IdDetalle";
            cboCajero.DisplayMember = "Descripcion";
            this.TraerCajas = true;
            cboCajero_SelectedIndexChanged(null, null);
        }

        private void cboCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TraerCajas)
            {
                dgvCaja.Rows.Clear();
                this.ListaCajas.Clear();

                if (cboCajero.SelectedItem != null)
                {
                    int IdDetCajero = Convert.ToInt32(cboCajero.SelectedValue);
                    this.ListaCajas = this.controllerBusiness.cajaBusiness.GetCajasById(IdDetCajero);
                    foreach (Caja c in ListaCajas)
                    {
                        dgvCaja.Rows.Add(c.IdCaja, c.sFechaDoc, c.NombreTurno, c.CreadoPor, c.EstadoFila, c.NombreEstado);
                    }
                }
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (cboCajero.SelectedItem != null)
            {
                Caja entity = this.ListaCajas.FirstOrDefault(x => x.EstadoFila.Equals(Constantes.EstadoActivo));
                if (entity == null)
                {
                    TablaDetalle entityCajero = (TablaDetalle)cboCajero.SelectedItem;
                    FormCajaDialog formCajaDialog = new FormCajaDialog(this.controllerBusiness);
                    bool Refresh = formCajaDialog.CajaAbrirCerrar(entityCajero, null, "Ab");
                    if (Refresh)
                    {
                        cboCajero_SelectedIndexChanged(null, null);
                    }
                }
                else { MessageBox.Show("La caja ya se encuentra abierta.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("Seleccione un cajero.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgvCaja.CurrentRow;
            if (r != null)
            {
                if (!r.Cells["ColEstadoFila"].Value.Equals(Constantes.EstadoCerrado))
                {
                    Caja entityCaja = this.ListaCajas.FirstOrDefault(x => x.IdCaja == Convert.ToInt32(r.Cells["ColIdCaja"].Value));
                    TablaDetalle entityCajero = (TablaDetalle)cboCajero.SelectedItem;
                    FormCajaDialog formCajaDialog = new FormCajaDialog(this.controllerBusiness);
                    bool Refresh = formCajaDialog.CajaAbrirCerrar(entityCajero, entityCaja, "Ce");
                    if (Refresh)
                    {
                        cboCajero_SelectedIndexChanged(null, null);
                    }
                }
                else { MessageBox.Show("La caja ya se encuentra cerrada.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("Seleccione un registro.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgvCaja.CurrentRow;
            if (r != null)
            {

            }
            else { MessageBox.Show("Seleccione un registro.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgvCaja.CurrentRow;
            if (r != null)
            {
                if (cboCajero.SelectedItem != null)
                {
                    Caja entityCaja = this.ListaCajas.FirstOrDefault(x => x.IdCaja == Convert.ToInt32(r.Cells["ColIdCaja"].Value));
                    TablaDetalle entityCajero = (TablaDetalle)cboCajero.SelectedItem;
                    FormCajaDialog formCajaDialog = new FormCajaDialog(this.controllerBusiness);
                    formCajaDialog.CajaIngresoEgreso(entityCajero, entityCaja, "In");
                }
            }
            else { MessageBox.Show("Seleccione un registro.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dgvCaja.CurrentRow;
            if (r != null)
            {
                if (cboCajero.SelectedItem != null)
                {
                    Caja entityCaja = this.ListaCajas.FirstOrDefault(x => x.IdCaja == Convert.ToInt32(r.Cells["ColIdCaja"].Value));
                    TablaDetalle entityCajero = (TablaDetalle)cboCajero.SelectedItem;
                    FormCajaDialog formCajaDialog = new FormCajaDialog(this.controllerBusiness);
                    formCajaDialog.CajaIngresoEgreso(entityCajero, entityCaja, "Eg");
                }
            }
            else { MessageBox.Show("Seleccione un registro.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

    }
}
