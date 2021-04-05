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
    public partial class FormMenuBusqueda : Form
    {
        private IControllerBusiness controllerBusiness;
        private List<Menu> ListaMenu;
        private Usuario entityUsuario;

        public FormMenuBusqueda(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        public List<Menu> GetMenuAgregar(Usuario entity)
        {
            this.entityUsuario = entity;
            this.ListaMenu = this.controllerBusiness.menuUsuarioBusiness.GetNotAllByIdUsuario(this.entityUsuario.IdUsuario);
            foreach(Menu m in this.ListaMenu)
            {
                m.Sel = false;
                dgvMenuBusqueda.Rows.Add(m.IdMenu, m.Sel, m.Descripcion);
            }
            this.ShowDialog();
            return this.ListaMenu.Where(x => x.Sel).ToList();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMenuBusqueda_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int IdMenu = Convert.ToInt32(dgvMenuBusqueda.CurrentRow.Cells["ColIdMenu"].Value);
            bool Sel = Convert.ToBoolean(dgvMenuBusqueda.CurrentCell.Value);

            Menu entity = this.ListaMenu.FirstOrDefault(x => x.IdMenu == IdMenu);
            entity.Sel = Sel;
        }
    }
}
