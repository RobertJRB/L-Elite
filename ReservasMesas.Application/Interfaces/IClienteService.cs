using ReservasMesas.Domain.Entities;

namespace ReservasMesas.Application.Interfaces;

public interface IClienteService
{
    Task<List<Cliente>> ObtenerTodosAsync();
    Task<Cliente?> ObtenerPorIdAsync(int id);
    Task<Cliente?> BuscarPorEmailAsync(string email);
    Task<Cliente> CrearAsync(Cliente cliente);
}