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
    public partial class FrmAgregarPaciente : Form
    {
        private Conexion conexion;
        private Paciente paciente;
        private int function = 0;
        private string cedulaConsultar;
        public FrmAgregarPaciente()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());
            this.cmbSexo.Items.Add("Selecione una opción");
            this.cmbSexo.Items.Add("H");
            this.cmbSexo.Items.Add("M");
            this.cmbSexo.Text="Selecione una opción";
            this.cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            this.cmbProvincia.Items.Add("Selecione una opción");
            this.cmbProvincia.Items.Add("San José");
            this.cmbProvincia.Items.Add("Alajuela");
            this.cmbProvincia.Items.Add("Heredia");
            this.cmbProvincia.Items.Add("Cartago");
            this.cmbProvincia.Items.Add("Guanacaste");
            this.cmbProvincia.Items.Add("Puntarenas");
            this.cmbProvincia.Items.Add("Limón");
            this.cmbProvincia.Text = "Selecione una opción";
            this.cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //metodo para cerrar el frm
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //método para validar los datos del paciente
        public void validaciones()
        {
            try
            {
                if (this.txtCedula.Text.Trim().Equals(""))
                {
                    throw new Exception("Error el campo Cédula no puede estar vacio");
                }
                if (this.txtNombreCompleto.Text.Trim().Equals(""))
                {
                    throw new Exception("Error el campo Nombre Completo no debe estar vacio");
                }
                if (this.txtEdad.Text.Trim().Equals(""))
                {
                    throw new Exception("Error el campo Edad no debe estar vacio");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//fin del método validaciones
        public string valdiarsexo()
        {
            if (cmbSexo.SelectedItem.ToString().Equals("Selecione una opción"))
            {
                return "null";
            }
            else 
            {
                return "";
            }
        }
        public void crearObjetoPaciente()
        {
            try
            {
                this.validaciones();
                this.paciente = new Paciente();
                this.paciente.cedula = this.txtCedula.Text.Trim();
                this.paciente.nombreCompleto = this.txtNombreCompleto.Text.Trim();
                this.paciente.provincia = this.cmbProvincia.SelectedItem.ToString();
                if (!this.cmbSexo.SelectedItem.Equals("Selecione una opción"))
                {
                    this.paciente.sexo = Convert.ToChar(this.cmbSexo.SelectedItem.ToString());
                }
                this.paciente.edad = Convert.ToInt32(this.txtEdad.Text.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método crear objeto paciente
        public void setFuncion(int valor)
        {
            this.function = valor;
        }//fin del método setFuncion
        public void limpiarFormulario()
        {
            this.txtCedula.Text = "";
            this.txtNombreCompleto.Text = "";
            this.cmbProvincia.Text = "Selecione una opción";
            this.cmbSexo.Text = "Selecione una opción";
            this.txtEdad.Text = "";
        }//fin del método limpiarFormulario
        private void FrmFormularioPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                //logica de negocio= 1 es modificar
                if (this.function == 1)
                {
                    //el valor 1 representa la funcion de modificar
                    this.btnAciones.Text = "Modificar";
                    //mostrar el login del usuario a modificar
                    this.txtCedula.Text = cedulaConsultar;
                    //el login se convierte en solo lectura
                    this.txtCedula.ReadOnly = true;
                    //se llama al método consultar para mostrar los datos
                    this.consultarPaciente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void setCedulaConsultar(string valor)
        {
            this.cedulaConsultar = valor;
        }//fin del método setCedulaConsultar
        //metodo encargado de agregar los pacientes
        public void AgregarPaciente()
        {
            try
            {
                if (cmbProvincia.SelectedItem.ToString().Equals("Selecione una opción"))
                {
                    MessageBox.Show("Porfavor selecione una provincia");
                }
                if (this.valdiarsexo().Equals("null"))
                {
                    MessageBox.Show("Porfavor selecione el sexo");
                }
                else 
                {
                    this.conexion.AgregarPacientes(this.paciente);
                    MessageBox.Show("Paciente registrado Correctamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limpiarFormulario();
                }
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
                this.crearObjetoPaciente();
                if (this.function == 0)
                {
                    Paciente temp = this.conexion.BuscarPacienteCedula(this.txtCedula.Text.Trim());
                    if (temp == null)
                    {
                        this.AgregarPaciente();
                    }
                    else 
                    {
                        MessageBox.Show("Error el Paciente ya se encuentra registrado");
                    }
                   
                }//fin if
                else
                {
                    if (MessageBox.Show("Desea aplicar los cambios", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.modificarPaciente();
                        this.limpiarFormulario();
                        MessageBox.Show("Paciente Modificado Correctamente.", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//
        public void modificarPaciente()
        {
            try
            {
                this.conexion.modificarPaciente(this.paciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método modificarPaciente
        public void consultarPaciente()
        {
            try
            {
                //se reyenan los datos
                this.paciente = this.conexion.BuscarPacienteCedula(this.cedulaConsultar);
                if (this.paciente != null)
                {
                   this.txtCedula.Text = "" + this.paciente.cedula;
                   this.txtNombreCompleto.Text = "" + this.paciente.nombreCompleto;
                   this.cmbProvincia.Text = "" + this.paciente.provincia;
                   this.cmbSexo.Text = "" + this.paciente.sexo;
                   this.txtEdad.Text = "" + this.paciente.edad;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarProducto

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
                MessageBox.Show("Sólo se permiten caracteres numéricos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("Sólo se permiten caracteres numéricos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddPaci_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    FrmPrincipal frm = new FrmPrincipal();
                    frm.ShowDialog();
                    frm.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//fin
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
