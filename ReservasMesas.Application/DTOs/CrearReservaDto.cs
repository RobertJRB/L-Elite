namespace ReservasMesas.Application.DTOs;

public class CrearReservaDto
{
    public int ClienteId { get; set; }
    public int MesaId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public int CantidadPersonas { get; set; }
    public string NotasEspeciales { get; set; } = string.Empty;
}