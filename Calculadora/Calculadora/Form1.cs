using System;
using System.Collections;
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
        Regex operacion_unitaria = new Regex(@"(\({1}[\d\+\-\/\*\^\%]+[\d+]*\){1})");
        List<String> partes_de_ecuacion = new List<String>();
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
                bool is_operator = operadores.IsMatch(n_anterior);
                
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
            List<double> resultados = new List<double>();
           
            Calc _calculator = new Calc();
            String nuevoR;
            if (cuenta.Contains('(') || cuenta.Contains(')'))
            {
                Console.WriteLine("Ecuacion con parentesis");
                if (validarEcuacion(cuenta))
                {
                    
                    separar_en_partes(cuenta);
                    foreach (String parte in partes_de_ecuacion)
                    {
                        Console.WriteLine(parte);
                    }
                        List<String> quita_parentesis = new List<String>();
                    double resultado = 0;
                    int i = 0;
                        foreach (String parte in partes_de_ecuacion)
                        {
                        
                        //Copio las partes para poder borrar los parentesis
                        quita_parentesis.Add(parte);
                        //Guardo los resultados para despues reemplazarlos
                        resultados.Add(_calculator.Solve(remover_parentesis(parte)));
                        //Hago el reemplazo en la cuenta
                        cuenta = cuenta.Replace(parte, Convert.ToString(resultados[i]));
                        Console.WriteLine("cuenta modificada: " + cuenta);
                        i++;

                        }
                   
                       
                        resultado = _calculator.Solve(remover_parentesis(cuenta));
                    
                    
                    Console.WriteLine("Resultado: " + resultado);
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
                double resultado = _calculator.Solve(cuenta);
                Console.WriteLine("Resultado: " + resultado);
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
        private int contar_parentesis(String cuenta)
        {
            char p_i = '(';
            char p_d = ')';
            
            int contador = 0;
            
            foreach (char p in cuenta)
            {
                if (p.Equals(p_i)||p.Equals(p_d))
                {
                    contador++;
                }
            }
            return contador;
        }
        private List<String> separar_en_partes(String cuenta)
        {
            // Limpio la lista por cada operacion nueva
            partes_de_ecuacion.Clear();
            // Si la operacion tiene parentesis al inicio y al final, los remuevo ya que da igual si los tiene
            if (cuenta[0]=='(' && cuenta[cuenta.Length - 1] == ')' && contar_parentesis(cuenta)==2)
            {
                
                partes_de_ecuacion.Add(cuenta);
                return partes_de_ecuacion;
            }
            Regex n = new Regex(@"(\({2}[\d\+\-\/\*\^\%]+[\d+]*\){2})");
            foreach(Match m in operacion_unitaria.Matches(cuenta))
            {
                partes_de_ecuacion.Add(Convert.ToString(m));
               
                
            }
            
            return partes_de_ecuacion;
            
        }
        private String remover_parentesis(String cuenta)
        {
            if (cuenta.Contains("("))
            {
                cuenta = cuenta.Remove(0, 1);
                cuenta = cuenta.Remove(cuenta.Length - 1, 1);
            }
            return cuenta;

        }
       

    }
}
