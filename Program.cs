using System;
class Program
{
    static void Main(string[] args)
    {
        retoDos();
    }

    static void retoDos() /*Funcion para que el usurio ingrese los numeros*/
    {

        Console.WriteLine("Ingrese el primer numero  ");
        string primerNumero = Console.ReadLine();

        Console.WriteLine("Ingrese el segundo numero  ");
        string segundoNumero = Console.ReadLine();

        string mensajeResultado = sumarNumeros(primerNumero, segundoNumero); /**/
        Console.WriteLine(mensajeResultado);
        Console.ReadKey();
    }

    static string sumarNumeros(string a, string b)/*Logica del reto dos*/
    {
        /*En esta linea guarda el valor de a convertida a doble en valorA es la variable que debe usarse en lugar de a */
        bool fts1 = double.TryParse(a, out double valorA);
        /*En esta linea guarda el valor de b convertida a doble en valorB es la variable que debe usarse en lugar de b */
        bool fts2 = double.TryParse(b, out double valorB);

        /* Validamos que la conversion de string a double fue exitosa */
        if (!fts1 || !fts2)
        {
            /*Si entra a este if es porque el string no tiene el formato correcto, es decir, contiene letras o simbolos invalidos como ´{+($, etc  */
            string mensje = "Ambos parámetros deben ser números enteros.";
            return mensje;
        }
        else
        {
            /* Si entra a este else es porque el string tiene el formato correcto, es decir, es un numero correcto */
            /* Se valida que sean numeros sin decimales*/
            if (valorA % 1 != 0 || valorB % 1 != 0) /* Si el residuo de la division es diferente a 0 significa que es decimal, con cualquiera de las dos variables*/
            {
                string mensje = "Ambos parámetros deben ser números enteros.";
                return mensje;
            }
            else
            {
                double res = valorA + valorB;/*Hace la suma de los variables, se define rest como double para respetar la suma de tipos*/
                string mensje = "El resultado de la suma es: " + res + " SW";
                return mensje;
            }
        }
    }
}


