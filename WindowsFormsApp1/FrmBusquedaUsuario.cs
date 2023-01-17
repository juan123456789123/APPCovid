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
    public partial class FrmBusquedaUsuario : Form
    {
        private Conexion conexion;
        public FrmBusquedaUsuario()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }
        public void mostrarfrmAgregarUsuario(int funcion)
        {
            FrmAgregarUsuario frm = new FrmAgregarUsuario();
            frm.setFuncion(funcion);
            if (funcion==1)
            {
                frm.setLoginConsultar(this.dtgDatos.Rows[this.dtgDatos.SelectedCells[0].RowIndex].Cells["Login"].Value.ToString());
            }
            frm.ShowDialog();
            frm.Dispose();
        }
   
        //Método encargado de consultar los usuarios del sistema por su login
        public void consultarUsuarios(string login)
        {
            try
            {
                this.dtgDatos.DataSource = this.conexion.BuscarUsuarioLogin(login).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }// fin del método consultarUsuarios

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            this.consultarUsuarios(this.txtLogin.Text.Trim());
        }

        private void dtgDatos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.mostrarfrmAgregarUsuario(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarUsuario()
        {
            try
            {
                if (this.dtgDatos.Rows.Count > 0)
                {

                    if (this.dtgDatos.SelectedCells.Count > 0)
                    {
                        string login = this.dtgDatos.Rows[this.dtgDatos.SelectedCells[0].RowIndex].Cells["Login"].Value.ToString();

                        if (MessageBox.Show("Desea eliminar el Usuario: " + login, "Confimrar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.conexion.EliminarUsuario(login);
                            MessageBox.Show("Se eliminó correctamete el Usuario");
                        }
                    }
                    else
                    {
                        throw new Exception("Consulte los datos del paciente a eliminar");
                    }//
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método EliminarProducto
        //
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            this.mostrarfrmAgregarUsuario(0);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EliminarUsuario();
        }
    }
}
