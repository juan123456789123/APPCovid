using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using DAL;
using BLL;
namespace WindowsFormsApp1
{
    public partial class FrmPrincipal : Form
    {
        private Conexion conexion;
        private string rolUsuario;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.rolUsuario = "";
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
            this.agregarConsultaCantH_M();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        //método para salir del sistema
        public void Salir()
        {
            Application.Exit();
        }
        //metodo encargado de devolver el string de conexion
        public static string ObtenerStringConexion()
        {
            return Settings.Default.StringConexion;
        }
        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void ptbSalir_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.mostrarFrmPacientes();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Método encargado de mostrar el frm que gestiona los pacientes del sistema
        public void mostrarFrmPacientes()
        {
            try
            {
                FrmBusquedaPaciente frm = new FrmBusquedaPaciente();
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAddPaci_Click(object sender, EventArgs e)
        {
            panelFondo.Visible = false;
            FrmBusquedaPaciente frm = new FrmBusquedaPaciente();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
   
        }

        
        //metodo encargado de mostrar el formulario para agregar un nuevo paciente
        public void mostrarFormularioPacientes()
        {
            try
            {
                FrmAgregarPaciente frm = new FrmAgregarPaciente();
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//fin del método para mostrar el formularioPacientes
        //método para mostrar el frm de registro de sintomas de covid-19
        public void mostrarFrmRegistroSintomas()
        {
            try
            {
                panelFondo.Visible = false;
                FrmSintomas frm = new FrmSintomas();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método mostrarFrmRegistroSintomas
        private void btnAddRegistro_Click(object sender, EventArgs e)
        {
            this.mostrarFrmRegistroSintomas();
            //this.gbxExtadisticas.Visible = false;
        }
        public void CargarCantCasos()
        {
            try
            {
                //if (this.conexion.consultarCantRegistros() > 1)
                //{
                //    this.lblCasos.Text = "" + this.conexion.consultarIndice();
                //}
                //else
                //{
                //    this.lblCasos.Text = "" + 0;
                //}
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//
        public void mostrarFrmLogin()
        {
            try
            {
                FrmLogin frm = new FrmLogin();
                frm.ShowDialog();
                if (this.conexion.consultarUsuarioLogin(frm.consultarRolUsuario())!=null)
                {
                    this.rolUsuario = this.conexion.consultarUsuarioLogin(frm.consultarRolUsuario()).rol;
                }
                
                this.validacionesRolesUsuario();
                frm.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.mostrarFrmLogin();

                this.CargarCantCasos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                panelFondo.Visible = false;
                FrmEstadistica frm = new FrmEstadistica();
                frm.chartBarras.Visible = false;
                frm.chartDona.Visible = false;
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        private void agregarConsultaCantH_M()
        {
            //try
            //{
            //    this.dtgDatos.DataSource = this.conexion.ConsultarCasosH_M().Tables[0];
            //    this.dtgDatos.AutoResizeColumns();
            //    this.dtgDatos.ReadOnly = true;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }
        public void mostrarFrmInformacion()
        {
            try
            {
                FrmEstadistica frm = new FrmEstadistica();
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del metodo mostrarFrmInformacion

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            this.mostrarFrmInformacion();
        }//fin del método

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void agregarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        private void agregarRegistroToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void agregarUnNuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCasos_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbxExtadisticas_Enter(object sender, EventArgs e)
        {

        }

        private void FrmFondo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.btnUsuarios.Enabled = true;
            this.btnAddPaci.Enabled = true;
            this.btnAddRegistro.Enabled = true;
            this.btnEstadistica.Enabled = true;
            this.mostrarFrmLogin();
        }
        public void validacionesRolesUsuario()
        {
            try
            {
                if (this.rolUsuario.Equals("Usuario médico"))
                {
                    this.btnUsuarios.Enabled = false;
                }
                if (this.rolUsuario.Equals("Administrador del Ministerio de Salud"))
                {
                    this.btnUsuarios.Enabled = false;
                    this.btnAddPaci.Enabled = false;
                    this.btnAddRegistro.Enabled = false;
                }

            }
            //validacionesRolesUsuario
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
                panelFondo.Visible = false;
                FrmBusquedaUsuario frm = new FrmBusquedaUsuario();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}//fin del namespace

