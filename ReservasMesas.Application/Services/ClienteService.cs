using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Infrastructure.Repositories;

namespace ReservasMesas.Application.Services;

public class ClienteService : IClienteService
{
    private readonly ClienteRepository _repo;

    public ClienteService(ClienteRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Cliente>> ObtenerTodosAsync() => _repo.ObtenerTodosAsync();
    public Task<Cliente?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);
    public Task<Cliente?> BuscarPorEmailAsync(string email) => _repo.BuscarPorEmailAsync(email);
    public Task<Cliente> CrearAsync(Cliente cliente) => _repo.CrearAsync(cliente);
}