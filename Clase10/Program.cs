using System;

readonly struct CoordenadaGPS
{
    public double Latitud { get; }
    public double Longitud { get; }

    public CoordenadaGPS(double lat, double lon)
    {
        if (lat < -90 || lat > 90)
            throw new ArgumentOutOfRangeException(nameof(lat), "Latitud fuera de rango [-90, 90]");
        if (lon < -180 || lon > 180)
            throw new ArgumentOutOfRangeException(nameof(lon), "Longitud fuera de rango [-180, 180]");

        Latitud = lat;
        Longitud = lon;
    }

    public void ImprimirUbicacion()
    {
        Console.WriteLine($"Latitud: {Latitud}, Longitud: {Longitud}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Ejemplo: crear y mostrar una coordenada válida
            var c1 = new CoordenadaGPS(19.4326, -99.1332); // Ciudad de México
            Console.WriteLine(" --- c1 --- ");
            c1.ImprimirUbicacion();

            // Copia por valor: c2 es independiente de c1
            var c2 = c1;
            c2 = new CoordenadaGPS(52.5200, 13.4050); // Berlín
            Console.WriteLine(" --- c2 (después de reasignar) --- ");
            c2.ImprimirUbicacion();

            // Mostrar que c1 no cambió
            Console.WriteLine(" --- c1 (verificar que no cambió) --- ");
            c1.ImprimirUbicacion();

            // Entrada desde usuario (opcional)
            Console.WriteLine();
            Console.Write("Latitud: ");
            double lat = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Longitud: ");
            double lon = double.Parse(Console.ReadLine() ?? "0");

            var userCoord = new CoordenadaGPS(lat, lon);
            Console.WriteLine("Coordenada ingresada:");
            userCoord.ImprimirUbicacion();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error de validación: {ex.ParamName} -> {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: formato numérico inválido.");
        }
    }
}
