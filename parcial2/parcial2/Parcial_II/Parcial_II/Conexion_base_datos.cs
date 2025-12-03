using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Parcial_II
{
    class Conexion_base_datos
    {
        public SqlConnection objConexion = new SqlConnection(); 
        public SqlCommand objComando = new SqlCommand();       
        public SqlDataAdapter objAdaptador = new SqlDataAdapter(); 
        DataSet objCrearDs = new DataSet();

        public Conexion_base_datos()
        {
            String cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bd_academica.mdf;Integrated Security=True";
            objConexion.ConnectionString = cadenaConexion;
            objConexion.Open();
        }

        public DataSet crearDs()
        {
            objCrearDs.Clear();
            objComando.Connection = objConexion;

            objComando.CommandText = "SELECT * FROM usuario";
            objAdaptador.SelectCommand = objComando;
            objAdaptador.Fill(objCrearDs, "usuario");

            return objCrearDs;
        }
        public string mantenimiento_usuario (String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo")
            {
                sql = "INSERT INTO usuario(usuario, clave, nombre, direccion, telefono) VALUES (@usuario, @clave, @nombre, @direccion, @telefono)";
            }
            else if (accion == "modificar")
            {
                sql = "UPDATE usuario SET usuario=@Idusuario, @usuario, @clave, @nombre, @direccion, @telefono WHERE Idusuario=@Idusuario";
            }
            else if (accion == "eliminar")
            {
                sql = "DELETED FROM usuario WHERE Idusuario=@Idusuario";
            }
            return procesar (sql, datos);
            
        } 
        private String procesar (string sql, String[] datos)
        {
            try
            {
                objComando.Connection = objConexion;              
                objComando.CommandText = sql;

                objComando.Parameters.Clear();

                
                objComando.Parameters.AddWithValue("@usuario", datos[1]);
                objComando.Parameters.AddWithValue("@clave", datos[2]);
                objComando.Parameters.AddWithValue("@nombre", datos[3]);
                objComando.Parameters.AddWithValue("@direccion", datos[4]);
                objComando.Parameters.AddWithValue("@telefono", datos[5]);

                return objComando.ExecuteNonQuery().ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
          
        }
        
    }
}
