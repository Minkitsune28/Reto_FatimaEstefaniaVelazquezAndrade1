using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese los datos:");
        string input = Console.ReadLine();

        string resultado = VersionValidator.Procesar(input);
        Console.WriteLine(resultado);
    }
}
