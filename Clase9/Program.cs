using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Write("Ingresa un número (recomendado 0-40): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
        {
            Console.WriteLine("Entrada inválida. Ingresa un entero no negativo.");
            return;
        }

        var sw = new Stopwatch();

        // Versión insegura (recursiva simple)
        sw.Restart();
        long rInseguro = FibonacciInseguro(n);
        sw.Stop();
        Console.WriteLine($"Inseguro: F({n}) = {rInseguro}  Tiempo: {sw.ElapsedMilliseconds} ms");

        // Versión con memoization (arreglo cache inicializado en -1)
        long[] cache = new long[n + 1];
        for (int i = 0; i <= n; i++) cache[i] = -1;

        sw.Restart();
        long rPro = FibonacciPro(n, cache);
        sw.Stop();
        Console.WriteLine($"Pro:      F({n}) = {rPro}  Tiempo: {sw.ElapsedMilliseconds} ms");
    }

    // Recursión pura (ineficiente para n grandes)
    static long FibonacciInseguro(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }

    // Memoization con arreglo
    static long FibonacciPro(int n, long[] cache)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (cache[n] != -1) return cache[n];
        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
        return cache[n];
    }
}
