
namespace SiinErp.Desktop.Forms.Ventas
{
    partial class FormCajaDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSaldoFinalAbCe = new System.Windows.Forms.TextBox();
            this.txtSaldoInicialAbCe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComentarioAbCe = new System.Windows.Forms.RichTextBox();
            this.btnGuardarAbCe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTurnoAbCe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCajeroAbCe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTurnoInEg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComentarioInEg = new System.Windows.Forms.RichTextBox();
            this.btnGuardarInEg = new System.Windows.Forms.Button();
            this.txtValorInEg = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCajeroInEg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorInEg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSaldoFinalAbCe);
            this.groupBox1.Controls.Add(this.txtSaldoInicialAbCe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtComentarioAbCe);
            this.groupBox1.Controls.Add(this.btnGuardarAbCe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTurnoAbCe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCajeroAbCe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtSaldoFinalAbCe
            // 
            this.txtSaldoFinalAbCe.Location = new System.Drawing.Point(327, 45);
            this.txtSaldoFinalAbCe.Name = "txtSaldoFinalAbCe";
            this.txtSaldoFinalAbCe.Size = new System.Drawing.Size(120, 22);
            this.txtSaldoFinalAbCe.TabIndex = 12;
            // 
            // txtSaldoInicialAbCe
            // 
            this.txtSaldoInicialAbCe.Location = new System.Drawing.Point(107, 45);
            this.txtSaldoInicialAbCe.Name = "txtSaldoInicialAbCe";
            this.txtSaldoInicialAbCe.Size = new System.Drawing.Size(120, 22);
            this.txtSaldoInicialAbCe.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Comentarios:";
            // 
            // txtComentarioAbCe
            // 
            this.txtComentarioAbCe.Location = new System.Drawing.Point(107, 74);
            this.txtComentarioAbCe.Name = "txtComentarioAbCe";
            this.txtComentarioAbCe.Size = new System.Drawing.Size(339, 108);
            this.txtComentarioAbCe.TabIndex = 9;
            this.txtComentarioAbCe.Text = "";
            // 
            // btnGuardarAbCe
            // 
            this.btnGuardarAbCe.Location = new System.Drawing.Point(107, 188);
            this.btnGuardarAbCe.Name = "btnGuardarAbCe";
            this.btnGuardarAbCe.Size = new System.Drawing.Size(120, 27);
            this.btnGuardarAbCe.TabIndex = 8;
            this.btnGuardarAbCe.Text = "Guardar";
            this.btnGuardarAbCe.UseVisualStyleBackColor = true;
            this.btnGuardarAbCe.Click += new System.EventHandler(this.btnGuardarAbCe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Saldo Final:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saldo Inicial:";
            // 
            // cboTurnoAbCe
            // 
            this.cboTurnoAbCe.FormattingEnabled = true;
            this.cboTurnoAbCe.Location = new System.Drawing.Point(326, 21);
            this.cboTurnoAbCe.Name = "cboTurnoAbCe";
            this.cboTurnoAbCe.Size = new System.Drawing.Size(121, 22);
            this.cboTurnoAbCe.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Turno:";
            // 
            // txtCajeroAbCe
            // 
            this.txtCajeroAbCe.Location = new System.Drawing.Point(107, 21);
            this.txtCajeroAbCe.Name = "txtCajeroAbCe";
            this.txtCajeroAbCe.ReadOnly = true;
            this.txtCajeroAbCe.Size = new System.Drawing.Size(120, 22);
            this.txtCajeroAbCe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cajero:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTurnoInEg);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtComentarioInEg);
            this.groupBox2.Controls.Add(this.btnGuardarInEg);
            this.groupBox2.Controls.Add(this.txtValorInEg);
            this.groupBox2.Controls.Add(this.numericUpDown4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCajeroInEg);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 221);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtTurnoInEg
            // 
            this.txtTurnoInEg.Location = new System.Drawing.Point(326, 21);
            this.txtTurnoInEg.Name = "txtTurnoInEg";
            this.txtTurnoInEg.Size = new System.Drawing.Size(120, 22);
            this.txtTurnoInEg.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Comentarios:";
            // 
            // txtComentarioInEg
            // 
            this.txtComentarioInEg.Location = new System.Drawing.Point(107, 74);
            this.txtComentarioInEg.Name = "txtComentarioInEg";
            this.txtComentarioInEg.Size = new System.Drawing.Size(339, 108);
            this.txtComentarioInEg.TabIndex = 9;
            this.txtComentarioInEg.Text = "";
            // 
            // btnGuardarInEg
            // 
            this.btnGuardarInEg.Location = new System.Drawing.Point(107, 188);
            this.btnGuardarInEg.Name = "btnGuardarInEg";
            this.btnGuardarInEg.Size = new System.Drawing.Size(120, 27);
            this.btnGuardarInEg.TabIndex = 8;
            this.btnGuardarInEg.Text = "Guardar";
            this.btnGuardarInEg.UseVisualStyleBackColor = true;
            // 
            // txtValorInEg
            // 
            this.txtValorInEg.Location = new System.Drawing.Point(326, 46);
            this.txtValorInEg.Name = "txtValorInEg";
            this.txtValorInEg.Size = new System.Drawing.Size(120, 22);
            this.txtValorInEg.TabIndex = 7;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(107, 46);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown4.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "Vr. Ingreso:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "Saldo En Caja:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "Turno:";
            // 
            // txtCajeroInEg
            // 
            this.txtCajeroInEg.Location = new System.Drawing.Point(107, 21);
            this.txtCajeroInEg.Name = "txtCajeroInEg";
            this.txtCajeroInEg.ReadOnly = true;
            this.txtCajeroInEg.Size = new System.Drawing.Size(120, 22);
            this.txtCajeroInEg.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Cajero:";
            // 
            // FormCajaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormCajaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCajaDialog";
            this.Load += new System.EventHandler(this.FormCajaDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorInEg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCajeroAbCe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTurnoAbCe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardarAbCe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtComentarioAbCe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtComentarioInEg;
        private System.Windows.Forms.Button btnGuardarInEg;
        private System.Windows.Forms.NumericUpDown txtValorInEg;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCajeroInEg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTurnoInEg;
        private System.Windows.Forms.TextBox txtSaldoFinalAbCe;
        private System.Windows.Forms.TextBox txtSaldoInicialAbCe;
    }
}