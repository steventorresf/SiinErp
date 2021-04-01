using SiinErp.Desktop.Common;
using SiinErp.Desktop.Controllers;
using SiinErp.Model.Abstract.General;
using SiinErp.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SiinErp.Desktop
{
    public partial class FormLogin : Form
    {
        private readonly IControllerBusiness controllerBusiness;

        public FormLogin(IControllerBusiness _controllerBusiness)
        {
            InitializeComponent();
            this.controllerBusiness = _controllerBusiness;
            LlenarEmpresas();
        }

        public string IniciarSesion()
        {
            Cookie.Respuesta = ".";
            this.ShowDialog();
            return Cookie.Respuesta;
        }

        private void LlenarEmpresas()
        {
            cboEmpresa.DataSource = controllerBusiness.empresaBusiness.GetEmpresasAct();
            cboEmpresa.DisplayMember = "RazonSocial";
            cboEmpresa.ValueMember = "IdEmpresa";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(cboEmpresa.SelectedValue != null && !string.IsNullOrEmpty(txtNombreUsuario.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                string claveEncriptada = Seguridad.EncriptarMD5(txtPassword.Text);
                var entityUsu = controllerBusiness.usuarioBusiness.GetByUsuario(txtNombreUsuario.Text, claveEncriptada);
                if(entityUsu != null)
                {
                    if (entityUsu.Estado.Equals(Constantes.EstadoActivo))
                    {
                        Cookie.IdUsu = entityUsu.IdUsuario;
                        Cookie.NombreUsuario = entityUsu.NombreUsuario;
                        Cookie.NombreCompleto = entityUsu.NombreCompleto;
                        Cookie.Imagen = "favicon.ico";
                        Cookie.IdEmpresa = int.Parse(cboEmpresa.SelectedValue.ToString());
                        Cookie.Respuesta = "TodoOkey";
                    }
                    else { Cookie.Respuesta = "Usuario Inactivo."; }
                }
                else { Cookie.Respuesta = "Usuario y/o contraseña incorrecta."; }


                if (Cookie.Respuesta.Equals("TodoOkey"))
                {
                    this.Close();
                }
                else { MessageBox.Show(Cookie.Respuesta, "¡No Valido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

    }
}
