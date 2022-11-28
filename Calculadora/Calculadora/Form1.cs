using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Calculadora
{
    public partial class Form1 : Form
    {
        //Regex para operandos
        //Regex for operands
        Regex operandos = new Regex(@"(-?[1-9]\d*)");
        //Regex para operadores
        //Regex for operators
        Regex operadores = new Regex(@"[\+\-\/\*\^\%]");
        //Regex para identificar operaciones individuales
        //Regex for unitary operations like 2+2, 2*2, 2/3, ...
        Regex operacion_unitaria = new Regex(@"(\({1}[\d\+\-\/\*\^\%]+[\d+]*\){1})");
        //Lista donde se almacenan las distintas partes de una ecuación que se encuentren encerradas en parentesis para ser resueltas y reemplazadas en la ecuación.
        //A list where the parts of the equation between brackets are saved, to be solved and replaced in the equation.
        List<String> partes_de_ecuacion = new List<String>();
        public Form1()
        {
            InitializeComponent();
        }



        //Metodo para escribir numeros, en caso de tener un parentesis de cierre => ), no permite escribir un numero siguiente a este.
        //Method to write numbers, it doesnt allow to write a number next to a closing bracket without a operator between.
        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
                txtResultado.Text = "";
            if (txtResultado.Text.Equals(""))
            {
                txtResultado.Text += boton.Text;
            }
            else
            {
                if (!txtResultado.Text[txtResultado.Text.Length - 1].Equals(')'))
                {
                    txtResultado.Text += boton.Text;


                }
            }


        }
        //Borra lo que haya en pantalla y setea 0
        //Cleans the window and sets value to 0
        private void button_borrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }
        //Metodo para escribir operadores, no permite escribir mas de un operador seguido, en caso de escribir uno, reemplaza el actual.
        //Method used to add operators, doesnt allow to write more than one operator, in case of this, replaces the actual one.
        private void click_operador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            String texto = boton.Text;
            char caracter = txtResultado.Text[txtResultado.Text.Length - 1];
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
                txtResultado.Text += boton.Text;
            }
            else
            {
                if (!operadores.IsMatch("" + txtResultado.Text[txtResultado.Text.Length - 1]))
                {
                    txtResultado.Text = txtResultado.Text.TrimEnd();
                    txtResultado.Text += boton.Text;
                }
                else
                {
                    txtResultado.Text = txtResultado.Text.TrimEnd(caracter);
                    txtResultado.Text += boton.Text;

                }
            }
        }
        //Metodo para borrar
        //Backspace method
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
        //Metodo para checkear si el caracter es un digito un parentesis cerrado
        //Method for checking if the character is a digit or a closing bracket.
        private bool number_closeBracket(string car)
        {
            Regex regex = new Regex(@"^\d$");
            return regex.IsMatch(car) || car.Equals(")");
        }
        //Metodos para agregar parentesis izquierdo y derecho, con validacion para no permitir )(, es necesario un operador intermedio, ej: )+(
        //Method for adding brackets, with validations to not allow )( cases, a intermediate operator in required. Ex: )+(
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
                bool is_operator = number_closeBracket(n_anterior);
                if (is_operator)
                {
                    txtResultado.Text += ")";
                }
            }
        }
        /* Los Logs por consola, son meramente para ver el proceso logico
         * Console logs are meant only to see the logic process
         */
        //Metodo para calcular el resultado
        //Equations solve method
        private void button_result_Click(object sender, EventArgs e)
        {
            Regex modNegativo = new Regex(@"(-[\d]+[\*\/][\d]+){1}");
            try
            {
                String cuenta = txtResultado.Text;
                //Muestro cuenta ingresada por consola
                //Show the equation on console
                Console.WriteLine("La cuenta ingresada es: " + cuenta);
                //Instancio una calculadora
                //Instanciate an calculator
                Calc _calculator = new Calc();
                //Seteo el resultado en 0
                //Set the result in 0
                double resultado = 0;

                /*
                 * Dependiendo el caso:                               Switch case:
                 * A - La ecuación tiene parentesís                   A - Equation has brackets
                 * B - La ecuación no tiene parentesís                B - Equations hasnt brackets
                 * es el procedimiento a seguir:                      Its the procedure to solve it
                  */

                if (cuenta.Contains('(') || cuenta.Contains(')'))
                {
                    Console.WriteLine("CASO A: Ecuación con paretensís");
                    /*La idea principal del caso A es, simplificar la ecuacion al punto de que no hayan parentesis, para poder aplicar 
                     * el algoritmo de calculo usando el arbol. Para ello, se resuelven las ecuaciones internas (que estan entre parentesis)
                     * y se reemplaza el resultado en la ecuación original, 
                     * Basicamente se abstrae la porcion entre parentesis, como otra ecuacion,se resuelve y reemplaza.
                     */

                    /* Case A idea it's simplifying the equation to the point when there are no brackets, that way we can apply the tree calculus algorithm
                     * With that in mind, we solve the intern equations (those in brackets) then, the result is replaced in the original equation.
                     * Basically we isolate the portion between brackets, like another equation, then solve and replace
                     */
                    //Caso A: primero validamos que la cantidad de parentesis presente sea correcta, por ej: 2(( y 2)), y no 2(( y 3))
                    //Case A: first we validate that the amount of brackets is equal for opening brackets and closing brackets. 
                    if (validarEcuacion(cuenta))
                    {
                        /* En caso de que existan parentesis internos, separamos estos como partes de la ecuacion
                         * Realizamos este proceso, las veces que sean necesarias (esto va ligado a la jerarquía de los parentesis)
                         * 
                         * In case of internal brackets, we separate them in "parts of the equation"
                         * We redo this process, the times we need (its connect with the bracket hierarchy) */

                        while (cuenta.Contains("("))
                        { 
                            separar_en_partes(cuenta);
                            cuenta = calcularResultado(cuenta, _calculator);
                            Console.WriteLine("Cuenta:" + cuenta);

                        }
                        // Una vez la ecuacion esta simplificada para ser resuelta por el algoritmo la resolvemos por completo
                        // Once the equation is simplified to be resolved for the algorithm, we solve it.
                        resultado = _calculator.Solve(remover_parentesis(cuenta));

                        //LLamamos a la funcion para calcular el resultado
                        //Call the funcion to obtain the result

                        Console.WriteLine("Resultado: " + resultado);
                        //Muestro el valor en el formulario
                        //Show the value in the form
                        txtResultado.Text = Convert.ToString(resultado);
                    }
                    else
                    {
                        //Si no se cumple la validacion se muestra error de sintaxis
                        //If the validation isnt accomplished, shows syntax error.
                        Console.WriteLine("Syntax error");
                        txtResultado.Text = "Syntax error";
                    }
                }
                else
                {
                    /* El caso B es el mas sencillo simplemente aplicamos el algoritmo del arbol, sin necesidad de hacer reemplazos en la ecuacion
                     * The B case is the easier, simply apply the tree algorithm, and no equation replaces are needed.
                     */
                        Console.WriteLine("CASO B: Ecuación sin paretensis");
                    //Calculo el resultado 
                    //Calculate the result
                    resultado = _calculator.Solve(cuenta);
                    Console.WriteLine("Resultado: " + resultado);
                    //Muestro el valor en el formulario
                    //Show the value in the form
                    txtResultado.Text = Convert.ToString(resultado);
                }
            }
            catch (Exception)
            {
                //En caso de que haya un fallo, suelta error matematico. Esto podría expandirse y hacerse mas especifico
                //In case of failure, shows math error. This can be expanded to be more specific.
                txtResultado.Text = "Math error";
            }
        }
        //Esta funcion, resuelve primero los parentesis, reemplaza los resultados, cuando obtiene la ecuacion simple, resuelve la misma.
        //This function, solves first the brackets, replaces the results, finally when obtains the equation, solves it.
        private String calcularResultado(String cuenta, Calc _calculator)
        {
            Regex negativoComienzo = new Regex(@"^(-[\d]+)");
            // Para casos de -(+n) => -n o -(-n) => n
            // For cases the -(+n) => -n o -(-n) => n cases
            Regex sRyRs = new Regex(@"(?<=[0-9])([+-]+)(?=[0-9]+)");
            Regex RR = new Regex(@"(?<=[0-9])([--]{2})(?=[0-9]+)");
            
            // Proceso de resolución y reemplazo de cada parentesis interno
            // Process of resolution and replacement of every internal bracket
            foreach (String parte in partes_de_ecuacion)
            {
                // Log por consola de la parte que se va a resolver
                // Console log of the part to be solved
                Console.WriteLine("parte de ecuacion: " + parte);

                //Guardo los resultados para despues reemplazarlos
                //Hago el reemplazo en la cuenta
                Console.WriteLine("Reemplazo: " + parte + " " + Convert.ToString(_calculator.Solve(remover_parentesis(parte))));
                cuenta = cuenta.Replace(parte, Convert.ToString(_calculator.Solve(remover_parentesis(parte))));

                // APLICACIÓN -> Para casos de -(+n) => -n o -(-n) => n 
                // APPLICATION -> For cases the -(+n) => -n o -(-n) => n cases 

                if (sRyRs.IsMatch(cuenta))
                {
                    /* Se ponen ambos replace en  base al funcionamiento del metodo Replace, ya que tenemos dos posibilidades
                     * en el primer caso, que matchee -+, pero le enviemos a replace +- como patron de coincidencia, si esto pasa
                     * no se efectuaran cambios, por ello realizamos un segundo replace con la alternativa correcta y viceversa.
                     * 
                     * Both Replace are used in base a the working method of Replace, there are two posibilities
                     * first, Replace matches -+, but we send as replace parameter +-, if this happens, no change is made, 
                     * for this we put a second Replace with the correct alternative and vice versa. */
                    cuenta = cuenta.Replace("+-", "-");
                    cuenta = cuenta.Replace("-+", "-");
                    Console.WriteLine("a: " + cuenta);
                }
                if (RR.IsMatch(cuenta))
                {
                    cuenta = cuenta.Replace("--", "+");
                    Console.WriteLine("a: " + cuenta);
                }
           
            }
            // Necesito retornar tanto la cuenta modificada, como el resultado por eso retorno un arraylist
            // The modified equation and the result is need, so we return an arraylist
            ArrayList retorno = new ArrayList();
            return cuenta;
        }
        //Valida la ecuacion contando si la cantidad de parentesis de apertura y cierre coinciden.
        //Validates the equation counting if the amount of opening and closing brackets are equal.
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
            Regex parentesis_innecesarios = new Regex(@"(\(\([\d]*\)\))");
            if (parentesis_innecesarios.IsMatch(cuenta))
            {
                cuenta = cuenta.Replace("(", "");
                cuenta = cuenta.Replace(")", "");
                Console.WriteLine(cuenta);

            }
            return contador_pd == contador_pi ? true : false;
        }
        //Separa las partes de la ecuacion que esten entre parentesis
        //Separates the equation parts between brackets
        private List<String> separar_en_partes(String cuenta)
        {
            // Limpio la lista por cada operacion nueva
            partes_de_ecuacion.Clear();
            foreach (Match m in operacion_unitaria.Matches(cuenta)){partes_de_ecuacion.Add(Convert.ToString(m));}
            return partes_de_ecuacion;
        }
        //Quita los parentesis de las partes de la ecuacion que esten entre parentesis
        //Remove the brackets from the equation parts
        private String remover_parentesis(String cuenta)
        {
            if (cuenta.Contains("("))
            {
                cuenta = cuenta.Remove(cuenta.IndexOf("("), 1);
                cuenta = cuenta.Remove(cuenta.LastIndexOf(")"), 1);
            }
            return cuenta;

        }


    }
}
