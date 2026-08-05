namespace DataCore;

public class TablaDinamica
{
    private NodoRegistro? cabeza;
    private int contadorRegistros;


    public TablaDinamica()
    {
        cabeza = null;
        contadorRegistros = 0;
    }


    public int TotalRegistros
    {
        get { return contadorRegistros; }
    }



    // =====================================
    // INSERTAR AL INICIO
    // Complejidad: O(1)
    // =====================================
    public void InsertarInicio(RegistroDatos nuevoRegistro)
    {
        NodoRegistro nuevoNodo =
            new NodoRegistro(nuevoRegistro);


        nuevoNodo.Siguiente = cabeza;

        cabeza = nuevoNodo;

        contadorRegistros++;
    }




    // =====================================
    // INSERTAR AL FINAL
    // Complejidad: O(n)
    // =====================================
    public void InsertarFinal(RegistroDatos nuevoRegistro)
    {
        NodoRegistro nuevoNodo =
            new NodoRegistro(nuevoRegistro);



        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            NodoRegistro actual = cabeza;


            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }


            actual.Siguiente = nuevoNodo;
        }


        contadorRegistros++;
    }




    // =====================================
    // ELIMINAR POR ID
    // =====================================
    public void EliminarPorId(int idTarget)
    {

        if (cabeza == null)
            return;



        if (cabeza.Dato.Id == idTarget)
        {
            cabeza =
                cabeza.Siguiente;

            contadorRegistros--;

            return;
        }



        NodoRegistro anterior = cabeza;

        NodoRegistro? actual =
            cabeza.Siguiente;



        while (actual != null)
        {

            if (actual.Dato.Id == idTarget)
            {

                anterior.Siguiente =
                    actual.Siguiente;


                contadorRegistros--;

                return;
            }


            anterior = actual;

            actual = actual.Siguiente;
        }

    }





    // =====================================
    // BUSCAR POR ID
    // Complejidad: O(n)
    // =====================================
    public RegistroDatos? BuscarPorId(int idBuscado)
    {

        NodoRegistro? actual =
            cabeza;



        while (actual != null)
        {

            if (actual.Dato.Id == idBuscado)
            {
                return actual.Dato;
            }


            actual =
                actual.Siguiente;

        }


        return null;
    }





    // =====================================
    // CONVERTIR LISTA A ARREGLO
    // =====================================
    public RegistroDatos[] ObtenerComoArreglo()
    {

        RegistroDatos[] arreglo =
            new RegistroDatos[contadorRegistros];



        NodoRegistro? actual =
            cabeza;



        int indice = 0;



        while (actual != null)
        {

            arreglo[indice] =
                actual.Dato;


            indice++;

            actual =
                actual.Siguiente;

        }


        return arreglo;

    }





    // =====================================
    // VERIFICAR SI ESTÁ VACÍA
    // =====================================
    public bool EstaVacia()
    {
        return cabeza == null;
    }





    // =====================================
    // LIMPIAR LISTA COMPLETA
    // =====================================
    public void Limpiar()
    {
        cabeza = null;

        contadorRegistros = 0;
    }





    // =====================================
    // MOSTRAR LISTA
    // =====================================
    public void Mostrar()
    {

        if (cabeza == null)
        {
            Console.WriteLine(
                "No existen registros.");
            
            return;
        }



        NodoRegistro? actual =
            cabeza;



        while (actual != null)
        {

            Console.WriteLine(
                $"ID: {actual.Dato.Id} | " +
                $"Hash: {actual.Dato.HashValidacion} | " +
                $"Peso: {actual.Dato.PesoBytes} bytes"
            );


            actual =
                actual.Siguiente;

        }

    }

}