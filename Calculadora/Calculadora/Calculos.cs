using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Calc
{
    public double Solve(string equation)
    {
        // Remove all spaces
        equation = Regex.Replace(equation, @"\s+", "");

        Operacion operation = new Operacion();
        operation.Parse(equation);

        double result = operation.Resolver();

        return result;
    }
}

public class Operacion
{
    public Operacion NumeroIzquierdo { get; set; }
    public string Operador { get; set; }
    public Operacion NumeroDerecho { get; set; }

    private Regex sumaResta = new Regex("[+-]", RegexOptions.RightToLeft);
    private Regex multiplicacionDivision = new Regex("[*/]", RegexOptions.RightToLeft);

    public void Parse(string equation)
    {
        var operatorLocation = sumaResta.Match(equation);
        if (!operatorLocation.Success)
        {
            operatorLocation = multiplicacionDivision.Match(equation);
        }

        if (operatorLocation.Success)
        {
            Operador = operatorLocation.Value;

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

        return result;
    }
}