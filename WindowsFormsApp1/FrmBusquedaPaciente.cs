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
    public partial class FrmBusquedaPaciente : Form
    {
        private Conexion conexion;
        public FrmBusquedaPaciente()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.mostrarFrmRegistroPacientes(0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //método encargado de mostrar el formulario para agregar a los pacientes
        public void mostrarFrmRegistroPacientes(int function)
        {
            try
            {
                FrmAgregarPaciente frm = new FrmAgregarPaciente();
                frm.setFuncion(function);
                if (function == 1)
                {
                    frm.setCedulaConsultar(this.dtgDatos.Rows[this.dtgDatos.SelectedCells[0].RowIndex].Cells["Cédula"].Value.ToString());
                }
                frm.ShowDialog();
                frm.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método mostrarFrmRegistroPacientes

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            this.buscarPacientePorNombre(this.txtCedula.Text.Trim());
        }
        private void buscarPacientePorNombre(string nombre)
        {
            try
            {
                this.dtgDatos.DataSource = this.conexion.BuscarPacienteNombre(nombre).Tables[0];
                this.dtgDatos.AutoResizeColumns();
                this.dtgDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método buscarClientePorNombre 

        private void dtgDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.mostrarFrmRegistroPacientes(1);
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
        public void EliminarPaciente()
        {
            try
            {
                if (this.dtgDatos.Rows.Count > 0)
                {

                    if (this.dtgDatos.SelectedCells.Count > 0)
                    {
                        string cedula =this.dtgDatos.Rows[this.dtgDatos.SelectedCells[0].RowIndex].Cells["Cédula"].Value.ToString();

                        if (MessageBox.Show("Desea eliminar el paciente con cédula " + cedula, "Confimrar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.conexion.EliminarPaciente(cedula);
                            MessageBox.Show("Se eliminó correctametne");
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
        }//fin del método EliminarPaciente
        //
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.EliminarPaciente();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.mostrarFrmRegistroPacientes(0);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex + "");
            }
        }
    }
}
