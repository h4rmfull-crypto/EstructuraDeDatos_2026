using System;

class Alumno
{
    public string Nombre { get; set; }
}

class Program
{
    // Módulo 1
    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Módulo 2
    static int CalcularYValidar(int dividendo, int divisor, out int residuo)
    {
        residuo = dividendo % divisor;
        return dividendo / divisor;
    }

    static void Main(string[] args)
    {
        // MÓDULO 1: ref
        int x = 10;
        int y = 25;

        Console.WriteLine("=== MÓDULO 1: INTERCAMBIAR ===");
        Console.WriteLine($"Antes: x = {x}, y = {y}");

        Intercambiar(ref x, ref y);

        Console.WriteLine($"Después: x = {x}, y = {y}");

        // MÓDULO 2: out
        Console.WriteLine("\n=== MÓDULO 2: CALCULAR Y VALIDAR ===");

        int cociente = CalcularYValidar(17, 5, out int residuo);

        Console.WriteLine($"Cociente: {cociente}");
        Console.WriteLine($"Residuo: {residuo}");

        // MÓDULO 3: Referencias de objetos
        Console.WriteLine("\n=== MÓDULO 3: REFERENCIAS DE OBJETOS ===");

        Alumno alumno1 = new Alumno();
        alumno1.Nombre = "Dany";

        Alumno alumno2 = alumno1;

        alumno2.Nombre = "3Treum";

        Console.WriteLine($"Alumno 1: {alumno1.Nombre}");
        Console.WriteLine($"Alumno 2: {alumno2.Nombre}");

        Console.WriteLine("\nAmbas variables apuntan al mismo objeto en memoria.");
    }
}