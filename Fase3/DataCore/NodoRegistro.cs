namespace DataCore;

public class NodoRegistro
{
    // Registro almacenado en el nodo
    public RegistroDatos Dato { get; set; }

    // Referencia al siguiente nodo
    public NodoRegistro? Siguiente { get; set; }

    // Constructor
    public NodoRegistro(RegistroDatos dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}