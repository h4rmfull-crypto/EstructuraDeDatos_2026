using System;

class SimuladorStack
{
    // EJERCICIO A
    public static void ImprimirCuentaRegresiva(int numero)
    {
        // Caso base
        if (numero < 1)
        {
            Console.WriteLine("¡Despegue! 🚀");
            return;
        }

        // Fase de apilado
        Console.WriteLine($"[APILANDO] Marco {numero}");

        // Caso recursivo
        ImprimirCuentaRegresiva(numero - 1);

        // Fase de retorno
        Console.WriteLine($"[LIBERANDO] Marco {numero}");
    }

    // EJERCICIO B
    public static int SumarHasta(int n)
    {
        // Caso base
        if (n == 1)
        {
            return 1;
        }

        // Caso recursivo
        return n + SumarHasta(n - 1);
    }
}