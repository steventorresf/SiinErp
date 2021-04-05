
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerceroBusqueda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBusquedaTercero
            // 
            this.txtBusquedaTercero.Location = new System.Drawing.Point(20, 21);
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
            this.dgvTerceroBusqueda.Location = new System.Drawing.Point(20, 21);
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
            this.btnAceptar.Location = new System.Drawing.Point(24, 21);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 32);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusquedaTercero);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTerceroBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 289);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAceptar);
            this.groupBox3.Location = new System.Drawing.Point(12, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 63);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // FormTerceroBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormTerceroBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTerceroBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerceroBusqueda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusquedaTercero;
        private System.Windows.Forms.DataGridView dgvTerceroBusqueda;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColIdTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColNitCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColNombreTercero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}