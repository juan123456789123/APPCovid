
namespace WindowsFormsApp1
{
    partial class FrmSintomas
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.btnGuardarRegistro = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.iconButtonAgregar = new FontAwesome.Sharp.IconButton();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.Sintoma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuracion1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSintomas = new System.Windows.Forms.ComboBox();
            this.txtOpcional = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.iconPictureBuscar = new FontAwesome.Sharp.IconPictureBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBuscar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Controls.Add(this.gbDatos);
            this.panel3.Location = new System.Drawing.Point(290, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 453);
            this.panel3.TabIndex = 3;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnGuardarRegistro);
            this.gbDatos.Controls.Add(this.btnLimpiar);
            this.gbDatos.Controls.Add(this.iconButtonAgregar);
            this.gbDatos.Controls.Add(this.dtgDatos);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtDuracion1);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.cmbSintomas);
            this.gbDatos.Controls.Add(this.txtOpcional);
            this.gbDatos.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.Location = new System.Drawing.Point(11, 9);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbDatos.Size = new System.Drawing.Size(428, 447);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Registro de sintomas";
            this.gbDatos.Visible = false;
            // 
            // btnGuardarRegistro
            // 
            this.btnGuardarRegistro.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardarRegistro.IconColor = System.Drawing.Color.Black;
            this.btnGuardarRegistro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardarRegistro.IconSize = 40;
            this.btnGuardarRegistro.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarRegistro.Location = new System.Drawing.Point(314, 396);
            this.btnGuardarRegistro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardarRegistro.Name = "btnGuardarRegistro";
            this.btnGuardarRegistro.Size = new System.Drawing.Size(43, 40);
            this.btnGuardarRegistro.TabIndex = 11;
            this.btnGuardarRegistro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarRegistro.UseVisualStyleBackColor = true;
            this.btnGuardarRegistro.Click += new System.EventHandler(this.btnGuardarRegistro_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 40;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.Location = new System.Drawing.Point(362, 396);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(46, 40);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // iconButtonAgregar
            // 
            this.iconButtonAgregar.BackColor = System.Drawing.Color.Transparent;
            this.iconButtonAgregar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonAgregar.IconColor = System.Drawing.Color.Black;
            this.iconButtonAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonAgregar.IconSize = 40;
            this.iconButtonAgregar.Location = new System.Drawing.Point(347, 148);
            this.iconButtonAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconButtonAgregar.Name = "iconButtonAgregar";
            this.iconButtonAgregar.Size = new System.Drawing.Size(46, 40);
            this.iconButtonAgregar.TabIndex = 12;
            this.iconButtonAgregar.UseVisualStyleBackColor = false;
            this.iconButtonAgregar.Click += new System.EventHandler(this.iconButtonAgregar_Click);
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sintoma,
            this.Duracion});
            this.dtgDatos.Location = new System.Drawing.Point(19, 210);
            this.dtgDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.RowHeadersWidth = 62;
            this.dtgDatos.RowTemplate.Height = 28;
            this.dtgDatos.Size = new System.Drawing.Size(388, 183);
            this.dtgDatos.TabIndex = 11;
            this.dtgDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellContentClick);
            // 
            // Sintoma
            // 
            this.Sintoma.HeaderText = "Sintoma";
            this.Sintoma.MinimumWidth = 8;
            this.Sintoma.Name = "Sintoma";
            this.Sintoma.ReadOnly = true;
            // 
            // Duracion
            // 
            this.Duracion.HeaderText = "Duración";
            this.Duracion.MinimumWidth = 8;
            this.Duracion.Name = "Duracion";
            this.Duracion.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Duración (Días)";
            // 
            // txtDuracion1
            // 
            this.txtDuracion1.Location = new System.Drawing.Point(185, 109);
            this.txtDuracion1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDuracion1.Multiline = true;
            this.txtDuracion1.Name = "txtDuracion1";
            this.txtDuracion1.Size = new System.Drawing.Size(149, 33);
            this.txtDuracion1.TabIndex = 9;
            this.txtDuracion1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracion1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Otro(s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sintomas comunes";
            // 
            // cmbSintomas
            // 
            this.cmbSintomas.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSintomas.FormattingEnabled = true;
            this.cmbSintomas.Location = new System.Drawing.Point(185, 68);
            this.cmbSintomas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSintomas.Name = "cmbSintomas";
            this.cmbSintomas.Size = new System.Drawing.Size(149, 32);
            this.cmbSintomas.TabIndex = 2;
            // 
            // txtOpcional
            // 
            this.txtOpcional.Location = new System.Drawing.Point(185, 155);
            this.txtOpcional.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOpcional.Multiline = true;
            this.txtOpcional.Name = "txtOpcional";
            this.txtOpcional.Size = new System.Drawing.Size(149, 26);
            this.txtOpcional.TabIndex = 1;
            this.txtOpcional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpcional_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 80);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Ebrima", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "GESTION DE SINTOMAS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.iconPictureBuscar);
            this.groupBox2.Controls.Add(this.txtEdad);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtProvincia);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCedula);
            this.groupBox2.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(280, 447);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paciente";
            // 
            // iconPictureBuscar
            // 
            this.iconPictureBuscar.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBuscar.ForeColor = System.Drawing.Color.MediumBlue;
            this.iconPictureBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBuscar.IconColor = System.Drawing.Color.MediumBlue;
            this.iconPictureBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBuscar.Location = new System.Drawing.Point(245, 67);
            this.iconPictureBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconPictureBuscar.Name = "iconPictureBuscar";
            this.iconPictureBuscar.Size = new System.Drawing.Size(35, 32);
            this.iconPictureBuscar.TabIndex = 19;
            this.iconPictureBuscar.TabStop = false;
            this.iconPictureBuscar.Click += new System.EventHandler(this.iconPictureBuscar_Click);
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(89, 296);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(156, 32);
            this.txtEdad.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 302);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Edad";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(89, 227);
            this.txtProvincia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(156, 32);
            this.txtProvincia.TabIndex = 16;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(89, 149);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(156, 32);
            this.txtNombre.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 227);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Provincia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cédula";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(89, 68);
            this.txtCedula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCedula.MaxLength = 9;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(145, 32);
            this.txtCedula.TabIndex = 11;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 453);
            this.panel2.TabIndex = 2;
            // 
            // FrmSintomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 533);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSintomas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSintomas";
            this.panel3.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBuscar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSintomas;
        private System.Windows.Forms.TextBox txtOpcional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDuracion1;
        private FontAwesome.Sharp.IconButton btnGuardarRegistro;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sintoma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconButtonAgregar;
        private System.Windows.Forms.GroupBox groupBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBuscar;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Panel panel2;
    }
}