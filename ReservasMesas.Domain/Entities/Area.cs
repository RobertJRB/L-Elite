using ReservasMesas.Domain.Abstractions;

namespace ReservasMesas.Domain.Entities;

public class Area : EntidadBase
{
    public string Nombre { get; set; } = string.Empty;
    public string Tematica { get; set; } = string.Empty;
    public int CapacidadMaxima { get; set; }

    public List<Mesa> Mesas { get; set; } = new();

    public override string ObtenerDescripcion()
        => $"Área: {Nombre} | Temática: {Tematica} | Capacidad: {CapacidadMaxima}";
}