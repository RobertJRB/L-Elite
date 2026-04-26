using Microsoft.EntityFrameworkCore;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Infrastructure.Data;

namespace ReservasMesas.Infrastructure.Repositories;

public class AreaRepository
{
    private readonly AppDbContext _context;

    public AreaRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Area>> ObtenerTodosAsync()
        => await _context.Areas
                         .Where(a => a.Activo)
                         .Include(a => a.Mesas)
                         .ToListAsync();

    public async Task<Area?> ObtenerPorIdAsync(int id)
        => await _context.Areas.Include(a => a.Mesas)
                                .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Area> CrearAsync(Area area)
    {
        _context.Areas.Add(area);
        await _context.SaveChangesAsync();
        return area;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var area = await _context.Areas.FindAsync(id);
        if (area == null) return false;
        area.Activo = false;
        await _context.SaveChangesAsync();
        return true;
    }
}