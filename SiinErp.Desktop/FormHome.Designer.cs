
using SiinErp.Model.Entities.General;
using System.Collections.Generic;

namespace SiinErp.Desktop
{
    partial class FormHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.Font = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuStripPrincipal.TabIndex = 0;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripPrincipal);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SiinErp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPrincipal;


        private void InicializarMenu(List<Menu> Listado)
        {
            foreach (Menu me in Listado)
            {
                System.Windows.Forms.ToolStripMenuItem toolStrip = new System.Windows.Forms.ToolStripMenuItem();
                toolStrip.Size = new System.Drawing.Size(100, 22);
                toolStrip.Text = me.Nombre;

                foreach (Menu mu in me.ListaMenu)
                {
                    System.Windows.Forms.ToolStripMenuItem toolStripSub = new System.Windows.Forms.ToolStripMenuItem();
                    toolStripSub.Size = new System.Drawing.Size(200, 22);
                    toolStripSub.Text = mu.Nombre;
                    toolStripSub.Click += GetEventoClick(mu.Codigo);
                    toolStrip.DropDownItems.Add(toolStripSub);
                }

                this.menuStripPrincipal.Items.Add(toolStrip);
            }
        }

        private System.EventHandler GetEventoClick(string Codigo)
        {
            System.EventHandler eventHandler = null;
            switch (Codigo)
            {
                case "GEN_USU":
                    eventHandler = new System.EventHandler(this.toolStripUsuario_Click);
                    break;
                case "INV_ART":
                    eventHandler = new System.EventHandler(this.toolStripArticulo_Click);
                    break;
                case "VEN_LPR":
                    eventHandler = new System.EventHandler(this.toolStripListaDePrecio_Click);
                    break;
                case "VEN_CLI":
                    eventHandler = new System.EventHandler(this.toolStripClientes_Click);
                    break;
                case "VEN_PVE":
                    eventHandler = new System.EventHandler(this.toolStripPuntoDeVenta_Click);
                    break;
                case "VEN_CAJ":
                    eventHandler = new System.EventHandler(this.toolStripCajas_Click);
                    break;
                case "GEN_TAB":
                    eventHandler = new System.EventHandler(this.toolStripTablas_Click);
                    break;
            }

            return eventHandler;
        }

        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

