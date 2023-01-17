namespace WindowsFormsApp1
{
    partial class FrmAgregarUsuario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExit = new FontAwesome.Sharp.IconPictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAciones = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 124);
            this.panel1.TabIndex = 10;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonExit.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.buttonExit.IconColor = System.Drawing.Color.White;
            this.buttonExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonExit.IconSize = 58;
            this.buttonExit.Location = new System.Drawing.Point(1068, 38);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(63, 58);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.TabStop = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Ebrima", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(369, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "GESTION DE USUARIOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfirmarContrasena);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAciones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtContrasena);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.cmbRol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Ebrima", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 142);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(898, 595);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del usuario";
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(304, 203);
            this.txtConfirmarContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.PasswordChar = '*';
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(329, 45);
            this.txtConfirmarContrasena.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 38);
            this.label4.TabIndex = 12;
            this.label4.Text = "Confirmar contraseña:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(303, 268);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(330, 45);
            this.txtEmail.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 38);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rol:";
            // 
            // btnAciones
            // 
            this.btnAciones.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAciones.FlatAppearance.BorderSize = 0;
            this.btnAciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAciones.ForeColor = System.Drawing.Color.White;
            this.btnAciones.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAciones.IconColor = System.Drawing.Color.White;
            this.btnAciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAciones.IconSize = 41;
            this.btnAciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAciones.Location = new System.Drawing.Point(364, 462);
            this.btnAciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAciones.Name = "btnAciones";
            this.btnAciones.Size = new System.Drawing.Size(223, 88);
            this.btnAciones.TabIndex = 8;
            this.btnAciones.Text = "Agregar";
            this.btnAciones.UseVisualStyleBackColor = false;
            this.btnAciones.Click += new System.EventHandler(this.btnAciones_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(304, 142);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(329, 45);
            this.txtContrasena.TabIndex = 5;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(304, 80);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogin.MaxLength = 35;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(329, 45);
            this.txtLogin.TabIndex = 4;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(303, 339);
            this.cmbRol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(330, 46);
            this.cmbRol.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario:";
            // 
            // FrmAgregarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 824);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAgregarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarUsuario";
            this.Load += new System.EventHandler(this.FrmAgregarUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnAciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox buttonExit;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Label label4;
    }
}