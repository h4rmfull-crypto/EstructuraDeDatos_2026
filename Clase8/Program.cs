using System;
using System.Numerics;

class Program
{
    // Función recursiva
    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * FactorialInt(n - 1);
    }

    // Función iterativa
    static int FactorialIterativo(int n)
    {
        int resultado = 1;

        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }

        return resultado;
    }

    // Función profesional con BigInteger
    static BigInteger FactorialProfesional(BigInteger n)
    {
        if (n == 0 || n == 1)
            return BigInteger.One;

        return n * FactorialProfesional(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("FACTORIAL CON int (Recursivo e Iterativo)\n");

        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(
                $"n={i:D2} | Recursivo: {FactorialInt(i),15} | Iterativo: {FactorialIterativo(i),15}");
        }

        /*
         Punto de quiebre:
         12! = 479001600 (correcto)
         13! = 6227020800 (ya no cabe en int)

         El valor que produce el programa es:
         1932053504

         A partir de n = 13 ocurre Arithmetic Overflow.
        */

        Console.WriteLine("\n100! usando BigInteger:\n");

        BigInteger resultado = FactorialProfesional(100);

        Console.WriteLine(resultado);
    }
}