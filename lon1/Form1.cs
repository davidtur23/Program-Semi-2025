using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lon1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnboton_Click(object sender, EventArgs e)
        {
                double numv = double.Parse(txtcant.Text);
                double me2 = 0;

                string unidadSeleccionada = "";
            if (rdopie.Checked)
            {
                unidadSeleccionada = "PieCuadrado";
            }
            else if (rdovaracuadra.Checked)
            {
                unidadSeleccionada = "VaraCuadrada";
            }
            else if (rdoyarda.Checked)
            {
                unidadSeleccionada = "YardaCuadrada";
            }
            else if (rdometrocuadrado.Checked)
            {
                unidadSeleccionada = "MetroCuadrado";
            }
            else if (rdotareacuadra.Checked)
            {
                unidadSeleccionada = "Tareas";
            }
            else if (rdomanzana.Checked)
            {
                unidadSeleccionada = "Manzana";
            }
            else if (rdohectaria.Checked)
            {
                unidadSeleccionada = "Hectarea";
            };

                switch (unidadSeleccionada)
                {
                    case "PieCuadrado":
                         me2 = numv * 0.0929; break;
                    case "VaraCuadrada":
                         me2 = numv * 0.6989; break;
                    case "YardaCuadrada":
                         me2 = numv * 0.8361; break;
                    case "MetroCuadrado":
                         me2 = numv; break;
                    case "Tareas":
                         me2 = numv * 393; break;
                    case "Manzana":
                         me2 = numv * 7027; break;
                    case "Hectarea":
                         me2 = numv * 10000; break;
                }

                // Mostrar resultados en labels
                lblpiecuadrado.Text = "Pie: " + (me2 / 0.0929).ToString();
                lblvaracuadrada.Text = "Vara: " + (me2 / 0.6989).ToString();
                lblyardacuadrada.Text = "Yarda: " + (me2 / 0.8361).ToString();
                lblmeetrocuadrado.Text = "Metro: " + me2.ToString();
                lbltarea.Text = "Tarea: " + (me2 / 393).ToString();
                lblmanzana.Text = "Manzana: " + (me2 / 7027).ToString();
                lblhecta.Text = "Hectarea: " + (me2 / 10000).ToString();
            }
        }
    }

