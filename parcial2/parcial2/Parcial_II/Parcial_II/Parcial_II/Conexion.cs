using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Parcial_II
{
    class Conexion
    {
        public SqlConnection objConexion = new SqlConnection(); // Conectarme a la BD.
        public SqlCommand objComando = new SqlCommand();        // Ejecutar SQL en BD.
        public SqlDataAdapter objAdaptador = new SqlDataAdapter(); // Puente entre la BD y la aplicación.
        DataSet objDs = new DataSet();

        public Conexion()
        {
            String cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bd_academica.mdf;Integrated Security=True";
            objConexion.ConnectionString = cadenaConexion;
            objConexion.Open();
        }

        public DataSet obtenerDatos()
        {
            objDs.Clear();
            objComando.Connection = objConexion;

            objComando.CommandText = "SELECT * FROM usuario";
            objAdaptador.Fill(objDs, "usuario");

            return objDs;
        }


      



    }
}
