
namespace lon1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtcant = new System.Windows.Forms.TextBox();
            this.btnboton = new System.Windows.Forms.Button();
            this.rdopie = new System.Windows.Forms.RadioButton();
            this.rdovaracuadra = new System.Windows.Forms.RadioButton();
            this.rdoyarda = new System.Windows.Forms.RadioButton();
            this.rdometrocuadrado = new System.Windows.Forms.RadioButton();
            this.rdotareacuadra = new System.Windows.Forms.RadioButton();
            this.rdomanzana = new System.Windows.Forms.RadioButton();
            this.rdohectaria = new System.Windows.Forms.RadioButton();
            this.lblpiecuadrado = new System.Windows.Forms.Label();
            this.lblvaracuadrada = new System.Windows.Forms.Label();
            this.lblyardacuadrada = new System.Windows.Forms.Label();
            this.lblmeetrocuadrado = new System.Windows.Forms.Label();
            this.lbltarea = new System.Windows.Forms.Label();
            this.lblmanzana = new System.Windows.Forms.Label();
            this.lblhecta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtcant
            // 
            this.txtcant.Location = new System.Drawing.Point(228, 73);
            this.txtcant.Name = "txtcant";
            this.txtcant.Size = new System.Drawing.Size(286, 20);
            this.txtcant.TabIndex = 0;
            this.txtcant.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnboton
            // 
            this.btnboton.Location = new System.Drawing.Point(582, 63);
            this.btnboton.Name = "btnboton";
            this.btnboton.Size = new System.Drawing.Size(97, 38);
            this.btnboton.TabIndex = 1;
            this.btnboton.Text = "calcular";
            this.btnboton.UseVisualStyleBackColor = true;
            this.btnboton.Click += new System.EventHandler(this.btnboton_Click);
            // 
            // rdopie
            // 
            this.rdopie.AutoSize = true;
            this.rdopie.Location = new System.Drawing.Point(420, 122);
            this.rdopie.Name = "rdopie";
            this.rdopie.Size = new System.Drawing.Size(87, 17);
            this.rdopie.TabIndex = 2;
            this.rdopie.TabStop = true;
            this.rdopie.Text = "pie cuadrado";
            this.rdopie.UseVisualStyleBackColor = true;
            // 
            // rdovaracuadra
            // 
            this.rdovaracuadra.AutoSize = true;
            this.rdovaracuadra.Location = new System.Drawing.Point(420, 157);
            this.rdovaracuadra.Name = "rdovaracuadra";
            this.rdovaracuadra.Size = new System.Drawing.Size(94, 17);
            this.rdovaracuadra.TabIndex = 3;
            this.rdovaracuadra.TabStop = true;
            this.rdovaracuadra.Text = "vara cuadrada";
            this.rdovaracuadra.UseVisualStyleBackColor = true;
            // 
            // rdoyarda
            // 
            this.rdoyarda.AutoSize = true;
            this.rdoyarda.Location = new System.Drawing.Point(420, 195);
            this.rdoyarda.Name = "rdoyarda";
            this.rdoyarda.Size = new System.Drawing.Size(51, 17);
            this.rdoyarda.TabIndex = 4;
            this.rdoyarda.TabStop = true;
            this.rdoyarda.Text = "yarda";
            this.rdoyarda.UseVisualStyleBackColor = true;
            // 
            // rdometrocuadrado
            // 
            this.rdometrocuadrado.AutoSize = true;
            this.rdometrocuadrado.Location = new System.Drawing.Point(420, 233);
            this.rdometrocuadrado.Name = "rdometrocuadrado";
            this.rdometrocuadrado.Size = new System.Drawing.Size(99, 17);
            this.rdometrocuadrado.TabIndex = 5;
            this.rdometrocuadrado.TabStop = true;
            this.rdometrocuadrado.Text = "metro cuadrado";
            this.rdometrocuadrado.UseVisualStyleBackColor = true;
            // 
            // rdotareacuadra
            // 
            this.rdotareacuadra.AutoSize = true;
            this.rdotareacuadra.Location = new System.Drawing.Point(420, 267);
            this.rdotareacuadra.Name = "rdotareacuadra";
            this.rdotareacuadra.Size = new System.Drawing.Size(97, 17);
            this.rdotareacuadra.TabIndex = 6;
            this.rdotareacuadra.TabStop = true;
            this.rdotareacuadra.Text = "tarea cuadrada";
            this.rdotareacuadra.UseVisualStyleBackColor = true;
            // 
            // rdomanzana
            // 
            this.rdomanzana.AutoSize = true;
            this.rdomanzana.Location = new System.Drawing.Point(420, 308);
            this.rdomanzana.Name = "rdomanzana";
            this.rdomanzana.Size = new System.Drawing.Size(68, 17);
            this.rdomanzana.TabIndex = 7;
            this.rdomanzana.TabStop = true;
            this.rdomanzana.Text = "manzana";
            this.rdomanzana.UseVisualStyleBackColor = true;
            // 
            // rdohectaria
            // 
            this.rdohectaria.AutoSize = true;
            this.rdohectaria.Location = new System.Drawing.Point(420, 344);
            this.rdohectaria.Name = "rdohectaria";
            this.rdohectaria.Size = new System.Drawing.Size(67, 17);
            this.rdohectaria.TabIndex = 8;
            this.rdohectaria.TabStop = true;
            this.rdohectaria.Text = "hectarea";
            this.rdohectaria.UseVisualStyleBackColor = true;
            // 
            // lblpiecuadrado
            // 
            this.lblpiecuadrado.AutoSize = true;
            this.lblpiecuadrado.Location = new System.Drawing.Point(191, 137);
            this.lblpiecuadrado.Name = "lblpiecuadrado";
            this.lblpiecuadrado.Size = new System.Drawing.Size(69, 13);
            this.lblpiecuadrado.TabIndex = 9;
            this.lblpiecuadrado.Text = "pie cuadrado";
            // 
            // lblvaracuadrada
            // 
            this.lblvaracuadrada.AutoSize = true;
            this.lblvaracuadrada.Location = new System.Drawing.Point(191, 172);
            this.lblvaracuadrada.Name = "lblvaracuadrada";
            this.lblvaracuadrada.Size = new System.Drawing.Size(76, 13);
            this.lblvaracuadrada.TabIndex = 10;
            this.lblvaracuadrada.Text = "vara cuadrada";
            // 
            // lblyardacuadrada
            // 
            this.lblyardacuadrada.AutoSize = true;
            this.lblyardacuadrada.Location = new System.Drawing.Point(191, 199);
            this.lblyardacuadrada.Name = "lblyardacuadrada";
            this.lblyardacuadrada.Size = new System.Drawing.Size(81, 13);
            this.lblyardacuadrada.TabIndex = 11;
            this.lblyardacuadrada.Text = "yarda cuadrada";
            // 
            // lblmeetrocuadrado
            // 
            this.lblmeetrocuadrado.AutoSize = true;
            this.lblmeetrocuadrado.Location = new System.Drawing.Point(191, 233);
            this.lblmeetrocuadrado.Name = "lblmeetrocuadrado";
            this.lblmeetrocuadrado.Size = new System.Drawing.Size(81, 13);
            this.lblmeetrocuadrado.TabIndex = 12;
            this.lblmeetrocuadrado.Text = "metro cuadrado";
            // 
            // lbltarea
            // 
            this.lbltarea.AutoSize = true;
            this.lbltarea.Location = new System.Drawing.Point(191, 267);
            this.lbltarea.Name = "lbltarea";
            this.lbltarea.Size = new System.Drawing.Size(79, 13);
            this.lbltarea.TabIndex = 13;
            this.lbltarea.Text = "tarea cuadrada";
            // 
            // lblmanzana
            // 
            this.lblmanzana.AutoSize = true;
            this.lblmanzana.Location = new System.Drawing.Point(191, 308);
            this.lblmanzana.Name = "lblmanzana";
            this.lblmanzana.Size = new System.Drawing.Size(50, 13);
            this.lblmanzana.TabIndex = 14;
            this.lblmanzana.Text = "manzana";
            // 
            // lblhecta
            // 
            this.lblhecta.AutoSize = true;
            this.lblhecta.Location = new System.Drawing.Point(191, 344);
            this.lblhecta.Name = "lblhecta";
            this.lblhecta.Size = new System.Drawing.Size(45, 13);
            this.lblhecta.TabIndex = 15;
            this.lblhecta.Text = "hectaria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "cantidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "conversor de area";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblhecta);
            this.Controls.Add(this.lblmanzana);
            this.Controls.Add(this.lbltarea);
            this.Controls.Add(this.lblmeetrocuadrado);
            this.Controls.Add(this.lblyardacuadrada);
            this.Controls.Add(this.lblvaracuadrada);
            this.Controls.Add(this.lblpiecuadrado);
            this.Controls.Add(this.rdohectaria);
            this.Controls.Add(this.rdomanzana);
            this.Controls.Add(this.rdotareacuadra);
            this.Controls.Add(this.rdometrocuadrado);
            this.Controls.Add(this.rdoyarda);
            this.Controls.Add(this.rdovaracuadra);
            this.Controls.Add(this.rdopie);
            this.Controls.Add(this.btnboton);
            this.Controls.Add(this.txtcant);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcant;
        private System.Windows.Forms.Button btnboton;
        private System.Windows.Forms.RadioButton rdopie;
        private System.Windows.Forms.RadioButton rdovaracuadra;
        private System.Windows.Forms.RadioButton rdoyarda;
        private System.Windows.Forms.RadioButton rdometrocuadrado;
        private System.Windows.Forms.RadioButton rdotareacuadra;
        private System.Windows.Forms.RadioButton rdomanzana;
        private System.Windows.Forms.RadioButton rdohectaria;
        private System.Windows.Forms.Label lblpiecuadrado;
        private System.Windows.Forms.Label lblvaracuadrada;
        private System.Windows.Forms.Label lblyardacuadrada;
        private System.Windows.Forms.Label lblmeetrocuadrado;
        private System.Windows.Forms.Label lbltarea;
        private System.Windows.Forms.Label lblmanzana;
        private System.Windows.Forms.Label lblhecta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

