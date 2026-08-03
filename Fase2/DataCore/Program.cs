using DataCore;


Random random = new();


int cantidadRegistros = 10000;


RegistroDatos[] registros =
    new RegistroDatos[cantidadRegistros];



try
{

    for(int i = 0; i < registros.Length; i++)
    {

        registros[i] =
            new RegistroDatos(
                random.Next(1, 100001),
                random.NextInt64(),
                random.Next(10, 5001)
            );

    }

}
catch(ArgumentException ex)
{

    Console.WriteLine(
        $"Error creando registro: {ex.Message}");

    return;

}



// Crear copias para que ambos algoritmos
// trabajen con los mismos datos

RegistroDatos[] datosSeleccion =
    (RegistroDatos[])registros.Clone();


RegistroDatos[] datosQuickSort =
    (RegistroDatos[])registros.Clone();



// =============================
// SELECTION SORT
// =============================

MetricasOrdenacion metricasSeleccion =
    OrdenadorSeleccion
    .OrdenarPorSeleccion(datosSeleccion);



// =============================
// QUICK SORT
// =============================

double tiempoQuickSort =
    OrdenadorQuickSort
    .OrdenarPorQuickSort(datosQuickSort);



// =============================
// CALCULO DEL RATIO
// =============================

double ratio =
    metricasSeleccion.TiempoMs /
    tiempoQuickSort;



// Evita división entre cero
if(tiempoQuickSort == 0)
{
    ratio = 0;
}



// =============================
// REPORTE FINAL
// =============================

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



Console.WriteLine();


Console.WriteLine(
"============================================================");