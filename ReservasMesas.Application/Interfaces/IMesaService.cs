using ReservasMesas.Domain.Entities;
using ReservasMesas.Domain.Enums;

namespace ReservasMesas.Application.Interfaces;

public interface IMesaService
{
    Task<List<Mesa>> ObtenerTodasAsync();
    Task<List<Mesa>> ObtenerDisponiblesAsync();
    Task<Mesa?> ObtenerPorIdAsync(int id);
    Task<Mesa> CrearAsync(Mesa mesa);
    Task ActualizarEstadoAsync(int id, EstadoMesa estado);
}