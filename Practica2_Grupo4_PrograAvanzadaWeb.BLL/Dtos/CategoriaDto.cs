using System.ComponentModel.DataAnnotations;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

public class CategoriaDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
}