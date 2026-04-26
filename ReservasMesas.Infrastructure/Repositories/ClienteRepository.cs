using Microsoft.EntityFrameworkCore;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Infrastructure.Data;

namespace ReservasMesas.Infrastructure.Repositories;

public class ClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ObtenerTodosAsync()
        => await _context.Clientes.Where(c => c.Activo).ToListAsync();

    public async Task<Cliente?> ObtenerPorIdAsync(int id)
        => await _context.Clientes.Include(c => c.Reservas)
                                   .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Cliente?> BuscarPorEmailAsync(string email)
        => await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

    public async Task<Cliente> CrearAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
}