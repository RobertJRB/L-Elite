using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Domain.Enums;
using ReservasMesas.Infrastructure.Repositories;

namespace ReservasMesas.Application.Services;

public class ReservaService : IReservaService
{
    private readonly ReservaRepository _repoReserva;
    private readonly MesaRepository _repoMesa;

    public ReservaService(ReservaRepository repoReserva, MesaRepository repoMesa)
    {
        _repoReserva = repoReserva;
        _repoMesa = repoMesa;
    }

    public Task<List<Reserva>> ObtenerTodasAsync() => _repoReserva.ObtenerTodosAsync();
    public Task<List<Reserva>> ObtenerPorFechaAsync(DateTime fecha) => _repoReserva.ObtenerPorFechaAsync(fecha);
    public Task<Reserva?> ObtenerPorIdAsync(int id) => _repoReserva.ObtenerPorIdAsync(id);

    public async Task<Reserva> CrearAsync(Reserva reserva)
    {
        // Verificar que la mesa esté disponible
        var mesa = await _repoMesa.ObtenerPorIdAsync(reserva.MesaId);
        if (mesa == null || !mesa.EstaDisponible(reserva.Fecha, reserva.Hora))
            throw new InvalidOperationException("La mesa no está disponible para esa fecha y hora.");

        // Bloquear la mesa
        await _repoMesa.ActualizarEstadoAsync(reserva.MesaId, EstadoMesa.Reservada);

        return await _repoReserva.CrearAsync(reserva);
    }

    public async Task<bool> ConfirmarAsync(int id) => await _repoReserva.ConfirmarAsync(id);

    public async Task<bool> CancelarAsync(int id)
    {
        var reserva = await _repoReserva.ObtenerPorIdAsync(id);
        if (reserva == null) return false;

        // Liberar la mesa
        await _repoMesa.ActualizarEstadoAsync(reserva.MesaId, EstadoMesa.Disponible);

        return await _repoReserva.CancelarAsync(id);
    }
}