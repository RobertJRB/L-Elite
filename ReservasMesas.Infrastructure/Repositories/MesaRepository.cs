using Microsoft.EntityFrameworkCore;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Domain.Enums;
using ReservasMesas.Infrastructure.Data;

namespace ReservasMesas.Infrastructure.Repositories;

public class MesaRepository
{
    private readonly AppDbContext _context;

    public MesaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Mesa>> ObtenerTodosAsync()
        => await _context.Mesas.Include(m => m.Area)
                                .Where(m => m.Activo)
                                .ToListAsync();

    public async Task<List<Mesa>> ObtenerDisponiblesAsync()
        => await _context.Mesas.Include(m => m.Area)
                                .Where(m => m.Estado == EstadoMesa.Disponible && m.Activo)
                                .ToListAsync();

    public async Task<Mesa?> ObtenerPorIdAsync(int id)
        => await _context.Mesas.Include(m => m.Area)
                                .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Mesa> CrearAsync(Mesa mesa)
    {
        _context.Mesas.Add(mesa);
        await _context.SaveChangesAsync();
        return mesa;
    }

    public async Task ActualizarEstadoAsync(int id, EstadoMesa nuevoEstado)
    {
        var mesa = await _context.Mesas.FindAsync(id);
        if (mesa != null)
        {
            mesa.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
        }
    }
}