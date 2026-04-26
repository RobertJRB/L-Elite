using Microsoft.AspNetCore.Mvc;
using ReservasMesas.Application.DTOs;
using ReservasMesas.Application.Interfaces;
using ReservasMesas.Domain.Entities;

namespace ReservasMesas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
        => Ok(await _service.ObtenerTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var cliente = await _service.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound("Cliente no encontrado.");
        return Ok(cliente);
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> BuscarPorEmail([FromQuery] string email)
    {
        var cliente = await _service.BuscarPorEmailAsync(email);
        if (cliente == null) return NotFound("Cliente no encontrado.");
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearClienteDto dto)
    {
        var cliente = new Cliente
        {
            Nombre = dto.Nombre,
            Telefono = dto.Telefono,
            Email = dto.Email,
            Preferencias = dto.Preferencias
        };
        var creado = await _service.CrearAsync(cliente);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }
}