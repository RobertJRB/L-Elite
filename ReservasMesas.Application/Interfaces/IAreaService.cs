using ReservasMesas.Domain.Entities;

namespace ReservasMesas.Application.Interfaces;

public interface IAreaService
{
    Task<List<Area>> ObtenerTodasAsync();
    Task<Area?> ObtenerPorIdAsync(int id);
    Task<Area> CrearAsync(Area area);
    Task<bool> EliminarAsync(int id);
}