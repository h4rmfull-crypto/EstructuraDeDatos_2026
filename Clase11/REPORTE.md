using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulacroClase11
{
    // =========================
    // COMPONENTE 1: STRUCT
    // =========================
    public struct PuntoDeRed
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public PuntoDeRed(double latitud, double longitud)
        {
            if (latitud < -90.0 || latitud > 90.0)
                throw new ArgumentOutOfRangeException(nameof(latitud),
                    "La latitud debe estar entre -90 y 90 grados.");

            if (longitud < -180.0 || longitud > 180.0)
                throw new ArgumentOutOfRangeException(nameof(longitud),
                    "La longitud debe estar entre -180 y 180 grados.");

            Latitud = latitud;
            Longitud = longitud;
        }

        public override string ToString()
            => $"({Latitud}°, {Longitud}°)";
    }

    // =========================
    // COMPONENTE 2: CLASE
    // =========================
    public class ServidorConexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public PuntoDeRed Ubicacion { get; set; }
        public List<int> CodigosRespuesta { get; set; }

        // CACHE (memoization)
        private readonly long[] _cache = new long[100];

        public ServidorConexion(int id, string nombre,
                                PuntoDeRed ubicacion,
                                List<int> codigos)
        {
            ID = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            CodigosRespuesta = codigos ?? new List<int>();
        }

        public override string ToString()
            => $"[{ID}] {Nombre} @ {Ubicacion}";

        // =========================
        // COMPONENTE 3: FIBONACCI (MEMOIZATION)
        // =========================
        public long DiagnosticarLatencia(int n, out string alerta)
        {
            if (n < 0 || n >= 100)
                throw new ArgumentOutOfRangeException(nameof(n),
                    "El valor de n debe estar entre 0 y 99.");

            if (n <= 1)
            {
                alerta = string.Empty;
                return n;
            }

            if (_cache[n] != 0)
            {
                alerta = string.Empty;
                return _cache[n];
            }

            _cache[n] = DiagnosticarLatencia(n - 1, out _) +
                        DiagnosticarLatencia(n - 2, out _);

            if (_cache[n] > 10_000)
                alerta = "ALERTA: Índice de estrés crítico en " + Nombre;
            else
                alerta = string.Empty;

            return _cache[n];
        }
    }

    // =========================
    // COMPONENTE 4: MAIN
    // =========================
    public class Program
    {
        public static void Main(string[] args)
        {
            var servidores = new List<ServidorConexion>
            {
                new ServidorConexion(
                    1,
                    "Servidor-CDMX",
                    new PuntoDeRed(19.43, -99.13),
                    new List<int> { 200, 200, 500 }
                ),
                new ServidorConexion(
                    2,
                    "Servidor-NYC",
                    new PuntoDeRed(40.71, -74.01),
                    new List<int> { 200, 404 }
                ),
                new ServidorConexion(
                    3,
                    "Servidor-Sydney",
                    new PuntoDeRed(-33.87, 151.21),
                    new List<int> { 500, 500 }
                ),
                new ServidorConexion(
                    4,
                    "Servidor-Londres",
                    new PuntoDeRed(51.51, -0.13),
                    new List<int> { 200, 200, 200 }
                )
            };

            // LINQ: filtro
            var servidoresCriticos = servidores
                .Where(s => s.Ubicacion.Latitud > 0
                         && s.CodigosRespuesta.Contains(500))
                .ToList();

            Console.WriteLine("=== SERVIDORES CRÍTICOS ===");

            foreach (var s in servidoresCriticos)
                Console.WriteLine(s);

            // Ejemplo de uso Fibonacci
            long resultado = servidores[0]
                .DiagnosticarLatencia(15, out string alerta);

            Console.WriteLine("\nResultado Fibonacci: " + resultado);

            if (!string.IsNullOrEmpty(alerta))
                Console.WriteLine(alerta);
        }
    }
}