using ReservasMesas.Domain.Abstractions;
using ReservasMesas.Domain.Enums;

namespace ReservasMesas.Domain.Entities;

public class Reserva : EntidadBase
{
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int CantidadPersonas { get; set; }
    public EstadoReserva Estado { get; set; } = EstadoReserva.Pendiente;
    public string NotasEspeciales { get; set; } = string.Empty;

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public int MesaId { get; set; }
    public Mesa Mesa { get; set; } = null!;

    public List<Observacion> Observaciones { get; set; } = new();

    public override string ObtenerDescripcion()
        => $"Reserva #{Id} | {Cliente?.Nombre} | Mesa {Mesa?.Numero} | {Fecha:dd/MM/yyyy} {Hora}";
}