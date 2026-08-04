using System.Diagnostics;

namespace DataCore;

/// <summary>
/// Implementa el algoritmo QuickSort con medición de rendimiento.
/// </summary>
public static class OrdenadorQuickSort
{

    private static int contadorLlamadas;


    /// <summary>
    /// Obtiene el número de llamadas recursivas realizadas.
    /// </summary>
    public static int ContadorLlamadas
    {
        get { return contadorLlamadas; }
    }


    /// <summary>
    /// Reinicia el contador de llamadas.
    /// </summary>
    public static void ReiniciarContador()
    {
        contadorLlamadas = 0;
    }


    /// <summary>
    /// Ordena registros utilizando QuickSort.
    /// </summary>
    /// <param name="datos">
    /// Arreglo de registros a ordenar.
    /// </param>
    /// <returns>
    /// Tiempo de ejecución en milisegundos.
    /// </returns>
    public static double OrdenarPorQuickSort(
        RegistroDatos[] datos)
    {

        ReiniciarContador();


        Stopwatch reloj = Stopwatch.StartNew();


        QuickSort(
            datos,
            0,
            datos.Length - 1);


        reloj.Stop();


        return reloj.Elapsed.TotalMilliseconds;

    }


    /// <summary>
    /// Método recursivo de QuickSort.
    /// </summary>
    private static void QuickSort(
        RegistroDatos[] datos,
        int izquierda,
        int derecha)
    {

        contadorLlamadas++;


        if (izquierda < derecha)
        {

            int pivote =
                Particionar(
                    datos,
                    izquierda,
                    derecha);


            QuickSort(
                datos,
                izquierda,
                pivote - 1);


            QuickSort(
                datos,
                pivote + 1,
                derecha);

        }

    }



    /// <summary>
    /// Divide el arreglo usando un pivote.
    /// </summary>
    private static int Particionar(
        RegistroDatos[] datos,
        int izquierda,
        int derecha)
    {

        RegistroDatos pivote =
            datos[derecha];


        int indiceMenor =
            izquierda - 1;


        for(int j = izquierda; j < derecha; j++)
        {

            if(datos[j].Id <= pivote.Id)
            {

                indiceMenor++;


                (datos[indiceMenor], datos[j]) =
                (datos[j], datos[indiceMenor]);

            }

        }


        (datos[indiceMenor + 1], datos[derecha]) =
        (datos[derecha], datos[indiceMenor + 1]);


        return indiceMenor + 1;

    }

}