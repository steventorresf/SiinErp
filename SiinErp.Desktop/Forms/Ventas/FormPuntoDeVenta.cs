using Newtonsoft.Json.Linq;
using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Desktop.Forms.General;
using SiinErp.Desktop.Forms.Inventario;
using SiinErp.Desktop.Reportes;
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

namespace SiinErp.Desktop.Forms.Ventas
{
    public partial class FormPuntoDeVenta : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private Movimiento entityMov;
        private List<MovimientoDetalle> listMovimientoDetalle;
        private List<MovimientoFormaPago> listMovimientoFormaPagos;
        private JObject data;
        private decimal VrTotalFp;
        private string ModoFact;

        public FormPuntoDeVenta(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
            this.listMovimientoDetalle = new List<MovimientoDetalle>();
            this.listMovimientoFormaPagos = new List<MovimientoFormaPago>();

            this.btnAnterior.BackgroundImage = Util.GetImage(AppSettings.IconoAnterior);
            this.btnAnterior.BackgroundImageLayout = ImageLayout.Zoom;

            this.btnSiguiente.BackgroundImage = Util.GetImage(AppSettings.IconoSiguiente);
            this.btnSiguiente.BackgroundImageLayout = ImageLayout.Zoom;

            this.btnNuevaFact.BackgroundImage = Util.GetImage(AppSettings.IconoNuevo);
            this.btnNuevaFact.BackgroundImageLayout = ImageLayout.Zoom;

            this.btnGuardar.Image = Util.GetBitmap(AppSettings.IconoGuardar);
            this.btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnGuardar.TextAlign = ContentAlignment.MiddleRight;
        }

        private void FormPuntoDeVenta_Load(object sender, EventArgs e)
        {
            this.NuevaFactura();
        }

        private void NuevaFactura()
        {
            this.ModoFact = "N";
            this.Limpiar();
            this.LlenarAlmacen();
            this.LlenarCajero();
            this.LlenarListaPrecio();
            this.LlenarFormasDePago();
            this.LlenarCuentasBanco();

            TipoDocumento entityTip = this.controllerBusiness.tipoDocumentoBusiness.GetTipoDocumento(Cookie.IdEmpresa, Constantes.TipoDocFacturaVenta);
            this.entityMov.TipoDoc = entityTip.TipoDoc;
            this.entityMov.NumDoc = entityTip.NumDoc + 1;

            txtNumeroFactura.Text = this.entityMov.NumDoc.ToString();
        }

        private void LlenarAlmacen()
        {
            cboAlmacen.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabAlmacen, Cookie.IdEmpresa);
            cboAlmacen.ValueMember = "IdDetalle";
            cboAlmacen.DisplayMember = "Descripcion";
        }

        private void LlenarCajero()
        {
            cboCajero.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabCajeros, Cookie.IdEmpresa);
            cboCajero.ValueMember = "IdDetalle";
            cboCajero.DisplayMember = "Descripcion";
        }

        private void LlenarListaPrecio()
        {
            cboListaPrecio.DataSource = this.controllerBusiness.listaPrecioBusiness.GetListaPrecios(Cookie.IdEmpresa);
            cboListaPrecio.ValueMember = "IdListaPrecio";
            cboListaPrecio.DisplayMember = "NombreLista";
        }

        private void LlenarFormasDePago()
        {
            cboFormaDePago.DataSource = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabFormasDePago, Cookie.IdEmpresa);
            cboFormaDePago.ValueMember = "IdDetalle";
            cboFormaDePago.DisplayMember = "Descripcion";

            cboFormaDePago.SelectedItem = null;
        }

        private void LlenarCuentasBanco()
        {
            List<TablaDetalle> ListaCuentaBanco = this.controllerBusiness.tablaDetalleBusiness.GetTablaEmpresaDetalleByCod(Constantes.TabCuentasBanco, Cookie.IdEmpresa);
            TablaDetalle entity = new TablaDetalle();
            entity.IdDetalle = 0;
            entity.Descripcion = "*NO APLICA*";
            ListaCuentaBanco.Insert(0, entity);

            cboCuentaBancaria.DataSource = ListaCuentaBanco;
            cboCuentaBancaria.ValueMember = "IdDetalle";
            cboCuentaBancaria.DisplayMember = "Descripcion";
        }

        private void btnTraerCliente_Click(object sender, EventArgs e)
        {
            FormTerceroBusqueda formTerceroBusqueda = new FormTerceroBusqueda(this.controllerBusiness);
            Tercero entityCli = formTerceroBusqueda.GetTerceroSeleccionado(Constantes.Cliente);
            if (entityCli != null)
            {
                this.entityMov.IdTercero = entityCli.IdTercero;
                this.entityMov.NombreTercero = entityCli.NombreTercero;
                this.entityMov.DireccionTercero = entityCli.Direccion;
                this.entityMov.TelefonoTercero = entityCli.Telefono;
                this.entityMov.IdPlazoPago = entityCli.IdPlazoPago;
                this.entityMov.PlazoPago = entityCli.PlazoPago;

                txtNitCedula.Text = entityCli.NitCedula;
                txtNombreCliente.Text = this.entityMov.NombreTercero;
                txtDireccion.Text = this.entityMov.DireccionTercero;
                txtTelefono.Text = this.entityMov.TelefonoTercero;

                txtDireccion.ReadOnly = false;
                txtTelefono.ReadOnly = false;
            }
        }

        private void btnRemoverCliente_Click(object sender, EventArgs e)
        {
            this.entityMov.IdTercero = null;
            this.entityMov.NombreTercero = null;
            this.entityMov.DireccionTercero = null;
            this.entityMov.TelefonoTercero = null;
            this.entityMov.IdPlazoPago = null;
            this.entityMov.PlazoPago = null;

            txtNitCedula.Text = "";
            txtNombreCliente.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";

            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
        }

        private void CalcularTotales()
        {
            this.entityMov.ValorBruto = 0;
            this.entityMov.ValorDscto = 0;
            this.entityMov.ValorIva = 0;
            this.entityMov.ValorNeto = 0;

            foreach(DataGridViewRow r in dgvDetalleFactura.Rows)
            {
                r.Cells["DgColVrBruto"].Value = Convert.ToDecimal(r.Cells["DgColVrUnit"].Value) * Convert.ToDecimal(r.Cells["DgColCantidad"].Value);
                r.Cells["DgColVrDscto"].Value = Convert.ToDecimal(r.Cells["DgColVrBruto"].Value) * Convert.ToDecimal(r.Cells["DgColPcDscto"].Value) / 100;

                bool IncluyeIVA = Convert.ToBoolean(r.Cells["DgColIncluyeIVA"].Value);
                if (IncluyeIVA)
                {
                    decimal ValorSinIVA = (Convert.ToDecimal(r.Cells["DgColVrBruto"].Value) - Convert.ToDecimal(r.Cells["DgColVrDscto"].Value) - ((Convert.ToDecimal(r.Cells["DgColPcIVA"].Value) / 100) + 1));
                    r.Cells["DgColVrIVA"].Value = Convert.ToDecimal(r.Cells["DgColVrBruto"].Value) - Convert.ToDecimal(r.Cells["DgColVrDscto"].Value) - ValorSinIVA;
                    r.Cells["DgColVrNeto"].Value = Convert.ToDecimal(r.Cells["DgColVrBruto"].Value) - Convert.ToDecimal(r.Cells["DgColVrDscto"].Value);
                }
                else
                {
                    r.Cells["DgColVrIVA"].Value = (Convert.ToDecimal(r.Cells["DgColVrBruto"].Value) - Convert.ToDecimal(r.Cells["DgColVrDscto"].Value)) * Convert.ToDecimal(r.Cells["DgColPcIVA"].Value) / 100;
                    r.Cells["DgColVrNeto"].Value = Convert.ToDecimal(r.Cells["DgColVrBruto"].Value) - Convert.ToDecimal(r.Cells["DgColVrDscto"].Value) + Convert.ToDecimal(r.Cells["DgColVrIVA"].Value);
                }

                this.entityMov.ValorBruto += Convert.ToDecimal(r.Cells["DgColVrBruto"].Value);
                this.entityMov.ValorDscto += Convert.ToDecimal(r.Cells["DgColVrDscto"].Value);
                this.entityMov.ValorIva += Convert.ToDecimal(r.Cells["DgColVrIVA"].Value);
                this.entityMov.ValorNeto += Convert.ToDecimal(r.Cells["DgColVrNeto"].Value);
            }

            txtVrBruto.Text = this.entityMov.ValorBruto.ToString("N2");
            txtVrDscto.Text = this.entityMov.ValorDscto.ToString("N2");
            txtVrIVA.Text = this.entityMov.ValorIva.ToString("N2");
            txtVrNeto.Text = this.entityMov.ValorNeto.ToString("N2");
        }

        private void CalcularTotalFp()
        {
            this.VrTotalFp = 0;
            foreach(DataGridViewRow r in dgvFormasDePago.Rows)
            {
                decimal ValorFp = Convert.ToDecimal(r.Cells["DgColValorFp"].Value);
                r.Cells["DgColValorFp"].Value = ValorFp;
                this.VrTotalFp += ValorFp;
            }
            txtTotalFp.Text = this.VrTotalFp.ToString("N2");
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if(cboListaPrecio.SelectedValue != null)
            {
                int IdListaPrecio = int.Parse(cboListaPrecio.SelectedValue.ToString());
                FormArticuloBusqueda formArticuloBusqueda = new FormArticuloBusqueda(this.controllerBusiness);
                List<Articulo> ListaArticulos = formArticuloBusqueda.GetListaArticulos(IdListaPrecio);
                foreach(Articulo ar in ListaArticulos)
                {
                    dgvDetalleFactura.Rows.Add(0, ar.IdArticulo, ar.CodArticulo, ar.NombreArticulo, 1, ar.VrCosto, ar.VrVenta, 0, ar.IncluyeIva, ar.PcIva, 0, 0);
                }
                this.CalcularTotales();
            }
        }

        private void dgvDetalleFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalleFactura.CurrentRow.Cells["DgColVrUnit"].Value = Convert.ToDecimal(dgvDetalleFactura.CurrentRow.Cells["DgColVrUnit"].Value);
            dgvDetalleFactura.CurrentRow.Cells["DgColCantidad"].Value = Convert.ToDecimal(dgvDetalleFactura.CurrentRow.Cells["DgColCantidad"].Value);
            this.CalcularTotales();
        }

        private void dgvDetalleFactura_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalcularTotales();
        }

        private void btnAgregrFp_Click(object sender, EventArgs e)
        {
            if (cboFormaDePago.SelectedItem != null && cboCuentaBancaria.SelectedItem != null && !string.IsNullOrEmpty(txtValor.Text))
            {
                TablaDetalle entityFp = (TablaDetalle)cboFormaDePago.SelectedItem;
                TablaDetalle entityCb = (TablaDetalle)cboCuentaBancaria.SelectedItem;

                dgvFormasDePago.Rows.Add(0, entityFp.IdDetalle, entityFp.Descripcion, entityCb.IdDetalle, entityCb.Descripcion, txtValor.Text);

                cboFormaDePago.SelectedItem = null;
                cboCuentaBancaria.SelectedValue = 0;
                txtValor.Text = "";

                this.CalcularTotalFp();
            }
        }

        private void dgvFormasDePago_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularTotalFp();
        }

        private void dgvFormasDePago_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalcularTotalFp();
        }




        private bool ValidarNuevo()
        {
            bool Resp = false;
            if (this.entityMov.ValorNeto == this.VrTotalFp)
            {
                bool Val = ValidarCredito();
                if (Val)
                {
                    string NoValido = "";
                    if (cboAlmacen.SelectedItem == null) { NoValido += "Seleccione un almacen.\r"; }
                    if (cboCajero.SelectedItem == null) { NoValido += "Seleccione un cajero.\r"; }
                    if (string.IsNullOrEmpty(NoValido))
                    {
                        this.entityMov.IdDetAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
                        this.entityMov.IdDetCajero = Convert.ToInt32(cboCajero.SelectedValue);
                        Resp = true;
                    }
                }
                else { MessageBox.Show("Una factura sin cliente no puede tener una forma de pago A CREDITO.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("El valor neto de la factura no coincide con el valor total pagado.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            return Resp;
        }

        private bool ValidarEdicion()
        {
            bool Resp = false;
            if (this.entityMov.IdDetCajero != null)
            {
                if (this.entityMov.ValorNeto == this.VrTotalFp)
                {
                    bool Val = ValidarCredito();
                    if (Val)
                    {
                        Resp = true;
                    }
                    else { MessageBox.Show("Una factura sin cliente no puede tener una forma de pago A CREDITO.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else { MessageBox.Show("El valor neto de la factura no coincide con el valor total pagado.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { Resp = true; }

            return Resp;
        }


        private bool ValidarCredito()
        {
            bool Resp = true;
            if (this.entityMov.IdTercero == null)
            {
                foreach (DataGridViewRow r in dgvFormasDePago.Rows)
                {
                    if (r.Cells["DgColFormaPago"].Value.Equals("A CREDITO"))
                    {
                        Resp = false;
                        break;
                    }
                }
            }
            return Resp;
        }

        private void LlenarDataObject()
        {
            this.entityMov.DireccionTercero = txtDireccion.Text;
            this.entityMov.TelefonoTercero = txtTelefono.Text;
            this.entityMov.FechaDoc = dtpFecha.Value;
            this.entityMov.IdDetAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
            if (cboCajero.SelectedItem != null)
            {
                this.entityMov.IdDetCajero = Convert.ToInt32(cboCajero.SelectedValue);
            }

            this.listMovimientoDetalle.Clear();
            foreach(DataGridViewRow r in dgvDetalleFactura.Rows)
            {
                MovimientoDetalle entityDet = new MovimientoDetalle();
                entityDet.IdDetalleMovimiento = Convert.ToInt32(r.Cells["DgColIdDetalleMov"].Value);
                entityDet.IdArticulo = Convert.ToInt32(r.Cells["DgColIdArticulo"].Value);
                entityDet.Cantidad = Convert.ToInt32(r.Cells["DgColCantidad"].Value);
                entityDet.VrUnitario = Convert.ToInt32(r.Cells["DgColVrUnit"].Value);
                entityDet.VrCosto = Convert.ToInt32(r.Cells["DgColVrCosto"].Value);
                entityDet.PcDscto = Convert.ToInt32(r.Cells["DgColPcDscto"].Value);
                entityDet.PcIva = Convert.ToInt32(r.Cells["DgColPcIVA"].Value);
                entityDet.VrBruto = Convert.ToInt32(r.Cells["DgColVrBruto"].Value);
                entityDet.VrNeto = Convert.ToInt32(r.Cells["DgColVrNeto"].Value);
                entityDet.CreadoPor = Cookie.NombreUsuario;
                entityDet.ModificadoPor = Cookie.NombreUsuario;
                entityDet.EstadoFila = Constantes.EstadoActivo;

                this.listMovimientoDetalle.Add(entityDet);
            }

            this.listMovimientoFormaPagos.Clear();
            foreach(DataGridViewRow r in dgvFormasDePago.Rows)
            {
                MovimientoFormaPago entityFp = new MovimientoFormaPago();
                entityFp.IdMovFormaDePago = Convert.ToInt32(r.Cells["DgColIdMovFp"].Value);
                entityFp.IdDetFormaDePago = Convert.ToInt32(r.Cells["DgColIdDetFormaPago"].Value);
                entityFp.IdDetCuenta = Convert.ToInt32(r.Cells["DgColIdDetCuenta"].Value);
                entityFp.Descripcion = r.Cells["DgColFormaPago"].Value.ToString();
                entityFp.DescripcionCuenta = r.Cells["DgColCuentaBancaria"].Value.ToString();
                entityFp.Valor = Convert.ToDecimal(r.Cells["DgColValorFp"].Value.ToString());
                entityFp.CreadoPor = Cookie.NombreUsuario;
                entityFp.ModificadoPor = Cookie.NombreUsuario;
                entityFp.EstadoFila = Constantes.EstadoActivo;

                this.listMovimientoFormaPagos.Add(entityFp);
            }

            data = new JObject();
            data.Add("entityMov", JObject.FromObject(this.entityMov));
            data.Add("listDetalleMov", JArray.FromObject(this.listMovimientoDetalle));
            data.Add("listDetallePag", JArray.FromObject(this.listMovimientoFormaPagos));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleFactura.Rows.Count > 0)
            {
                bool Resp = false;
                if (this.ModoFact.Equals("N"))
                {
                    Resp = this.ValidarNuevo();
                    if (Resp)
                    {
                        this.entityMov.IdCaja = this.controllerBusiness.cajaBusiness.GetIdCajaActiva(Convert.ToInt32(this.entityMov.IdDetCajero));
                        if(this.entityMov.IdCaja > 0)
                        {
                            this.LlenarDataObject();
                            int IdMov = this.controllerBusiness.movimientoBusiness.CreateByPuntoDeVenta(data);
                            if(IdMov > 0)
                            {
                                MessageBox.Show("La factura ha sido registrada correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.NuevaFactura();
                            }
                            else { MessageBox.Show("Ha ocurrido un error inesperado.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else { MessageBox.Show("La caja no se encuentra abierta.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                }

                if (this.ModoFact.Equals("E"))
                {
                    Resp = this.ValidarEdicion();
                    if (Resp)
                    {
                        this.LlenarDataObject();
                        int IdMov = this.controllerBusiness.movimientoBusiness.UpdateByPuntoDeVenta(data);
                        if (IdMov > 0)
                        {
                            MessageBox.Show("La factura ha sido actualizada correctamente.", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.NuevaFactura();
                        }
                    }
                }
            }
        }

        private void Limpiar()
        {
            this.entityMov = new Movimiento();
            this.entityMov.IdEmpresa = Cookie.IdEmpresa;
            this.entityMov.CreadoPor = Cookie.NombreUsuario;
            this.entityMov.ModificadoPor = Cookie.NombreUsuario;
            this.entityMov.EstadoFila = Constantes.EstadoActivo;

            this.txtNitCedula.Text = "";
            this.txtNombreCliente.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.dtpFecha.Value = DateTime.Now;
            this.dgvDetalleFactura.Rows.Clear();
            this.txtVrBruto.Text = "";
            this.txtVrDscto.Text = "";
            this.txtVrIVA.Text = "";
            this.txtVrNeto.Text = "";
            this.dgvFormasDePago.Rows.Clear();
            this.cboFormaDePago.SelectedItem = null;
            this.cboCuentaBancaria.SelectedItem = null;
            this.txtValor.Text = "";
            this.txtTotalFp.Text = "";
        }

        private void btnNuevaFact_Click(object sender, EventArgs e)
        {
            this.NuevaFactura();
        }


        private void LlenarFactura(int numDoc)
        {
            txtNumeroFactura.Text = numDoc.ToString();
            this.Limpiar();

            JObject data = new JObject();
            data.Add("idEmpresa", Cookie.IdEmpresa);
            data.Add("tipoDoc", Constantes.TipoDocFacturaVenta);
            data.Add("numDoc", numDoc);

            this.entityMov = this.controllerBusiness.movimientoBusiness.GetByDocumento(data);
            if (this.entityMov != null)
            {
                this.ModoFact = "E";
                if (this.entityMov.IdTercero > 0)
                {
                    txtNitCedula.Text = this.entityMov.NitCedula;
                    txtNombreCliente.Text = this.entityMov.NombreTercero;
                    txtDireccion.Text = this.entityMov.DireccionTercero;
                    txtTelefono.Text = this.entityMov.TelefonoTercero;
                    dtpFecha.Value = this.entityMov.FechaDoc;
                    cboAlmacen.SelectedValue = this.entityMov.IdDetAlmacen;

                    if (this.entityMov.IdDetCajero > 0)
                    {
                        cboCajero.SelectedValue = this.entityMov.IdDetCajero;
                    }
                    if (this.entityMov.IdListaPrecio > 0)
                    {
                        cboListaPrecio.SelectedValue = this.entityMov.IdListaPrecio;
                    }
                }

                foreach (MovimientoDetalle md in this.entityMov.ListaDetalle)
                {
                    dgvDetalleFactura.Rows.Add(md.IdDetalleMovimiento, md.IdArticulo, md.CodArticulo, md.NombreArticulo, md.Cantidad, md.VrCosto, md.VrUnitario, 0, md.Articulo.IncluyeIva, md.PcIva, 0, 0);
                }
                this.CalcularTotales();

                foreach (MovimientoFormaPago mf in this.entityMov.ListaFormaPago)
                {
                    dgvFormasDePago.Rows.Add(mf.IdMovFormaDePago, mf.IdDetFormaDePago, mf.Descripcion, mf.IdDetCuenta, mf.DescripcionCuenta, mf.Valor);
                }
                this.CalcularTotalFp();
            }
            else
            {
                this.ModoFact = "N";
                MessageBox.Show("El documento no existe.", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int numDoc = Convert.ToInt32(txtNumeroFactura.Text) - 1;
            this.LlenarFactura(numDoc);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int numDoc = Convert.ToInt32(txtNumeroFactura.Text) + 1;
            this.LlenarFactura(numDoc);
        }

        private void btnImprimirFact_Click(object sender, EventArgs e)
        {
            FormReporte formReporte = new FormReporte(this.controllerBusiness);
            formReporte.RptNumeroFactura(1);
        }
    }
}
