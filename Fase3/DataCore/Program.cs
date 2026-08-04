using DataCore;


// =================================
// FASE 3 - LISTA DINÁMICA
// =================================

Console.WriteLine("=================================");
Console.WriteLine("FASE 3 - LISTA ENLAZADA");
Console.WriteLine("=================================\n");


TablaDinamica tabla = new();


Random random = new();


// Insertar 15 registros

for (int i = 1; i <= 15; i++)
{
    RegistroDatos registro =
        new RegistroDatos(
            i,
            random.NextInt64(),
            random.Next(10, 5001)
        );


    tabla.InsertarFinal(registro);
}


Console.WriteLine(
    $"Registros iniciales: {tabla.TotalRegistros}");


// Eliminar IDs solicitados

tabla.EliminarPorId(5);
tabla.EliminarPorId(11);


Console.WriteLine(
    $"Registros después de eliminar ID 5 y 11: {tabla.TotalRegistros}");



Console.WriteLine("\nLista actual:");

tabla.Mostrar();



// Convertir lista a arreglo

RegistroDatos[] arregloLista =
    tabla.ObtenerComoArreglo();



// Ordenar con QuickSort

OrdenadorQuickSort.OrdenarPorQuickSort(arregloLista);



Console.WriteLine("\nLista convertida y ordenada:");

foreach (RegistroDatos registro in arregloLista)
{
    Console.WriteLine(registro);
}





// =================================
// FASE 2 - COMPARACIÓN DE ALGORITMOS
// =================================


Console.WriteLine("\n\n=================================");
Console.WriteLine("FASE 2 - COMPARACIÓN DE ORDENAMIENTO");
Console.WriteLine("=================================\n");



int cantidadRegistros = 10000;


RegistroDatos[] registros =
    new RegistroDatos[cantidadRegistros];



try
{
    for (int i = 0; i < registros.Length; i++)
    {
        registros[i] =
            new RegistroDatos(
                random.Next(1, 100001),
                random.NextInt64(),
                random.Next(10, 5001)
            );
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(
        $"Error creando registro: {ex.Message}");

    return;
}




RegistroDatos[] datosSeleccion =
    (RegistroDatos[])registros.Clone();


RegistroDatos[] datosQuickSort =
    (RegistroDatos[])registros.Clone();





MetricasOrdenacion metricasSeleccion =
    OrdenadorSeleccion
    .OrdenarPorSeleccion(datosSeleccion);




double tiempoQuickSort =
    OrdenadorQuickSort
    .OrdenarPorQuickSort(datosQuickSort);




double ratio =
    metricasSeleccion.TiempoMs /
    tiempoQuickSort;



if (tiempoQuickSort == 0)
{
    ratio = 0;
}





Console.WriteLine(
"============================================================");


Console.WriteLine(
$"REPORTE COMPARATIVO DE ORDENAMIENTO (n = {cantidadRegistros})");


Console.WriteLine(
"============================================================");



Console.WriteLine();


Console.WriteLine(
"Algoritmo : Selección Directa");


Console.WriteLine(
$"Registros procesados: {cantidadRegistros}");


Console.WriteLine(
$"Comparaciones : {metricasSeleccion.TotalComparaciones:N0}");


Console.WriteLine(
$"Intercambios : {metricasSeleccion.TotalIntercambios:N0}");


Console.WriteLine(
$"Tiempo de ejecución : {metricasSeleccion.TiempoMs:F2} ms");



Console.WriteLine(
"------------------------------------------------------------");



Console.WriteLine();


Console.WriteLine(
"Algoritmo : QuickSort");


Console.WriteLine(
$"Registros procesados: {cantidadRegistros}");


Console.WriteLine(
$"Llamadas recursivas : {OrdenadorQuickSort.ContadorLlamadas:N0}");


Console.WriteLine(
$"Tiempo de ejecución : {tiempoQuickSort:F2} ms");



Console.WriteLine(
"------------------------------------------------------------");



Console.WriteLine();


Console.WriteLine(
$"Ratio de velocidad : QuickSort fue {ratio:F0}x más rápido");



Console.WriteLine(
"============================================================");