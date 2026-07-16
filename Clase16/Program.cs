using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // MÓDULO 1: Inicialización aleatoria
            int[] calificaciones = new int[100];
            Random rng = new Random();
            for (int i = 0; i < calificaciones.Length; i++)
                calificaciones[i] = rng.Next(0, 101); // 0 a 100 inclusive

            Console.WriteLine("=== Estado inicial: calificaciones desordenadas ===");
            ImprimirArreglo(calificaciones);

            // MÓDULO 2: Bubble Sort tradicional
            OrdenarPorBurbuja(calificaciones);

            Console.WriteLine("\n=== Estado final: calificaciones ordenadas (menor a mayor) ===");
            ImprimirArreglo(calificaciones);

            // MÓDULO 2 (optimizado): Bubble Sort con bandera swapped
            Console.WriteLine("\n=== Ordenamiento optimizado con bandera swapped ===");
            OrdenarPorBurbujaOptimizado(calificaciones);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"[ERROR] Índice fuera de rango detectado: {ex.Message}");
            Console.WriteLine("Revisa los límites de tus ciclos for anidados.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR inesperado]: {ex.Message}");
        }
    }

    // Método auxiliar para imprimir el arreglo
    static void ImprimirArreglo(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    // Bubble Sort tradicional con contador
    static void OrdenarPorBurbuja(int[] arr)
    {
        int n = arr.Length;
        int contadorIntercambios = 0;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Intercambio con sintaxis moderna de tuplas
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    contadorIntercambios++;
                }
            }
        }

        Console.WriteLine($"Total de intercambios realizados (tradicional): {contadorIntercambios}");
    }

    // Bubble Sort optimizado con bandera swapped
    static void OrdenarPorBurbujaOptimizado(int[] arr)
    {
        int n = arr.Length;
        int contadorIntercambios = 0;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    contadorIntercambios++;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }

        Console.WriteLine($"Total de intercambios realizados (optimizado): {contadorIntercambios}");
    }
}
