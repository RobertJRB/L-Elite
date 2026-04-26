using ReservasMesas.Domain.Abstractions;

namespace ReservasMesas.Domain.Entities;

public class Observacion : EntidadBase
{
    public string Tipo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;

    public int ReservaId { get; set; }
    public Reserva Reserva { get; set; } = null!;

    public override string ObtenerDescripcion()
        => $"[{Tipo}] {Descripcion}";
}