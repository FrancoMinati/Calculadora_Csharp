using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculadora
{
    public partial class Form1 : Form
    {
        Regex operandos = new Regex(@"(-?[1-9]\d*)");
        Regex operadores = new Regex(@"[\+\-\/\*\^\%]");
        Regex operacion_basica = new Regex(@"([\d+(\.\d+)]*[\+\-\/\*\^\%]+[\d+(\.\d+)]*)");
        List<int> valores = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }
        



        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
                txtResultado.Text = "";
            txtResultado.Text += boton.Text;

        }

        private void button_borrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }
        private void click_operador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
                txtResultado.Text += boton.Text;
            }
            else
            {

                String texto = boton.Text;
                char caracter = txtResultado.Text[txtResultado.Text.Length - 1];
                if (!operadores.IsMatch("" + txtResultado.Text[txtResultado.Text.Length - 1]))
                {
                    txtResultado.Text = txtResultado.Text.TrimEnd();
                    txtResultado.Text += boton.Text;
                }
                else
                {
                    txtResultado.Text = txtResultado.Text.Replace(caracter, Convert.ToChar(boton.Text));

                }
            }
        }

        private void button_backspace_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            if (txtResultado.Text.Length == 0)
            {
                txtResultado.Text = "0";
            }
        }
        private bool is_number(string digit)
        {
            Regex regex = new Regex(@"^\d$");
            return regex.IsMatch(digit) || digit.Equals(")");
        }
        private void button_p_izq_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            if (txtResultado.Text.Length > 0)
            {
                string n_anterior = "" + txtResultado.Text[txtResultado.Text.Length - 1];
                bool is_operator = is_number(n_anterior) ;
                if (is_operator || n_anterior.Equals("("))
                {
                    txtResultado.Text += "(";
                }
            }
            else
            {
                txtResultado.Text += "(";
            }
        }

        private void button_p_der_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            if (txtResultado.Text.Length > 0)
            {
                string n_anterior = "" + txtResultado.Text[txtResultado.Text.Length - 1];
                bool is_operator = is_number(n_anterior);
                if (is_operator)
                {
                    txtResultado.Text += ")";
                }
            }
        }

        private void button_result_Click(object sender, EventArgs e)
        {
            String cuenta = txtResultado.Text;
            /*Calc _calculator = new Calc();*/
            if (cuenta.Contains('(') || cuenta.Contains(')'))
            {
                Console.WriteLine("Ecuacion con parentesis");
                if (validarEcuacion(cuenta))
                {
                    /*double valor = _calculator.Solve(cuenta);*/
                    Console.WriteLine("Caso parentesis valido");
                }
                else
                {
                    Console.WriteLine("Ecuación invalida");
                    txtResultado.Text = "Ecuación invalida";
                }
            }
            else
            {
                Console.WriteLine("Ecuacion sin parentesis");
            }
        }
        private bool validarEcuacion(String cuenta)
        {
            char p_i = '(';
            char p_d = ')';
            int contador_pd = 0;
            int contador_pi = 0;
            foreach (char p in cuenta)
            {
                if (p.Equals(p_i))
                {
                    contador_pi++;
                }
                if (p.Equals(p_d))
                {
                    contador_pd++;
                }
            }
            return contador_pd == contador_pi ? true : false;
        }
    }
}
