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
    public partial class FormCajaDialog : Form
    {
        // Size 515; 284
        // Location 12; 12

        private readonly IControllerBusiness controllerBusiness;
        private TablaDetalle entityCajero;
        private Caja entityCaja;
        private string tipo;
        private bool Refresh;

        public FormCajaDialog(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormCajaDialog_Load(object sender, EventArgs e)
        {

        }

        public bool CajaAbrirCerrar(TablaDetalle _entityCajero, Caja _entityCaja, string _tipo)
        {
            this.Refresh = false;
            this.entityCajero = _entityCajero;
            this.entityCaja = _entityCaja;
            this.tipo = _tipo;
            txtCajeroAbCe.Text = this.entityCajero.Descripcion;
            groupBox2.Visible = false;
            this.Size = new Size(515, 284);

            cboTurnoAbCe.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabTurnos, Cookie.IdEmpresa);
            cboTurnoAbCe.ValueMember = "IdDetalle";
            cboTurnoAbCe.DisplayMember = "Descripcion";

            switch (this.tipo)
            {
                case "Ab":
                    groupBox1.Text = "Abrir caja";
                    txtSaldoFinalAbCe.ReadOnly = true;
                    cboTurnoAbCe.SelectedItem = null;
                    break;
                case "Ce":
                    groupBox1.Text = "Cerrar caja";
                    txtComentarioAbCe.Text = this.entityCaja.Comentario;
                    cboTurnoAbCe.SelectedValue = this.entityCaja.IdTurno;
                    cboTurnoAbCe.Enabled = false;
                    txtSaldoInicialAbCe.Text = this.entityCaja.SaldoInicial.ToString("N2");
                    txtSaldoInicialAbCe.ReadOnly = true;
                    break;
            }

            this.ShowDialog();
            return this.Refresh;
        }

        public void CajaIngresoEgreso(TablaDetalle _entityCajero, Caja _entityCaja, string _tipo)
        {
            this.entityCajero = _entityCajero;
            this.entityCaja = _entityCaja;
            this.tipo = _tipo;
            txtCajeroInEg.Text = this.entityCajero.Descripcion;
            groupBox1.Visible = false;
            groupBox2.Location = new Point(12, 12);
            this.Size = new Size(515, 284);
            switch (this.tipo)
            {
                case "In": groupBox2.Text = "Ingreso a caja"; break;
                case "Eg": groupBox2.Text = "Egreso de caja"; break;
            }

            this.ShowDialog();
        }

        private void btnGuardarAbCe_Click(object sender, EventArgs e)
        {
            string NoValido = "";
            if (this.tipo.Equals("Ab"))
            {
                if (cboTurnoAbCe.SelectedItem == null) { NoValido += "Seleccione un turno.\r"; }
                if (txtSaldoInicialAbCe.Text.Trim() == "") { NoValido += "Digite el saldo inicial."; }
                if (NoValido == "")
                {
                    Caja entity = new Caja();
                    entity.IdDetCajero = this.entityCajero.IdDetalle;
                    entity.IdEmpresa = Cookie.IdEmpresa;
                    entity.IdTurno = Convert.ToInt32(cboTurnoAbCe.SelectedValue);
                    entity.SaldoInicial = Convert.ToDecimal(txtSaldoInicialAbCe.Text);
                    entity.Comentario = txtComentarioAbCe.Text;
                    entity.CreadoPor = Cookie.NombreUsuario;
                    entity.ModificadoPor = Cookie.NombreUsuario;
                    entity.EstadoFila = Constantes.EstadoActivo;
                    this.controllerBusiness.cajaBusiness.Create(entity);

                    MessageBox.Show("La caja ha sido abierta correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Refresh = true;
                    this.Close();
                }
                else { MessageBox.Show(NoValido, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }

            if (this.tipo.Equals("Ce"))
            {
                if (txtSaldoFinalAbCe.Text.Trim() == "") { NoValido += "Digite el saldo final."; }
                if (NoValido == "")
                {
                    this.entityCaja.Comentario = txtComentarioAbCe.Text;
                    this.entityCaja.ModificadoPor = Cookie.NombreUsuario;
                    this.entityCaja.EstadoFila = Constantes.EstadoCerrado;
                    this.controllerBusiness.cajaBusiness.Update(this.entityCaja.IdCaja, this.entityCaja);

                    MessageBox.Show("La caja ha sido cerrada correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Refresh = true;
                    this.Close();
                }
                else { MessageBox.Show(NoValido, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }

        }
    }
}
