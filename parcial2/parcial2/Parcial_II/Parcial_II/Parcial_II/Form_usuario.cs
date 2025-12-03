using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_II
{
    public partial class Form_usuario : Form
    {
        public Form_usuario()
        {
            InitializeComponent();
        }
        Conexion objConexion = new Conexion();
        DataSet objDs = new DataSet();
        DataTable objDt = new DataTable();

        public int posicion = 0;
        public string accion = "nuevo";

        private void actualizarDs()
        {
            objDs.Clear();
            objDs = objConexion.obtenerDatos();
            objDt = objDs.Tables["usuarios"];
            objDt.PrimaryKey = new DataColumn[] { objDt.Columns["idusuario"] };

            mostrarDatos();
        }

        private void mostrarDatos()
        {
            if( objDt.Rows.Count>0)
            {
                lblIdUsuario.Text = objDt.Rows[posicion]["id_usuario:"].ToString();
                txtClave.Text = objDt.Rows[posicion]["Clave"].ToString();
                textNombre.Text = objDt.Rows[posicion]["nombre"].ToString();
                txtDireccion.Text = objDt.Rows[posicion]["dirección"].ToString();
                txtTelefono.Text = objDt.Rows[posicion]["Telefono:"].ToString();

                lblRegistroUsuario.Text = (posicion + 1) + " de " + objDt.Rows.Count;
            }    
                

        }

        private void btnSiguienteUsuario_Click(object sender, EventArgs e)
        {
           if (posicion<objDt.Rows.Count - 1)
           {
             posicion++;
             mostrarDatos();              
           }

           else
           {
                MessageBox.Show("estas en el ultimo registro.", "Navegación de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);

           }
             
        }

        private void btnAnteriorUsuario_Click(object sender, EventArgs e)
        {
          if (posicion > 0)
          {
                posicion--;
                mostrarDatos();
          }

            else 
            {
                MessageBox.Show("este es el primer registro.", "Navegación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUltimoUsuario_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }
        private void estadoContrales(Boolean estado)
        {
            grbDatosUsuario.Enabled = estado;
            grbNavegacionUsuario.Enabled = !estado;
            btnEliminarUsuario.Enabled = !estado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
          if (btnAgregar.Text == "Nuevo")
              btnAgregar.Text = "Guardar";
              btnModificar.Text = "Cancelar";
              estadoContrales(true);
              accion = "nuevo";
        }

        else 
        {
        estadoControles(false);
        btnAgregar.Text = "Nuevo"
        }
        
        
        
        
        
    }
}
