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
    public partial class FormUsuario : Form
    {
        private IControllerBusiness controllerBusiness;
        private List<Usuario> ListaUsuarios;
        private List<MenuUsuario> DetalleListaMenu;
        private Usuario entityUsuario;
        private int IdUsuario;
        private string ModoUs;
        private int index;

        public FormUsuario(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            this.NuevoUsuario();
        }

        private void NuevoUsuario()
        {
            this.ModoUs = "N";
            this.ListaUsuarios = this.controllerBusiness.usuarioBusiness.GetUsuarios();
            this.entityUsuario = new Usuario();
            this.IdUsuario = 0;
            this.index = this.ListaUsuarios.Count;
            txtNombreCompleto.Text = "";
            txtNombreUsuario.Text = "";
            this.btnAgregar.Enabled = false;
            dgvDetalleMenu.Rows.Clear();
        }

        private void LlenarUsuario()
        {
            this.ModoUs = "E";
            this.entityUsuario = this.ListaUsuarios[this.index];
            this.IdUsuario = this.entityUsuario.IdUsuario;
            txtNombreCompleto.Text = this.entityUsuario.NombreCompleto;
            txtNombreUsuario.Text = this.entityUsuario.NombreUsuario;
            txtNombreUsuario.Enabled = false;
            this.btnAgregar.Enabled = true;
            dgvDetalleMenu.Rows.Clear();
            this.DetalleListaMenu = this.controllerBusiness.menuUsuarioBusiness.GetAllByIdUsuario(this.entityUsuario.IdUsuario);
            foreach (MenuUsuario m in this.DetalleListaMenu)
            {
                dgvDetalleMenu.Rows.Add(m.IdMenuUsuario, m.Menu.Descripcion);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.index > 0)
            {
                this.index--;
                this.LlenarUsuario();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.index < this.ListaUsuarios.Count - 1)
            {
                this.index++;
                this.LlenarUsuario();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.NuevoUsuario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string NombreCompleto = txtNombreCompleto.Text.Trim();
            string NombreUsuario = txtNombreUsuario.Text.Trim();
            string NoValido = "";
            if (NombreCompleto.Equals("")) { NoValido += "Digite el nombre completo.\r"; }
            if (NombreUsuario.Equals("")) { NoValido += "Digite el nombre de usuario.\r"; }
            if (NoValido.Equals(""))
            {
                this.entityUsuario.IdUsuario = this.IdUsuario;
                this.entityUsuario.NombreCompleto = NombreCompleto;
                this.entityUsuario.NombreUsuario = NombreUsuario;
                this.entityUsuario.ModificadoPor = Cookie.NombreUsuario;

                switch (this.ModoUs)
                {
                    case "N":
                        this.entityUsuario.CreadoPor = Cookie.NombreUsuario;
                        this.controllerBusiness.usuarioBusiness.Create(this.entityUsuario);
                        MessageBox.Show("¡El usuario ha sido creada correctamente.!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NuevoUsuario();
                        break;
                    case "E":
                        this.controllerBusiness.usuarioBusiness.Update(this.IdUsuario, this.entityUsuario);
                        MessageBox.Show("¡el usuario ha sido modificada correctamente.!", "¡Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ListaUsuarios[this.index] = this.entityUsuario;
                        break;
                }
            }
            else
            {
                MessageBox.Show(NoValido, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
