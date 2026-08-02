using System;
using Xunit;
using DataCore;

namespace DataCore.Tests;

public class DataCoreTests
{
    [Fact]
    public void RegistroDatos_CrearRegistroCorrectamente()
    {
        var registro = new RegistroDatos(1, 12345, 100);

        Assert.Equal(1, registro.Id);
        Assert.Equal(12345, registro.HashValidacion);
        Assert.Equal(100, registro.PesoBytes);
    }

    [Fact]
    public void RegistroDatos_PesoMenorOIgualACero_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new RegistroDatos(1, 1000, 0);
        });
    }

    [Fact]
    public void RegistroDatos_Iguales_DebenSerIguales()
    {
        var r1 = new RegistroDatos(1, 10, 100);
        var r2 = new RegistroDatos(1, 10, 100);

        Assert.True(r1 == r2);
    }

    [Fact]
    public void RegistroDatos_Diferentes_NoSonIguales()
    {
        var r1 = new RegistroDatos(1, 10, 100);
        var r2 = new RegistroDatos(2, 10, 100);

        Assert.True(r1 != r2);
    }

    [Fact]
    public void RegistroDatos_ToString_ContieneElId()
    {
        var registro = new RegistroDatos(15, 500, 300);

        Assert.Contains("Id:15", registro.ToString());
    }

    [Fact]
    public void SelectionSort_OrdenaCorrectamente()
    {
        RegistroDatos[] datos =
        {
            new RegistroDatos(30,1,100),
            new RegistroDatos(10,2,100),
            new RegistroDatos(20,3,100)
        };

        OrdenadorSeleccion.OrdenarPorSeleccion(datos);

        Assert.Equal(10, datos[0].Id);
        Assert.Equal(20, datos[1].Id);
        Assert.Equal(30, datos[2].Id);
    }

    [Fact]
    public void SelectionSort_ArregloVacio_NoFalla()
    {
        RegistroDatos[] datos = Array.Empty<RegistroDatos>();

        var metricas = OrdenadorSeleccion.OrdenarPorSeleccion(datos);

        Assert.Equal(0, metricas.TotalComparaciones);
        Assert.Equal(0, metricas.TotalIntercambios);
    }

    [Fact]
    public void SelectionSort_UnElemento_PermaneceIgual()
    {
        RegistroDatos[] datos =
        {
            new RegistroDatos(50,1,100)
        };

        OrdenadorSeleccion.OrdenarPorSeleccion(datos);

        Assert.Equal(50, datos[0].Id);
    }

    [Fact]
    public void SelectionSort_GeneraComparaciones()
    {
        RegistroDatos[] datos =
        {
            new RegistroDatos(3,1,100),
            new RegistroDatos(2,2,100),
            new RegistroDatos(1,3,100)
        };

        var metricas = OrdenadorSeleccion.OrdenarPorSeleccion(datos);

        Assert.True(metricas.TotalComparaciones > 0);
    }

    [Fact]
    public void SelectionSort_GeneraIntercambios()
    {
        RegistroDatos[] datos =
        {
            new RegistroDatos(2,1,100),
            new RegistroDatos(1,2,100)
        };

        var metricas = OrdenadorSeleccion.OrdenarPorSeleccion(datos);

        Assert.True(metricas.TotalIntercambios > 0);
    }

    [Fact]
    public void MetricasOrdenacion_GuardaValoresCorrectamente()
    {
        var metricas = new MetricasOrdenacion(10, 5, 1.5);

        Assert.Equal(10, metricas.TotalComparaciones);
        Assert.Equal(5, metricas.TotalIntercambios);
        Assert.Equal(1.5, metricas.TiempoMs);
    }

    [Fact]
    public void MetricasOrdenacion_ToString_ContieneInformacion()
    {
        var metricas = new MetricasOrdenacion(10, 5, 1.5);

        string texto = metricas.ToString();

        Assert.Contains("Comparaciones", texto);
        Assert.Contains("Intercambios", texto);
        Assert.Contains("Tiempo", texto);
    }
}