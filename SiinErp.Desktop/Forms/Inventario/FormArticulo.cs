using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.General;
using SiinErp.Model.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiinErp.Desktop.Forms.Inventario
{
    public partial class FormArticulo : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private List<Articulo> ListaArticulo;
        private Articulo entityArticulo;
        private int index;
        private string ModoAr;
        private int IdArticulo;

        public FormArticulo(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormArticulo_Load(object sender, EventArgs e)
        {
            this.NuevoArticulo();
        }

        private void NuevoArticulo()
        {
            this.entityArticulo = new Articulo();
            this.IdArticulo = 0;
            this.ModoAr = "N";

            txtCodigo.Text = this.controllerBusiness.secuenciaBusiness.GetPrefijoSecuencia(Constantes.Cliente, Cookie.IdEmpresa);
            this.ListaArticulo = this.controllerBusiness.articuloBusiness.GetArticulos(Cookie.IdEmpresa);
            this.index = this.ListaArticulo.Count;

            this.LlenarUnidadMedida();
            this.LlenarTipoArticulo();
            this.LlenarEsLinea();
            this.LlenarIncluyeIVA();
            this.LlenarAfectaInv();
            this.LlenarEstados();

            txtCodigo.Text = "";
            txtReferencia.Text = "";
            txtNombreArticulo.Text = "";
            cboTipoArticulo.SelectedItem = null;
            txtPeso.Text = "0,00";
            txtStockMin.Text = "0";
            txtStockMax.Text = "0";
            txtIVA.Text = "";
            txtCosto.Text = "";
            txtVenta.Text = "";
        }

        private void LlenarUnidadMedida()
        {
            cboUnidadMed.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabUnidadMed, Cookie.IdEmpresa);
            cboUnidadMed.ValueMember = "IdDetalle";
            cboUnidadMed.DisplayMember = "Descripcion";
        }

        private void LlenarTipoArticulo()
        {
            cboTipoArticulo.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabTipoArticulo, Cookie.IdEmpresa);
            cboTipoArticulo.ValueMember = "IdDetalle";
            cboTipoArticulo.DisplayMember = "Descripcion";
        }

        private void LlenarEsLinea()
        {
            List<TablaDetalle> ListaSiNo = new List<TablaDetalle>();

            TablaDetalle entityNo = new TablaDetalle();
            entityNo.Codigo = "false";
            entityNo.Descripcion = "No";
            ListaSiNo.Add(entityNo);

            TablaDetalle entitySi = new TablaDetalle();
            entitySi.Codigo = "true";
            entitySi.Descripcion = "Si";
            ListaSiNo.Add(entitySi);

            cboEsLinea.DataSource = ListaSiNo;
            cboEsLinea.ValueMember = "Codigo";
            cboEsLinea.DisplayMember = "Descripcion";
        }

        private void LlenarIncluyeIVA()
        {
            List<TablaDetalle> ListaSiNo = new List<TablaDetalle>();

            TablaDetalle entitySi = new TablaDetalle();
            entitySi.Codigo = "true";
            entitySi.Descripcion = "Si";
            ListaSiNo.Add(entitySi);

            TablaDetalle entityNo = new TablaDetalle();
            entityNo.Codigo = "false";
            entityNo.Descripcion = "No";
            ListaSiNo.Add(entityNo);

            cboIVA.DataSource = ListaSiNo;
            cboIVA.ValueMember = "Codigo";
            cboIVA.DisplayMember = "Descripcion";
        }

        private void LlenarAfectaInv()
        {
            List<TablaDetalle> ListaSiNo = new List<TablaDetalle>();

            TablaDetalle entitySi = new TablaDetalle();
            entitySi.Codigo = "true";
            entitySi.Descripcion = "Si";
            ListaSiNo.Add(entitySi);

            TablaDetalle entityNo = new TablaDetalle();
            entityNo.Codigo = "false";
            entityNo.Descripcion = "No";
            ListaSiNo.Add(entityNo);

            cboAfectaInv.DataSource = ListaSiNo;
            cboAfectaInv.ValueMember = "Codigo";
            cboAfectaInv.DisplayMember = "Descripcion";
        }

        private void LlenarEstados()
        {
            List<TablaDetalle> ListaEstados = new List<TablaDetalle>();

            TablaDetalle entityAc = new TablaDetalle();
            entityAc.Codigo = "A";
            entityAc.Descripcion = "ACTIVO";
            ListaEstados.Add(entityAc);

            TablaDetalle entityIn = new TablaDetalle();
            entityIn.Codigo = "I";
            entityIn.Descripcion = "INACTIVO";
            ListaEstados.Add(entityIn);

            cboEstado.DataSource = ListaEstados;
            cboEstado.ValueMember = "Codigo";
            cboEstado.DisplayMember = "Descripcion";
        }

        private void LlenarArticulo()
        {
            this.ModoAr = "E";
            this.entityArticulo = this.ListaArticulo[this.index];
            this.IdArticulo = this.entityArticulo.IdArticulo;
            txtCodigo.Text = this.entityArticulo.CodArticulo;
            txtReferencia.Text = this.entityArticulo.Referencia;
            txtNombreArticulo.Text = this.entityArticulo.NombreArticulo;
            cboUnidadMed.SelectedValue = this.entityArticulo.IdDetUnidadMed;
            cboTipoArticulo.SelectedValue = this.entityArticulo.IdDetTipoArticulo;
            txtPeso.Text = this.entityArticulo.Peso.ToString();
            cboEsLinea.SelectedValue = this.entityArticulo.EsLinea.ToString().ToLower();
            txtStockMin.Text = this.entityArticulo.StkMin.ToString();
            txtStockMax.Text = this.entityArticulo.StkMax.ToString();
            cboIVA.SelectedValue = this.entityArticulo.IncluyeIva.ToString().ToLower();
            txtIVA.Text = this.entityArticulo.PcIva.ToString("N2");
            txtCosto.Text = this.entityArticulo.VrCosto.ToString("N2");
            txtVenta.Text = this.entityArticulo.VrVenta.ToString("N2");
            cboAfectaInv.SelectedValue = this.entityArticulo.AfectaInventario.ToString().ToLower();
            cboEstado.SelectedValue = this.entityArticulo.EstadoFila;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.index > 0)
            {
                this.index--;
                this.LlenarArticulo();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.index < this.ListaArticulo.Count - 1)
            {
                this.index++;
                this.LlenarArticulo();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormArticuloBusqueda formArticuloBusqueda = new FormArticuloBusqueda(this.controllerBusiness);
            Articulo entity = formArticuloBusqueda.GetArticuloSeleccionado();
            if (entity != null)
            {
                this.index = this.ListaArticulo.FindIndex(x => x.IdArticulo == entity.IdArticulo);
                if (this.index < 0)
                {
                    this.ListaArticulo = this.controllerBusiness.articuloBusiness.GetArticulos(Cookie.IdEmpresa);
                    this.index = this.ListaArticulo.FindIndex(x => x.IdArticulo == entity.IdArticulo);
                }
                this.LlenarArticulo();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.NuevoArticulo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string NoValido = "";
            if (txtCodigo.Text.Trim().Equals("")) { NoValido += "Digite el código.\r"; }
            if (txtReferencia.Text.Trim().Equals("")) { NoValido += "Digite la referencia.\r"; }
            if (txtNombreArticulo.Text.Trim().Equals("")) { NoValido += "Digite el nombre del articulo.\r"; }
            if (cboUnidadMed.SelectedItem == null) { NoValido += "Seleccione una unidad de medida.\r"; }            
            if (cboTipoArticulo.SelectedItem == null) { NoValido += "Seleccione el tipo de articulo.\r"; }
            if (txtPeso.Text.Trim().Equals("")) { NoValido += "Digite el peso.\r"; }
            if (cboEsLinea.SelectedItem == null) { NoValido += "Seleccione si es linea o no.\r"; }
            if (txtStockMin.Text.Trim().Equals("")) { NoValido += "Digite el stock mínimo.\r"; }
            if (txtStockMax.Text.Trim().Equals("")) { NoValido += "Digite el stock máximo.\r"; }
            if (cboIVA.SelectedItem == null) { NoValido += "Seleccione si el IVA está o no incluido.\r"; }
            if (txtIVA.Text.Trim().Equals("")) { NoValido += "Digite el porcentaje del IVA.\r"; }
            if (txtCosto.Text.Trim().Equals("")) { NoValido += "Digite el valor del costo.\r"; }
            if (txtVenta.Text.Trim().Equals("")) { NoValido += "Digite el valor de venta.\r"; }
            if (cboAfectaInv.SelectedItem == null) { NoValido += "Seleccione si afecta o no el inventario.\r"; }
            if (cboEstado.SelectedItem == null) { NoValido += "Seleccione el estado.\r"; }
            if (NoValido.Equals(""))
            {
                this.entityArticulo.IdArticulo = this.IdArticulo;
                this.entityArticulo.IdEmpresa = Cookie.IdEmpresa;
                this.entityArticulo.CodArticulo = txtCodigo.Text.Trim();
                this.entityArticulo.Referencia = txtReferencia.Text.Trim();
                this.entityArticulo.NombreArticulo = txtNombreArticulo.Text.Trim();
                this.entityArticulo.IdDetUnidadMed = Convert.ToInt32(cboUnidadMed.SelectedValue);
                this.entityArticulo.IdDetTipoArticulo = Convert.ToInt32(cboTipoArticulo.SelectedValue);
                this.entityArticulo.Peso = Convert.ToDecimal(txtPeso.Text.Trim());
                this.entityArticulo.EsLinea = Convert.ToBoolean(cboEsLinea.SelectedValue);
                this.entityArticulo.StkMin = Convert.ToDecimal(txtStockMin.Text.Trim());
                this.entityArticulo.StkMax = Convert.ToDecimal(txtStockMax.Text.Trim());
                this.entityArticulo.IncluyeIva = Convert.ToBoolean(cboIVA.SelectedValue);
                this.entityArticulo.PcIva = Convert.ToDecimal(txtIVA.Text.Trim());
                this.entityArticulo.VrCosto = Convert.ToDecimal(txtCosto.Text.Trim());
                this.entityArticulo.VrVenta = Convert.ToDecimal(txtVenta.Text.Trim());
                this.entityArticulo.AfectaInventario = Convert.ToBoolean(cboAfectaInv.SelectedValue);
                this.entityArticulo.EstadoFila = cboEstado.SelectedValue.ToString();
                this.entityArticulo.ModificadoPor = Cookie.NombreUsuario;

                switch (this.ModoAr)
                {
                    case "N":
                        this.entityArticulo.CreadoPor = Cookie.NombreUsuario;
                        this.controllerBusiness.articuloBusiness.Create(this.entityArticulo);
                        MessageBox.Show("¡El articulo ha sido registrado correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NuevoArticulo();
                        break;
                    case "E":
                        this.controllerBusiness.articuloBusiness.Update(this.IdArticulo, this.entityArticulo);
                        this.ListaArticulo[this.index] = this.entityArticulo;
                        MessageBox.Show("¡El articulo ha sido modificado correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else { MessageBox.Show(NoValido, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
    }
}
