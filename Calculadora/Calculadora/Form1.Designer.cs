namespace Calculadora
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
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button_menos = new System.Windows.Forms.Button();
            this.button_suma = new System.Windows.Forms.Button();
            this.button_borrar = new System.Windows.Forms.Button();
            this.button_div = new System.Windows.Forms.Button();
            this.button_mult = new System.Windows.Forms.Button();
            this.button_backspace = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button_p_der = new System.Windows.Forms.Button();
            this.button_p_izq = new System.Windows.Forms.Button();
            this.button_result = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtResultado.Location = new System.Drawing.Point(12, 13);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(296, 53);
            this.txtResultado.TabIndex = 0;
            this.txtResultado.Text = "0";
            this.txtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button1.Location = new System.Drawing.Point(13, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button2.Location = new System.Drawing.Point(73, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button3.Location = new System.Drawing.Point(134, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button6.Location = new System.Drawing.Point(134, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 45);
            this.button6.TabIndex = 7;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button5.Location = new System.Drawing.Point(73, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 45);
            this.button5.TabIndex = 6;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button4.Location = new System.Drawing.Point(13, 157);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 45);
            this.button4.TabIndex = 5;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button9.Location = new System.Drawing.Point(134, 222);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(45, 45);
            this.button9.TabIndex = 10;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button8.Location = new System.Drawing.Point(73, 222);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(45, 45);
            this.button8.TabIndex = 9;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button7.Location = new System.Drawing.Point(13, 222);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(45, 45);
            this.button7.TabIndex = 8;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button_menos
            // 
            this.button_menos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_menos.Location = new System.Drawing.Point(199, 222);
            this.button_menos.Name = "button_menos";
            this.button_menos.Size = new System.Drawing.Size(45, 45);
            this.button_menos.TabIndex = 13;
            this.button_menos.Text = "-";
            this.button_menos.UseVisualStyleBackColor = true;
            this.button_menos.Click += new System.EventHandler(this.click_operador);
            // 
            // button_suma
            // 
            this.button_suma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_suma.Location = new System.Drawing.Point(199, 157);
            this.button_suma.Name = "button_suma";
            this.button_suma.Size = new System.Drawing.Size(45, 45);
            this.button_suma.TabIndex = 12;
            this.button_suma.Text = "+";
            this.button_suma.UseVisualStyleBackColor = true;
            this.button_suma.Click += new System.EventHandler(this.click_operador);
            // 
            // button_borrar
            // 
            this.button_borrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_borrar.Location = new System.Drawing.Point(199, 92);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(45, 45);
            this.button_borrar.TabIndex = 11;
            this.button_borrar.Text = "C";
            this.button_borrar.UseVisualStyleBackColor = true;
            this.button_borrar.Click += new System.EventHandler(this.button_borrar_Click);
            // 
            // button_div
            // 
            this.button_div.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_div.Location = new System.Drawing.Point(263, 222);
            this.button_div.Name = "button_div";
            this.button_div.Size = new System.Drawing.Size(45, 45);
            this.button_div.TabIndex = 16;
            this.button_div.Text = "/";
            this.button_div.UseVisualStyleBackColor = true;
            this.button_div.Click += new System.EventHandler(this.click_operador);
            // 
            // button_mult
            // 
            this.button_mult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_mult.Location = new System.Drawing.Point(263, 157);
            this.button_mult.Name = "button_mult";
            this.button_mult.Size = new System.Drawing.Size(45, 45);
            this.button_mult.TabIndex = 15;
            this.button_mult.Text = "*";
            this.button_mult.UseVisualStyleBackColor = true;
            this.button_mult.Click += new System.EventHandler(this.click_operador);
            // 
            // button_backspace
            // 
            this.button_backspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_backspace.Location = new System.Drawing.Point(263, 92);
            this.button_backspace.Name = "button_backspace";
            this.button_backspace.Size = new System.Drawing.Size(45, 45);
            this.button_backspace.TabIndex = 14;
            this.button_backspace.Text = "<-";
            this.button_backspace.UseVisualStyleBackColor = true;
            this.button_backspace.Click += new System.EventHandler(this.button_backspace_Click);
            // 
            // button0
            // 
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button0.Location = new System.Drawing.Point(72, 283);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(45, 45);
            this.button0.TabIndex = 17;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.AgregarNumero);
            // 
            // button_p_der
            // 
            this.button_p_der.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_p_der.Location = new System.Drawing.Point(198, 283);
            this.button_p_der.Name = "button_p_der";
            this.button_p_der.Size = new System.Drawing.Size(45, 45);
            this.button_p_der.TabIndex = 19;
            this.button_p_der.Text = ")";
            this.button_p_der.UseVisualStyleBackColor = true;
            this.button_p_der.Click += new System.EventHandler(this.button_p_der_Click);
            // 
            // button_p_izq
            // 
            this.button_p_izq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_p_izq.Location = new System.Drawing.Point(134, 283);
            this.button_p_izq.Name = "button_p_izq";
            this.button_p_izq.Size = new System.Drawing.Size(45, 45);
            this.button_p_izq.TabIndex = 18;
            this.button_p_izq.Text = "(";
            this.button_p_izq.UseVisualStyleBackColor = true;
            this.button_p_izq.Click += new System.EventHandler(this.button_p_izq_Click);
            // 
            // button_result
            // 
            this.button_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_result.Location = new System.Drawing.Point(263, 283);
            this.button_result.Name = "button_result";
            this.button_result.Size = new System.Drawing.Size(45, 45);
            this.button_result.TabIndex = 20;
            this.button_result.Text = "=";
            this.button_result.UseVisualStyleBackColor = true;
            this.button_result.Click += new System.EventHandler(this.button_result_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 352);
            this.Controls.Add(this.button_result);
            this.Controls.Add(this.button_p_der);
            this.Controls.Add(this.button_p_izq);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button_div);
            this.Controls.Add(this.button_mult);
            this.Controls.Add(this.button_backspace);
            this.Controls.Add(this.button_menos);
            this.Controls.Add(this.button_suma);
            this.Controls.Add(this.button_borrar);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtResultado);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button_menos;
        private System.Windows.Forms.Button button_suma;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.Button button_div;
        private System.Windows.Forms.Button button_mult;
        private System.Windows.Forms.Button button_backspace;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button_p_der;
        private System.Windows.Forms.Button button_p_izq;
        private System.Windows.Forms.Button button_result;
    }
}

