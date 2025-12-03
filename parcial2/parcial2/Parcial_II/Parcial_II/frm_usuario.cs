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
    public partial class frm_usuario : Form
    {
        public frm_usuario()
        {
            InitializeComponent();
        }
        Conexion_base_datos objConexion = new Conexion_base_datos();
        DataSet objDs = new DataSet();
        DataTable objDt = new DataTable();

        public int posicion = 0;
        public string accion = "nuevo";

        private void actualizarDs()
        {
            objDs.Clear();
            objDs = objConexion.crearDs();
            objDt = objDs.Tables["usuario"];
            objDt.PrimaryKey = new DataColumn[] { objDt.Columns["idusuario"] };

            mostrarDatos();
        }
        private void mostrarDatos()
        {
            if (objDt.Rows.Count > 0)
            {
                lblIdUsuario.Text = objDt.Rows[posicion]["idusuario"].ToString();
                txtUsuario.Text = objDt.Rows[posicion]["usuario"].ToString();
                txtClave.Text = objDt.Rows[posicion]["clave"].ToString();
                txtNombre.Text = objDt.Rows[posicion]["nombre"].ToString();
                txtDireccion.Text = objDt.Rows[posicion]["direccion"].ToString();
                txtTelefono.Text = objDt.Rows[posicion]["telefono"].ToString();

                lblRegistroUsuario.Text = (posicion + 1) + " de " + objDt.Rows.Count;
            }
        }
        private void btnSiguienteUsuario_Click(object sender, EventArgs e)
        {
            if (posicion < objDt.Rows.Count - 1)
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
            posicion = objDt.Rows.Count - 1;
            mostrarDatos();
        }
        private void btnPrimeroUsuario_Click(object sender, EventArgs e)
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
        private void limpiarControles()
        {
            lblIdUsuario.Text = "";
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtClave.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if
            (btnAgregar.Text == "Nuevo")
            {
                btnAgregar.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                estadoContrales(true);
                accion = "nuevo";
                limpiarControles();
            }
            else
            {
                String[] usuario =
                {
                  lblIdUsuario.Text, txtUsuario.Text, txtClave.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text
                };
                String respuesta = objConexion.mantenimiento_usuario(usuario, accion);
                if 
                (respuesta != "1")
                {
                  MessageBox.Show(respuesta, "Error al guardar usuario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   estadoContrales(false);
                   btnAgregar.Text = "Nuevo";
                   btnModificar.Text = "Modificar";
                   actualizarDs();
                }                
            }           
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if
           (btnModificar.Text == "Modificar")
            {
                btnAgregar.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                estadoContrales(true);
                accion = "Modificar";
            }
            else
            {
                mostrarDatos();
                estadoContrales(false);
                btnAgregar.Text = "Nuevo";
                btnModificar.Text = "Modificar";
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Se eliminará a "+ txtNombre.Text, "Eliminando usuario", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String respuesta = objConexion.mantenimiento_usuario
                (new String[]
                {lblIdUsuario.Text, "", "", "", "", "",}, "eliminar"
                );
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al eliminar alumno. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDs();
                }
            }
        }
        private void btnSalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {

        }
    }
}
