
namespace SiinErp.Desktop.Forms.Inventario
{
    partial class FormArticuloBusqueda
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
            this.DgArticuloBusq = new System.Windows.Forms.DataGridView();
            this.DgColSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgColIdArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColNombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBusquedaArt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgArticuloBusq)).BeginInit();
            this.SuspendLayout();
            // 
            // DgArticuloBusq
            // 
            this.DgArticuloBusq.AllowUserToAddRows = false;
            this.DgArticuloBusq.AllowUserToDeleteRows = false;
            this.DgArticuloBusq.BackgroundColor = System.Drawing.Color.White;
            this.DgArticuloBusq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgArticuloBusq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgColSel,
            this.DgColIdArticulo,
            this.DgColCodigo,
            this.DgColNombreArticulo});
            this.DgArticuloBusq.Location = new System.Drawing.Point(12, 78);
            this.DgArticuloBusq.Name = "DgArticuloBusq";
            this.DgArticuloBusq.RowTemplate.Height = 25;
            this.DgArticuloBusq.Size = new System.Drawing.Size(776, 262);
            this.DgArticuloBusq.TabIndex = 0;
            this.DgArticuloBusq.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgArticuloBusq_CellEndEdit);
            // 
            // DgColSel
            // 
            this.DgColSel.HeaderText = "";
            this.DgColSel.Name = "DgColSel";
            this.DgColSel.Width = 60;
            // 
            // DgColIdArticulo
            // 
            this.DgColIdArticulo.HeaderText = "IdArticulo";
            this.DgColIdArticulo.Name = "DgColIdArticulo";
            this.DgColIdArticulo.Visible = false;
            // 
            // DgColCodigo
            // 
            this.DgColCodigo.HeaderText = "Código";
            this.DgColCodigo.Name = "DgColCodigo";
            this.DgColCodigo.ReadOnly = true;
            this.DgColCodigo.Width = 150;
            // 
            // DgColNombreArticulo
            // 
            this.DgColNombreArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgColNombreArticulo.HeaderText = "Descripción";
            this.DgColNombreArticulo.Name = "DgColNombreArticulo";
            this.DgColNombreArticulo.ReadOnly = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(353, 346);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 34);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBusquedaArt
            // 
            this.txtBusquedaArt.Location = new System.Drawing.Point(12, 49);
            this.txtBusquedaArt.Name = "txtBusquedaArt";
            this.txtBusquedaArt.Size = new System.Drawing.Size(196, 23);
            this.txtBusquedaArt.TabIndex = 2;
            this.txtBusquedaArt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaArt_KeyUp);
            // 
            // FormArticuloBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.txtBusquedaArt);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.DgArticuloBusq);
            this.Name = "FormArticuloBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormArticuloBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.DgArticuloBusq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgArticuloBusq;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBusquedaArt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgColSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColIdArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColNombreArticulo;
    }
}