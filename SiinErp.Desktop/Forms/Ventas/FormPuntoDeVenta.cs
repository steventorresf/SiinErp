using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Desktop.Forms.Inventario;
using SiinErp.Model.Common;
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

        public FormPuntoDeVenta(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormPuntoDeVenta_Load(object sender, EventArgs e)
        {
            this.LlenarClientes();
            this.LlenarAlmacen();
            this.LlenarCajero();
            this.LlenarListaPrecio();
        }

        private void LlenarClientes()
        {
            cboCliente.DataSource = this.controllerBusiness.terceroBusiness.GetClientes(Cookie.IdEmpresa);
            cboCliente.ValueMember = "IdTercero";
            cboCliente.DisplayMember = "NombreTercero";
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

        private void CalcularTotales()
        {
            foreach(DataGridViewRow r in dgvDetalleFactura.Rows)
            {

            }
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
                    dgvDetalleFactura.Rows.Add(ar.IdArticulo, ar.CodArticulo, ar.NombreArticulo, 1, ar.VrVenta, 0, ar.PcIva, 0, 0);
                }
                this.CalcularTotales();
            }
        }
    }
}
