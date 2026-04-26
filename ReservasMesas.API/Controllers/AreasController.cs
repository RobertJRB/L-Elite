using Microsoft.AspNetCore.Mvc;
using ReservasMesas.Application.DTOs;
using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;

namespace ReservasMesas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AreasController : ControllerBase
{
    private readonly IAreaService _service;

    public AreasController(IAreaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodas()
    {
        var areas = await _service.ObtenerTodasAsync();
        return Ok(areas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var area = await _service.ObtenerPorIdAsync(id);
        if (area == null) return NotFound("Área no encontrada.");
        return Ok(area);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearAreaDto dto)
    {
        var area = new Area
        {
            Nombre = dto.Nombre,
            Tematica = dto.Tematica,
            CapacidadMaxima = dto.CapacidadMaxima
        };
        var creada = await _service.CrearAsync(area);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creada.Id }, creada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var resultado = await _service.EliminarAsync(id);
        if (!resultado) return NotFound("Área no encontrada.");
        return Ok("Área eliminada correctamente.");
    }
}