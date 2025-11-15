using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pa1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtnum.Text, out double monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            double impuesto = 0;
            double precioFijo = 0;
            double adicional = 0;

            // Condicionales por rango
            if (monto <= 500) {
                precioFijo = 1.5; adicional = 0; impuesto = precioFijo;
            }
            else if (monto <= 1000) {
                precioFijo = 1.5; adicional = 3; impuesto = precioFijo + (monto - 500.01) / 1000 * adicional; 
            }
            else if (monto <= 2000) {
                precioFijo = 3; adicional = 3; impuesto = precioFijo + (monto - 1000.01) / 1000 * adicional;
            }
            else if (monto <= 3000) { 
                precioFijo = 6; adicional = 3; impuesto = precioFijo + (monto - 2000.01) / 1000 * adicional;
            }
            else if (monto <= 6000) {
                precioFijo = 9; adicional = 2; impuesto = precioFijo + (monto - 3000.01) / 1000 * adicional;
            }
            else if (monto <= 18000) {
                precioFijo = 15; adicional = 2; impuesto = precioFijo + (monto - 8000.01) / 1000 * adicional;
            }
            else if (monto <= 30000) {
                precioFijo = 39; adicional = 2; impuesto = precioFijo + (monto - 18000.01) / 1000 * adicional;
            }
            else if (monto <= 60000) {
                precioFijo = 63; adicional = 1; impuesto = precioFijo + (monto - 30000.01) / 1000 * adicional;
            }
            else if (monto <= 100000) { 
                precioFijo = 93; adicional = 0.8; impuesto = precioFijo + (monto - 60000.01) / 1000 * adicional;
            }
            else if (monto <= 200000) {
                precioFijo = 125; adicional = 0.7; impuesto = precioFijo + (monto - 100000.01) / 1000 * adicional;
            }
            else if (monto <= 300000) {
                precioFijo = 195; adicional = 0.6; impuesto = precioFijo + (monto - 200000.01) / 1000 * adicional; 
            }
            else if (monto <= 400000) {
                precioFijo = 255; adicional = 0.45; impuesto = precioFijo + (monto - 300000.01) / 1000 * adicional;
            }
            else if (monto <= 500000) { 
                precioFijo = 300; adicional = 0.4; impuesto = precioFijo + (monto - 400000.01) / 1000 * adicional;
            }
            else if (monto <= 1000000) {
                precioFijo = 340; adicional = 0.3; impuesto = precioFijo + (monto - 500000.01) / 1000 * adicional;
            }
            else {
                precioFijo = 490; adicional = 0.18; impuesto = precioFijo + (monto - 1000000.01) / 1000 * adicional;
            }

            
            lblpread.Text = "Precio fijo: " + precioFijo + "   Adicional: " + adicional;

           
            lbltotal.Text = $"Impuesto total: ${Math.Round(impuesto, 2)}";
        }
    }
    }

