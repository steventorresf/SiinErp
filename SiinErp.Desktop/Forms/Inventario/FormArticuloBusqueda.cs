using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
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
    public partial class FormArticuloBusqueda : Form
    {
        private readonly IControllerBusiness controllerBusiness;
        private List<Articulo> ListaArticulos;
        private Articulo Articulo;

        public FormArticuloBusqueda(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
            this.ListaArticulos = new List<Articulo>();
        }

        private void LlenarArticulo(int IdListaPrecio)
        {
            if(IdListaPrecio > 0)
            {
                this.ListaArticulos = this.controllerBusiness.articuloBusiness.GetArticulosByIdListaPrecio(IdListaPrecio);
            }
            else
            {
                this.ListaArticulos = this.controllerBusiness.articuloBusiness.GetArticulos(Cookie.IdEmpresa);
            }

            foreach (Articulo ar in this.ListaArticulos)
            {
                ar.Sel = false;
                dgvArticuloBusq.Rows.Add(ar.Sel, ar.IdArticulo, ar.CodArticulo, ar.NombreArticulo);
            }
        }

        public List<Articulo> GetListaArticulos(int IdListaPrecio)
        {
            this.LlenarArticulo(IdListaPrecio);
            this.btnAceptar.Visible = false;
            this.ShowDialog();
            return ListaArticulos.Where(x => x.Sel).ToList();
        }

        private void DgArticuloBusq_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdArt = Convert.ToInt32(dgvArticuloBusq.Rows[e.RowIndex].Cells["DgColIdArticulo"].Value);
            bool Sel = Convert.ToBoolean(dgvArticuloBusq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            Articulo entityArt = this.ListaArticulos.FirstOrDefault(x => x.IdArticulo == IdArt);
            entityArt.Sel = Sel;
        }

        private void txtBusquedaArt_KeyUp(object sender, KeyEventArgs e)
        {
            dgvArticuloBusq.Rows.Clear();

            string busqueda = txtBusquedaArt.Text.Trim().ToUpper();
            List<Articulo> ListaBusqueda = this.ListaArticulos.Where(x => x.NombreBusqueda.ToUpper().Contains(busqueda)).ToList();
            foreach (Articulo ar in ListaBusqueda)
            {
                dgvArticuloBusq.Rows.Add(ar.Sel, ar.IdArticulo, ar.CodArticulo, ar.NombreArticulo);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Articulo GetArticuloSeleccionado()
        {
            this.Articulo = null;
            this.LlenarArticulo(-1);
            this.DgColSel.Visible = false;
            this.btnAgregar.Visible = false;
            this.btnAceptar.Location = this.btnAgregar.Location;
            this.ShowDialog();
            return this.Articulo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvArticuloBusq.CurrentRow != null)
            {
                int idArticulo = Convert.ToInt32(dgvArticuloBusq.CurrentRow.Cells["DgColIdArticulo"].Value);
                this.Articulo = this.ListaArticulos.FirstOrDefault(x => x.IdArticulo == idArticulo);
            }

            this.Close();
        }
    }
}
