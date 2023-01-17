using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using BLL;
using DAL;
namespace WindowsFormsApp1
{
    public partial class FrmLogin : Form
    {
        private Conexion conexion;
        private Usuario usuario;
        private string rolValidar;
        public FrmLogin()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }
        public void crearObjetoUsuario()
        {
            try
            {
                this.usuario = new Usuario();
                this.usuario.login = this.txtLogin.Text.Trim();
                this.usuario.password = this.txtContrasena.Text.Trim();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//
        public bool validarContrasena()
        {
            try
            {
                this.crearObjetoUsuario();
                if (this.usuario != null)
                {
                    Usuario temp = this.conexion.consultarUsuarioLogin(this.usuario.login);
                    if (temp != null)
                    {
                        if (this.usuario.login.Equals(temp.login))
                        {
                            if (temp.password.Equals(usuario.password))
                            {
                                return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método validar contrasena
        public string consultarRolUsuario()
        {
            try
            {
                if (this.usuario != null)
                {
                    return this.usuario.login;
                }
                else return "Error";
               
            }
            catch (Exception)
            {

                throw;
            }
              
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarContrasena() == true)
                {

                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Error el usuario o contrasena no con válidos");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
