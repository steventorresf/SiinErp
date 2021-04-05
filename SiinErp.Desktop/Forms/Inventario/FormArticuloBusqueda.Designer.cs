
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
            this.dgvArticuloBusq = new System.Windows.Forms.DataGridView();
            this.DgColSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgColIdArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColNombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBusquedaArt = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloBusq)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvArticuloBusq
            // 
            this.dgvArticuloBusq.AllowUserToAddRows = false;
            this.dgvArticuloBusq.AllowUserToDeleteRows = false;
            this.dgvArticuloBusq.BackgroundColor = System.Drawing.Color.White;
            this.dgvArticuloBusq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticuloBusq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgColSel,
            this.DgColIdArticulo,
            this.DgColCodigo,
            this.DgColNombreArticulo});
            this.dgvArticuloBusq.Location = new System.Drawing.Point(18, 21);
            this.dgvArticuloBusq.MultiSelect = false;
            this.dgvArticuloBusq.Name = "dgvArticuloBusq";
            this.dgvArticuloBusq.RowTemplate.Height = 25;
            this.dgvArticuloBusq.Size = new System.Drawing.Size(776, 245);
            this.dgvArticuloBusq.TabIndex = 0;
            this.dgvArticuloBusq.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgArticuloBusq_CellEndEdit);
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
            this.btnAgregar.Location = new System.Drawing.Point(27, 21);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 29);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBusquedaArt
            // 
            this.txtBusquedaArt.Location = new System.Drawing.Point(19, 21);
            this.txtBusquedaArt.Name = "txtBusquedaArt";
            this.txtBusquedaArt.Size = new System.Drawing.Size(196, 22);
            this.txtBusquedaArt.TabIndex = 2;
            this.txtBusquedaArt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaArt_KeyUp);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(138, 21);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 29);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusquedaArt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvArticuloBusq);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(818, 277);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAgregar);
            this.groupBox3.Controls.Add(this.btnAceptar);
            this.groupBox3.Location = new System.Drawing.Point(12, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(818, 68);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // FormArticuloBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 436);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormArticuloBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormArticuloBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloBusq)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticuloBusq;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBusquedaArt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgColSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColIdArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColNombreArticulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}