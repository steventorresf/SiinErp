
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
            this.toolStripGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPuntoDeVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCajas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripGeneral,
            this.toolStripInventario,
            this.toolStripVentas});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(800, 26);
            this.menuStripPrincipal.TabIndex = 0;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // toolStripGeneral
            // 
            this.toolStripGeneral.Name = "toolStripGeneral";
            this.toolStripGeneral.Size = new System.Drawing.Size(69, 22);
            this.toolStripGeneral.Text = "General";
            // 
            // toolStripInventario
            // 
            this.toolStripInventario.Name = "toolStripInventario";
            this.toolStripInventario.Size = new System.Drawing.Size(86, 22);
            this.toolStripInventario.Text = "Inventario";
            // 
            // toolStripVentas
            // 
            this.toolStripVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPuntoDeVenta,
            this.toolStripCajas});
            this.toolStripVentas.Name = "toolStripVentas";
            this.toolStripVentas.Size = new System.Drawing.Size(65, 22);
            this.toolStripVentas.Text = "Ventas";
            // 
            // toolStripPuntoDeVenta
            // 
            this.toolStripPuntoDeVenta.Name = "toolStripPuntoDeVenta";
            this.toolStripPuntoDeVenta.Size = new System.Drawing.Size(179, 22);
            this.toolStripPuntoDeVenta.Text = "Punto De Venta";
            this.toolStripPuntoDeVenta.Click += new System.EventHandler(this.toolStripPuntoDeVenta_Click);
            // 
            // toolStripCajas
            // 
            this.toolStripCajas.Name = "toolStripCajas";
            this.toolStripCajas.Size = new System.Drawing.Size(179, 22);
            this.toolStripCajas.Text = "Cajas";
            this.toolStripCajas.Click += new System.EventHandler(this.toolStripCajas_Click);
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
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripGeneral;
        private System.Windows.Forms.ToolStripMenuItem toolStripInventario;
        private System.Windows.Forms.ToolStripMenuItem toolStripVentas;
        private System.Windows.Forms.ToolStripMenuItem toolStripPuntoDeVenta;
        private System.Windows.Forms.ToolStripMenuItem toolStripCajas;
    }
}

