using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Domain.Enums;
using ReservasMesas.Infrastructure.Repositories;

namespace ReservasMesas.Application.Services;

public class MesaService : IMesaService
{
    private readonly MesaRepository _repo;

    public MesaService(MesaRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Mesa>> ObtenerTodasAsync() => _repo.ObtenerTodosAsync();
    public Task<List<Mesa>> ObtenerDisponiblesAsync() => _repo.ObtenerDisponiblesAsync();
    public Task<Mesa?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);
    public Task<Mesa> CrearAsync(Mesa mesa) => _repo.CrearAsync(mesa);
    public Task ActualizarEstadoAsync(int id, EstadoMesa estado) => _repo.ActualizarEstadoAsync(id, estado);
}