namespace DataCore;

/// <summary>
/// Contiene las métricas obtenidas durante una ordenación.
/// </summary>
public readonly struct MetricasOrdenacion
{
    /// <summary>
    /// Número total de comparaciones realizadas.
    /// </summary>
    public int TotalComparaciones { get; }


    /// <summary>
    /// Número total de intercambios realizados.
    /// </summary>
    public int TotalIntercambios { get; }


    /// <summary>
    /// Tiempo empleado en milisegundos.
    /// </summary>
    public double TiempoMs { get; }


    /// <summary>
    /// Constructor de métricas.
    /// </summary>
    public MetricasOrdenacion(
        int comparaciones,
        int intercambios,
        double tiempo)
    {
        TotalComparaciones = comparaciones;
        TotalIntercambios = intercambios;
        TiempoMs = tiempo;
    }


    /// <summary>
    /// Muestra el reporte de rendimiento.
    /// </summary>
    public override string ToString()
    {
        return
            $"Comparaciones: {TotalComparaciones}\n" +
            $"Intercambios: {TotalIntercambios}\n" +
            $"Tiempo: {TiempoMs} ms";
    }
}