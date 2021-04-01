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

        public FormArticuloBusqueda(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
            this.ListaArticulos = new List<Articulo>();
        }

        public List<Articulo> GetListaArticulos(int IdListaPrecio)
        {
            this.ListaArticulos = this.controllerBusiness.articuloBusiness.GetArticulosByIdListaPrecio(IdListaPrecio);
            foreach (Articulo ar in this.ListaArticulos)
            {
                ar.Sel = false;
                DgArticuloBusq.Rows.Add(ar.Sel, ar.IdArticulo, ar.CodArticulo, ar.NombreArticulo);
            }

            this.ShowDialog();
            return ListaArticulos.Where(x => x.Sel).ToList();
        }

        private void DgArticuloBusq_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdArt = Convert.ToInt32(DgArticuloBusq.Rows[e.RowIndex].Cells["DgColIdArticulo"].Value);
            bool Sel = Convert.ToBoolean(DgArticuloBusq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            Articulo entityArt = this.ListaArticulos.FirstOrDefault(x => x.IdArticulo == IdArt);
            entityArt.Sel = Sel;
        }

        private void txtBusquedaArt_KeyUp(object sender, KeyEventArgs e)
        {
            DgArticuloBusq.Rows.Clear();

            string busqueda = txtBusquedaArt.Text.Trim().ToUpper();
            List<Articulo> ListaBusqueda = this.ListaArticulos.Where(x => x.NombreBusqueda.ToUpper().Contains(busqueda)).ToList();
            foreach (Articulo ar in ListaBusqueda)
            {
                DgArticuloBusq.Rows.Add(ar.Sel, ar.IdArticulo, ar.CodArticulo, ar.NombreArticulo);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
