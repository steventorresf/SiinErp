using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Desktop.Forms.Inventario;
using SiinErp.Model.Common;
using SiinErp.Model.Entities.Inventario;
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
    public partial class FormListaPrecio : Form
    {
        private IControllerBusiness controllerBusiness;
        private List<ListaPrecio> ListaPrecios;
        private List<ListaPrecioDetalle> DetalleListaPrecios;
        private ListaPrecio entityListaPrecio;
        private int IdListaPrecio;
        private string ModoLi;
        private int index;

        public FormListaPrecio(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormListaPrecio_Load(object sender, EventArgs e)
        {
            this.NuevaLista();
        }

        private void NuevaLista()
        {
            this.ModoLi = "N";
            this.ListaPrecios = this.controllerBusiness.listaPrecioBusiness.GetListaPrecios(Cookie.IdEmpresa);
            this.entityListaPrecio = new ListaPrecio();
            this.IdListaPrecio = 0;
            this.index = this.ListaPrecios.Count;
            txtNombreLista.Text = "";
            txtBusqueda.Text = "";
            txtBusqueda.Enabled = false;
            this.btnAgregar.Enabled = false;
            dgvDetalleLista.Rows.Clear();
        }

        private void LlenarListaPrecio()
        {
            this.ModoLi = "E";
            this.entityListaPrecio = this.ListaPrecios[this.index];
            this.IdListaPrecio = this.entityListaPrecio.IdListaPrecio;
            txtNombreLista.Text = this.entityListaPrecio.NombreLista;

            txtBusqueda.Text = "";
            txtBusqueda.Enabled = true;
            this.btnAgregar.Enabled = true;
            dgvDetalleLista.Rows.Clear();
            this.DetalleListaPrecios = this.controllerBusiness.listaPrecioDetalleBusiness.GetListaPreciosDetalle(this.entityListaPrecio.IdListaPrecio);
            foreach(ListaPrecioDetalle d in this.DetalleListaPrecios)
            {
                dgvDetalleLista.Rows.Add(d.IdDetalleListaPrecio, d.Articulo.CodArticulo, d.Articulo.NombreArticulo, d.VrUnitario.ToString("N2"));
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.index > 0)
            {
                this.index--;
                this.LlenarListaPrecio();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.index < this.ListaPrecios.Count - 1)
            {
                this.index++;
                this.LlenarListaPrecio();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.NuevaLista();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string NombreLista = txtNombreLista.Text.Trim();
            if (!NombreLista.Equals(""))
            {
                this.entityListaPrecio.IdListaPrecio = this.IdListaPrecio;
                this.entityListaPrecio.NombreLista = NombreLista;
                this.entityListaPrecio.ModificadoPor = Cookie.NombreUsuario;

                switch (this.ModoLi)
                {
                    case "N":
                        this.entityListaPrecio.IdEmpresa = Cookie.IdEmpresa;
                        this.entityListaPrecio.CreadoPor = Cookie.NombreUsuario;
                        this.controllerBusiness.listaPrecioBusiness.Create(this.entityListaPrecio);
                        MessageBox.Show("¡La lista de precio ha sido creada correctamente.!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NuevaLista();
                        break;
                    case "E":
                        this.controllerBusiness.listaPrecioBusiness.Update(this.IdListaPrecio, this.entityListaPrecio);
                        MessageBox.Show("¡La lista de precio ha sido modificada correctamente.!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ListaPrecios[this.index] = this.entityListaPrecio;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Digite el nombre de la lista de precios.!", "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormArticuloBusqueda formArticuloBusqueda = new FormArticuloBusqueda(this.controllerBusiness);
            List<Articulo> ListaArticulos = formArticuloBusqueda.GetListaArticulosNot(this.IdListaPrecio);
            if(ListaArticulos.Count > 0)
            {
                List<ListaPrecioDetalle> ListaDetalle = new List<ListaPrecioDetalle>();
                foreach(Articulo ar in ListaArticulos)
                {
                    ListaPrecioDetalle entityDet = new ListaPrecioDetalle();
                    entityDet.IdArticulo = ar.IdArticulo;
                    entityDet.IdListaPrecio = this.IdListaPrecio;
                    entityDet.PcDscto = 0;
                    entityDet.VrUnitario = 0;
                    entityDet.CreadoPor = Cookie.NombreUsuario;
                    entityDet.ModificadoPor = Cookie.NombreUsuario;
                    entityDet.EstadoFila = Constantes.EstadoActivo;
                    ListaDetalle.Add(entityDet);
                }

                this.controllerBusiness.listaPrecioDetalleBusiness.Creates(ListaDetalle);
                this.LlenarListaPrecio();
            }
        }

        private void dgvDetalleLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdDetalleListaPrecio = Convert.ToInt32(dgvDetalleLista.CurrentRow.Cells["ColIdDetalle"].Value);
            decimal VrUnitario = Convert.ToDecimal(dgvDetalleLista.CurrentRow.Cells["ColPrecio"].Value);
            dgvDetalleLista.CurrentRow.Cells["ColPrecio"].Value = VrUnitario.ToString("N2");

            ListaPrecioDetalle entityDet = this.DetalleListaPrecios.FirstOrDefault(x => x.IdDetalleListaPrecio == IdDetalleListaPrecio);
            entityDet.VrUnitario = VrUnitario;
            entityDet.ModificadoPor = Cookie.NombreUsuario;

            this.controllerBusiness.listaPrecioDetalleBusiness.Update(IdDetalleListaPrecio, entityDet);
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            string Busqueda = txtBusqueda.Text.Trim().ToUpper();
            List<ListaPrecioDetalle> ListaDetalle = this.DetalleListaPrecios.Where(x => x.Articulo.NombreBusqueda.ToUpper().Contains(Busqueda)).ToList();
            dgvDetalleLista.Rows.Clear();
            this.DetalleListaPrecios = this.controllerBusiness.listaPrecioDetalleBusiness.GetListaPreciosDetalle(this.entityListaPrecio.IdListaPrecio);
            foreach (ListaPrecioDetalle d in ListaDetalle)
            {
                dgvDetalleLista.Rows.Add(d.IdDetalleListaPrecio, d.Articulo.CodArticulo, d.Articulo.NombreArticulo, d.VrUnitario.ToString("N2"));
            }
        }

        private void dgvDetalleLista_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar +el articulo '" + e.Row.Cells["ColDescripcion"].Value + "' de la lista de precio?",
                                                  "¡Confirmación!",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                int IdDetalleListaPrecio = Convert.ToInt32(e.Row.Cells["ColIdDetalle"].Value);
                this.controllerBusiness.listaPrecioDetalleBusiness.Delete(IdDetalleListaPrecio);
                this.LlenarListaPrecio();
            }
        }
    }
}
