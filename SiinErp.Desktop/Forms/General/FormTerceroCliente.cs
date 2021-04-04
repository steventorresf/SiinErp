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
    public partial class FormTerceroCliente : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private List<Tercero> ListaTercero;
        private Tercero entityCliente;
        private int index;
        private string ModoCl;
        private int IdCliente;

        public FormTerceroCliente(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormTerceroCliente_Load(object sender, EventArgs e)
        {
            this.NuevoCliente();
        }

        private void NuevoCliente()
        {
            this.entityCliente = new Tercero();
            this.IdCliente = 0;
            this.ModoCl = "N";

            txtCodigo.Text = this.controllerBusiness.secuenciaBusiness.GetPrefijoSecuencia(Constantes.Cliente, Cookie.IdEmpresa);
            this.ListaTercero = this.controllerBusiness.terceroBusiness.GetClientes(Cookie.IdEmpresa);
            this.index = this.ListaTercero.Count;

            this.LlenarTipoCliente();
            this.LlenarPlazoPago();
            this.LlenarMunicipios();
            this.LlenarZonas();
            this.LlenarListaPrecios();
            this.LlenarEstados();
            this.LlenarVendedor();
            this.LlenarIVA();

            txtNitCedula.Text = "";
            txtDgVerif.Text = "";
            cboTipoCliente.SelectedItem = null;
            txtNombreCliente.Text = "";
            cboPlazoPago.SelectedItem = null;
            cboMunicipio.SelectedItem = null;
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cboZona.SelectedItem = null;
            txtCorreo.Text = "";
            txtLimiteCredito.Text = "0,00";
        }

        private void LlenarTipoCliente()
        {
            cboTipoCliente.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabTipoPersona, Cookie.IdEmpresa);
            cboTipoCliente.ValueMember = "IdDetalle";
            cboTipoCliente.DisplayMember = "Descripcion";

            cboTipoCliente.SelectedItem = null;
        }

        private void LlenarPlazoPago()
        {
            cboPlazoPago.DataSource = this.controllerBusiness.plazoPagoBusiness.GetPlazosPagos(Cookie.IdEmpresa);
            cboPlazoPago.ValueMember = "IdPlazoPago";
            cboPlazoPago.DisplayMember = "Descripcion";

            cboPlazoPago.SelectedItem = null;
        }

        private void LlenarMunicipios()
        {
            cboMunicipio.DataSource = this.controllerBusiness.ciudadBusiness.GetAll();
            cboMunicipio.ValueMember = "IdCiudad";
            cboMunicipio.DisplayMember = "NombreCiudad";

            cboMunicipio.SelectedItem = null;
        }

        private void LlenarZonas()
        {
            cboZona.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabZona, Cookie.IdEmpresa);
            cboZona.ValueMember = "IdDetalle";
            cboZona.DisplayMember = "Descripcion";
        }

        private void LlenarListaPrecios()
        {
            cboListaPrecio.DataSource = this.controllerBusiness.listaPrecioBusiness.GetListaPrecios(Cookie.IdEmpresa);
            cboListaPrecio.ValueMember = "IdListaPrecio";
            cboListaPrecio.DisplayMember = "NombreLista";
        }

        private void LlenarVendedor()
        {
            cboVendedor.DataSource = this.controllerBusiness.vendedorBusiness.GetVendedoresAct(Cookie.IdEmpresa);
            cboVendedor.ValueMember = "IdVendedor";
            cboVendedor.DisplayMember = "NombreVendedor";
        }

        private void LlenarIVA()
        {
            List<TablaDetalle> ListaIVA = new List<TablaDetalle>();

            TablaDetalle entitySi = new TablaDetalle();
            entitySi.Codigo = "true";
            entitySi.Descripcion = "Si";
            ListaIVA.Add(entitySi);

            TablaDetalle entityNo = new TablaDetalle();
            entityNo.Codigo = "false";
            entityNo.Descripcion = "No";
            ListaIVA.Add(entityNo);

            cboIVA.DataSource = ListaIVA;
            cboIVA.ValueMember = "Codigo";
            cboIVA.DisplayMember = "Descripcion";
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

        private void LlenarCliente()
        {
            this.ModoCl = "E";

            this.entityCliente = this.ListaTercero[this.index];
            this.IdCliente = entityCliente.IdTercero;
            txtCodigo.Text = entityCliente.CodTercero;
            txtNitCedula.Text = entityCliente.NitCedula;
            txtDgVerif.Text = entityCliente.DgVerificacion;
            cboTipoCliente.SelectedValue = entityCliente.IdDetTipoPersona;
            txtNombreCliente.Text = entityCliente.NombreTercero;
            cboPlazoPago.SelectedValue = entityCliente.IdPlazoPago;
            cboMunicipio.SelectedValue = entityCliente.IdCiudad;
            txtDireccion.Text = entityCliente.Direccion;
            txtTelefono.Text = entityCliente.Telefono;
            txtCorreo.Text = entityCliente.EMail;
            cboZona.SelectedValue = entityCliente.IdDetZona;
            cboListaPrecio.SelectedValue = entityCliente.IdListaPrecio;
            cboVendedor.SelectedValue = entityCliente.IdVendedor;
            cboCuentaContable.SelectedValue = entityCliente.IdCuentaContable;
            cboIVA.SelectedValue = entityCliente.Iva.ToString().ToLower();
            txtLimiteCredito.Text = entityCliente.LimiteCredito.ToString("N2");
            cboEstado.SelectedValue = entityCliente.EstadoFila;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.index > 0)
            {
                this.index--;
                this.LlenarCliente();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.index < this.ListaTercero.Count - 1)
            {
                this.index++;
                this.LlenarCliente();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.NuevoCliente();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormTerceroBusqueda formTerceroBusqueda = new FormTerceroBusqueda(this.controllerBusiness);
            Tercero entity = formTerceroBusqueda.GetTerceroSeleccionado(Constantes.Cliente);
            if(entity != null)
            {
                this.index = this.ListaTercero.FindIndex(x => x.IdTercero == entity.IdTercero);
                if (this.index < 0)
                {
                    this.ListaTercero = this.controllerBusiness.terceroBusiness.GetClientes(Cookie.IdEmpresa);
                    this.index = this.ListaTercero.FindIndex(x => x.IdTercero == entity.IdTercero);
                }
                this.LlenarCliente();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string NoValido = "";
            if (txtNitCedula.Text.Trim().Equals("")) { NoValido += "Digite el NIT/Cedula.\r"; }
            if (cboTipoCliente.SelectedItem == null) { NoValido += "Seleccione el tipo de cliente.\r"; }
            if (txtNombreCliente.Text.Trim().Equals("")) { NoValido += "Digite el nombre del cliente.\r"; }
            if (cboPlazoPago.SelectedItem == null) { NoValido += "Seleccione el plazo pago.\r"; }
            if (cboMunicipio.SelectedItem == null) { NoValido += "Seleccione el municipio.\r"; }
            if (txtTelefono.Text.Trim().Equals("")) { NoValido += "Digite el teléfono.\r"; }
            if (txtDireccion.Text.Trim().Equals("")) { NoValido += "Digite la dirección.\r"; }
            if (cboZona.SelectedItem == null) { NoValido += "Seleccione la zona.\r"; }
            if (txtCorreo.Text.Trim().Equals("")) { NoValido += "Digite el correo.\r"; }
            if (cboVendedor.SelectedItem == null) { NoValido += "Seleccione el vendedor.\r"; }
            if (cboListaPrecio.SelectedItem == null) { NoValido += "Seleccione la lista de precios.\r"; }
            if (cboIVA.SelectedItem == null) { NoValido += "Seleccione si incluye IVA.\r"; }
            if (txtLimiteCredito.Text.Trim().Equals("")) { NoValido += "Digite el límite de crédito.\r"; }
            if (cboEstado.SelectedItem == null) { NoValido += "Seleccione el estado.\r"; }
            if (NoValido.Equals(""))
            {
                this.entityCliente.IdTercero = this.IdCliente;
                this.entityCliente.IdEmpresa = Cookie.IdEmpresa;
                this.entityCliente.NitCedula = txtNitCedula.Text.Trim();
                this.entityCliente.DgVerificacion = txtDgVerif.Text.Trim();
                this.entityCliente.IdDetTipoPersona = Convert.ToInt32(cboTipoCliente.SelectedValue);
                this.entityCliente.NombreTercero = txtNombreCliente.Text.Trim();
                this.entityCliente.IdPlazoPago = Convert.ToInt32(cboPlazoPago.SelectedValue);
                this.entityCliente.IdCiudad = Convert.ToInt32(cboMunicipio.SelectedValue);
                this.entityCliente.Telefono = txtTelefono.Text.Trim();
                this.entityCliente.Direccion = txtDireccion.Text.Trim();
                this.entityCliente.IdDetZona = Convert.ToInt32(cboZona.SelectedValue);
                this.entityCliente.EMail = txtCorreo.Text.Trim();
                this.entityCliente.IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);
                this.entityCliente.IdListaPrecio = Convert.ToInt32(cboListaPrecio.SelectedValue);
                this.entityCliente.Iva = Convert.ToBoolean(cboIVA.SelectedValue);
                this.entityCliente.LimiteCredito = Convert.ToDecimal(txtLimiteCredito.Text.Trim());
                this.entityCliente.EstadoFila = cboEstado.SelectedValue.ToString();
                if (cboCuentaContable.SelectedItem == null) { this.entityCliente.IdCuentaContable = null; }
                else { this.entityCliente.IdCuentaContable = Convert.ToInt32(cboCuentaContable.SelectedValue); }
                this.entityCliente.ModificadoPor = Cookie.NombreUsuario;

                switch (this.ModoCl)
                {
                    case "N":
                        this.entityCliente.CreadoPor = Cookie.NombreUsuario;
                        this.controllerBusiness.terceroBusiness.Create(this.entityCliente);
                        MessageBox.Show("¡El cliente ha sido registrado correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NuevoCliente();
                        break;
                    case "E":
                        this.controllerBusiness.terceroBusiness.UpdateCliente(this.IdCliente, this.entityCliente);
                        this.ListaTercero[this.index] = this.entityCliente;
                        MessageBox.Show("¡El cliente ha sido modificado correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else { MessageBox.Show(NoValido, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

    }
}
