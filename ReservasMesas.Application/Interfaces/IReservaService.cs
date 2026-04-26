using ReservasMesas.Domain.Entities;

namespace ReservasMesas.Application.Interfaces;

public interface IReservaService
{
    Task<List<Reserva>> ObtenerTodasAsync();
    Task<List<Reserva>> ObtenerPorFechaAsync(DateTime fecha);
    Task<Reserva?> ObtenerPorIdAsync(int id);
    Task<Reserva> CrearAsync(Reserva reserva);
    Task<bool> ConfirmarAsync(int id);
    Task<bool> CancelarAsync(int id);
}