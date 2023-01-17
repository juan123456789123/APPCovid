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
    public partial class FrmSintomas : Form
    {
        Conexion conexion;
        private Sintomas sintomas;
        private SintomasDetalle sintomasDetalle;
        public FrmSintomas()
        {
            InitializeComponent();
            this.cmbSintomas.Items.Add("Selecione una opción");
            this.cmbSintomas.Items.Add("Tos");
            this.cmbSintomas.Items.Add("Dolor de garganta");
            this.cmbSintomas.Items.Add("Fiebre");
            this.cmbSintomas.Items.Add("Falta de olfato");
            this.cmbSintomas.Items.Add("Diarrea");
            this.cmbSintomas.Items.Add("Falta de gusto");
            this.cmbSintomas.Items.Add("Congestión nasal");
            this.cmbSintomas.Items.Add("Cansancio");
            this.cmbSintomas.Items.Add("Asintomático");
            this.cmbSintomas.Text = "Selecione una opción";
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
        }

        private void ptbSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
         
        }
        //método que valida que la cedula no esté vacia
       
        //método para cargar los datos de un paciente al registro
        public void cargarPaciente()
        {
            try
            {
                if (this.txtCedula.Text.Trim().Equals(""))
                {
                 MessageBox.Show("Por favor digite la cédula del paciente a registrar sintomas");
                }
                else 
                {
                    if (this.conexion.BuscarPacienteCedula(this.txtCedula.Text.Trim()) == null)
                    {
                        MessageBox.Show("El número de cédula consultado no se encuentra registrado en el sistema");
                        this.txtCedula.Text = "";
                    }
                    else 
                    {
                        this.txtNombre.Text = this.conexion.BuscarPacienteCedula(this.txtCedula.Text.Trim()).nombreCompleto;
                        this.txtProvincia.Text = this.conexion.BuscarPacienteCedula(this.txtCedula.Text.Trim()).provincia;
                        this.txtEdad.Text = "" + this.conexion.BuscarPacienteCedula(this.txtCedula.Text.Trim()).edad;
                        this.mostrarFormularioSintomas(true);
                    }
                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método cargarPaciente
        private void btnBucarPaciente_Click(object sender, EventArgs e)
        {
            this.cargarPaciente();
        }
        //método que hace visible el formulario de registro de los sintomas de los pacientes
        public void mostrarFormularioSintomas(bool estado)
        {
            try
            {
                this.gbDatos.Visible = estado;
               // this.gbAciones.Visible = estado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin mostrarFormulario
        public void AgregarSintoma()
        {
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dtgDatos);
            if (!this.txtOpcional.Text.Trim().Equals(""))
            {

                file.Cells[0].Value = this.txtOpcional.Text.Trim();
                file.Cells[1].Value = this.txtDuracion1.Text.Trim(); 
            }
            else 
            {
                file.Cells[0].Value = this.cmbSintomas.SelectedItem.ToString();
                file.Cells[1].Value = this.txtDuracion1.Text.Trim();
            }
            dtgDatos.Rows.Add(file);
            this.limpiar();

        }//fin del método AgregarSintoma

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!this.cmbSintomas.SelectedItem.ToString().Equals("Selecione una opción") && !this.txtOpcional.Text.Trim().Equals(""))
            {
                MessageBox.Show("Por favor selecione un síntoma a la vez");
            }
            else 
            {
                if (this.txtOpcional.Text.Trim().Equals(""))
                {
                    if (this.cmbSintomas.SelectedItem.ToString().Equals("Selecione una opción"))
                    {
                        MessageBox.Show("Por favor selecione un síntoma a agregar");
                    }
                }
                if (this.txtDuracion1.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Por favor selecione la duración del síntoma");
                }
                else
                {
                    this.AgregarSintoma();
                }
            } 
        }
        public void limpiar()
        {
            this.txtOpcional.Text = "";
            this.txtDuracion1.Text = "";
            this.cmbSintomas.Text = "Selecione una opción";
        }//fin del método  limpiar
        public void CrearObjetoSintoma()
        {
            this.validaciones();
            this.sintomas.cedula = this.txtCedula.Text.Trim();
            //fecha se maneja a nivel de base de datos.
            this.sintomas.usuario = "admin";
        }//
        public void validaciones()
        { 
        
        }//
        public void CrearRegistroSintoma()
        {
            try
            {
                this.sintomas = new Sintomas();
                if (this.conexion.consultarCantRegistros() != -1)
                {
                    this.CrearObjetoSintoma();
                    this.conexion.AgregarRegistroSintoma(this.sintomas);
                    
                }
                else MessageBox.Show("Error");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//fin del método
        public void AgregarDetalleSintomas()
        {
            try
            {
                this.CrearRegistroSintoma();
                int consecutivo = 1;
                foreach (DataGridViewRow row in dtgDatos.Rows)
                {
                    this.sintomasDetalle = new SintomasDetalle();
                    this.sintomasDetalle.numRegistro = this.conexion.consultarIndice();
                    this.sintomasDetalle.codInterno = consecutivo;
                    this.sintomasDetalle.descripcion = Convert.ToString(row.Cells["Sintoma"].Value.ToString());
                    this.sintomasDetalle.duracion = Convert.ToInt32((row.Cells["Duracion"].Value.ToString()));
                    this.conexion.AgregarDetalleSintoma(this.sintomasDetalle);
                    consecutivo++;
                }//fin del foreach
                foreach (DataGridViewRow row in dtgDatos.Rows)
                {
                    dtgDatos.Rows.Remove(dtgDatos.CurrentRow);
                }//fin del foreach
                MessageBox.Show("Se Registró el caso de covid de la persona: " + this.txtNombre.Text.Trim());
                this.limpiarPanelPaciente();
                //dtgDatos.Rows.Remove(dtgDatos.CurrentRow);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }// fin del método cargarSintomas
        public void limpiarPanelPaciente()
        {
            try
            {
                this.txtCedula.Text = "";
                this.txtNombre.Text = "";
                this.txtProvincia.Text = "";
                this.txtEdad.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }//
        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDatos.Rows.Count == 0)
                {
                    MessageBox.Show("Por favor agregue síntomas a registrar para el paciente");
                }
                else
                {
                    this.AgregarDetalleSintomas();
                }  
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                dtgDatos.Rows.Remove(dtgDatos.CurrentRow);
            }
            catch (Exception ex)
            {

                MessageBox.Show("No hay síntomas asignados a este paciente");
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDuracion1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo numeros", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtOpcional_KeyPress(object sender, KeyPressEventArgs e)
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

        private void iconPictureBuscar_Click(object sender, EventArgs e)
        {
            this.cargarPaciente();
        }

        private void iconButtonAgregar_Click(object sender, EventArgs e)
        {

            if (!this.cmbSintomas.SelectedItem.ToString().Equals("Selecione una opción") && !this.txtOpcional.Text.Trim().Equals(""))
            {
                MessageBox.Show("Por favor selecione un síntoma a la vez");
            }
            else
            {
                if (this.txtOpcional.Text.Trim().Equals(""))
                {
                    if (!this.txtDuracion1.Text.Trim().Equals(""))
                    {
                        if (this.cmbSintomas.SelectedItem.ToString().Equals("Selecione una opción"))
                        {
                            MessageBox.Show("Por favor selecione un síntoma a agregar");
                        }
                        else
                        {
                            this.AgregarSintoma();
                        }
                    }
                    else
                    {
                        
                        MessageBox.Show("Por favor selecione la duración del síntoma");
                    }
                }
           
            }
        }

        private void dtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }//fin de la clase
}//fin namespace




