using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Calc
{


    public Regex hayNegativo = new Regex(@"[\+\-\/\*\^\%]{1}[\-]");
    public Regex Resta = new Regex("[-]");
    public double Solve(string equation)
    {
        // Remove all spaces
        equation = Regex.Replace(equation, @"\s+", "");
        bool hayDosOperadores = hayNegativo.IsMatch(equation);
        Operacion operation = new Operacion();
       
        operation.Parse(equation);
        double result = operation.Resolver();
        return result;
        
        
        
       
        
        
    }
}

public class Operacion
{
    public Regex operadores = new Regex(@"[\+\-\/\*\^\%]");
    public Regex hayNegativo = new Regex(@"[\*\/]{1}[\-]");
    private Regex Resta = new Regex("[-]");
   

    public Operacion NumeroIzquierdo { get; set; }
    public string Operador { get; set; }
    public Operacion NumeroDerecho { get; set; }

    private Regex sumaResta = new Regex("[+-]");
    private Regex multiplicacionDivision = new Regex("[*/]");

    public void Parse(string equation)

    {
        
       //Busca el operador usando el regex, priorizando suma y resta
        var operatorLocation =sumaResta.Match(equation);
        //Si no encuentra con suma y resta busca mult y div
        if (!operatorLocation.Success)
        {
            operatorLocation = multiplicacionDivision.Match(equation);
        }
        //Este condicional se fija si hay casos de *(-numero o  /(-numero
        bool hayDosOperadores = hayNegativo.IsMatch(equation);
        if (hayDosOperadores)
        {
            //Si encuentra el caso entra aca y tira el mensaje
            Console.WriteLine("entre : "+ equation.Remove(Resta.Match(equation).Index, 1));
            //le borra la primera parte a la ecuacion para que no se rompa porque analiza con los regex
            equation = equation.Remove(Resta.Match(equation).Index, 1);
            //Mismo proceso que si la cuenta no tuviera esos casos de *(- etc
            operatorLocation = sumaResta.Match(equation);

            if (!operatorLocation.Success)
            {
                operatorLocation = multiplicacionDivision.Match(equation);
            }
        }
        //Si hay exito encontrando un operador
        if (operatorLocation.Success)
        {
            //Le setea el valor a operador sacandolo de la posicion
            Operador = operatorLocation.Value;
            //Y crea las ramas usando numero izquierdo y derecho basicamente
            NumeroIzquierdo = new Operacion();
            NumeroIzquierdo.Parse(equation.Substring(0, operatorLocation.Index));
            
            NumeroDerecho = new Operacion();
            NumeroDerecho.Parse(equation.Substring(operatorLocation.Index + 1));
        }
        else
        {
            Operador = "v";
            result = double.Parse(equation);
        }
    }

    private double result;

    public double Resolver()
    {
        switch (Operador)
        {
            case "v":
                break;
            case "+":
                result = NumeroIzquierdo.Resolver() + NumeroDerecho.Resolver();
                break;
            case "-":
                result = NumeroIzquierdo.Resolver() - NumeroDerecho.Resolver();
                break;
            case "*":
                result = NumeroIzquierdo.Resolver() * NumeroDerecho.Resolver();
                break;
            case "/":
                result = NumeroIzquierdo.Resolver() / NumeroDerecho.Resolver();
                break;
            default:
                throw new Exception("Call Parse first.");
        }
        Console.WriteLine("retorno resultado: " + result);
        return result;
    }
}