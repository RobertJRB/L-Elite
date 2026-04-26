namespace ReservasMesas.Application.DTOs;

public class CrearAreaDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Tematica { get; set; } = string.Empty;
    public int CapacidadMaxima { get; set; }
}