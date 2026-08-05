using DataCore;

TablaDinamica tabla = new();
Random random = new();

bool salir = false;

while (!salir)
{
    Console.Clear();

    Console.WriteLine("===========================================");
    Console.WriteLine("           DATACORE v4.0");
    Console.WriteLine("===========================================");
    Console.WriteLine($"Registros actuales: {tabla.TotalRegistros}");
    Console.WriteLine();
    Console.WriteLine("1. Insertar registro");
    Console.WriteLine("2. Eliminar registro");
    Console.WriteLine("3. Mostrar registros");
    Console.WriteLine("4. Ordenar registros (QuickSort)");
    Console.WriteLine("5. Buscar registro");
    Console.WriteLine("6. Estadísticas");
    Console.WriteLine("7. Generar 15 registros aleatorios");
    Console.WriteLine("8. Limpiar registros");
    Console.WriteLine("0. Salir");
    Console.WriteLine();
    Console.Write("Seleccione una opción: ");

    try
    {
        int opcion = int.Parse(Console.ReadLine()!);

        switch (opcion)
        {
            case 1:
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

                RegistroDatos nuevo =
                    new RegistroDatos(
                        id,
                        random.NextInt64(),
                        random.Next(10, 5001));

                tabla.InsertarFinal(nuevo);

                Console.WriteLine("\nRegistro agregado correctamente.");
                break;
            }

            case 2:
            {
                Console.Write("ID a eliminar: ");

                int id =
                    int.Parse(Console.ReadLine()!);

                tabla.EliminarPorId(id);

                Console.WriteLine("\nOperación finalizada.");
                break;
            }

            case 3:
            {
                Console.WriteLine();

                tabla.Mostrar();

                break;
            }

            case 4:
            {
                if (tabla.EstaVacia())
                {
                    Console.WriteLine("\nNo existen registros.");
                    break;
                }

                RegistroDatos[] arreglo =
                    tabla.ObtenerComoArreglo();

                double tiempo =
                    OrdenadorQuickSort
                    .OrdenarPorQuickSort(arreglo);

                Console.WriteLine();
                Console.WriteLine("===== REGISTROS ORDENADOS =====");
                Console.WriteLine();

                foreach (RegistroDatos registro in arreglo)
                {
                    Console.WriteLine(registro);
                }

                Console.WriteLine();
                Console.WriteLine($"Tiempo: {tiempo:F2} ms");
                Console.WriteLine($"Llamadas recursivas: {OrdenadorQuickSort.ContadorLlamadas}");

                break;
            }

            case 5:
            {
                Console.WriteLine();
                Console.WriteLine("1. Búsqueda Lineal");
                Console.WriteLine("2. Búsqueda Binaria Indexada");
                Console.Write("Seleccione: ");

                int tipo =
                    int.Parse(Console.ReadLine()!);

                Console.Write("ID a buscar: ");

                int id =
                    int.Parse(Console.ReadLine()!);

                if (tipo == 1)
                {
                    RegistroDatos? encontrado =
                        tabla.BuscarPorId(id);

                    if (encontrado != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Registro encontrado:");
                        Console.WriteLine(encontrado);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Registro no encontrado.");
                    }
                }
                else if (tipo == 2)
                {
                    RegistroDatos[] indice =
                        tabla.ObtenerComoArreglo();

                    OrdenadorQuickSort
                        .OrdenarPorQuickSort(indice);

                    var resultado =
                        GestorDatos.BuscarRegistroIndexado(
                            indice,
                            id);

                    if (resultado.registro != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Registro encontrado:");
                        Console.WriteLine(resultado.registro);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Registro no encontrado.");
                    }

                    Console.WriteLine(
                        $"Comparaciones: {resultado.comparaciones}");
                }

                break;
            }
                        case 6:
            {
                Console.WriteLine();
                Console.WriteLine("========== ESTADÍSTICAS ==========");
                Console.WriteLine($"Total de registros: {tabla.TotalRegistros}");

                int memoria =
                    tabla.TotalRegistros * sizeof(int) * 2;

                Console.WriteLine(
                    $"Uso estimado de memoria: {memoria} bytes");

                break;
            }

            case 7:
            {
                tabla.Limpiar();

                for (int i = 1; i <= 15; i++)
                {
                    RegistroDatos registro =
                        new RegistroDatos(
                            i,
                            random.NextInt64(),
                            random.Next(10, 5001));

                    tabla.InsertarFinal(registro);
                }

                Console.WriteLine();
                Console.WriteLine("15 registros generados correctamente.");

                break;
            }

            case 8:
            {
                Console.Write("¿Seguro que desea eliminar todos los registros? (S/N): ");

                string respuesta =
                    Console.ReadLine()!.ToUpper();

                if (respuesta == "S")
                {
                    tabla.Limpiar();

                    Console.WriteLine();
                    Console.WriteLine("Todos los registros fueron eliminados.");
                }

                break;
            }

            case 0:
            {
                Console.Write("¿Desea salir del sistema? (S/N): ");

                string respuesta =
                    Console.ReadLine()!.ToUpper();

                if (respuesta == "S")
                    salir = true;

                break;
            }

            default:
            {
                Console.WriteLine();
                Console.WriteLine("Opción inválida.");
                break;
            }
        }
    }
    catch (FormatException)
    {
        Console.WriteLine();
        Console.WriteLine("Error: debe ingresar un número válido.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    if (!salir)
    {
        Console.WriteLine();
        Console.WriteLine("Presione ENTER para continuar...");
        Console.ReadLine();
    }
}

Console.WriteLine();
Console.WriteLine("==================================");
Console.WriteLine("Gracias por utilizar DataCore v4.0");
Console.WriteLine("==================================");
