# Reporte de Pruebas - DataCore v4.0

## 1. Introducción

El presente reporte documenta las pruebas realizadas sobre el sistema DataCore v4.0, verificando el correcto funcionamiento de las estructuras de datos implementadas, los algoritmos de ordenamiento y el sistema de búsqueda integrado en la Fase 4.

Las pruebas fueron realizadas utilizando la aplicación de consola desarrollada en C#.

---

# 2. Objetivo de las pruebas

Validar que el sistema pueda:

* Administrar registros mediante una lista enlazada dinámica.
* Insertar y eliminar elementos correctamente.
* Ordenar registros utilizando QuickSort.
* Buscar información mediante búsqueda lineal y búsqueda binaria indexada.
* Ejecutar correctamente el menú maestro del sistema.

---

# 3. Pruebas funcionales

## Prueba 1: Inserción de registros

### Procedimiento

1. Ejecutar el programa.
2. Seleccionar la opción:

```
1. Insertar registro
```

3. Introducir los datos solicitados.

### Resultado esperado

El sistema debe agregar el registro y aumentar el contador total.

### Resultado obtenido

✅ Registro agregado correctamente.

---

# Prueba 2: Generación automática de registros

### Procedimiento

Seleccionar:

```
7. Generar 15 registros aleatorios
```

### Resultado esperado

El sistema debe crear 15 registros válidos.

### Resultado obtenido

✅ Se generaron registros correctamente.

---

# Prueba 3: Eliminación por ID

### Procedimiento

Seleccionar:

```
2. Eliminar registro
```

Ingresar el ID del registro.

### Resultado esperado

El registro seleccionado debe eliminarse de la lista.

### Resultado obtenido

✅ Eliminación realizada correctamente.

---

# Prueba 4: Mostrar registros

### Procedimiento

Seleccionar:

```
3. Mostrar registros
```

### Resultado esperado

El sistema debe mostrar todos los registros almacenados.

### Resultado obtenido

✅ Los registros fueron mostrados correctamente.

---

# Prueba 5: Ordenamiento QuickSort

### Procedimiento

Seleccionar:

```
4. Ordenar registros
```

### Resultado esperado

Los registros deben ordenarse utilizando QuickSort tomando como criterio el campo ID.

### Resultado obtenido

✅ Ordenamiento realizado correctamente.

Se muestran:

* Registros ordenados.
* Tiempo de ejecución.
* Número de llamadas recursivas.

---

# Prueba 6: Búsqueda lineal

### Procedimiento

Seleccionar:

```
5. Buscar registro
```

Elegir:

```
1. Búsqueda Lineal
```

Ingresar un ID existente.

### Resultado esperado

El sistema debe encontrar el registro correspondiente.

### Resultado obtenido

✅ Registro encontrado correctamente.

---

# Prueba 7: Búsqueda Binaria Indexada

### Procedimiento

Seleccionar:

```
5. Buscar registro
```

Elegir:

```
2. Búsqueda Binaria Indexada
```

Ingresar un ID existente.

### Resultado esperado

El sistema debe ordenar el arreglo y realizar una búsqueda binaria.

### Resultado obtenido

✅ Registro encontrado correctamente.

La operación muestra:

* Registro encontrado.
* Número de comparaciones realizadas.

---

# Prueba 8: Manejo de entradas incorrectas

### Procedimiento

Ingresar valores no numéricos en opciones del menú.

### Resultado esperado

El sistema debe evitar el cierre inesperado.

### Resultado obtenido

✅ Se capturaron excepciones correctamente.

---

# 4. Análisis de resultados

Las pruebas realizadas demostraron que DataCore v4.0 integra correctamente una estructura dinámica de almacenamiento con algoritmos eficientes de procesamiento.

La implementación de QuickSort permite mejorar el rendimiento del ordenamiento respecto a métodos con complejidad cuadrática como Selección Directa.

Además, la búsqueda binaria indexada permite reducir la cantidad de comparaciones necesarias para localizar registros dentro de un conjunto ordenado.

---

# 5. Conclusión de pruebas

El sistema cumple con los objetivos establecidos para la Fase 4, integrando correctamente las funcionalidades desarrolladas durante las fases anteriores.

Las pruebas confirmaron que las operaciones principales funcionan correctamente y que la aplicación puede administrar registros, ordenarlos y buscarlos mediante diferentes estrategias algorítmicas.
