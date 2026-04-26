using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Infrastructure.Repositories;

namespace ReservasMesas.Application.Services;

public class AreaService : IAreaService
{
    private readonly AreaRepository _repo;

    public AreaService(AreaRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Area>> ObtenerTodasAsync() => _repo.ObtenerTodosAsync();
    public Task<Area?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);
    public Task<Area> CrearAsync(Area area) => _repo.CrearAsync(area);
    public Task<bool> EliminarAsync(int id) => _repo.EliminarAsync(id);
}