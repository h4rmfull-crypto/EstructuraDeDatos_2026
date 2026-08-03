using System.Diagnostics;

namespace DataCore;

/// <summary>
/// Implementa algoritmos de ordenamiento.
/// </summary>
public static class OrdenadorSeleccion
{

    /// <summary>
    /// Ordena registros mediante Selection Sort.
    /// </summary>
    /// <param name="datos">
    /// Arreglo de registros a ordenar.
    /// </param>
    /// <returns>
    /// Métricas del proceso.
    /// </returns>
    public static MetricasOrdenacion 
        OrdenarPorSeleccion(RegistroDatos[] datos)
    {

        int comparaciones = 0;
        int intercambios = 0;


        Stopwatch reloj = Stopwatch.StartNew();


        for (int i = 0; i < datos.Length - 1; i++)
        {

            int indiceMinimo = i;


            for (int j = i + 1; j < datos.Length; j++)
            {

                comparaciones++;


                if(datos[j].Id < datos[indiceMinimo].Id)
                {
                    indiceMinimo = j;
                }

            }


            if(indiceMinimo != i)
            {

                (datos[i], datos[indiceMinimo]) =
                (datos[indiceMinimo], datos[i]);


                intercambios++;

            }

        }


        reloj.Stop();


        return new MetricasOrdenacion(
            comparaciones,
            intercambios,
            reloj.Elapsed.TotalMilliseconds
        );

    }
}