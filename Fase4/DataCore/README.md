# DataCore v4.0

## Descripción del proyecto

DataCore es un sistema desarrollado en C# enfocado en la administración eficiente de registros mediante estructuras dinámicas de datos y algoritmos de ordenamiento y búsqueda.

El proyecto integra una lista enlazada dinámica para almacenar registros, algoritmos de ordenamiento como Selección Directa y QuickSort, además de un sistema de búsqueda binaria indexada para mejorar la eficiencia en la localización de información.

La Fase 4 integra todas las funcionalidades anteriores mediante un menú maestro interactivo por consola (CLI).

---

# Características principales

## Gestión de registros

El sistema permite:

* Insertar registros al inicio y al final.
* Eliminar registros mediante su identificador.
* Mostrar todos los registros almacenados.
* Convertir la lista dinámica a un arreglo.
* Limpiar la estructura completa.

Cada registro contiene:

* ID único.
* Hash de validación.
* Peso en bytes.

---

# Algoritmos implementados

## Lista enlazada dinámica

La estructura principal utilizada es una lista enlazada simple.

Características:

* Inserción al inicio: O(1)
* Inserción al final: O(n)
* Eliminación por ID: O(n)
* Recorrido completo: O(n)

---

## Ordenamiento por Selección Directa

Implementado para comparar rendimiento contra algoritmos más eficientes.

Permite obtener:

* Número de comparaciones.
* Número de intercambios.
* Tiempo de ejecución.

Complejidad:

```
O(n²)
```

---

## Ordenamiento QuickSort

Algoritmo de ordenamiento basado en división y conquista.

Características:

* Ordenamiento por ID.
* Conteo de llamadas recursivas.
* Medición de tiempo de ejecución.

Complejidad promedio:

```
O(n log n)
```

---

## Búsqueda Binaria Indexada

Implementada en la clase:

```
GestorDatos.cs
```

Permite localizar registros utilizando un arreglo previamente ordenado.

Características:

* Búsqueda eficiente.
* Conteo de comparaciones.
* Complejidad:

```
O(log n)
```

---

# Estructura del proyecto

```
DataCore
│
├── Program.cs
├── RegistroDatos.cs
├── NodoRegistro.cs
├── TablaDinamica.cs
├── GestorDatos.cs
├── OrdenadorQuickSort.cs
├── OrdenadorSeleccion.cs
├── MetricasOrdenacion.cs
│
└── DataCore.csproj
```

---

# Ejecución del programa

Requisitos:

* .NET SDK instalado.
* Visual Studio 2022 o Visual Studio Code.

Para ejecutar:

```bash
dotnet build
```

Después:

```bash
dotnet run
```

---

# Menú principal

El sistema cuenta con las siguientes opciones:

```
1. Insertar registro
2. Eliminar registro
3. Mostrar registros
4. Ordenar registros (QuickSort)
5. Buscar registro
6. Estadísticas
7. Generar registros aleatorios
8. Limpiar registros
0. Salir
```

---

# Pruebas realizadas

Se realizaron pruebas para verificar:

* Inserción correcta de registros.
* Eliminación mediante ID.
* Ordenamiento mediante QuickSort.
* Búsqueda lineal.
* Búsqueda binaria indexada.
* Manejo de errores en entradas inválidas.

---

# Tecnologías utilizadas

* Lenguaje: C#
* Framework: .NET
* Tipo de aplicación: Consola (CLI)
* Estructuras de datos:

  * Lista enlazada.
  * Arreglos.
* Algoritmos:

  * Selección Directa.
  * QuickSort.
  * Búsqueda Binaria.

---

# Autor

Proyecto académico de Ingeniería en Sistemas Computacionales.

DataCore v4.0
