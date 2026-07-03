using System.ComponentModel.DataAnnotations;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

public class ProductoDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una categoría")]
    public int FkCategoria { get; set; }

    public string? NombreCategoria { get; set; } // solo lectura, para el Index
}