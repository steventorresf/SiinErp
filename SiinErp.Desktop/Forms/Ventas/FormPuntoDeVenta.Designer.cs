
namespace SiinErp.Desktop.Forms.Ventas
{
    partial class FormPuntoDeVenta
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtnitCedula = new System.Windows.Forms.TextBox();
            this.cboCajero = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboListaPrecio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.DgColCodArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgVrUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColDscto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColVrBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColVrNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtVrNeto = new System.Windows.Forms.TextBox();
            this.txtVrIVA = new System.Windows.Forms.TextBox();
            this.txtVrDscto = new System.Windows.Forms.TextBox();
            this.txtVrBruto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvFormasDePago = new System.Windows.Forms.DataGridView();
            this.DgColFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgColValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormasDePago)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura de venta";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFactura.Location = new System.Drawing.Point(152, 18);
            this.txtNumeroFactura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(83, 33);
            this.txtNumeroFactura.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtNombreCliente);
            this.groupBox1.Controls.Add(this.txtnitCedula);
            this.groupBox1.Controls.Add(this.cboCajero);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboAlmacen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboListaPrecio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Location = new System.Drawing.Point(18, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1111, 163);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 14);
            this.label10.TabIndex = 17;
            this.label10.Text = "Teléfono:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "Dirección";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nombre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "NIT/Cedula";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(113, 119);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(321, 22);
            this.txtTelefono.TabIndex = 8;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(113, 95);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(321, 22);
            this.txtDireccion.TabIndex = 7;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(113, 71);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(321, 22);
            this.txtNombreCliente.TabIndex = 6;
            // 
            // txtnitCedula
            // 
            this.txtnitCedula.Location = new System.Drawing.Point(113, 47);
            this.txtnitCedula.Name = "txtnitCedula";
            this.txtnitCedula.Size = new System.Drawing.Size(321, 22);
            this.txtnitCedula.TabIndex = 5;
            // 
            // cboCajero
            // 
            this.cboCajero.FormattingEnabled = true;
            this.cboCajero.Location = new System.Drawing.Point(658, 71);
            this.cboCajero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(321, 22);
            this.cboCajero.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cajero:";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(658, 47);
            this.cboAlmacen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(321, 22);
            this.cboAlmacen.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Almacen:";
            // 
            // cboListaPrecio
            // 
            this.cboListaPrecio.FormattingEnabled = true;
            this.cboListaPrecio.Location = new System.Drawing.Point(658, 95);
            this.cboListaPrecio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboListaPrecio.Name = "cboListaPrecio";
            this.cboListaPrecio.Size = new System.Drawing.Size(321, 22);
            this.cboListaPrecio.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(562, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lista de precio:";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(113, 23);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(321, 22);
            this.cboCliente.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(658, 23);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(321, 22);
            this.dtpFecha.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetalleFactura);
            this.groupBox2.Location = new System.Drawing.Point(18, 255);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1111, 248);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgColCodArticulo,
            this.DgColDescripcion,
            this.DgColCantidad,
            this.DgVrUnit,
            this.DgColDscto,
            this.DgColIVA,
            this.DgColVrBruto,
            this.DgColVrNeto});
            this.dgvDetalleFactura.Location = new System.Drawing.Point(6, 23);
            this.dgvDetalleFactura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.RowHeadersWidth = 35;
            this.dgvDetalleFactura.RowTemplate.Height = 24;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(1097, 219);
            this.dgvDetalleFactura.TabIndex = 13;
            // 
            // DgColCodArticulo
            // 
            this.DgColCodArticulo.HeaderText = "Código";
            this.DgColCodArticulo.MinimumWidth = 6;
            this.DgColCodArticulo.Name = "DgColCodArticulo";
            this.DgColCodArticulo.Width = 150;
            // 
            // DgColDescripcion
            // 
            this.DgColDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgColDescripcion.HeaderText = "Descripción";
            this.DgColDescripcion.MinimumWidth = 6;
            this.DgColDescripcion.Name = "DgColDescripcion";
            // 
            // DgColCantidad
            // 
            this.DgColCantidad.HeaderText = "Cant";
            this.DgColCantidad.MinimumWidth = 6;
            this.DgColCantidad.Name = "DgColCantidad";
            this.DgColCantidad.Width = 60;
            // 
            // DgVrUnit
            // 
            this.DgVrUnit.HeaderText = "VrUnit";
            this.DgVrUnit.MinimumWidth = 6;
            this.DgVrUnit.Name = "DgVrUnit";
            this.DgVrUnit.Width = 125;
            // 
            // DgColDscto
            // 
            this.DgColDscto.HeaderText = "Dscto";
            this.DgColDscto.MinimumWidth = 6;
            this.DgColDscto.Name = "DgColDscto";
            this.DgColDscto.Width = 50;
            // 
            // DgColIVA
            // 
            this.DgColIVA.HeaderText = "IVA";
            this.DgColIVA.MinimumWidth = 6;
            this.DgColIVA.Name = "DgColIVA";
            this.DgColIVA.Width = 50;
            // 
            // DgColVrBruto
            // 
            this.DgColVrBruto.HeaderText = "VrBruto";
            this.DgColVrBruto.MinimumWidth = 6;
            this.DgColVrBruto.Name = "DgColVrBruto";
            this.DgColVrBruto.Width = 125;
            // 
            // DgColVrNeto
            // 
            this.DgColVrNeto.HeaderText = "VrNeto";
            this.DgColVrNeto.MinimumWidth = 6;
            this.DgColVrNeto.Name = "DgColVrNeto";
            this.DgColVrNeto.Width = 125;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSiguiente);
            this.groupBox3.Controls.Add(this.btnAnterior);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtNumeroFactura);
            this.groupBox3.Location = new System.Drawing.Point(16, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1113, 67);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(290, 18);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(48, 33);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(241, 18);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(48, 33);
            this.btnAnterior.TabIndex = 2;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtVrNeto);
            this.groupBox4.Controls.Add(this.txtVrIVA);
            this.groupBox4.Controls.Add(this.txtVrDscto);
            this.groupBox4.Controls.Add(this.txtVrBruto);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(18, 510);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(379, 163);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // txtVrNeto
            // 
            this.txtVrNeto.Location = new System.Drawing.Point(88, 93);
            this.txtVrNeto.Name = "txtVrNeto";
            this.txtVrNeto.Size = new System.Drawing.Size(100, 22);
            this.txtVrNeto.TabIndex = 17;
            // 
            // txtVrIVA
            // 
            this.txtVrIVA.Location = new System.Drawing.Point(88, 69);
            this.txtVrIVA.Name = "txtVrIVA";
            this.txtVrIVA.Size = new System.Drawing.Size(100, 22);
            this.txtVrIVA.TabIndex = 16;
            // 
            // txtVrDscto
            // 
            this.txtVrDscto.Location = new System.Drawing.Point(88, 45);
            this.txtVrDscto.Name = "txtVrDscto";
            this.txtVrDscto.Size = new System.Drawing.Size(100, 22);
            this.txtVrDscto.TabIndex = 15;
            // 
            // txtVrBruto
            // 
            this.txtVrBruto.Location = new System.Drawing.Point(88, 21);
            this.txtVrBruto.Name = "txtVrBruto";
            this.txtVrBruto.Size = new System.Drawing.Size(100, 22);
            this.txtVrBruto.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "Vr. Neto:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 14);
            this.label13.TabIndex = 2;
            this.label13.Text = "Vr. IVA:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 14);
            this.label12.TabIndex = 1;
            this.label12.Text = "Vr. Dscto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Vr. Bruto:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvFormasDePago);
            this.groupBox5.Location = new System.Drawing.Point(403, 510);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(725, 163);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // dgvFormasDePago
            // 
            this.dgvFormasDePago.AllowUserToAddRows = false;
            this.dgvFormasDePago.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormasDePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormasDePago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgColFormaPago,
            this.DgColCuentaBancaria,
            this.DgColValor});
            this.dgvFormasDePago.Location = new System.Drawing.Point(6, 24);
            this.dgvFormasDePago.Name = "dgvFormasDePago";
            this.dgvFormasDePago.Size = new System.Drawing.Size(712, 122);
            this.dgvFormasDePago.TabIndex = 18;
            // 
            // DgColFormaPago
            // 
            this.DgColFormaPago.HeaderText = "FormaDePago";
            this.DgColFormaPago.Name = "DgColFormaPago";
            this.DgColFormaPago.Width = 150;
            // 
            // DgColCuentaBancaria
            // 
            this.DgColCuentaBancaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgColCuentaBancaria.HeaderText = "CuentaBancaria";
            this.DgColCuentaBancaria.Name = "DgColCuentaBancaria";
            // 
            // DgColValor
            // 
            this.DgColValor.HeaderText = "Valor";
            this.DgColValor.Name = "DgColValor";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAnular);
            this.groupBox6.Controls.Add(this.btnGuardar);
            this.groupBox6.Location = new System.Drawing.Point(18, 679);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1110, 73);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(1013, 21);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 28);
            this.btnAnular.TabIndex = 20;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 21);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 28);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FormPuntoDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1140, 764);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPuntoDeVenta";
            this.Text = "FormPuntoDeVenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormasDePago)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboListaPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboCajero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAlmacen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtnitCedula;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColCodArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgVrUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColDscto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColVrBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColVrNeto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtVrNeto;
        private System.Windows.Forms.TextBox txtVrIVA;
        private System.Windows.Forms.TextBox txtVrDscto;
        private System.Windows.Forms.TextBox txtVrBruto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvFormasDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColCuentaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgColValor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAnular;
    }
}