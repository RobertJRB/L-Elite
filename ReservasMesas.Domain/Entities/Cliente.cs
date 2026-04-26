using ReservasMesas.Domain.Abstractions;

namespace ReservasMesas.Domain.Entities;

public class Cliente : Persona
{
    public string Preferencias { get; set; } = string.Empty;

    public List<Reserva> Reservas { get; set; } = new();

    public override string ObtenerDescripcion()
        => $"Cliente: {Nombre} | Tel: {Telefono} | Email: {Email}";

    public override string ObtenerRol() => "Cliente";

    public void AgregarReserva(Reserva reserva)
    {
        Reservas.Add(reserva);
    }

    public void AgregarReserva(Reserva reserva, string observacion)
    {
        reserva.Observaciones.Add(new Observacion
        {
            Tipo = "General",
            Descripcion = observacion
        });
        Reservas.Add(reserva);
    }
}