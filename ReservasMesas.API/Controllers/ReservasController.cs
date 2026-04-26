using Microsoft.AspNetCore.Mvc;
using ReservasMesas.Application.DTOs;
using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;

namespace ReservasMesas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly IReservaService _service;

    public ReservasController(IReservaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodas()
        => Ok(await _service.ObtenerTodasAsync());

    [HttpGet("fecha")]
    public async Task<IActionResult> ObtenerPorFecha([FromQuery] DateTime fecha)
        => Ok(await _service.ObtenerPorFechaAsync(fecha));

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var reserva = await _service.ObtenerPorIdAsync(id);
        if (reserva == null) return NotFound("Reserva no encontrada.");
        return Ok(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearReservaDto dto)
    {
        try
        {
            var reserva = new Reserva
            {
                ClienteId = dto.ClienteId,
                MesaId = dto.MesaId,
                Fecha = dto.Fecha,
                Hora = dto.Hora,
                CantidadPersonas = dto.CantidadPersonas,
                NotasEspeciales = dto.NotasEspeciales
            };
            var creada = await _service.CrearAsync(reserva);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creada.Id }, creada);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}/confirmar")]
    public async Task<IActionResult> Confirmar(int id)
    {
        var resultado = await _service.ConfirmarAsync(id);
        if (!resultado) return NotFound("Reserva no encontrada.");
        return Ok("Reserva confirmada.");
    }

    [HttpPatch("{id}/cancelar")]
    public async Task<IActionResult> Cancelar(int id)
    {
        var resultado = await _service.CancelarAsync(id);
        if (!resultado) return NotFound("Reserva no encontrada.");
        return Ok("Reserva cancelada.");
    }
}