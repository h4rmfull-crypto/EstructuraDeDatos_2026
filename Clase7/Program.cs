using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== SIMULADOR DEL CALL STACK =====");

        // Ejercicio A
        Console.WriteLine("\n--- Ejercicio A: Cuenta Regresiva ---");
        SimuladorStack.ImprimirCuentaRegresiva(5);

        // Ejercicio B
        Console.WriteLine("\n--- Ejercicio B: Sumatoria Recursiva ---");

        int numero = Validador.LeerNumeroPositivo();

        int resultado = SimuladorStack.SumarHasta(numero);

        Console.WriteLine($"La suma de 1 hasta {numero} es: {resultado}");

        Console.WriteLine("\nPresiona una tecla para finalizar...");
        Console.ReadKey();
    }
}