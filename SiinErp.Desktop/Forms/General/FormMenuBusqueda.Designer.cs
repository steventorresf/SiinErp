
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
            this.ColIdMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(180, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 30);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgvMenuBusqueda
            // 
            this.dgvMenuBusqueda.AllowUserToAddRows = false;
            this.dgvMenuBusqueda.AllowUserToDeleteRows = false;
            this.dgvMenuBusqueda.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdMenu,
            this.ColSel,
            this.DgColDescripcion});
            this.dgvMenuBusqueda.Location = new System.Drawing.Point(12, 11);
            this.dgvMenuBusqueda.MultiSelect = false;
            this.dgvMenuBusqueda.Name = "dgvMenuBusqueda";
            this.dgvMenuBusqueda.RowTemplate.Height = 25;
            this.dgvMenuBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuBusqueda.Size = new System.Drawing.Size(436, 240);
            this.dgvMenuBusqueda.TabIndex = 3;
            this.dgvMenuBusqueda.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuBusqueda_CellEndEdit);
            // 
            // ColIdMenu
            // 
            this.ColIdMenu.HeaderText = "IdMenu";
            this.ColIdMenu.Name = "ColIdMenu";
            this.ColIdMenu.ReadOnly = true;
            this.ColIdMenu.Visible = false;
            // 
            // ColSel
            // 
            this.ColSel.HeaderText = "";
            this.ColSel.Name = "ColSel";
            this.ColSel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColSel.Width = 60;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 307);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvMenuBusqueda);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormMenuBusqueda";
            this.Text = "FormMenuBusqueda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvMenuBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdMenu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColDescripcion;
    }
}