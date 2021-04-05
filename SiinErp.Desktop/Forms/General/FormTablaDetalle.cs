using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
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
    public partial class FormTablaDetalle : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private bool LlenaDetalle;

        public FormTablaDetalle(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormTablaDetalle_Load(object sender, EventArgs e)
        {
            this.LlenarTabla();
        }

        private void LlenarTabla()
        {
            this.LlenaDetalle = false;
            cboTabla.DataSource = this.controllerBusiness.tablaBusiness.GetTablasVisible();
            cboTabla.ValueMember = "IdTabla";
            cboTabla.DisplayMember = "Descripcion";
            this.LlenaDetalle = true;
            cboTabla.SelectedItem = null;
        }

        private void LlenarTablaDetalle()
        {
            dgvTablaDetalle.Rows.Clear();
            if (cboTabla.SelectedItem != null)
            {
                Tabla entity = (Tabla)cboTabla.SelectedItem;
                List<TablaDetalle> ListaDetalle = this.controllerBusiness.tablaDetalleBusiness.GetAllTablaDetalleByIdTabEmp(entity.IdTabla, Cookie.IdEmpresa);
                foreach(TablaDetalle d in ListaDetalle)
                {
                    dgvTablaDetalle.Rows.Add(d.IdDetalle, d.Codigo, d.Descripcion, d.Orden, d.EstadoFila);
                }
                
            }
        }

        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LlenaDetalle)
            {
                this.LlenarTablaDetalle();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboTabla.SelectedItem != null)
            {
                string NoValido = "";
                if (txtCodigo.Text.Trim().Equals("")) { NoValido += "Digite el codigo.\r"; }
                if (txtDescripcion.Text.Trim().Equals("")) { NoValido += "Digite la descripcion.\r"; }
                if (txtOrden.Text.Trim().Equals("")) { NoValido += "Digite el orden.\r"; }
                if (!txtEstado.Text.Trim().Equals("A") && !txtEstado.Text.Trim().Equals("I")) { NoValido += "Digite el estado (A, I).\r"; }
                if (NoValido == "")
                {
                    TablaDetalle entityDet = new TablaDetalle();
                    entityDet.IdDetalle = 0;
                    entityDet.IdTabla = Convert.ToInt32(cboTabla.SelectedValue);
                    entityDet.IdEmpresa = Cookie.IdEmpresa;
                    entityDet.Codigo = txtCodigo.Text.Trim();
                    entityDet.Descripcion = txtDescripcion.Text.Trim();
                    entityDet.Orden = Convert.ToInt16(txtOrden.Text.Trim());
                    entityDet.EstadoFila = txtEstado.Text.Trim();
                    entityDet.CreadoPor = Cookie.NombreUsuario;
                    entityDet.ModificadoPor = Cookie.NombreUsuario;

                    this.controllerBusiness.tablaDetalleBusiness.Create(entityDet);
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    txtOrden.Text = "";
                    txtEstado.Text = "";
                    this.LlenarTablaDetalle();
                }
                else { MessageBox.Show(NoValido, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        private void dgvTablaDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string Dato = e.FormattedValue.ToString().Trim();
            if (!string.IsNullOrEmpty(Dato))
            {
                bool TodoOk = false;

                TablaDetalle entityDet = new TablaDetalle();
                entityDet.IdDetalle = Convert.ToInt32(dgvTablaDetalle.CurrentRow.Cells["ColIdDetalle"].Value);
                entityDet.Orden = -1;
                entityDet.ModificadoPor = Cookie.NombreUsuario;

                if (dgvTablaDetalle.CurrentRow.Cells["ColCodigo"].ColumnIndex == e.ColumnIndex)
                {
                    entityDet.Codigo = Dato;
                    TodoOk = true;
                }

                if (dgvTablaDetalle.CurrentRow.Cells["ColDescripcion"].ColumnIndex == e.ColumnIndex)
                {
                    entityDet.Descripcion = Dato;
                    TodoOk = true;
                }

                if (dgvTablaDetalle.CurrentRow.Cells["ColOrden"].ColumnIndex == e.ColumnIndex)
                {
                    entityDet.Orden = Convert.ToInt16(Dato);
                    TodoOk = true;
                }

                if (dgvTablaDetalle.CurrentRow.Cells["ColEstado"].ColumnIndex == e.ColumnIndex)
                {
                    if (Dato.Equals("A") || Dato.Equals("I"))
                    {
                        entityDet.EstadoFila = Dato;
                        TodoOk = true;
                    }
                    else { MessageBox.Show("Digite estado (A, I).", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }

                if (TodoOk)
                {
                    this.controllerBusiness.tablaDetalleBusiness.Update(entityDet.IdDetalle, entityDet);
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    txtOrden.Text = "";
                    txtEstado.Text = "";
                }
                else { e.Cancel = true; }
            }
            else
            {
                MessageBox.Show("El dato no puede ser Nulo", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            
        }
    }
}
