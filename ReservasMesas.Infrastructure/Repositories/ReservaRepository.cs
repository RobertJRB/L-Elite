using Microsoft.EntityFrameworkCore;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Domain.Enums;
using ReservasMesas.Infrastructure.Data;

namespace ReservasMesas.Infrastructure.Repositories;

public class ReservaRepository
{
    private readonly AppDbContext _context;

    public ReservaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reserva>> ObtenerTodosAsync()
        => await _context.Reservas
                         .Include(r => r.Cliente)
                         .Include(r => r.Mesa)
                         .Include(r => r.Observaciones)
                         .Where(r => r.Activo)
                         .ToListAsync();

    public async Task<List<Reserva>> ObtenerPorFechaAsync(DateTime fecha)
        => await _context.Reservas
                         .Include(r => r.Cliente)
                         .Include(r => r.Mesa)
                         .Where(r => r.Fecha.Date == fecha.Date && r.Activo)
                         .ToListAsync();

    public async Task<Reserva?> ObtenerPorIdAsync(int id)
        => await _context.Reservas
                         .Include(r => r.Cliente)
                         .Include(r => r.Mesa)
                         .Include(r => r.Observaciones)
                         .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<Reserva> CrearAsync(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task<bool> CancelarAsync(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null) return false;
        reserva.Estado = EstadoReserva.Cancelada;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ConfirmarAsync(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null) return false;
        reserva.Estado = EstadoReserva.Confirmada;
        await _context.SaveChangesAsync();
        return true;
    }
}