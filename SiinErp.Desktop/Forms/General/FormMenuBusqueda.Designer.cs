
namespace SiinErp.Desktop.Forms.General
{
    partial class FormMenuBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dgvMenuBusqueda = new System.Windows.Forms.DataGridView();
            this.DgColIdMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(180, 275);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 32);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // dgvMenuBusqueda
            // 
            this.dgvMenuBusqueda.AllowUserToAddRows = false;
            this.dgvMenuBusqueda.AllowUserToDeleteRows = false;
            this.dgvMenuBusqueda.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgColIdMenu,
            this.DgColDescripcion});
            this.dgvMenuBusqueda.Location = new System.Drawing.Point(12, 12);
            this.dgvMenuBusqueda.MultiSelect = false;
            this.dgvMenuBusqueda.Name = "dgvMenuBusqueda";
            this.dgvMenuBusqueda.ReadOnly = true;
            this.dgvMenuBusqueda.RowTemplate.Height = 25;
            this.dgvMenuBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuBusqueda.Size = new System.Drawing.Size(436, 257);
            this.dgvMenuBusqueda.TabIndex = 3;
            // 
            // DgColIdMenu
            // 
            this.DgColIdMenu.HeaderText = "IdMenu";
            this.DgColIdMenu.Name = "DgColIdMenu";
            this.DgColIdMenu.ReadOnly = true;
            this.DgColIdMenu.Visible = false;
            // 
            // DgColDescripcion
            // 
            this.DgColDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgColDescripcion.HeaderText = "Descripción";
            this.DgColDescripcion.Name = "DgColDescripcion";
            this.DgColDescripcion.ReadOnly = true;
            // 
            // FormMenuBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 323);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvMenuBusqueda);
            this.Name = "FormMenuBusqueda";
            this.Text = "FormMenuBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvMenuBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColIdMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColDescripcion;
    }
}