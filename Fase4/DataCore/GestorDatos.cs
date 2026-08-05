namespace DataCore;

/// <summary>
/// Clase encargada de realizar operaciones de búsqueda avanzada.
/// </summary>
public static class GestorDatos
{

    /// <summary>
    /// Realiza una búsqueda binaria sobre un arreglo ordenado por Id.
    /// Complejidad: O(log n)
    /// </summary>
    /// <param name="arrOrdenado">
    /// Arreglo de registros previamente ordenado.
    /// </param>
    /// <param name="idBuscado">
    /// Identificador del registro que se desea encontrar.
    /// </param>
    /// <returns>
    /// Registro encontrado y cantidad de comparaciones realizadas.
    /// </returns>
    public static 
        (RegistroDatos? registro, int comparaciones)
        BuscarRegistroIndexado(
            RegistroDatos[] arrOrdenado,
            int idBuscado)
    {

        if (arrOrdenado == null ||
            arrOrdenado.Length == 0)
        {
            return (null, 0);
        }


        int izquierda = 0;

        int derecha =
            arrOrdenado.Length - 1;


        int comparaciones = 0;



        while (izquierda <= derecha)
        {

            int medio =
                izquierda +
                (derecha - izquierda) / 2;



            comparaciones++;



            if (arrOrdenado[medio].Id == idBuscado)
            {
                return
                (
                    arrOrdenado[medio],
                    comparaciones
                );
            }



            if (arrOrdenado[medio].Id < idBuscado)
            {
                izquierda =
                    medio + 1;
            }
            else
            {
                derecha =
                    medio - 1;
            }

        }


        return
        (
            null,
            comparaciones
        );

    }

}
