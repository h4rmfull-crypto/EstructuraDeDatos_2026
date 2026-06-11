using System;

class Validador
{
    public static int LeerNumeroPositivo()
    {
        while (true)
        {
            Console.Write("Introduce un número positivo: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero) && numero > 0)
            {
                return numero;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Solo se aceptan enteros positivos.");
            Console.ResetColor();
        }
    }
}