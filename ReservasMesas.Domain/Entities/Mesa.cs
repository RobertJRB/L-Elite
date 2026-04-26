using ReservasMesas.Domain.Abstractions;
using ReservasMesas.Domain.Enums;

namespace ReservasMesas.Domain.Entities;

public class Mesa : EntidadBase
{
    public int Numero { get; set; }
    public int Capacidad { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public EstadoMesa Estado { get; set; } = EstadoMesa.Disponible;

    public int AreaId { get; set; }
    public Area Area { get; set; } = null!;

    public override string ObtenerDescripcion()
        => $"Mesa #{Numero} | Capacidad: {Capacidad} | Tipo: {Tipo} | Estado: {Estado}";

    public bool EstaDisponible(DateTime fecha, TimeSpan hora)
    {
        return Estado == EstadoMesa.Disponible;
    }

    public bool EstaDisponible(DateTime fecha)
    {
        return Estado == EstadoMesa.Disponible && Activo;
    }
}