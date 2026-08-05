using System;

namespace DataCore;

/// <summary>
/// Representa un registro de datos inmutable del motor DataCore.
/// </summary>
public readonly struct RegistroDatos : IEquatable<RegistroDatos>
{
    /// <summary>
    /// Identificador único utilizado para ordenar.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Código de validación del registro.
    /// </summary>
    public long HashValidacion { get; }

    /// <summary>
    /// Tamaño físico del registro en bytes.
    /// </summary>
    public int PesoBytes { get; }


    /// <summary>
    /// Constructor del registro con validación de integridad.
    /// </summary>
    /// <param name="id">Identificador del registro.</param>
    /// <param name="hash">Hash de validación.</param>
    /// <param name="pesoBytes">Peso del registro.</param>
    public RegistroDatos(int id, long hash, int pesoBytes)
    {
        if (pesoBytes <= 0)
        {
            throw new ArgumentException(
                "PesoBytes debe ser mayor a cero.",
                nameof(pesoBytes));
        }

        Id = id;
        HashValidacion = hash;
        PesoBytes = pesoBytes;
    }


    /// <summary>
    /// Compara igualdad entre registros.
    /// </summary>
    public bool Equals(RegistroDatos other)
    {
        return Id == other.Id &&
               HashValidacion == other.HashValidacion &&
               PesoBytes == other.PesoBytes;
    }


    /// <summary>
    /// Compara igualdad con otro objeto.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is RegistroDatos other && Equals(other);
    }


    /// <summary>
    /// Obtiene el código hash del registro.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(
            Id,
            HashValidacion,
            PesoBytes);
    }


    /// <summary>
    /// Operador de igualdad.
    /// </summary>
    public static bool operator ==(
        RegistroDatos izquierda,
        RegistroDatos derecha)
    {
        return izquierda.Equals(derecha);
    }


    /// <summary>
    /// Operador de desigualdad.
    /// </summary>
    public static bool operator !=(
        RegistroDatos izquierda,
        RegistroDatos derecha)
    {
        return !(izquierda == derecha);
    }


    /// <summary>
    /// Representación del registro en texto.
    /// </summary>
    public override string ToString()
    {
        return 
            $"Id:{Id} | Hash:{HashValidacion} | Peso:{PesoBytes} bytes";
    }
}