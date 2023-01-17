 using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmEstadistica : Form
    {
        Conexion conexion;
        public FrmEstadistica()
        {
            InitializeComponent();
            this.conexion = new Conexion(FrmPrincipal.ObtenerStringConexion());

            this.comboBoxOpcEstadistica.Items.Add("Cantidad de casos por género");
            this.comboBoxOpcEstadistica.Items.Add("Cantidad de casos por provincia");
            this.comboBoxOpcEstadistica.Items.Add("Cantidad de pacientes asintomáticos por género");
            this.comboBoxOpcEstadistica.Items.Add("Cuatro sintomas más comunes en todo el país");
        }

        

        private void FrmEsta_Load(object sender, EventArgs e)
        {
           // cargarDatos();
        }

        private void comboBoxOpcEstadistica_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxOpcEstadistica.SelectedIndex == 0)
            {
                chartBarras.Visible = true;
                chartDona.Visible = false;
                chartBarras.Series[0].Points.DataBindXY(conexion.graficoGeneroPrueba(), conexion.graficoGeneroPrueba2());
            }
  
            if (comboBoxOpcEstadistica.SelectedIndex == 1)
            {
                chartDona.Visible = true;
                chartBarras.Visible = false;
                chartDona.Series[0].Points.DataBindXY(conexion.graficoCantSintomasProvincia(), conexion.graficoCantSintomasProvincia2());
            }
            if (comboBoxOpcEstadistica.SelectedIndex == 2)
            {
                chartBarras.Visible = true;
                chartDona.Visible = false;
                chartBarras.Series[0].Points.DataBindXY(conexion.graficoAsintomaticosGenero(), conexion.graficoAsintomaticosGenero2());
            }
            if (comboBoxOpcEstadistica.SelectedIndex == 3)
            {
                chartBarras.Visible = true;
                chartDona.Visible = false;
                chartBarras.Series[0].Points.DataBindXY(conexion.graficoSintomasComunes(), conexion.graficoSintomasComunes2());
            }

        }
    }
}
