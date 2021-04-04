
namespace SiinErp.Desktop.Forms.General
{
    partial class FormTerceroBusqueda
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
            this.txtBusquedaTercero = new System.Windows.Forms.TextBox();
            this.dgvTerceroBusqueda = new System.Windows.Forms.DataGridView();
            this.DgColIdTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColNitCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColNombreTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerceroBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusquedaTercero
            // 
            this.txtBusquedaTercero.Location = new System.Drawing.Point(12, 83);
            this.txtBusquedaTercero.Name = "txtBusquedaTercero";
            this.txtBusquedaTercero.Size = new System.Drawing.Size(197, 22);
            this.txtBusquedaTercero.TabIndex = 0;
            this.txtBusquedaTercero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaTercero_KeyUp);
            // 
            // dgvTerceroBusqueda
            // 
            this.dgvTerceroBusqueda.AllowUserToAddRows = false;
            this.dgvTerceroBusqueda.AllowUserToDeleteRows = false;
            this.dgvTerceroBusqueda.BackgroundColor = System.Drawing.Color.White;
            this.dgvTerceroBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerceroBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgColIdTercero,
            this.DgColNitCedula,
            this.DgColNombreTercero});
            this.dgvTerceroBusqueda.Location = new System.Drawing.Point(12, 111);
            this.dgvTerceroBusqueda.MultiSelect = false;
            this.dgvTerceroBusqueda.Name = "dgvTerceroBusqueda";
            this.dgvTerceroBusqueda.ReadOnly = true;
            this.dgvTerceroBusqueda.RowTemplate.Height = 25;
            this.dgvTerceroBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTerceroBusqueda.Size = new System.Drawing.Size(621, 257);
            this.dgvTerceroBusqueda.TabIndex = 1;
            // 
            // DgColIdTercero
            // 
            this.DgColIdTercero.HeaderText = "IdTercero";
            this.DgColIdTercero.Name = "DgColIdTercero";
            this.DgColIdTercero.ReadOnly = true;
            this.DgColIdTercero.Visible = false;
            // 
            // DgColNitCedula
            // 
            this.DgColNitCedula.HeaderText = "NitCedula";
            this.DgColNitCedula.Name = "DgColNitCedula";
            this.DgColNitCedula.ReadOnly = true;
            this.DgColNitCedula.Width = 150;
            // 
            // DgColNombreTercero
            // 
            this.DgColNombreTercero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgColNombreTercero.HeaderText = "Nombre";
            this.DgColNombreTercero.Name = "DgColNombreTercero";
            this.DgColNombreTercero.ReadOnly = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(265, 374);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 32);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FormTerceroBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 450);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvTerceroBusqueda);
            this.Controls.Add(this.txtBusquedaTercero);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormTerceroBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTerceroBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerceroBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusquedaTercero;
        private System.Windows.Forms.DataGridView dgvTerceroBusqueda;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColIdTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColNitCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColNombreTercero;
    }
}