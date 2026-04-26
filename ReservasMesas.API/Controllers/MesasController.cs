using Microsoft.AspNetCore.Mvc;
using ReservasMesas.Application.DTOs;
using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;
using ReservasMesas.Domain.Enums;

namespace ReservasMesas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MesasController : ControllerBase
{
    private readonly IMesaService _service;

    public MesasController(IMesaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodas()
        => Ok(await _service.ObtenerTodasAsync());

    [HttpGet("disponibles")]
    public async Task<IActionResult> ObtenerDisponibles()
        => Ok(await _service.ObtenerDisponiblesAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var mesa = await _service.ObtenerPorIdAsync(id);
        if (mesa == null) return NotFound("Mesa no encontrada.");
        return Ok(mesa);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearMesaDto dto)
    {
        var mesa = new Mesa
        {
            Numero = dto.Numero,
            Capacidad = dto.Capacidad,
            Tipo = dto.Tipo,
            AreaId = dto.AreaId
        };
        var creada = await _service.CrearAsync(mesa);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creada.Id }, creada);
    }

    [HttpPatch("{id}/estado")]
    public async Task<IActionResult> ActualizarEstado(int id, [FromBody] EstadoMesa estado)
    {
        await _service.ActualizarEstadoAsync(id, estado);
        return Ok("Estado actualizado correctamente.");
    }
}