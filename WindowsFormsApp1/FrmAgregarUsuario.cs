using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
namespace WindowsFormsApp1
{
    public partial class FrmAgregarUsuario : Form
    {
        private Conexion conexion;
        private Usuario usuario;
        private int function = 0;
        private string loginConsultar;
        public FrmAgregarUsuario()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
            this.cmbRol.Items.Add("Selecione una opción");
            this.cmbRol.Items.Add("Administrador");
            this.cmbRol.Items.Add("Usuario médico");
            this.cmbRol.Items.Add("Administrador del Ministerio de Salud");
            this.cmbRol.Text = "Selecione una opción";
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //Método encargado de realizar las validaciones respectivas antes de agregar un nuevo usuario
        public void validaciones()
        {
            try
            {
                if (this.txtLogin.Text.Trim().Equals(""))
                {
                    throw new Exception("Error el campo Nombre de usuario no puede estar vacio");
                }
                if (this.txtContrasena.Text.Trim().Equals(""))
                {
                    throw new Exception("Error el campo Contraseña no puede estar vacio");
                }
                if (this.txtEmail.Text.Trim().Equals(""))
                {
                    throw new Exception("Error el campo Email no puede estar vacio");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método validaciones
        //método encargado de crear un nuevo objeto Usuario
        public void crearObjetoUsuario()
        {
            try
            {
                this.validaciones();
                this.usuario = new Usuario();
                this.usuario.login = this.txtLogin.Text.Trim();
                this.usuario.email = this.txtEmail.Text.Trim();
                if (this.txtContrasena.Text.Trim().Equals(this.txtConfirmarContrasena.Text.Trim()))
                {
                    this.usuario.password = this.txtContrasena.Text.Trim();
                }
                else
                {
                     throw new Exception("Error las contraseñas no coinciden");
                }
                if (!this.cmbRol.SelectedItem.Equals("Selecione una opción"))
                {
                    this.usuario.rol = this.cmbRol.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }// fin del método crearObjetoUsuario
         //método encargado de agregar los usaurios al sistema
        public void setLoginConsultar(string valor)
        {
            this.loginConsultar = valor;
        }//fin del método setLoginConsultar
        public void limpiarFormulario()
        {
            try
            {
                this.txtLogin.Text = "";
                this.txtEmail.Text = "";
                this.txtContrasena.Text = "";
                this.txtConfirmarContrasena.Text = "";
                this.cmbRol.Text = "Selecione una opción";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setFuncion(int valor)
        {
            this.function = valor;
        }//fin del método setFuncion
        public void AgregarUsuario()
        {
            try
            {
                if (this.cmbRol.SelectedItem.ToString().Equals("Selecione una opción"))
                {
                    MessageBox.Show("Porfavor selecione un Rol para el Usuario");
                }
                else 
                {
                    this.conexion.AgregarUsuarios(this.usuario);
                    MessageBox.Show("Usuario registrado Correctamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limpiarFormulario();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método agregar usuario
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void consultarUsuario()
        {
            try
            {
                this.usuario = this.conexion.consultarUsuarioLogin(this.loginConsultar);
                if (this.usuario!=null)
                {
                    this.txtLogin.Text = ""+this.usuario.login;
                    this.txtContrasena.Text = "" + this.usuario.password;
                    this.txtEmail.Text = ""+this.usuario.email;
                    this.cmbRol.Text = "" + this.usuario.rol;
                    this.txtConfirmarContrasena.Text = ""+this.usuario.password;
                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método consultar Usuario
        private void FrmAgregarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                //Lógica de negocio 1 es Modificar 0 Agregar
                if (this.function==1)
                {
                    btnAciones.Text = "Modificar";
                    this.txtLogin.Text = loginConsultar;
                    this.txtLogin.ReadOnly = true;
                    //se llama al metodo de modificar
                    this.consultarUsuario();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void modificarUsuario()
        {
            try
            {
                this.conexion.modificarUsuario(this.usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnAciones_Click(object sender, EventArgs e)
        {
            try
            {
                this.crearObjetoUsuario();
                if (this.function==0)
                {
                    Usuario temp = this.conexion.consultarUsuarioLogin(this.txtLogin.Text.Trim());
                    if (temp == null)
                    {
                        this.AgregarUsuario();
                    }
                    else
                    {
                        MessageBox.Show("Error, ya existe un usuario con ese Login por favor digite uno distinto");
                    }
                }
                else
                {
                    if (this.cmbRol.SelectedItem.ToString().Equals("Selecione una opción"))
                    {
                        throw new Exception("Por favor selecione un rol para el usuario");
                    }
                    if (MessageBox.Show("Desea aplicar los cambios", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.modificarUsuario();
                        this.limpiarFormulario();
                        MessageBox.Show("Usuario Modificado Correctamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
