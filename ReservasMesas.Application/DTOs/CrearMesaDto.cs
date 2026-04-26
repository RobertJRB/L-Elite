namespace ReservasMesas.Application.DTOs;

public class CrearMesaDto
{
    public int Numero { get; set; }
    public int Capacidad { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int AreaId { get; set; }
}