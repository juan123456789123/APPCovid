using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
namespace DAL
{
    public class Conexion
    {
        //Objetos que interactual con la BD
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private SqlDataReader dataReader;
        //contenedor de datos
        private DataSet dataSet;
        //variable para almacenar el string de conexion
        private string strConexion;
        //constructor de la clase
        public Conexion(string strCnx)
        {
            this.strConexion = strCnx;
        }//fin constructor
        public DataSet BuscarPacienteNombre(string nombre)
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[SP_Cns_Paciente_Nombre]";
                //asignamos el valor del parámetro del procedimiento
                this.command.Parameters.AddWithValue("@nombre", nombre);
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método para buscar Pacientes por nombre
        public void AgregarPacientes(Paciente paciente)
        {
            try
            {
                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Ins_Paciente]";
                this.command.Parameters.AddWithValue("@cedula",paciente.cedula);
                this.command.Parameters.AddWithValue("@nombreCompleto", paciente.nombreCompleto);
                this.command.Parameters.AddWithValue("@provincia", paciente.provincia);
                this.command.Parameters.AddWithValue("@sexo", paciente.sexo);
                this.command.Parameters.AddWithValue("@edad", paciente.edad);
                this.command.ExecuteNonQuery();
                //Cierre de conexión
                this.connection.Close();
                //Liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método AgregarPacientes
        public void modificarPaciente(Paciente paciente)
        {
            try
            {
                //se instancia la conexión
                this.connection = new SqlConnection(this.strConexion);
                //se abre la conexión
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_upd_Paciente]";
                //se asignan los parámetros
                this.command.Parameters.AddWithValue("@cedula", paciente.cedula);
                this.command.Parameters.AddWithValue("@nombreCompleto", paciente.nombreCompleto);
                this.command.Parameters.AddWithValue("@provincia", paciente.provincia);
                this.command.Parameters.AddWithValue("@sexo", paciente.sexo);
                this.command.Parameters.AddWithValue("@edad", paciente.edad);
           
                //se ejecuta el comando
                this.command.ExecuteNonQuery();
                this.command.Dispose();
                this.connection.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método editar Paciente
        public Paciente BuscarPacienteCedula(string cedula)
        {
            try
            {
                Paciente paciente = null;
                this.connection = new SqlConnection(this.strConexion);
                //se abre la conexión
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Cns_PacienteCedula]";

                this.command.Parameters.AddWithValue("@cedula", cedula);
                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                if (this.dataReader.Read())
                {
                    paciente  = new Paciente();
                    paciente.cedula = this.dataReader.GetValue(0).ToString();
                    paciente.nombreCompleto = this.dataReader.GetValue(1).ToString();
                    paciente.provincia = this.dataReader.GetValue(2).ToString();
                    paciente.sexo = Convert.ToChar(this.dataReader.GetValue(3).ToString());
                    paciente.edad = Convert.ToInt32(this.dataReader.GetValue(4).ToString());
                    //cerramos conexion
                    this.connection.Close();
                    //liberamos recursos
                    this.connection.Dispose();
                    this.command.Dispose();
                    this.dataReader = null;
                }//fin if
                 //se retorna el objeto
                return paciente;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método para buscar Pacientes por cédula
        public void EliminarPaciente(string cedula)
        {
            try
            {
                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Del_Paciente]";
                this.command.Parameters.AddWithValue("@cedula", cedula);
                this.command.ExecuteNonQuery();
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método EliminarPaciente
        //método para consultar cuantos regitros existen en esa tabla
        public int consultarCantRegistros()
        {
            this.connection = new SqlConnection(this.strConexion);
            this.connection.Open();

            this.command = new SqlCommand();
            this.command.Connection = this.connection;
            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = "[Sp_ConsultarSintomas]";

            this.dataReader = this.command.ExecuteReader();
            //pregunta si tiene datos
            if (this.dataReader.Read())
            {
                return Convert.ToInt32(this.dataReader.GetValue(0));
            }
            else return -1;   
            }//fin del método consultarCantRegistros
        public void AgregarRegistroSintoma(Sintomas sintomas)
        {
            try
            {
                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Agregar_RegistroSintoma]";
                this.command.Parameters.AddWithValue("@cedula", sintomas.cedula);
                this.command.Parameters.AddWithValue("@usuario", sintomas.usuario);
                this.command.ExecuteNonQuery();
                //Cierre de conexión
                this.connection.Close();
                //Liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método AgregarRegistroSintoma
        public int consultarIndice()
        {
            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_ConsultarUltimo_Indice]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                if (this.dataReader.Read())
                {
                    return Convert.ToInt32(this.dataReader.GetValue(0));
                }
                else return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoGeneroPrueba()
        {
            ArrayList genero = new ArrayList();
            ArrayList generoCant = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Cns_CantCasos_Género]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while(this.dataReader.Read())
                {
                    genero.Add(this.dataReader.GetString(0));
                    
                }
                // else return -1;
                return genero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoGeneroPrueba2()
        {
            ArrayList generoCant = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Cns_CantCasos_Género]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while(this.dataReader.Read())
                {
                    generoCant.Add(this.dataReader.GetInt32(1));

                }
                // else return -1;
                return generoCant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoCantSintomasProvincia()
        {
            ArrayList provincia = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_cns_CntSintomas_Provincia]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while (this.dataReader.Read())
                {
                    provincia.Add(this.dataReader.GetString(0));

                }
                // else return -1;
                return provincia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoCantSintomasProvincia2()
        {
            ArrayList cantProvincia = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_cns_CntSintomas_Provincia]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while (this.dataReader.Read())
                {
                    cantProvincia.Add(this.dataReader.GetInt32(1));

                }
                // else return -1;
                return cantProvincia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoSintomasComunes()
        {
            ArrayList sintomas = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_cns_SintomasComunes_Provincia]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while (this.dataReader.Read())
                {
                    sintomas.Add(this.dataReader.GetString(0));

                }
                // else return -1;
                return sintomas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoSintomasComunes2()
        {
            ArrayList sintomas = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_cns_SintomasComunes_Provincia]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while (this.dataReader.Read())
                {
                    sintomas.Add(this.dataReader.GetInt32(1));

                }
                // else return -1;
                return sintomas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoAsintomaticosGenero()
        {
            ArrayList genero = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Cns_CantCasos_Asintomatico_Genero]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while (this.dataReader.Read())
                {
                    genero.Add(this.dataReader.GetString(0));

                }
                // else return -1;
                return genero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice

        public ArrayList graficoAsintomaticosGenero2()
        {
            ArrayList cant = new ArrayList();

            try
            {

                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Cns_CantCasos_Asintomatico_Genero]";

                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                while (this.dataReader.Read())
                {
                    cant.Add(this.dataReader.GetInt32(1));

                }
                // else return -1;
                return cant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarIndice







        public void AgregarDetalleSintoma(SintomasDetalle sintomasDetalle)
        {
            try
            {
                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_Agr_DetalleSintomas]";
                this.command.Parameters.AddWithValue("@numRegistro", sintomasDetalle.numRegistro);
                this.command.Parameters.AddWithValue("@codInterno", sintomasDetalle.codInterno);
                this.command.Parameters.AddWithValue("@descripcion", sintomasDetalle.descripcion);
                this.command.Parameters.AddWithValue("@duracion", sintomasDetalle.duracion);
 
                this.command.ExecuteNonQuery();
                //Cierre de conexión
                this.connection.Close();
                //Liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método AgregarDetalleSintoma
        public DataSet ConsultarCasosH_M()
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[CnsCantH_M]";
                //asignamos el valor del parámetro del procedimiento
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método  ConsultarCasosH_M
        public DataSet ConsultarPromedioSintomas()
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[Sp_cnsPromDuracion_Sintomas]";
                //asignamos el valor del parámetro del procedimiento
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método ConsultarPromedioSintomas
        public DataSet ConsultarDatosComunes()
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[Sp_cns_SintomasComunes_Provincia]";
                //asignamos el valor del parámetro del procedimiento
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método ConsultarDatosComunes
        public DataSet ConsultarCasosProvincia()
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[Sp_cns_CntSintomas_Provincia]";
                //asignamos el valor del parámetro del procedimiento
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método ConsultarCasosProvincia
        public DataSet ConsultarCasosGenero()
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[Cns_CantCasos_Género]";
                //asignamos el valor del parámetro del procedimiento
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método ConsultarCasosGenero
        public DataSet BuscarUsuarioLogin(string login)
        {
            try
            {
                //se instancia una conexion
                this.connection = new SqlConnection(this.strConexion);
                //se intenta abrir la conexión
                this.connection.Open();
                //se instancia el comando 
                this.command = new SqlCommand();
                //se asigna la conección al comando
                this.command.Connection = this.connection;
                //se indica el tipo de comando
                this.command.CommandType = CommandType.StoredProcedure;
                //se indica el nombre del procedimiento
                this.command.CommandText = "[Sp_cons_Usuarios]";
                //asignamos el valor del parámetro del procedimiento
                this.command.Parameters.AddWithValue("@login", login);
                //se intancia un adaptador
                this.dataAdapter = new SqlDataAdapter();
                //se instancia un dataSet para guardar los datos
                this.dataAdapter.SelectCommand = this.command;
                this.dataSet = new DataSet();
                //se llena el data set con los datos del comando
                this.dataAdapter.Fill(this.dataSet);
                //se cierran los recursos
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.dataAdapter.Dispose();
                //se retorna el dataset
                return this.dataSet;
            }//fin try
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método para buscar Usuarios por login
        public void AgregarUsuarios(Usuario usuario)
        {
            try
            {
                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_agr_Usuario]";
                this.command.Parameters.AddWithValue("@login", usuario.login);
                this.command.Parameters.AddWithValue("@password", usuario.password);
                this.command.Parameters.AddWithValue("@email", usuario.email);
                this.command.Parameters.AddWithValue("@rol", usuario.rol);
                this.command.ExecuteNonQuery();
                //Cierre de conexión
                this.connection.Close();
                //Liberamos los recursos
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método AgregarUsuarios
        public void modificarUsuario(Usuario usuario)
        {
            try
            {
                //se instancia la conexión
                this.connection = new SqlConnection(this.strConexion);
                //se abre la conexión
                this.connection.Open();
                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_upd_Usuario]";
                //se asignan los parámetros
                this.command.Parameters.AddWithValue("@login", usuario.login);
                this.command.Parameters.AddWithValue("@password", usuario.password);
                this.command.Parameters.AddWithValue("@email", usuario.email);
                this.command.Parameters.AddWithValue("@rol", usuario.rol);

                //se ejecuta el comando
                this.command.ExecuteNonQuery();
                this.command.Dispose();
                this.connection.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método editar Usuario
        public Usuario consultarUsuarioLogin(string login)
        {
            try
            {
                Usuario usuario = null;
                this.connection = new SqlConnection(this.strConexion);
                //se abre la conexión
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Sp_cnsUsuarioLogin]";

                this.command.Parameters.AddWithValue("@login", login);
                this.dataReader = this.command.ExecuteReader();
                //pregunta si tiene datos
                if (this.dataReader.Read())
                {
                    usuario = new Usuario();
                    usuario.login = this.dataReader.GetValue(0).ToString();
                    usuario.email = this.dataReader.GetValue(1).ToString();
                    usuario.password = this.dataReader.GetValue(2).ToString();
                    usuario.rol =   this.dataReader.GetValue(3).ToString();
                    //cerramos conexion
                    this.connection.Close();
                    //liberamos recursos
                    this.connection.Dispose();
                    this.command.Dispose();
                    this.dataReader = null;
                }//fin if
                 //se retorna el objeto
                return usuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método consultarUsuarioLogin
        public void EliminarUsuario(string login)
        {
            try
            {
                this.connection = new SqlConnection(this.strConexion);
                this.connection.Open();

                this.command = new SqlCommand();
                this.command.Connection = this.connection;
                this.command.CommandType = CommandType.StoredProcedure;
                this.command.CommandText = "[Del_Usuario]";
                this.command.Parameters.AddWithValue("@login",login);
                this.command.ExecuteNonQuery();
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin del método EliminarPaciente
    }//fin de la clase conexion
}//fin del namespace
