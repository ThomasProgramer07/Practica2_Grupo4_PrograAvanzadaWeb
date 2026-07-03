namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

public class Respuesta<T>
{
    public bool Exito { get; set; }
    public string? Mensaje { get; set; }
    public T? Datos { get; set; }
}