using System;

namespace EF3_InsertionSort
{
    struct Transaccion
    {
        public int Id;
        public double Monto;
        public long Timestamp;

        public Transaccion(int id, double monto, long timestamp)
        {
            Id = id;
            Monto = monto;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"ID: {Id,4} | Monto: {Monto,10:F2} | Timestamp: {Timestamp}";
        }
    }

    class Program
    {
        static int OrdenarPorInsercion(Transaccion[] arr)
        {
            int contadorDesplazamientos = 0;
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                Transaccion clave = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].Id > clave.Id)
                {
                    arr[j + 1] = arr[j];
                    contadorDesplazamientos++;
                    j--;
                }

                arr[j + 1] = clave;
            }

            return contadorDesplazamientos;
        }

        static void Main(string[] args)
        {
            try
            {
                Transaccion[] bitacora = new Transaccion[50];
                Random rng = new Random();

                // Primeros 45 registros ordenados
                for (int i = 0; i < 45; i++)
                {
                    bitacora[i] = new Transaccion(
                        id: i + 1,
                        monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + i * 100
                    );
                }

                // Últimos 5 registros desordenados
                int[] idsAleatorios = { 78, 3, 99, 12, 55 };

                for (int i = 0; i < 5; i++)
                {
                    bitacora[45 + i] = new Transaccion(
                        id: idsAleatorios[i],
                        monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (45 + i) * 100
                    );
                }

                Console.WriteLine("===============================================");
                Console.WriteLine(" OPTIMIZADOR DE BITÁCORAS DE TRANSACCIONES");
                Console.WriteLine("===============================================\n");

                Console.WriteLine("ANTES DE ORDENAR:\n");

                foreach (var t in bitacora)
                {
                    Console.WriteLine(t);
                }

                Console.WriteLine("\nOrdenando transacciones...\n");

                int totalDesplazamientos = OrdenarPorInsercion(bitacora);

                Console.WriteLine("DESPUÉS DE ORDENAR:\n");

                foreach (var t in bitacora)
                {
                    Console.WriteLine(t);
                }

                Console.WriteLine("\n-----------------------------------------------");
                Console.WriteLine($"Total de desplazamientos: {totalDesplazamientos}");

                double peorCaso = (50 * 49) / 2.0;
                double eficiencia = (1 - totalDesplazamientos / peorCaso) * 100;

                Console.WriteLine($"Eficiencia respecto al peor caso: {eficiencia:F1}%");
                Console.WriteLine("-----------------------------------------------");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"[ERROR] Desbordamiento: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[ERROR] Formato inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Excepción inesperada: {ex.Message}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}